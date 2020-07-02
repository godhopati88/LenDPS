Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Threading.Tasks

Public Class Server
    Private _listener As TcpListener
    Private _connection As New List(Of ConnectionInfo)
    Private _connectionMonitor As Task

    Private Sub StartStopButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartStopButton.CheckedChanged
        If StartStopButton.Checked Then
            StartStopButton.Text = "Stop"
            _listener = New TcpListener(IPAddress.Any, CInt(PortTextBox.Text))
            _listener.Start()
            ListenForClient()
            _connectionMonitor = Task.Factory.StartNew(AddressOf DoMonitorConnection, New MonitorInfo(_listener, _connection), TaskCreationOptions.LongRunning)
        Else
            StartStopButton.Text = "Start"
            CType(_connectionMonitor.AsyncState, MonitorInfo).Cancel = True
            _listener.Stop()
            _listener = Nothing
        End If
    End Sub

    Private Sub PortTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PortTextBox.Validating
        Dim deltaPort As Integer
        If Not Integer.TryParse(PortTextBox.Text, deltaPort) OrElse deltaPort < 1 OrElse deltaPort > 65535 Then
            MessageBox.Show("Port number must be an integer between 1 and 65535.", "Invalid Port Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            PortTextBox.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub ListenForClient()
        Dim info As New ConnectionInfo(_listener)
        _listener.BeginAcceptTcpClient(AddressOf DoAcceptClient, info)
    End Sub

    Private Sub DoAcceptClient(ByVal result As IAsyncResult)
        Dim monitorInfo As MonitorInfo = CType(_connectionMonitor.AsyncState, MonitorInfo)
        If monitorInfo.Listener IsNot Nothing AndAlso Not monitorInfo.Cancel Then
            Dim info As ConnectionInfo = CType(result.AsyncState, ConnectionInfo)
            monitorInfo.Connection.Add(info)
            info.AcceptClient(result)
            ListenForClient()
            info.AwaitData()
            Dim doUpdateConnectionCountLabel As New Action(AddressOf UpdateConnectionCountLabel)
            Invoke(doUpdateConnectionCountLabel)
        End If
    End Sub

    Private Sub DoMonitorConnection()
        Dim doAppendOutput As New Action(Of String)(AddressOf AppendOutput)
        Dim doUpdateConnectionCountLabel As New Action(AddressOf UpdateConnectionCountLabel)
        Dim monitorInfo As MonitorInfo = CType(_connectionMonitor.AsyncState, MonitorInfo)

        Me.Invoke(doAppendOutput, "Monitor Started")
        Do
            Dim lostConnection As New List(Of ConnectionInfo)
            For Each info As ConnectionInfo In monitorInfo.Connection
                If info.Client.Connected Then
                    If info.DataQueue.Count > 0 Then
                        Dim messageBytes As New List(Of Byte)
                        While info.DataQueue.Count > 0
                            messageBytes.Add(info.DataQueue.Dequeue)
                        End While
                        Me.Invoke(doAppendOutput, System.Text.Encoding.ASCII.GetString(messageBytes.ToArray))
                    End If
                Else
                    lostConnection.Add(info)
                End If
            Next

            If lostConnection.Count > 0 Then
                While lostConnection.Count > 0
                    monitorInfo.Connection.Remove(lostConnection(0))
                    lostConnection.RemoveAt(0)
                End While
                Invoke(doUpdateConnectionCountLabel)
            End If

            _connectionMonitor.Wait(1)
        Loop While Not monitorInfo.Cancel

        For Each info As ConnectionInfo In monitorInfo.Connection
            info.Client.Close()
        Next
        monitorInfo.Connection.Clear()

        Invoke(doUpdateConnectionCountLabel)
        Me.Invoke(doAppendOutput, "Monitor Stopped.")
    End Sub

    Private Sub AppendOutput(ByVal message As String)
        If RichTextBox1.TextLength > 0 Then
            RichTextBox1.AppendText(ControlChars.NewLine)
        End If
        RichTextBox1.AppendText(message)
        RichTextBox1.ScrollToCaret()
    End Sub

    Private Sub UpdateConnectionCountLabel()
        ConnectionCountLabel.Text = String.Format("{0} Connections", _connection.Count)
    End Sub

    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Dim monitorInfo As MonitorInfo = CType(_connectionMonitor.AsyncState, MonitorInfo)
        For Each info As ConnectionInfo In monitorInfo.Connection
            If info.Client.Connected Then
                Dim buffer() As Byte = System.Text.Encoding.ASCII.GetBytes(txtSend.Text)
                info.Stream.Write(buffer, 0, buffer.Length)
            End If
        Next
    End Sub
End Class

Public Class MonitorInfo
    Public Property Cancel As Boolean

    Private _connection As List(Of ConnectionInfo)
    Public ReadOnly Property Connection As List(Of ConnectionInfo)
        Get
            Return _connection
        End Get
    End Property

    Private _listener As TcpListener
    Public ReadOnly Property Listener As TcpListener
        Get
            Return _listener
        End Get
    End Property

    Public Sub New(ByVal tcpListener As TcpListener, ByVal connectionInfoList As List(Of ConnectionInfo))
        _listener = tcpListener
        _connection = connectionInfoList
    End Sub
End Class

Public Class ConnectionInfo
    Private _listener As TcpListener
    Public ReadOnly Property Listener As TcpListener
        Get
            Return _listener
        End Get
    End Property

    Private _client As TcpClient
    Public ReadOnly Property Client As TcpClient
        Get
            Return _client
        End Get
    End Property

    Private _stream As NetworkStream
    Public ReadOnly Property Stream As NetworkStream
        Get
            Return _stream
        End Get
    End Property

    Private _dataQueue As Queue(Of Byte)
    Public ReadOnly Property DataQueue As Queue(Of Byte)
        Get
            Return _dataQueue
        End Get
    End Property

    Private _lastReadLength As Integer
    Public ReadOnly Property LastReadLength As Integer
        Get
            Return _lastReadLength
        End Get
    End Property

    Private _buffer(63) As Byte

    Public Sub New(ByVal tcpListener As TcpListener)
        _listener = tcpListener
        _dataQueue = New Queue(Of Byte)
    End Sub

    Public Sub AcceptClient(ByVal result As IAsyncResult)
        _client = _listener.EndAcceptTcpClient(result)
        If _client IsNot Nothing AndAlso _client.Connected Then
            _stream = _client.GetStream
        End If
    End Sub

    Public Sub AwaitData()
        _stream.BeginRead(_buffer, 0, _buffer.Length, AddressOf DoReadData, Me)
    End Sub

    Private Sub DoReadData(ByVal result As IAsyncResult)
        Dim info As ConnectionInfo = CType(result.AsyncState, ConnectionInfo)
        Try
            If info.Stream IsNot Nothing AndAlso info.Stream.CanRead Then
                info._lastReadLength = info.Stream.EndRead(result)
                For index As Integer = 0 To _lastReadLength - 1
                    info._dataQueue.Enqueue(info._buffer(index))
                Next

                info.SendMessage("Received " & info._lastReadLength & " Bytes")
                info.AwaitData()
            Else
                info.Client.Close()
            End If
        Catch ex As Exception
            info._lastReadLength = -1
        End Try
    End Sub

    Private Sub SendMessage(ByVal message As String)
        If _stream IsNot Nothing Then
            Dim messageData() As Byte = System.Text.Encoding.ASCII.GetBytes(message)
            Stream.Write(messageData, 0, messageData.Length)
        End If
    End Sub
End Class