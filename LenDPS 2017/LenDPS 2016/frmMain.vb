Imports System
Imports System.Drawing
Imports System.IO
Imports FastColoredTextBoxNS
Imports System.Text.RegularExpressions
Imports Railway

Public Class frmMain
#Region "class properties"
    Private mCouplerAddress As Integer
    Public Property GetCouplerAddress() As Integer
        Get
            Return mCouplerAddress
        End Get
        Set(ByVal value As Integer)
            mCouplerAddress = value
        End Set
    End Property

    Private mGetStatusIO As String
    Public Property GetStatusIO() As String
        Get
            Return mGetStatusIO
        End Get
        Set(ByVal value As String)
            mGetStatusIO = value
        End Set
    End Property

#End Region


    Dim LoadObject As clsLoadObject
    Dim ObjControl As ControlHandler
    Dim IdxControl As Integer = 0

    Dim pbStatus(15) As Boolean
    Dim pb As New PictureBox

    Structure ObjBuffer
        Dim Name As String
        Dim Index As Integer
    End Structure
    Dim ObjCutBuffer As ObjBuffer

    Enum ObjStatus
        None
        Cut
        Copy
    End Enum
    Dim _ObjStatus As ObjStatus = ObjStatus.None

    Private Declare Function ShowScrollBar Lib "user32" (ByVal hwnd As IntPtr, ByVal wBar As Integer, ByVal bShow As Boolean) As Integer

    ' Constants
    Private Const SB_HORZ As Integer = 0
    Private Const SB_VERT As Integer = 1
    Private Const SB_BOTH As Integer = 3

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim btn As New Button
        With btn
            .Width = 50
            .Height = 50
            .Top = 9950
            .Left = 9950
        End With
        pContainer.Controls.Add(btn)

        LoadObject = New clsLoadObject
        ObjControl = New ControlHandler

        '------------- Load Preferensi 
        GridSpacing = LoadPreferensi()
        Me.WdwContainer.Grid = GridSpacing
        tbGridSizeToolStripTextBox.Text = CStr(GridSpacing)

        '------------- HDW
        'make_hdw_table()
        Me.panelDevice.Visible = False
        Me.panelCommunication.Visible = False
        'Me.WindowState = FormWindowState.Maximized

        lvToLCP.GridLines = True
        lvFromLCP.GridLines = True

        lvToLCP.FullRowSelect = True
        lvFromLCP.FullRowSelect = True

        lvToLCP.Items.Clear()
        lvFromLCP.Items.Clear()
        Dim str As String() = New String(1) {}
        Dim item1, item2 As ListViewItem
        For i As Integer = 1 To 512
            str(0) = i
            str(1) = ""
            item1 = New ListViewItem(str)
            lvFromLCP.Items.Add(item1)
            item2 = New ListViewItem(str)
            lvToLCP.Items.Add(item2)
        Next
        ''Date and Time Info
        'Dim Time As DateTime = Today
        'Dim this_day As String = String.Format("{0:00}", Time.Day)
        'Dim this_month As String = String.Format("{0:00}", Time.Month)
        'Dim this_year As String = String.Format("{0:00}", Time.Year)
        'this_year = Mid(this_year, 3, 2)
        'Debug.Print(this_day & "/" & this_month & "/" & this_year)
    End Sub

#Region "       Load and Save Preferensi"
    Private Function LoadPreferensi() As Integer
        Dim staFile As String
        Dim ReadStream As FileStream
        Dim data As Integer
        Try
            staFile = App_Path() & "Preferensi.DAT"
            ReadStream = New FileStream(staFile, FileMode.Open)
            Dim readBinary As New BinaryReader(ReadStream)

            data = CInt(readBinary.ReadInt32())
            ReadStream.Close()
            LoadPreferensi = data
        Catch ex As Exception

        End Try
        Return data
    End Function

    Private Sub SavePreferensi(ByVal s As Integer)
        Dim staFile As String
        Dim writeStream As FileStream
        Try
            staFile = App_Path() & "Preferensi.DAT"
            writeStream = New FileStream(staFile, FileMode.Create)
            Dim writeBinary As New BinaryWriter(writeStream)

            writeBinary.Write(s)
            writeBinary.Close()

        Catch ex As Exception

        End Try
    End Sub

#End Region



#Region "       Handler of Window Editor"
    Private Sub LoadObjHandler(ByVal sender As Object)
        ObjControl.boundControls.Add(New ControlHandler.boundControl(WdwContainer, sender))
        ObjControl.bindControls(IdxControl)
        IdxControl += 1
    End Sub

    Private Sub Load_Object(ByVal f As winContainer, ByVal id As IdObj)
        Select Case id
            Case IdObj.None : IdObject = IdObj.None
            Case IdObj.Signal : LoadObjHandler(LoadObject.LoadSignal(f)) : IdObject = IdObj.None
            Case IdObj.PoinMachine : LoadObjHandler(LoadObject.LoadPointMachine(f)) : IdObject = IdObj.None
            Case IdObj.Track : LoadObjHandler(LoadObject.LoadTrack(f)) : IdObject = IdObj.None
            Case IdObj.Label : LoadObjHandler(LoadObject.LoadLabel(f)) : IdObject = IdObj.None
            Case IdObj.CheckBox : LoadObjHandler(LoadObject.LoadCheckBox(f)) : IdObject = IdObj.None
            Case IdObj.Counter : LoadObjHandler(LoadObject.LoadCounter(f)) : IdObject = IdObj.None
            Case IdObj.Buzzer : LoadObjHandler(LoadObject.LoadBuzzer(f)) : IdObject = IdObj.None
            Case IdObj.EquipmentName : LoadObjHandler(LoadObject.LoadEquipmentName(f)) : IdObject = IdObj.None
            Case IdObj.PictureBox : LoadObjHandler(LoadObject.LoadPictureBox(f)) : IdObject = IdObj.None
            Case IdObj.Shapes : LoadObjHandler(LoadObject.LoadShapes(f)) : IdObject = IdObj.None
            Case IdObj.Buttons : LoadObjHandler(LoadObject.LoadButton(f)) : IdObject = IdObj.None
        End Select
    End Sub

    Private Sub WinContainer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WdwContainer.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            winCoordinat.X = SnapGrid(e.X) : winCoordinat.Y = SnapGrid(e.Y)
            'Debug.Print(winCoordinat.X & " ---> " & SnapGrid(winCoordinat.X))
            'SnapToGrid(winCoordinat.X, winCoordinat.Y)
            If IdObject <> IdObj.None And _ObjStatus = ObjStatus.None Then Normalization() : ObjectDefault(IdObject) : Load_Object(WdwContainer, IdObject)
        End If
        If _ObjStatus <> ObjStatus.Cut Then
            ObjControl.deselectAll()
        End If
        ClearWinContainer()
        Debug.Print(App_Path)
    End Sub

    Private Sub ClearWinContainer()
        Me.tbName.Text = ""
        Me.tbNameObject.Text = ""
        Me.txFont.Text = ""
        Me.txColor.BackColor = Color.White
        Me.cbTextPos.Items.Clear()
        Me.tbX.Text = winCoordinat.X.ToString
        Me.tbY.Text = winCoordinat.Y.ToString
        Me.tbW.Text = ""
        Me.tbH.Text = ""
        Me.cbType.Items.Clear()
        Me.cbDirection.Items.Clear()
        Me.txDiameter.Text = ""
        Me.txThickness.Text = ""
        Me.txIdColor1.BackColor = Color.White
        Me.txIdColor2.BackColor = Color.White
        Me.txIdColor3.BackColor = Color.White
        Me.txIdColor4.BackColor = Color.White
    End Sub

    Private Sub WinContainer_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles WdwContainer.Paint
        If ObjControl.boundingRectangle <> Nothing Then
            Dim p As New Pen(Color.Red, 2)
            p.DashStyle = Drawing2D.DashStyle.Solid
            e.Graphics.DrawRectangle(p, ObjControl.boundingRectangle)
        End If
    End Sub

#End Region

#Region "       Load Animation Menu"
    Dim idxPb As Integer = 0

    Private Sub Normalization()
        If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
    End Sub

    Private Sub pbMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSignal.Click, pbPointMachine.Click, pbTrack.Click, pbCheckBox.Click, pbLabel.Click, pbBuzzer.Click, pbShape.Click, pbButton.Click, pbCounter.Click, pbPushButton.Click, pbToggleButton.Click, pbPairButton.Click
        Dim Index As Integer

        Index = CInt(CType(sender, PictureBox).Tag)
        Select Case Index
            Case 1      '------------>>> Signal
                IdObject = IdObj.Signal : _ObjStatus = ObjStatus.None
                If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                pb = pbSignal
                pbStatus(idxPb) = False : pbStatus(1) = True : idxPb = 1
                pbSignal.BorderStyle = BorderStyle.Fixed3D : pbSignal.BackColor = Color.Blue

            Case 2      '------------>>> Point Machine
                IdObject = IdObj.PoinMachine : _ObjStatus = ObjStatus.None
                If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                pb = pbPointMachine
                pbStatus(idxPb) = False : pbStatus(2) = True : idxPb = 2
                pbPointMachine.BorderStyle = BorderStyle.Fixed3D : pbPointMachine.BackColor = Color.Blue

            Case 3      '------------>>> Track
                IdObject = IdObj.Track : _ObjStatus = ObjStatus.None
                If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                pb = pbTrack
                pbStatus(idxPb) = False : pbStatus(3) = True : idxPb = 3
                pbTrack.BorderStyle = BorderStyle.Fixed3D : pbTrack.BackColor = Color.Blue

            Case 4      '------------>>> Check Box
                IdObject = IdObj.CheckBox : _ObjStatus = ObjStatus.None
                If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                pb = pbCheckBox
                pbStatus(idxPb) = False : pbStatus(4) = True : idxPb = 4
                pbCheckBox.BorderStyle = BorderStyle.Fixed3D : pbCheckBox.BackColor = Color.Blue

            Case 5      '------------>>> Label
                IdObject = IdObj.Label : _ObjStatus = ObjStatus.None
                If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                pb = pbLabel
                pbStatus(idxPb) = False : pbStatus(5) = True : idxPb = 5
                pbLabel.BorderStyle = BorderStyle.Fixed3D : pbLabel.BackColor = Color.Blue

            Case 6      '------------>>> Buzzer
                IdObject = IdObj.Buzzer : _ObjStatus = ObjStatus.None
                If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                pb = pbBuzzer
                pbStatus(idxPb) = False : pbStatus(6) = True : idxPb = 6
                pbBuzzer.BorderStyle = BorderStyle.Fixed3D : pbBuzzer.BackColor = Color.Blue

            Case 7      '------------>>> Shape
                IdObject = IdObj.Shapes : _ObjStatus = ObjStatus.None
                If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                pb = pbShape
                pbStatus(idxPb) = False : pbStatus(7) = True : idxPb = 7
                pbShape.BorderStyle = BorderStyle.Fixed3D : pbShape.BackColor = Color.Blue

            Case 8      '------------>>> Buttons
                IdObject = IdObj.Buttons : _ObjStatus = ObjStatus.None
                If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                pb = pbButton
                pbStatus(idxPb) = False : pbStatus(8) = True : idxPb = 8
                pbButton.BorderStyle = BorderStyle.Fixed3D : pbButton.BackColor = Color.Blue

            Case 9      '------------>>> Counter
                IdObject = IdObj.Counter : _ObjStatus = ObjStatus.None
                If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                pb = pbCounter
                pbStatus(idxPb) = False : pbStatus(9) = True : idxPb = 9
                pbCounter.BorderStyle = BorderStyle.Fixed3D : pbCounter.BackColor = Color.Blue

            Case 10     '------------>>> Push Button
                'IdObject = IdObj.PushButton : _ObjStatus = ObjStatus.None
                'If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                'pb = pbPushButton
                'pbStatus(idxPb) = False : pbStatus(10) = True : idxPb = 10
                'pbPushButton.BorderStyle = BorderStyle.Fixed3D : pbPushButton.BackColor = Color.Blue

            Case 11     '------------>>> Toggle Button
                'IdObject = IdObj.ToggleButton : _ObjStatus = ObjStatus.None
                'If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                'pb = pbToggleButton
                'pbStatus(idxPb) = False : pbStatus(11) = True : idxPb = 11
                'pbToggleButton.BorderStyle = BorderStyle.Fixed3D : pbToggleButton.BackColor = Color.Blue

            Case 12     '------------>>> Pair Button
                'IdObject = IdObj.PairButton : _ObjStatus = ObjStatus.None
                'If pb.BorderStyle = BorderStyle.Fixed3D Then pb.BorderStyle = BorderStyle.None : pb.BackColor = Color.Silver
                'pb = pbPairButton
                'pbStatus(idxPb) = False : pbStatus(12) = True : idxPb = 12
                'pbPairButton.BorderStyle = BorderStyle.Fixed3D : pbPairButton.BackColor = Color.Blue
        End Select
    End Sub

    Private tt As New ToolTip
    Private Sub pbMenu_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbSignal.MouseHover, pbPointMachine.MouseHover, pbTrack.MouseHover, pbCheckBox.MouseHover, pbLabel.MouseHover, pbBuzzer.MouseHover, pbShape.MouseHover, pbButton.MouseHover, pbCounter.MouseHover, pbPushButton.MouseHover, pbToggleButton.MouseHover, pbPairButton.MouseHover
        Dim Index As Integer

        tt.ShowAlways = True
        Index = CInt(CType(sender, PictureBox).Tag)
        Select Case Index
            Case 1      '------------>>> Signal
                pbSignal.BackColor = Color.Blue
                tt.SetToolTip(pbSignal, "Signal")
            Case (2)      '------------>>> Point Machine
                pbPointMachine.BackColor = Color.Blue
                tt.SetToolTip(pbPointMachine, "Point Machine")
            Case 3      '------------>>> Track
                pbTrack.BackColor = Color.Blue
                tt.SetToolTip(pbTrack, "Track")
            Case 4      '------------>>> Check Box
                pbCheckBox.BackColor = Color.Blue
                tt.SetToolTip(pbCheckBox, "Check Box")
            Case 5      '------------>>> Label
                pbLabel.BackColor = Color.Blue
                tt.SetToolTip(pbLabel, "Label")
            Case 6      '------------>>> Buzzer
                pbBuzzer.BackColor = Color.Blue
                tt.SetToolTip(pbBuzzer, "Buzzer")
            Case 7       '------------>>> Shape
                pbShape.BackColor = Color.Blue
                tt.SetToolTip(pbShape, "Shape")
            Case 8      '------------>>> Button
                pbButton.BackColor = Color.Blue
                tt.SetToolTip(pbButton, "Button")
            Case 9      '------------>>> Counter
                pbCounter.BackColor = Color.Blue
                tt.SetToolTip(pbCounter, "Counter")
            Case 10     '------------>>> Push Button
                pbPushButton.BackColor = Color.Blue
                'tt.SetToolTip(pbPushButton, "Push Button")
            Case 11     '------------>>> Toggle Button
                pbToggleButton.BackColor = Color.Blue
                'tt.SetToolTip(pbToggleButton, "Toggle Button")
            Case 12     '------------>>> Pair Button
                pbPairButton.BackColor = Color.Blue
                'tt.SetToolTip(pbPairButton, "Pair Button")
        End Select
    End Sub

    Private Sub pbMenu_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbSignal.MouseLeave, pbPointMachine.MouseLeave, pbTrack.MouseLeave, pbCheckBox.MouseLeave, pbLabel.MouseLeave, pbBuzzer.MouseLeave, pbShape.MouseLeave, pbButton.MouseLeave, pbCounter.MouseLeave, pbPushButton.MouseLeave, pbToggleButton.MouseLeave, pbPairButton.MouseLeave
        Dim Index As Integer

        Index = CInt(CType(sender, PictureBox).Tag)
        Select Case Index
            Case 1      '------------>>> Signal
                If pbStatus(1) = False Then pbSignal.BackColor = Color.Silver

            Case 2      '------------>>> Point Machine
                If pbStatus(2) = False Then pbPointMachine.BackColor = Color.Silver
            Case 3      '------------>>> Track
                If pbStatus(3) = False Then pbTrack.BackColor = Color.Silver
            Case 4      '------------>>> Check Box
                If pbStatus(4) = False Then pbCheckBox.BackColor = Color.Silver
            Case 5      '------------>>> Label
                If pbStatus(5) = False Then pbLabel.BackColor = Color.Silver
            Case 6      '------------>>> Buzzer
                If pbStatus(6) = False Then pbBuzzer.BackColor = Color.Silver
            Case 7       '------------>>> Shape
                If pbStatus(7) = False Then pbShape.BackColor = Color.Silver
            Case 8      '------------>>> Button
                If pbStatus(8) = False Then pbButton.BackColor = Color.Silver
            Case 9      '------------>>> Counter
                If pbStatus(9) = False Then pbCounter.BackColor = Color.Silver
            Case 10     '------------>>> Push Button
                If pbStatus(10) = False Then pbPushButton.BackColor = Color.Silver
            Case 11     '------------>>> Toggle Button
                If pbStatus(11) = False Then pbToggleButton.BackColor = Color.Silver
            Case 12     '------------>>> Pair Button
                If pbStatus(12) = False Then pbPairButton.BackColor = Color.Silver
        End Select
    End Sub

#End Region

    Private Sub tbGridSizeToolStripTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbGridSizeToolStripTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridSpacing = CInt(Trim(tbGridSizeToolStripTextBox.Text))
            Me.WdwContainer.Grid = GridSpacing
            Me.Refresh()
            SavePreferensi(GridSpacing)
        End If
    End Sub

#Region "       Text ID"
    Private Sub tbNameObject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbNameObject.KeyDown
        If e.KeyCode = Keys.Enter Then
            WriteObjProperty()
        End If
    End Sub

    Dim FontDlg As New FontDialog
    Dim FontFlag As Boolean = False
    Private Sub btFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFont.Click
        FontFlag = True
        If FontDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txFont.Text = FontDlg.Font.Name & ", " & FontDlg.Font.Style.ToString & ", " & FontDlg.Font.Size.ToString
            WriteObjProperty()
        End If
    End Sub

    Private Sub btTextColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTextColor.Click
        Dim ColorDlg As New ColorDialog
        Dim cMyCustomColors(15) As Color

        'Convert colors to integers
        Dim colorBlue As Integer
        Dim colorGreen As Integer
        Dim colorRed As Integer
        Dim iMyCustomColor As Integer
        Dim iMyCustomColors(cMyCustomColors.Length - 1) As Integer

        cMyCustomColors(0) = Color.FromArgb(255, 255, 255) 'white
        cMyCustomColors(1) = Color.FromArgb(239, 239, 239)
        cMyCustomColors(2) = Color.FromArgb(223, 223, 223)
        cMyCustomColors(3) = Color.FromArgb(207, 207, 207)
        cMyCustomColors(4) = Color.FromArgb(191, 191, 191)
        cMyCustomColors(5) = Color.FromArgb(175, 175, 175)
        cMyCustomColors(6) = Color.FromArgb(159, 159, 159)
        cMyCustomColors(7) = Color.FromArgb(143, 143, 143)
        cMyCustomColors(8) = Color.FromArgb(127, 127, 127)
        cMyCustomColors(9) = Color.FromArgb(111, 111, 111)
        cMyCustomColors(10) = Color.FromArgb(95, 95, 95)
        cMyCustomColors(11) = Color.FromArgb(79, 79, 79)
        cMyCustomColors(12) = Color.FromArgb(63, 63, 63)
        cMyCustomColors(13) = Color.FromArgb(47, 47, 47)
        cMyCustomColors(14) = Color.FromArgb(31, 31, 31)
        cMyCustomColors(15) = Color.FromArgb(15, 15, 15)

        For Index = 0 To cMyCustomColors.Length - 1
            'cast to integer
            colorBlue = cMyCustomColors(Index).B
            colorGreen = cMyCustomColors(Index).G
            colorRed = cMyCustomColors(Index).R

            'shift the bits
            iMyCustomColor = colorBlue << 16 Or colorGreen << 8 Or colorRed

            iMyCustomColors(Index) = iMyCustomColor
        Next
        ColorDlg.CustomColors = iMyCustomColors

        If ColorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txColor.BackColor = ColorDlg.Color
            WriteObjProperty()
        End If
    End Sub

    Private Sub cbTextPos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTextPos.SelectedIndexChanged
        Select Case ObjRec(IndexObj).Name
            Case "Signal"
                Select Case cbTextPos.SelectedIndex
                    Case Signal.eTextPosition.Down
                        AnyObj(IndexObj).mSignal.TextPosition = Signal.eTextPosition.Down
                        UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)

                    Case Signal.eTextPosition.Up
                        AnyObj(IndexObj).mSignal.TextPosition = Signal.eTextPosition.Up
                        UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)

                End Select

            Case "Track"
                Select Case cbTextPos.SelectedIndex
                    Case Signal.eTextPosition.Down
                        AnyObj(IndexObj).mTrack.TextPosition = Signal.eTextPosition.Down
                        UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)

                    Case Signal.eTextPosition.Up
                        AnyObj(IndexObj).mTrack.TextPosition = Signal.eTextPosition.Up
                        UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)

                End Select
        End Select
    End Sub

#End Region

#Region "       Geometri"
    Private Sub tbGeometri_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbX.KeyDown, tbY.KeyDown, tbW.KeyDown, tbH.KeyDown
        If e.KeyCode = Keys.Enter Then
            WriteObjProperty()
        End If
    End Sub
#End Region

#Region "       Type"
    Private Sub cbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbType.SelectedIndexChanged
        Select Case ObjRec(IndexObj).Name
            Case "Signal"
                Select Case cbType.SelectedIndex
                    Case Signal.eType.DistanceSignal : AnyObj(IndexObj).mSignal.Type = Signal.eType.DistanceSignal : UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)
                    Case Signal.eType.HomeSigal : AnyObj(IndexObj).mSignal.Type = Signal.eType.HomeSigal : UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)
                    Case Signal.eType.StartingSignal : AnyObj(IndexObj).mSignal.Type = Signal.eType.StartingSignal : UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)
                    Case Signal.eType.ShuntSignal : AnyObj(IndexObj).mSignal.Type = Signal.eType.ShuntSignal : UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)
                    Case Signal.eType.StartingSignalWithShunt : AnyObj(IndexObj).mSignal.Type = Signal.eType.StartingSignalWithShunt : UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)
                End Select

            Case "PointMachine"
                Select Case cbType.SelectedIndex
                    Case PointMachine.eType.LeftDown : AnyObj(IndexObj).mPointMachine.Type = PointMachine.eType.LeftDown : UpdateObj(AnyObj(IndexObj).mPointMachine.Name, IndexObj)
                    Case PointMachine.eType.LeftUp : AnyObj(IndexObj).mPointMachine.Type = PointMachine.eType.LeftUp : UpdateObj(AnyObj(IndexObj).mPointMachine.Name, IndexObj)
                    Case PointMachine.eType.RightDown : AnyObj(IndexObj).mPointMachine.Type = PointMachine.eType.RightDown : UpdateObj(AnyObj(IndexObj).mPointMachine.Name, IndexObj)
                    Case PointMachine.eType.RightUp : AnyObj(IndexObj).mPointMachine.Type = PointMachine.eType.RightUp : UpdateObj(AnyObj(IndexObj).mPointMachine.Name, IndexObj)
                End Select

            Case "Track"
                Select Case cbType.SelectedIndex
                    Case Track.eType.LeftSlash : AnyObj(IndexObj).mTrack.Type = Track.eType.LeftSlash : UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)
                    Case Track.eType.RightSlash : AnyObj(IndexObj).mTrack.Type = Track.eType.RightSlash : UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)
                    Case Track.eType.StraightLine : AnyObj(IndexObj).mTrack.Type = Track.eType.StraightLine : UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)
                End Select

            Case "Label"
                Select Case cbType.SelectedIndex
                    Case LabelName.eType.FixedSingle : AnyObj(IndexObj).mLabel.Type = LabelName.eType.FixedSingle : UpdateObj(AnyObj(IndexObj).mLabel.Name, IndexObj)
                    Case LabelName.eType.Fixed3D : AnyObj(IndexObj).mLabel.Type = LabelName.eType.Fixed3D : UpdateObj(AnyObj(IndexObj).mLabel.Name, IndexObj)
                End Select

            Case "Shape"
                Select Case cbType.SelectedIndex
                    Case Shapes.eShape.Circle : AnyObj(IndexObj).mShapes.Shape = Shapes.eShape.Circle : cbDirection.Items.Clear() : UpdateObj(AnyObj(IndexObj).mShapes.Name, IndexObj)
                    Case Shapes.eShape.Triangle : AnyObj(IndexObj).mShapes.Shape = Shapes.eShape.Triangle : UpdateObj(AnyObj(IndexObj).mShapes.Name, IndexObj)
                        cbDirection.Items.Clear()
                        cbDirection.Items.Insert(0, "Top") : cbDirection.Items.Insert(1, "Bottom")
                        cbDirection.Items.Insert(2, "Left") : cbDirection.Items.Insert(3, "Right")
                        cbDirection.SelectedIndex = AnyObj(IndexObj).mShapes.Direction
                End Select

            Case "Button"
                Select Case cbType.SelectedIndex
                    Case Buttons.eType.PushButton : AnyObj(IndexObj).mButton.Type = Buttons.eType.PushButton : UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)
                        cbDirection.Items.Clear()
                        tbNameObject.Text = AnyObj(IndexObj).mButton.TextName
                        txFont.Text = AnyObj(IndexObj).mButton.Font.Name & ", " & AnyObj(IndexObj).mButton.Font.Style.ToString & ", " & AnyObj(IndexObj).mButton.Font.Size.ToString
                    Case Buttons.eType.ToggleButton : AnyObj(IndexObj).mButton.Type = Buttons.eType.ToggleButton : UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)
                        cbDirection.Items.Clear()
                        tbNameObject.Text = AnyObj(IndexObj).mButton.TextName
                        txFont.Text = AnyObj(IndexObj).mButton.Font.Name & ", " & AnyObj(IndexObj).mButton.Font.Style.ToString & ", " & AnyObj(IndexObj).mButton.Font.Size.ToString
                    Case Buttons.eType.PairButton : AnyObj(IndexObj).mButton.Type = Buttons.eType.PairButton : UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)
                        cbDirection.Items.Clear()
                        cbDirection.Items.Insert(0, "Rectangle") : cbDirection.Items.Insert(1, "Circle")
                        cbDirection.Items.Insert(2, "TriangleLeft") : cbDirection.Items.Insert(3, "TriangleRight")
                        cbDirection.SelectedIndex = AnyObj(IndexObj).mButton.Shape
                        txFont.Text = "" : tbNameObject.Text = ""
                End Select
        End Select
    End Sub

    Private Sub cbDirection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDirection.SelectedIndexChanged
        Select Case ObjRec(IndexObj).Name
            Case "Signal"
                Select Case cbDirection.SelectedIndex
                    Case Signal.ePosition.Left : AnyObj(IndexObj).mSignal.SignalPosition = Signal.ePosition.Left : UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)
                    Case Signal.ePosition.Right : AnyObj(IndexObj).mSignal.SignalPosition = Signal.ePosition.Right : UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)
                End Select

            Case "Track"
                Select Case cbDirection.SelectedIndex
                    Case Track.eLinePosition.None : AnyObj(IndexObj).mTrack.LinePosition = Track.eLinePosition.None : UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)
                    Case Track.eLinePosition.Down : AnyObj(IndexObj).mTrack.LinePosition = Track.eLinePosition.Down : UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)
                    Case Track.eLinePosition.Up : AnyObj(IndexObj).mTrack.LinePosition = Track.eLinePosition.Up : UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)
                End Select

            Case "Shape"
                Select Case cbDirection.SelectedIndex
                    Case Shapes.eDirection.Bottom : AnyObj(IndexObj).mShapes.Direction = Shapes.eDirection.Bottom : UpdateObj(AnyObj(IndexObj).mShapes.Name, IndexObj)
                    Case Shapes.eDirection.Left : AnyObj(IndexObj).mShapes.Direction = Shapes.eDirection.Left : UpdateObj(AnyObj(IndexObj).mShapes.Name, IndexObj)
                    Case Shapes.eDirection.Right : AnyObj(IndexObj).mShapes.Direction = Shapes.eDirection.Right : UpdateObj(AnyObj(IndexObj).mShapes.Name, IndexObj)
                    Case Shapes.eDirection.Top : AnyObj(IndexObj).mShapes.Direction = Shapes.eDirection.Top : UpdateObj(AnyObj(IndexObj).mShapes.Name, IndexObj)
                End Select

            Case "Button"
                Select Case cbDirection.SelectedIndex
                    Case Buttons.eShape.Circle : AnyObj(IndexObj).mButton.Shape = Buttons.eShape.Circle : UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)
                    Case Buttons.eShape.Rectangle : AnyObj(IndexObj).mButton.Shape = Buttons.eShape.Rectangle : UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)
                    Case Buttons.eShape.TriangleLeft : AnyObj(IndexObj).mButton.Shape = Buttons.eShape.TriangleLeft : UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)
                    Case Buttons.eShape.TriangleRight : AnyObj(IndexObj).mButton.Shape = Buttons.eShape.TriangleRight : UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)
                End Select

        End Select
    End Sub

    Private Sub txThickness_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txThickness.KeyDown
        If e.KeyCode = Keys.Enter Then
            WriteObjProperty()
        End If
    End Sub

    Private Sub txDiameter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txDiameter.KeyDown
        If e.KeyCode = Keys.Enter Then
            WriteObjProperty()
        End If
    End Sub
#End Region

#Region "        Object Color"
    Private Sub btIdColor1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIdColor1.Click, btIdColor2.Click, btIdColor3.Click, btIdColor4.Click
        Dim ColorDlg As New ColorDialog
        Dim cMyCustomColors(15) As Color
        Dim Index As Integer

        'Convert colors to integers
        Dim colorBlue As Integer
        Dim colorGreen As Integer
        Dim colorRed As Integer
        Dim iMyCustomColor As Integer
        Dim iMyCustomColors(cMyCustomColors.Length - 1) As Integer

        cMyCustomColors(0) = Color.FromArgb(255, 255, 255) 'white
        cMyCustomColors(1) = Color.FromArgb(239, 239, 239)
        cMyCustomColors(2) = Color.FromArgb(223, 223, 223)
        cMyCustomColors(3) = Color.FromArgb(207, 207, 207)
        cMyCustomColors(4) = Color.FromArgb(191, 191, 191)
        cMyCustomColors(5) = Color.FromArgb(175, 175, 175)
        cMyCustomColors(6) = Color.FromArgb(159, 159, 159)
        cMyCustomColors(7) = Color.FromArgb(143, 143, 143)
        cMyCustomColors(8) = Color.FromArgb(127, 127, 127)
        cMyCustomColors(9) = Color.FromArgb(111, 111, 111)
        cMyCustomColors(10) = Color.FromArgb(95, 95, 95)
        cMyCustomColors(11) = Color.FromArgb(79, 79, 79)
        cMyCustomColors(12) = Color.FromArgb(63, 63, 63)
        cMyCustomColors(13) = Color.FromArgb(47, 47, 47)
        cMyCustomColors(14) = Color.FromArgb(31, 31, 31)
        cMyCustomColors(15) = Color.FromArgb(15, 15, 15)

        For Index = 0 To cMyCustomColors.Length - 1
            'cast to integer
            colorBlue = cMyCustomColors(Index).B
            colorGreen = cMyCustomColors(Index).G
            colorRed = cMyCustomColors(Index).R

            'shift the bits
            iMyCustomColor = colorBlue << 16 Or colorGreen << 8 Or colorRed

            iMyCustomColors(Index) = iMyCustomColor
        Next

        ColorDlg.CustomColors = iMyCustomColors

        Index = (CType(sender, Button).Tag)
        If ColorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Select Case Index
                Case 1
                    txIdColor1.BackColor = ColorDlg.Color
                Case 2
                    txIdColor2.BackColor = ColorDlg.Color
                Case 3
                    txIdColor3.BackColor = ColorDlg.Color
                Case 4
                    txIdColor4.BackColor = ColorDlg.Color
            End Select
            WriteObjProperty()
        End If

    End Sub
#End Region

#Region "       Write Property"
    Private Sub WriteObjProperty()
        Select Case ObjRec(IndexObj).Name
            Case "Signal"
                AnyObj(IndexObj).mSignal.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mSignal.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mSignal.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mSignal.Height = CInt(tbH.Text)
                AnyObj(IndexObj).mSignal.TextName = tbNameObject.Text
                AnyObj(IndexObj).mSignal.Diameter = CInt(txDiameter.Text)
                AnyObj(IndexObj).mSignal.ShuntThickness = CInt(txThickness.Text)
                '--------------- Font --------------
                If FontFlag Then
                    AnyObj(IndexObj).mSignal.Font = FontDlg.Font
                    FontFlag = False
                End If
                '--------------- Color ------------
                AnyObj(IndexObj).mSignal.Idx1Color = txIdColor1.BackColor
                AnyObj(IndexObj).mSignal.Idx2Color = txColor.BackColor
                AnyObj(IndexObj).mSignal.Idx3Color = txIdColor2.BackColor
                AnyObj(IndexObj).mSignal.Idx4Color = txIdColor3.BackColor
                AnyObj(IndexObj).mSignal.Idx5Color = txIdColor4.BackColor
                '--------------- Update Object Property -----------------
                UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)

            Case "PointMachine"
                AnyObj(IndexObj).mPointMachine.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mPointMachine.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mPointMachine.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mPointMachine.Height = CInt(tbH.Text)
                AnyObj(IndexObj).mPointMachine.TextName = tbNameObject.Text
                AnyObj(IndexObj).mPointMachine.Thickness = CInt(txThickness.Text)
                '--------------- Font --------------
                If FontFlag Then
                    AnyObj(IndexObj).mPointMachine.Font = FontDlg.Font
                    FontFlag = False
                End If
                '--------------- Color ------------
                AnyObj(IndexObj).mPointMachine.Idx1Color = txIdColor1.BackColor
                AnyObj(IndexObj).mPointMachine.Idx2Color = txColor.BackColor
                AnyObj(IndexObj).mPointMachine.Idx3Color = txIdColor2.BackColor
                AnyObj(IndexObj).mPointMachine.Idx4Color = txIdColor3.BackColor
                AnyObj(IndexObj).mPointMachine.Idx5Color = txIdColor4.BackColor
                '--------------- Update Object Property -----------------
                UpdateObj(AnyObj(IndexObj).mPointMachine.Name, IndexObj)

            Case "Track"
                AnyObj(IndexObj).mTrack.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mTrack.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mTrack.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mTrack.Height = CInt(tbH.Text)
                AnyObj(IndexObj).mTrack.Thickness = CInt(txThickness.Text)
                AnyObj(IndexObj).mTrack.TextName = tbNameObject.Text
                '--------------- Font --------------
                If FontFlag Then
                    AnyObj(IndexObj).mTrack.Font = FontDlg.Font
                    FontFlag = False
                End If
                '--------------- Color ------------
                AnyObj(IndexObj).mTrack.Idx1Color = txIdColor1.BackColor
                AnyObj(IndexObj).mTrack.Idx2Color = txColor.BackColor
                AnyObj(IndexObj).mTrack.Idx3Color = txIdColor2.BackColor
                AnyObj(IndexObj).mTrack.Idx4Color = txIdColor3.BackColor
                AnyObj(IndexObj).mTrack.Idx5Color = txIdColor4.BackColor
                '--------------- Update Object Property -----------------
                UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)

            Case "Label"
                AnyObj(IndexObj).mLabel.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mLabel.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mLabel.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mLabel.Height = CInt(tbH.Text)
                AnyObj(IndexObj).mLabel.TextName = tbNameObject.Text
                '--------------- Font --------------
                If FontFlag Then
                    AnyObj(IndexObj).mLabel.Font = FontDlg.Font
                    FontFlag = False
                End If
                '--------------- Color ------------
                AnyObj(IndexObj).mLabel.Idx1Color = txIdColor1.BackColor
                AnyObj(IndexObj).mLabel.Idx2Color = txColor.BackColor
                AnyObj(IndexObj).mLabel.Idx3Color = txIdColor2.BackColor
                '--------------- Update Object Property -----------------
                UpdateObj(AnyObj(IndexObj).mLabel.Name, IndexObj)

            Case "CheckBox"
                AnyObj(IndexObj).mCheckBox.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mCheckBox.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mCheckBox.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mCheckBox.Height = CInt(tbH.Text)
                AnyObj(IndexObj).mCheckBox.TextName = tbNameObject.Text
                '--------------- Font --------------
                If FontFlag Then
                    AnyObj(IndexObj).mCheckBox.Font = FontDlg.Font
                    FontFlag = False
                End If
                '--------------- Color ------------
                AnyObj(IndexObj).mCheckBox.Idx1Color = txIdColor1.BackColor
                AnyObj(IndexObj).mCheckBox.Idx2Color = txColor.BackColor
                '--------------- Update Object Property -----------------
                UpdateObj(AnyObj(IndexObj).mCheckBox.Name, IndexObj)

            Case "Shape"
                AnyObj(IndexObj).mShapes.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mShapes.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mShapes.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mShapes.Height = CInt(tbH.Text)
                AnyObj(IndexObj).mShapes.Diameter = CInt(txDiameter.Text)
                '--------------- Color ------------------------
                AnyObj(IndexObj).mShapes.Idx1Color = txIdColor1.BackColor
                AnyObj(IndexObj).mShapes.Idx3Color = txIdColor2.BackColor
                '--------------- Update Object Property -----------------
                UpdateObj(AnyObj(IndexObj).mShapes.Name, IndexObj)

            Case "Button"
                AnyObj(IndexObj).mButton.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mButton.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mButton.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mButton.Height = CInt(tbH.Text)
                AnyObj(IndexObj).mButton.TextName = tbNameObject.Text
                '--------------- Font --------------
                If FontFlag Then
                    AnyObj(IndexObj).mButton.Font = FontDlg.Font
                    FontFlag = False
                End If
                '--------------- Color ------------
                AnyObj(IndexObj).mButton.Idx1Color = txIdColor1.BackColor
                AnyObj(IndexObj).mButton.Idx2Color = txColor.BackColor
                AnyObj(IndexObj).mButton.Idx3Color = txIdColor2.BackColor
                '--------------- Update Object Property -----------------
                UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)

            Case "Counter"
                AnyObj(IndexObj).mCounter.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mCounter.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mCounter.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mCounter.Height = CInt(tbH.Text)
                '--------------- Color ------------------------
                AnyObj(IndexObj).mCounter.Idx1Color = txIdColor1.BackColor
                AnyObj(IndexObj).mCounter.Idx3Color = txIdColor2.BackColor
                '--------------- Update Object Property -----------------
                UpdateObj(AnyObj(IndexObj).mCounter.Name, IndexObj)

            Case "Buzzer"
                AnyObj(IndexObj).mBuzzer.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mBuzzer.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mBuzzer.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mBuzzer.Height = CInt(tbH.Text)
                '--------------- Color ------------------------
                AnyObj(IndexObj).mBuzzer.Idx1Color = txIdColor1.BackColor
                AnyObj(IndexObj).mBuzzer.Idx3Color = txIdColor2.BackColor
                '--------------- Update Object Property -----------------
                UpdateObj(AnyObj(IndexObj).mBuzzer.Name, IndexObj)

            Case "EquipmentName"
                AnyObj(IndexObj).mEquipmentName.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mEquipmentName.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mEquipmentName.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mEquipmentName.Height = CInt(tbH.Text)

            Case "PictureBox"
                AnyObj(IndexObj).mPictureBox.Top = CInt(tbY.Text)
                AnyObj(IndexObj).mPictureBox.Left = CInt(tbX.Text)
                AnyObj(IndexObj).mPictureBox.Width = CInt(tbW.Text)
                AnyObj(IndexObj).mPictureBox.Height = CInt(tbH.Text)

        End Select

    End Sub
#End Region

#Region "       Grid View"
    Private Sub NoGridToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoGridToolStripButton.Click
        Me.WdwContainer.Style = winContainer.eStyle.None
        Me.WdwContainer.Refresh()
    End Sub

    Private Sub DotToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DotToolStripButton.Click
        Me.WdwContainer.Style = winContainer.eStyle.Dot
        Me.WdwContainer.Refresh()
    End Sub

    Private Sub LineToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineToolStripButton.Click
        Me.WdwContainer.Style = winContainer.eStyle.Line
        Me.WdwContainer.Refresh()
    End Sub
#End Region

#Region "       Contex Menu Strip"
    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        Select Case ObjRec(IndexObj).Name
            Case "Signal" : AnyObj(IndexObj).mSignal.Visible = False
            Case "PointMachine" : AnyObj(IndexObj).mPointMachine.Visible = False
            Case "Track" : AnyObj(IndexObj).mTrack.Visible = False
            Case "Label" : AnyObj(IndexObj).mLabel.Visible = False
            Case "CheckBox" : AnyObj(IndexObj).mCheckBox.Visible = False
            Case "Counter" : AnyObj(IndexObj).mCounter.Visible = False
            Case "Buzzer" : AnyObj(IndexObj).mBuzzer.Visible = False
            Case "EquipmentName" : AnyObj(IndexObj).mEquipmentName.Visible = False
            Case "PictureBox" : AnyObj(IndexObj).mPictureBox.Visible = False
            Case "Shape" : AnyObj(IndexObj).mShapes.Visible = False
            Case "Button" : AnyObj(IndexObj).mButton.Visible = False
        End Select
        Me.pContainer.AutoScrollPosition = New Point(0, 0)
        ObjCutBuffer.Name = ObjRec(IndexObj).Name
        ObjCutBuffer.Index = IndexObj
        _ObjStatus = ObjStatus.Cut
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Select Case ObjRec(IndexObj).Name
            Case "Signal" : IdObject = IdObj.Signal : CopyObject(ObjRec(IndexObj).Name)
            Case "PointMachine" : IdObject = IdObj.PoinMachine : CopyObject(ObjRec(IndexObj).Name)
            Case "Track" : IdObject = IdObj.Track : CopyObject(ObjRec(IndexObj).Name)
            Case "Label" : IdObject = IdObj.Label : CopyObject(ObjRec(IndexObj).Name)
            Case "CheckBox" : IdObject = IdObj.CheckBox : CopyObject(ObjRec(IndexObj).Name)
            Case "Counter" : IdObject = IdObj.Counter : CopyObject(ObjRec(IndexObj).Name)
            Case "Buzzer" : IdObject = IdObj.Buzzer : CopyObject(ObjRec(IndexObj).Name)
            Case "EquipmentName" : IdObject = IdObj.EquipmentName : CopyObject(ObjRec(IndexObj).Name)
            Case "PictureBox" : IdObject = IdObj.PictureBox : CopyObject(ObjRec(IndexObj).Name)
            Case "Shape" : IdObject = IdObj.Shapes : CopyObject(ObjRec(IndexObj).Name)
            Case "Button" : IdObject = IdObj.Buttons : CopyObject(ObjRec(IndexObj).Name)
        End Select
        _ObjStatus = ObjStatus.Copy
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Dim s As IdObj
        Select Case _ObjStatus
            Case ObjStatus.Cut
                Select Case ObjCutBuffer.Name
                    Case "Signal"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mSignal.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mSignal.Visible = True
                        IdObject = IdObj.Signal : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)

                    Case "PointMachine"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mPointMachine.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mPointMachine.Visible = True
                        IdObject = IdObj.PoinMachine : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mPointMachine.Name, IndexObj)

                    Case "Track"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mTrack.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mTrack.Visible = True
                        IdObject = IdObj.Track : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)

                    Case "Label"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mLabel.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mLabel.Visible = True
                        IdObject = IdObj.Label : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mLabel.Name, IndexObj)

                    Case "CheckBox"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mCheckBox.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mCheckBox.Visible = True
                        IdObject = IdObj.CheckBox : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mCheckBox.Name, IndexObj)

                    Case "Counter"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mCounter.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mCounter.Visible = True
                        IdObject = IdObj.Counter : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mCounter.Name, IndexObj)

                    Case "Buzzer"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mBuzzer.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mBuzzer.Visible = True
                        IdObject = IdObj.Buzzer : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mBuzzer.Name, IndexObj)

                    Case "EquipmentName"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mEquipmentName.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mEquipmentName.Visible = True
                        IdObject = IdObj.EquipmentName : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mEquipmentName.Name, IndexObj)

                    Case "PictureBox"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mEquipmentName.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mEquipmentName.Visible = True
                        IdObject = IdObj.PictureBox : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mEquipmentName.Name, IndexObj)

                    Case "Shape"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mShapes.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mShapes.Visible = True
                        IdObject = IdObj.Shapes : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mShapes.Name, IndexObj)

                    Case "Button"
                        IndexObj = ObjCutBuffer.Index
                        AnyObj(IndexObj).mButton.Location = New Point(SnapGrid(winCoordinat.X), SnapGrid(winCoordinat.Y))
                        AnyObj(IndexObj).mButton.Visible = True
                        IdObject = IdObj.Buttons : _ObjStatus = ObjStatus.Copy
                        UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)
                End Select

            Case ObjStatus.Copy
                s = IdObject
                winCoordinat.X = SnapGrid(winCoordinat.X) + GridSpacing : winCoordinat.Y = SnapGrid(winCoordinat.Y) + GridSpacing
                If IdObject <> IdObj.None Then Load_Object(WdwContainer, IdObject)
                IdObject = s
        End Select

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Select Case ObjRec(IndexObj).Name
            Case "Signal" : AnyObj(IndexObj).mSignal.Visible = False : AnyObj(IndexObj).mSignal.OnVisible = False : UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)
            Case "PointMachine" : AnyObj(IndexObj).mPointMachine.Visible = False : AnyObj(IndexObj).mPointMachine.OnVisible = False : UpdateObj(AnyObj(IndexObj).mPointMachine.Name, IndexObj)
            Case "Track" : AnyObj(IndexObj).mTrack.Visible = False : AnyObj(IndexObj).mTrack.OnVisible = False : UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)
            Case "Label" : AnyObj(IndexObj).mLabel.Visible = False : AnyObj(IndexObj).mLabel.OnVisible = False : UpdateObj(AnyObj(IndexObj).mLabel.Name, IndexObj)
            Case "CheckBox" : AnyObj(IndexObj).mCheckBox.Visible = False : AnyObj(IndexObj).mCheckBox.OnVisible = False : UpdateObj(AnyObj(IndexObj).mCheckBox.Name, IndexObj)
            Case "Counter" : AnyObj(IndexObj).mCounter.Visible = False : AnyObj(IndexObj).mCounter.OnVisible = False : UpdateObj(AnyObj(IndexObj).mCounter.Name, IndexObj)
            Case "Buzzer" : AnyObj(IndexObj).mBuzzer.Visible = False : AnyObj(IndexObj).mBuzzer.OnVisible = False : UpdateObj(AnyObj(IndexObj).mBuzzer.Name, IndexObj)
            Case "EquipmentName" : AnyObj(IndexObj).mEquipmentName.Visible = False : AnyObj(IndexObj).mEquipmentName.OnVisible = False : UpdateObj(AnyObj(IndexObj).mEquipmentName.Name, IndexObj)
            Case "PictureBox" : AnyObj(IndexObj).mPictureBox.Visible = False : UpdateObj(AnyObj(IndexObj).mPictureBox.Name, IndexObj) 'on visible blom
            Case "Shape" : AnyObj(IndexObj).mShapes.Visible = False : AnyObj(IndexObj).mShapes.OnVisible = False : UpdateObj(AnyObj(IndexObj).mShapes.Name, IndexObj)
            Case "Button" : AnyObj(IndexObj).mButton.Visible = False : AnyObj(IndexObj).mButton.OnVisible = False : UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)
        End Select
        LoadObject.Remove(WdwContainer, IndexObj)
        Me.pContainer.AutoScrollPosition = New Point(0, 0)
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        Dim f As New frmObjectProperty

        f.ShowDialog()
    End Sub
#End Region

#Region "       Load and Save Layout Station"
    Private Sub Open_Layout_Station_File(ByVal sta As String)
        If File.Exists(sta) Then
            Dim iFile As New StreamReader(sta)
            Dim iLine As String
            Dim data(0) As String
            Dim i As Integer
            Dim objName As String


            i = 0
            Do
                iLine = iFile.ReadLine()
                data(i) = iLine
                If i > 2 And iLine <> "" Then
                    '-- No - Name - Left - Top -Width - Height - Type - Group - Diameter - Thickness - Direction - Text - Text Position - Font - Font Size - Font Style 
                    '-- IdxColor1 - IdxColor2 - IdxColor3 - IdxColor4 - IdxColor5
                    '-- TagId1Color - TagId2Color - TagId3Color - TagId4Color - TagId5Color
                    '-- TagId1Val - TagId2Val - TagId3Val - TagId4Val - TagId5Val
                    '-- Active - TagTx - TagTx1 - TagTx2 - TagTx3 - TagTx4 - TagTx5
                    '-- OnVisible
                    Dim value() As String = Split(data(i), ",")
                    Dim IsiParsing(39) As String
                    Dim j As Integer

                    j = 0
                    For Each s As String In value
                        IsiParsing(j) = s
                        j += 1
                    Next
                    '---------- Load Object ----------
                    'ObjProp.Visible = True
                    ObjProp.OnRunTime = False

                    objName = Mid(IsiParsing(1), 2, Len(IsiParsing(1)) - 2)
                    winCoordinat.X = Integer.Parse(IsiParsing(2))
                    winCoordinat.Y = Integer.Parse(IsiParsing(3))
                    ObjProp.Width = Integer.Parse(IsiParsing(4))
                    ObjProp.Height = Integer.Parse(IsiParsing(5))
                    ObjProp.Type = Integer.Parse(IsiParsing(6))
                    ObjProp.Group = Integer.Parse(IsiParsing(7))
                    ObjProp.Diameter = Integer.Parse(IsiParsing(8))
                    ObjProp.Thickness = Integer.Parse(IsiParsing(9))
                    ObjProp.Direction = Integer.Parse(IsiParsing(10))
                    ObjProp.Text = Mid(IsiParsing(11), 2, Len(IsiParsing(11)) - 2)
                    ObjProp.TextPosition = Integer.Parse(IsiParsing(12))
                    ObjProp.fName = Mid(IsiParsing(13), 2, Len(IsiParsing(13)) - 2)
                    ObjProp.fSize = Integer.Parse(IsiParsing(14))
                    ObjProp.fStyle = Integer.Parse(IsiParsing(15))
                    ObjProp.IdColor1 = Color.FromArgb(Integer.Parse(IsiParsing(16)))
                    ObjProp.IdColor2 = Color.FromArgb(Integer.Parse(IsiParsing(17)))
                    ObjProp.IdColor3 = Color.FromArgb(Integer.Parse(IsiParsing(18)))
                    ObjProp.IdColor4 = Color.FromArgb(Integer.Parse(IsiParsing(19)))
                    ObjProp.IdColor5 = Color.FromArgb(Integer.Parse(IsiParsing(20)))
                    ObjProp.TagId1Color = Color.FromArgb(Integer.Parse(IsiParsing(21)))
                    ObjProp.TagId2Color = Color.FromArgb(Integer.Parse(IsiParsing(22)))
                    ObjProp.TagId3Color = Color.FromArgb(Integer.Parse(IsiParsing(23)))
                    ObjProp.TagId4Color = Color.FromArgb(Integer.Parse(IsiParsing(24)))
                    ObjProp.TagId5Color = Color.FromArgb(Integer.Parse(IsiParsing(25)))
                    ObjProp.TagIdVal = Convert.ToBoolean(Mid(IsiParsing(26), 2, Len(IsiParsing(26)) - 2))
                    ObjProp.TagId1Val = Convert.ToBoolean(Mid(IsiParsing(27), 2, Len(IsiParsing(27)) - 2))
                    ObjProp.TagId2Val = Convert.ToBoolean(Mid(IsiParsing(28), 2, Len(IsiParsing(28)) - 2))
                    ObjProp.TagId3Val = Convert.ToBoolean(Mid(IsiParsing(29), 2, Len(IsiParsing(29)) - 2))
                    ObjProp.TagId4Val = Convert.ToBoolean(Mid(IsiParsing(30), 2, Len(IsiParsing(30)) - 2))
                    ObjProp.TagId5Val = Convert.ToBoolean(Mid(IsiParsing(31), 2, Len(IsiParsing(31)) - 2))
                    ObjProp.Active = Convert.ToBoolean(Mid(IsiParsing(32), 2, Len(IsiParsing(32)) - 2))
                    ObjProp.TagTx = Mid(IsiParsing(33), 2, Len(IsiParsing(33)) - 2)
                    ObjProp.TagTx1 = Mid(IsiParsing(34), 2, Len(IsiParsing(34)) - 2)
                    ObjProp.TagTx2 = Mid(IsiParsing(35), 2, Len(IsiParsing(35)) - 2)
                    ObjProp.TagTx3 = Mid(IsiParsing(36), 2, Len(IsiParsing(36)) - 2)
                    ObjProp.TagTx4 = Mid(IsiParsing(37), 2, Len(IsiParsing(37)) - 2)
                    ObjProp.TagTx5 = Mid(IsiParsing(38), 2, Len(IsiParsing(38)) - 2)
                    ObjProp.OnVisible = Convert.ToBoolean(Mid(IsiParsing(39), 2, Len(IsiParsing(39)) - 2))

                    Select Case objName
                        Case "Signal" : Load_Object(WdwContainer, IdObj.Signal) ' : Me.Refresh()
                        Case "PointMachine" : Load_Object(WdwContainer, IdObj.PoinMachine) ': Me.Refresh()
                        Case "Track" : Load_Object(WdwContainer, IdObj.Track) ': Me.Refresh()
                        Case "Label" : Load_Object(WdwContainer, IdObj.Label) ': Me.Refresh()
                        Case "CheckBox" : Load_Object(WdwContainer, IdObj.CheckBox) ' : Me.Refresh()
                        Case "Counter" : Load_Object(WdwContainer, IdObj.Counter) ' : Me.Refresh()
                        Case "Buzzer" : Load_Object(WdwContainer, IdObj.Buzzer) ': Me.Refresh()
                        Case "EquipmentName" : Load_Object(WdwContainer, IdObj.EquipmentName) ' : Me.Refresh()
                        Case "PictureBox" : Load_Object(WdwContainer, IdObj.PictureBox) ' : Me.Refresh()
                        Case "Shape" : Load_Object(WdwContainer, IdObj.Shapes) ': Me.Refresh()
                        Case "Button" : Load_Object(WdwContainer, IdObj.Buttons) ': Me.Refresh()
                    End Select

                End If
                i += 1
                ReDim Preserve data(i)
            Loop Until iLine Is Nothing
            iFile.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Save_Layout_Station_File(ByVal sta As String)
        FileOpen(1, sta, OpenMode.Output)
        Try
            WriteLine(1, "File Layout Station")
            WriteLine(1, "CBI")
            WriteLine(1, "No", "Name", "Left", "Top", "Width", "Height", "Type", "Group", "Diameter", "Thickness", "Direction", _
                      "Text", "Text Position", "Font", "FontSize", "FontStyle", _
                      "IdxColor1", "IdxColor2", "IdxColor3", "IdxColor4", "IdxColor5", _
                      "TagId1Color", "TagId2Color", "TagId3Color", "TagId4Color", "TagId5Color", _
                      "TagIdVal", "TagId1Val", "TagId2Val", "TagId3Val", "TagId4Val", "TagId5Val", "Active", _
                      "TagTx", "TagTx1", "TagTx2", "TagTx3", "TagTx4", "TagTx5", "OnVisible")
            '----------------------------------------------------------
            '------------------ save layout station -------------------
            '----------------------------------------------------------
            For i As Integer = 1 To UBound(AnyObj)
                'Debug.Print(ObjRec(i).Name & ObjRec(i).OnVisible)
                If ObjRec(i).OnVisible Then
                    WriteLine(1, i, ObjRec(i).Name, ObjRec(i).Left, ObjRec(i).Top, ObjRec(i).Width, ObjRec(i).Height, _
                              ObjRec(i).Type, ObjRec(i).Group, ObjRec(i).Diameter, ObjRec(i).Thickness, ObjRec(i).Direction, ObjRec(i).Text, _
                              ObjRec(i).TextPosition, ObjRec(i).fName, ObjRec(i).fSize, ObjRec(i).fStyle, ObjRec(i).IdColor1.ToArgb, ObjRec(i).IdColor2.ToArgb, _
                              ObjRec(i).IdColor3.ToArgb, ObjRec(i).IdColor4.ToArgb, ObjRec(i).IdColor5.ToArgb, _
                              ObjRec(i).TagId1Color.ToArgb, ObjRec(i).TagId2Color.ToArgb, ObjRec(i).TagId3Color.ToArgb, ObjRec(i).TagId4Color.ToArgb, ObjRec(i).TagId5Color.ToArgb, _
                              ObjRec(i).TagIdVal.ToString, ObjRec(i).TagId1Val.ToString, ObjRec(i).TagId2Val.ToString, ObjRec(i).TagId3Val.ToString, ObjRec(i).TagId4Val.ToString, ObjRec(i).TagId5Val.ToString, ObjRec(i).Active.ToString, _
                              ObjRec(i).TagTx, ObjRec(i).TagTx1, ObjRec(i).TagTx2, ObjRec(i).TagTx3, ObjRec(i).TagTx4, ObjRec(i).TagTx5, _
                              ObjRec(i).OnVisible.ToString)
                End If
            Next
        Catch ex As Exception

        End Try
        FileClose(1)
    End Sub


    Public Sub OpenHdwConfiguration(ByVal source As String)
        If File.Exists(source) Then
            Dim iFile As New StreamReader(source)
            Dim iLine As String
            Dim data(0) As String
            Dim i, k As Integer

            i = 0
            k = 0
            Do
                iLine = iFile.ReadLine()
                data(i) = iLine
                If i > 2 And iLine <> "" Then
                    Dim value() As String = Split(data(i), ",")
                    Dim IsiParsing(20) As String
                    Dim j As Integer

                    j = 0
                    For Each s As String In value
                        IsiParsing(j) = s
                        j += 1
                    Next

                    '----------------------------------------------
                    dbHDW(k).coupler = Integer.Parse(IsiParsing(1))
                    dbHDW(k).address = Integer.Parse(IsiParsing(2))
                    dbHDW(k).status = Integer.Parse(IsiParsing(3))
                    dbHDW(k).InOut = Integer.Parse(IsiParsing(4))
                    dbHDW(k).bit0 = Mid(IsiParsing(5), 2, Len(IsiParsing(5)) - 2)
                    dbHDW(k).bit1 = Mid(IsiParsing(6), 2, Len(IsiParsing(6)) - 2)
                    dbHDW(k).bit2 = Mid(IsiParsing(7), 2, Len(IsiParsing(7)) - 2)
                    dbHDW(k).bit3 = Mid(IsiParsing(8), 2, Len(IsiParsing(8)) - 2)
                    dbHDW(k).bit4 = Mid(IsiParsing(9), 2, Len(IsiParsing(9)) - 2)
                    dbHDW(k).bit5 = Mid(IsiParsing(10), 2, Len(IsiParsing(10)) - 2)
                    dbHDW(k).bit6 = Mid(IsiParsing(11), 2, Len(IsiParsing(11)) - 2)
                    dbHDW(k).bit7 = Mid(IsiParsing(12), 2, Len(IsiParsing(12)) - 2)
                    dbHDW(k).bit8 = Mid(IsiParsing(13), 2, Len(IsiParsing(13)) - 2)
                    dbHDW(k).bit9 = Mid(IsiParsing(14), 2, Len(IsiParsing(14)) - 2)
                    dbHDW(k).bit10 = Mid(IsiParsing(15), 2, Len(IsiParsing(15)) - 2)
                    dbHDW(k).bit11 = Mid(IsiParsing(16), 2, Len(IsiParsing(16)) - 2)
                    dbHDW(k).bit12 = Mid(IsiParsing(17), 2, Len(IsiParsing(17)) - 2)
                    dbHDW(k).bit13 = Mid(IsiParsing(18), 2, Len(IsiParsing(18)) - 2)
                    dbHDW(k).bit14 = Mid(IsiParsing(19), 2, Len(IsiParsing(19)) - 2)
                    dbHDW(k).bit15 = Mid(IsiParsing(20), 2, Len(IsiParsing(20)) - 2)
                    k += 1
                    ReDim Preserve dbHDW(k)
                End If
                i += 1
                ReDim Preserve data(i)
            Loop Until iLine Is Nothing
            iFile.Close()
            createTreesWhenOpenFile()
            'Debug.Print("-----------------------------")
            'For x As Integer = 0 To UBound(dbHDW) - 1
            '    Debug.Print(dbHDW(x).coupler & dbHDW(x).address & dbHDW(x).status & dbHDW(x).InOut & dbHDW(x).bit0 & dbHDW(x).bit1 & dbHDW(x).bit2 & dbHDW(x).bit3 & dbHDW(x).bit4 & dbHDW(x).bit5 & dbHDW(x).bit6 & dbHDW(x).bit7 & dbHDW(x).bit8 & dbHDW(x).bit9 & dbHDW(x).bit10 & dbHDW(x).bit11 & dbHDW(x).bit12 & dbHDW(x).bit13 & dbHDW(x).bit14 & dbHDW(x).bit15)
            'Next

            'Debug.Print(UBound(Parameter) & " <<<----")
        Else
            Exit Sub
        End If

    End Sub

    Private Sub SaveHdwConfiguration(ByVal source As String)
        FileOpen(1, source, OpenMode.Output)
        Try
            WriteLine(1, "File Hardware Configuration")
            WriteLine(1, "CBI")
            WriteLine(1, "No", "Coupler", "Address", "Status", "InOut", "bit0", "bit1", "bit2", "bit3", "bit4", "bit5", "bit6", "bit7", _
                      "bit8", "bit9", "bit10", "bit11", "bit12", "bit13", "bit14", "bit15")
            '----------------------------------------------------------
            '---------------- save hardware configuration -------------
            '----------------------------------------------------------
            For i As Integer = 0 To UBound(dbHDW) - 1
                If dbHDW(i).status = slotStatus.boooked Then
                    WriteLine(1, i + 1, dbHDW(i).coupler, dbHDW(i).address, dbHDW(i).status, dbHDW(i).InOut, dbHDW(i).bit0, dbHDW(i).bit1, dbHDW(i).bit2, dbHDW(i).bit3, dbHDW(i).bit4, dbHDW(i).bit5, dbHDW(i).bit6, dbHDW(i).bit7, _
                              dbHDW(i).bit8, dbHDW(i).bit9, dbHDW(i).bit10, dbHDW(i).bit11, dbHDW(i).bit12, dbHDW(i).bit13, dbHDW(i).bit14, dbHDW(i).bit15)
                End If
            Next
        Catch ex As Exception

        End Try
        FileClose(1)
        'Debug.Print("-----------------------------")
        'For x As Integer = 0 To UBound(dbHDW) - 1
        '    Debug.Print(dbHDW(x).coupler & dbHDW(x).address & dbHDW(x).status & dbHDW(x).InOut & dbHDW(x).bit0 & dbHDW(x).bit1 & dbHDW(x).bit2 & dbHDW(x).bit3 & dbHDW(x).bit4 & dbHDW(x).bit5 & dbHDW(x).bit6 & dbHDW(x).bit7 & dbHDW(x).bit8 & dbHDW(x).bit9 & dbHDW(x).bit10 & dbHDW(x).bit11 & dbHDW(x).bit12 & dbHDW(x).bit13 & dbHDW(x).bit14 & dbHDW(x).bit15)
        'Next
    End Sub
#End Region

    Private Sub DeleteAllComponent()
        For i As Integer = 1 To UBound(AnyObj)
            LoadObject.Remove(WdwContainer, i)
        Next
        IndexObj = 0
        ReDim AnyObj(IndexObj)
        ReDim ObjRec(IndexObj)
        LoadObject = New clsLoadObject
    End Sub

    Private Sub DeletedTrees()
        treeView1.SelectedNode = GetNode("I/O Devices", treeView1.Nodes(0).Nodes)
        treeView1.Select()
        treeView1.SelectedNode.Remove()
        treeView1.Nodes(0).Nodes.Add("I/O Devices")
        treeView1.Sort()
        treeView1.ExpandAll()
    End Sub

    Private Sub clearComm()
        ReDim dbComNVtl(512)
        ReDim dbComVtl(512)

        For i As Integer = 0 To 511
            lvFromLCP.Items(0).SubItems(1).Text = ""
            lvToLCP.Items(0).SubItems(1).Text = ""
            Debug.Print(i + 1 & dbComVtl(i) & " - " & dbComNVtl(i))
        Next
    End Sub

#Region "       Menu Strip"
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        'Dim result As DialogResult = MessageBox.Show("Are you sure want to make a new project...!!!", "Warning...!!!", MessageBoxButtons.YesNo)
        'If result = Windows.Forms.DialogResult.Yes Then

        'End If
        Try
            If UBound(AnyObj) > 0 Or UBound(dbHDW) > 0 Then
                ReDim DataHdw(0)
                ReDim dbCoupler(0)
                Me.Text = "LenDPS"
                DeleteAllComponent()
                DeletedTrees()
                clearComm()
                pathLocation = ""
                ProjectFile = ""
                Editor.Text = stringCode
            End If
            'If UBound(dbHDW) > 0 Then
            '    ReDim dbHDW(0)
            '    ReDim dbCoupler(0)
            '    DeletedTrees()
            '    clearComm()
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Dim ProjectFile As String

    '----------------- Save Project ----------------------
    Private Sub SaveProject(ByVal path As String)
        Dim sFile As String
        Dim wStream As FileStream
        Try
            sFile = path
            wStream = New FileStream(sFile, FileMode.Create)
            Dim wBin As New BinaryWriter(wStream)
            wBin.Write(sFile)
            wBin.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveDbCommunication(ByVal path As String)
        Dim sw As StreamWriter
        Dim data As String
        sw = File.CreateText(path)

        For i As Integer = 0 To 511
            If dbComVtl(i) <> String.Empty Or dbComNVtl(i) <> String.Empty Then
                data = i + 1 & "," & dbComVtl(i) & "," & dbComNVtl(i)
                sw.WriteLine(data)
            End If
        Next
        sw.Flush()
        sw.Close()
    End Sub

    Public Sub SaveIOconfiguration(ByVal path As String)
        Dim sw As StreamWriter
        Dim data As String
        sw = File.CreateText(path)

        If frmAssignIO.DataGridView1.RowCount > 0 Then
            For i As Integer = 0 To frmAssignIO.DataGridView1.RowCount - 1
                data = frmAssignIO.DataGridView1.Rows(i).Cells(0).Value & ","
                If data <> "" Then
                    For j As Integer = 1 To 3
                        data &= frmAssignIO.DataGridView1.Rows(i).Cells(j).Value & ","
                    Next
                    sw.WriteLine(data)
                Else
                    sw.WriteLine(data)
                End If
            Next

        End If
        sw.Flush()
        sw.Close()
    End Sub

    Private Sub saveEquationFile(ByVal path As String, ByVal data As String)
        Dim sw As StreamWriter

        sw = File.CreateText(path)
        sw.WriteLine(data)
        sw.Flush()
        sw.Close()
    End Sub

    Private Sub SaveComSetting(ByVal path As String)
        Dim sw As StreamWriter

        sw = File.CreateText(path)
        sw.WriteLine(setUdp.Ip)
        sw.WriteLine(setUdp.Port)
        sw.WriteLine(setUdp.LocalPort)
        sw.Flush()
        sw.Close()
    End Sub

    Private Sub SaveProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectToolStripMenuItem.Click
        If ProjectFile = "" Then
            SaveProjectAsToolStripMenuItem_Click(sender, e)
        Else
            Try
                If File.Exists(ProjectFile) Then
                    Save_Layout_Station_File(Mid(ProjectFile, 1, Len(ProjectFile) - 4) & ".csv")
                    saveEquationFile(Mid(ProjectFile, 1, Len(ProjectFile) - 4) & ".vtl", Editor.Text)
                    SaveIOconfiguration(Mid(ProjectFile, 1, Len(ProjectFile) - 4) & ".hdw")
                    SaveHdwConfiguration(Mid(ProjectFile, 1, Len(ProjectFile) - 4) & ".conf")
                    SaveDbCommunication(Mid(ProjectFile, 1, Len(ProjectFile) - 4) & ".com")
                    SaveComSetting(Mid(ProjectFile, 1, Len(ProjectFile) - 4) & ".comm")
                    SavePreferensi(GridSpacing)
                    pathLocation = ProjectFile
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub SaveProjectAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectAsToolStripMenuItem.Click
        Dim fileSave As New SaveFileDialog
        Dim staFile As String
        Dim dFile As String

        With fileSave
            .Filter = "pro File (*.pro)|*.pro|All files (*.*)|*.*"
            '.InitialDirectory = App_Path()
        End With

        If fileSave.ShowDialog = Windows.Forms.DialogResult.OK Then
            staFile = fileSave.FileName
            pathLocation = fileSave.FileName
            Me.Text = "LenDPS - " + staFile
            SaveProject(staFile)
            dFile = Mid(staFile, 1, Len(staFile) - 4)
            Save_Layout_Station_File(dFile & ".csv")
            saveEquationFile(dFile & ".vtl", Editor.Text)
            SaveIOconfiguration(dFile & ".hdw")
            SaveHdwConfiguration(dFile & ".conf")
            SaveDbCommunication(dFile & ".com") 'vc1
            SaveComSetting(dFile & ".comm")
            SavePreferensi(GridSpacing)
        End If
        ProjectFile = fileSave.FileName
    End Sub

    '----------------- Open Project ----------------------
    Private Function LoadProject(ByVal source As String) As String
        Dim sFile As String
        Dim rStream As FileStream
        Dim data As String

        sFile = source
        rStream = New FileStream(sFile, FileMode.Open)
        Dim rBin As New BinaryReader(rStream)

        data = rBin.ReadString
        rStream.Close()
        LoadProject = data

    End Function

    Private Sub openUdpSetting(ByVal path As String)
        If File.Exists(path) Then
            Try
                Using sr As StreamReader = New StreamReader(path)
                    Dim readLine As String
                    Dim Data(0) As String
                    Dim i As Integer

                    i = 0
                    Do
                        readLine = sr.ReadLine
                        Data(i) = readLine

                        i += 1
                        ReDim Preserve Data(i)
                    Loop Until readLine Is Nothing
                    sr.Close()
                    setUdp.Ip = Data(0)
                    setUdp.Port = Data(1)
                    setUdp.LocalPort = Data(2)
                End Using
            Catch ex As Exception

            End Try
        Else
            Exit Sub
        End If
    End Sub
    Private Sub OpenDbCommunication(ByVal path As String)
        If File.Exists(path) Then
            Try
                Using sr As StreamReader = New StreamReader(path)
                    Dim readLine As String
                    Dim Data(0) As String
                    Dim i, j, k As Integer

                    i = 0
                    j = 0
                    k = 0
                    Do
                        readLine = sr.ReadLine
                        Data(i) = readLine
                        Dim value() As String = Split(Data(i), ",")
                        Dim isiParsing(2) As String
                        Dim x As Integer = 0
                        For Each s As String In value
                            isiParsing(x) = s
                            x += 1
                        Next

                        'sorting 
                        If isiParsing(1) <> "" Then dbComVtl(j) = isiParsing(1) : lvToLCP.Items(j).SubItems(1).Text = isiParsing(1) : j += 1
                        If isiParsing(2) <> "" Then dbComNVtl(k) = isiParsing(2) : lvFromLCP.Items(k).SubItems(1).Text = isiParsing(2) : k += 1
                        i += 1
                        ReDim Preserve Data(i)
                    Loop Until readLine Is Nothing
                    sr.Close()
                End Using
            Catch ex As Exception

            End Try
        Else
            Exit Sub
        End If
    End Sub

    Public Sub OpenIOconfiguration(ByVal source As String)
        If File.Exists(source) Then
            Try
                Using sr As StreamReader = New StreamReader(source)
                    Dim hdwFile As String
                    Dim Data(0) As String
                    Dim i As Integer = 0

                    ReDim DataHdw(0)
                    i = 0
                    Do
                        hdwFile = sr.ReadLine
                        Data(i) = hdwFile
                        Dim value() As String = Split(Data(i), ",")
                        Dim IsiParsing(4) As String
                        Dim j As Integer

                        j = 0
                        For Each s As String In value
                            IsiParsing(j) = s
                            j += 1
                        Next

                        If IsiParsing(0) <> "" Then
                            DataHdw(i).Name = IsiParsing(0)
                            DataHdw(i).Type = IsiParsing(1)
                            DataHdw(i).Port = IsiParsing(2)
                            DataHdw(i).Bit = IsiParsing(3)

                            i += 1
                            ReDim Preserve Data(i)
                            ReDim Preserve DataHdw(i)
                        End If
                    Loop Until hdwFile Is Nothing
                    sr.Close()
                End Using
            Catch
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub OpenEquationFile(ByVal path As String)
        If File.Exists(path) Then
            Try
                Using sr As StreamReader = New StreamReader(path)
                    Dim EquSource As String = sr.ReadToEnd
                    Editor.Text = EquSource
                    sr.Close()
                End Using
            Catch
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Sub OpenProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim ObjOpenFileDialog As New OpenFileDialog
        Dim proFile As String

        With ObjOpenFileDialog
            .Filter = "pro File (*.pro)|*.pro|All files (*.*)|*.*"
        End With

        If ObjOpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            NewToolStripMenuItem_Click(sender, e)
            ReDim DataHdw(0)
            ReDim dbHDW(0)
            proFile = ObjOpenFileDialog.FileName
            pathLocation = ObjOpenFileDialog.FileName
            Me.Text = "LenDPS - " + proFile
            Open_Layout_Station_File(Mid(proFile, 1, Len(proFile) - 4) & ".csv")
            OpenEquationFile(Mid(proFile, 1, Len(proFile) - 4) & ".vtl")
            OpenIOconfiguration(Mid(proFile, 1, Len(proFile) - 4) & ".hdw")
            OpenHdwConfiguration(Mid(proFile, 1, Len(proFile) - 4) & ".conf")
            OpenDbCommunication(Mid(proFile, 1, Len(proFile) - 4) & ".com")
            openUdpSetting(Mid(proFile, 1, Len(proFile) - 4) & ".comm")
            ProjectFile = (LoadProject(proFile))
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
#End Region

#Region "       Tool Strip"
    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        NewToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        OpenProjectToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        SaveProjectAsToolStripMenuItem_Click(sender, e)
    End Sub
#End Region


    Private Sub AboutDPSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutDPSToolStripMenuItem.Click
        Dim f As New frmAbout

        f.ShowDialog()
    End Sub

    Private Sub RunToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunToolStripButton.Click
        Dim f As New frmRunTime

        BuildToolStripMenuItem1_Click(sender, e)
        If IdxError = 0 Then f.Show()  'f.ShowDialog()
    End Sub

    Private Sub RunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunToolStripMenuItem.Click
        RunToolStripButton_Click(sender, e)
    End Sub

#Region "       Context Menu Strip Boolean Text Editor"
    Private Sub CutToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem2.Click
        Editor.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem2.Click
        Editor.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem2.Click
        Editor.Paste()
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
        Editor.ClearSelected()
    End Sub

    Private Sub DsfdfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DsfdfToolStripMenuItem.Click
        Editor.Undo()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Editor.SelectAll()
    End Sub
#End Region

#Region "       Modul Compiler"
    Dim GreenStyle As Style = New TextStyle(Brushes.Green, Nothing, FontStyle.Regular)
    Dim BlueStyle As Style = New TextStyle(Brushes.Blue, Nothing, FontStyle.Bold)
    Dim RedStyle As Style = New TextStyle(Brushes.Red, Nothing, FontStyle.Regular)

    Private Sub Editor_TextChanged(ByVal sender As Object, ByVal e As FastColoredTextBoxNS.TextChangedEventArgs) Handles Editor.TextChanged

        e.ChangedRange.ClearStyle(BlueStyle, GreenStyle, RedStyle)

        '-> *<commet>
        Dim comment As Regex = New Regex("(^\*.*)", RegexOptions.Multiline Or RegexOptions.Compiled)
        '-> <keyword>
        Dim keyword As Regex = New Regex("\b(BOOL|GOTO|IF|ELSE|FALSE|TRUE|TIME|DELAY|SECONDS|MINUTES|APPLICATION)\b", RegexOptions.Compiled)
        '-> <huruf kecil>
        Dim e_word As Regex = New Regex("[a-z]+", RegexOptions.Compiled)

        Dim def_word As Regex = New Regex("\b(BOOLEAN|TIMER|VITAL|INPUT|OUTPUT|NONVITAL|COMMUNICATION|PARAMETER|EQUATION|SECTION|END)\b", RegexOptions.Compiled)
        ' set style
        e.ChangedRange.SetStyle(RedStyle, e_word)
        e.ChangedRange.SetStyle(GreenStyle, comment)
        e.ChangedRange.SetStyle(BlueStyle, keyword)
        e.ChangedRange.SetStyle(BlueStyle, def_word)

    End Sub

    Private Sub Editor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Editor.Click
        Editor.CurrentLineColor = Color.White
    End Sub

    Private Sub lbError_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbError.SelectedIndexChanged
        Dim lineError As String

        If lbError.SelectedItem = "" Then
        Else
            lineError = Microsoft.VisualBasic.Right(lbError.SelectedItem, Len(lbError.SelectedItem) - InStrRev(lbError.SelectedItem, " "))
            Try
                Editor.Focus()
                Editor.Navigate(Val(lineError) - 1)
                Editor.CurrentLineColor = Color.Blue
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub CompileWindowEditor()
        Dim erCount As Integer = 0
        For i As Integer = 1 To UBound(ObjRec)
            If ObjRec(i).TagTx1 <> "" Then
                For j As Integer = 0 To IdxParam - 1 Step 1
                    If ObjRec(i).TagTx1 = Parameter(j).Name Then erCount += 1 : Exit For
                Next j
                If erCount = 0 Then error_add("Error on Layout Editor : Variable ' " & ObjRec(i).TagTx1 & " ' is not Declared --> " & ObjRec(i).Text)
                If erCount >= 1 Then erCount = 0
            End If

            If ObjRec(i).TagTx2 <> "" Then
                For j As Integer = 0 To IdxParam - 1 Step 1
                    If ObjRec(i).TagTx2 = Parameter(j).Name Then erCount += 1 : Exit For
                Next j
                If erCount = 0 Then error_add("Error on Layout Editor : Variable ' " & ObjRec(i).TagTx2 & " ' is not Declared --> " & ObjRec(i).Text)
                If erCount >= 1 Then erCount = 0
            End If

            If ObjRec(i).TagTx3 <> "" Then
                For j As Integer = 0 To IdxParam - 1 Step 1
                    If ObjRec(i).TagTx3 = Parameter(j).Name Then erCount += 1 : Exit For
                Next j
                If erCount = 0 Then error_add("Error on Layout Editor : Variable ' " & ObjRec(i).TagTx3 & " ' is not Declared --> " & ObjRec(i).Text)
                If erCount >= 1 Then erCount = 0
            End If

            If ObjRec(i).TagTx4 <> "" Then
                For j As Integer = 0 To IdxParam - 1 Step 1
                    If ObjRec(i).TagTx4 = Parameter(j).Name Then erCount += 1 : Exit For
                Next j
                If erCount = 0 Then error_add("Error on Layout Editor : Variable ' " & ObjRec(i).TagTx4 & " ' is not Declared --> " & ObjRec(i).Text)
                If erCount >= 1 Then erCount = 0
            End If

            ' Input
            If ObjRec(i).TagTx <> "" Then
                For j As Integer = 0 To IdxParam - 1 Step 1
                    If ObjRec(i).TagTx = Parameter(j).Name Then erCount += 1 : Parameter(j).value = ObjRec(i).TagIdVal : Exit For
                Next j
                If erCount = 0 Then error_add("Error on Layout Editor : Variable ' " & ObjRec(i).TagTx & " ' is not Declared --> " & ObjRec(i).Text)
                If erCount >= 1 Then erCount = 0
            End If
        Next i
    End Sub

#End Region

    Private Sub CodeCompiled()
        Me.Cursor = Cursors.WaitCursor
        Dim pathBERC As String = ""
        Dim pathTERC As String = ""
        Dim pathAppFile As String = ""
        Dim pathHdwFile As String = ""
        Dim pathLinkFile As String = ""
        Dim amountOfCoupler As Integer = 0

        If pathLocation = "" Then
            MessageBox.Show("Save it first...!!!!!!")
        Else
            Dim startAdr As Integer = 10
            Dim index As Integer = 15
            Dim idxCount As Integer = 0
            Dim sFormat As String = ""
            Dim sLink As String = ""
            Dim adrList As New ArrayList
            Dim couplerList As New ArrayList

            ReDim dbIO(index)
            couplerList.Add(0)
            For i As Integer = 0 To UBound(dbCoupler) - 1
                If dbCoupler(i).status = slotStatus.boooked Then
                    couplerList.Add(dbCoupler(i).address)
                    couplerList.Sort()
                End If
            Next

            For i As Integer = 0 To couplerList.Count - 1
                For j As Integer = 0 To UBound(dbHDW) - 1
                    If couplerList(i) = dbHDW(j).coupler And dbHDW(j).status = slotStatus.boooked Then
                        adrList.Add(dbHDW(j).address)
                        adrList.Sort()
                    End If
                Next
                If adrList.Count > 0 Then
                    sFormat &= "[" & String.Format("{0:00}", CInt(couplerList(i))) & "]"
                    'sLink &= adrList.Count.ToString
                    sLink &= String.Format("{0:00}", adrList.Count)
                    amountOfCoupler += 1
                    For j As Integer = 0 To adrList.Count - 1
                        For k As Integer = 0 To UBound(dbHDW) - 1
                            If couplerList(i) = dbHDW(k).coupler And adrList(j) = dbHDW(k).address And dbHDW(k).status = slotStatus.boooked Then
                                If dbHDW(k).InOut = 1 Then
                                    sFormat &= "I" & String.Format("{0:00}", CInt(dbHDW(k).address))
                                    sLink &= "I" & String.Format("{0:0000}", startAdr)
                                ElseIf dbHDW(k).InOut = 2 Then
                                    sFormat &= "O" & String.Format("{0:00}", CInt(dbHDW(k).address))
                                    sLink &= "O" & String.Format("{0:0000}", startAdr)
                                End If

                                '
                                dbIO(idxCount + 0).name = dbHDW(k).bit0
                                dbIO(idxCount + 1).name = dbHDW(k).bit1
                                dbIO(idxCount + 2).name = dbHDW(k).bit2
                                dbIO(idxCount + 3).name = dbHDW(k).bit3
                                dbIO(idxCount + 4).name = dbHDW(k).bit4
                                dbIO(idxCount + 5).name = dbHDW(k).bit5
                                dbIO(idxCount + 6).name = dbHDW(k).bit6
                                dbIO(idxCount + 7).name = dbHDW(k).bit7
                                dbIO(idxCount + 8).name = dbHDW(k).bit8
                                dbIO(idxCount + 9).name = dbHDW(k).bit9
                                dbIO(idxCount + 10).name = dbHDW(k).bit10
                                dbIO(idxCount + 11).name = dbHDW(k).bit11
                                dbIO(idxCount + 12).name = dbHDW(k).bit12
                                dbIO(idxCount + 13).name = dbHDW(k).bit13
                                dbIO(idxCount + 14).name = dbHDW(k).bit14
                                dbIO(idxCount + 15).name = dbHDW(k).bit15

                                startAdr += 16
                                idxCount += 16
                                index += 16
                                ReDim Preserve dbIO(index)
                            End If
                        Next
                    Next
                End If
                adrList = New ArrayList
            Next
            'Debug.Print(sFormat & " -> " & UBound(dbIO))
            'Debug.Print(sLink & " <<<")
            'Debug.Print(amountOfCoupler & "  <<< jumlah sVCM")

            Scanner = New LexicalAnalysis(Editor.Text)
            Syntax = New SyntaxAnalysis
            CodeGen = New CodeGenerator

            pathBERC = findPath(pathLocation) & "BERC"
            pathTERC = findPath(pathLocation) & "TERC"
            pathAppFile = Mid(pathLocation, 1, Len(pathLocation) - 3) & "app"
            pathHdwFile = Mid(pathLocation, 1, Len(pathLocation) - 3) & "hdw"
            pathLinkFile = Mid(pathLocation, 1, Len(pathLocation) - 3) & "lnk"


            If IdxError = 0 Then
                If File.Exists(pathBERC) Then File.Delete(pathBERC)
                If File.Exists(pathTERC) Then File.Delete(pathTERC)
                If File.Exists(pathBERC & ".bin") Then File.Delete(pathBERC & ".bin")
                If File.Exists(pathTERC & ".bin") Then File.Delete(pathTERC & ".bin")

                CodeGen.DataBounded()
                CodeGen.ModularIO(sFormat) 'just in here

                For i As ULong = 0 To UBound(dbEquation) - 1
                    CodeGen.ParseEquation(dbEquation(i).Result, dbEquation(i).Expression, dbEquation(i).Type, pathBERC, pathTERC)
                Next
                bCompiled = False

                CodeGen.ReadAndCreateHex_BERC(pathBERC)
                CodeGen.ReadAndCreateHex_TERC(pathTERC)
                CodeGen.WriteBinFile(pathAppFile, pathBERC & ".bin", pathTERC & ".bin")
                CodeGen.Create_Link_HDW(pathLinkFile, sLink)
                CodeGen.Create_Modular_Hdw(amountOfCoupler, pathHdwFile, pathLinkFile, pathAppFile, pathTERC & ".bin")
                'CodeGen.CreateHdw(pathHdwFile, pathAppFile, pathTERC & ".bin")
            Else
                TabPageError.Text = "(" & IdxError & ") Errors"
                Me.lbError.Items.Clear()
                For i As Integer = 0 To IdxError - 1 Step 1
                    Me.lbError.Items.Add(Error_List(i))
                Next
            End If

        End If






        'If pathLocation = "" Then
        '    MessageBox.Show("Save it first...!!!!!!")
        'Else
        '    Scanner = New LexicalAnalysis(Editor.Text)
        '    Syntax = New SyntaxAnalysis
        '    CodeGen = New CodeGenerator

        '    pathBERC = findPath(pathLocation) & "BERC"
        '    pathTERC = findPath(pathLocation) & "TERC"
        '    pathAppFile = Mid(pathLocation, 1, Len(pathLocation) - 3) & "app"
        '    pathHdwFile = Mid(pathLocation, 1, Len(pathLocation) - 3) & "hdw"

        '    If IdxError = 0 Then
        '        'If File.Exists(pathBERC) Then File.Delete(pathBERC)
        '        'If File.Exists(pathTERC) Then File.Delete(pathTERC)
        '        'If File.Exists(pathBERC & ".bin") Then File.Delete(pathBERC & ".bin")
        '        'If File.Exists(pathTERC & ".bin") Then File.Delete(pathTERC & ".bin")

        '        CodeGen.DataBounded()
        '        CodeGen.GenerateVariable() 'just in here

        '        'For i As Integer = 0 To UBound(dbEquation) - 1
        '        '    CodeGen.ParseEquation(dbEquation(i).Result, dbEquation(i).Expression, dbEquation(i).Type, pathBERC, pathTERC)
        '        'Next
        '        'bCompiled = False

        '        'CodeGen.ReadAndCreateHex_BERC(pathBERC)
        '        'CodeGen.ReadAndCreateHex_TERC(pathTERC)
        '        'CodeGen.WriteBinFile(pathAppFile, pathBERC & ".bin", pathTERC & ".bin")
        '        'CodeGen.CreateHdw(pathHdwFile, pathAppFile, pathTERC & ".bin")

        '    Else
        '        TabPageError.Text = "(" & IdxError & ") Errors"
        '        Me.lbError.Items.Clear()
        '        For i As Integer = 0 To IdxError - 1 Step 1
        '            Me.lbError.Items.Add(Error_List(i))
        '        Next
        '    End If
        'End If
        Me.Cursor = Cursors.Default
    End Sub '

    Private Sub MarkLinkStatusParameter()
        For i As Integer = 0 To UBound(Parameter) - 1
            For j As Integer = 0 To UBound(dbHDW) - 1
                Select Case Parameter(i).Name
                    Case dbHDW(j).bit0
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit1
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit2
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit3
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit4
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit5
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit6
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit7
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit8
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit9
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit10
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit11
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit12
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit13
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit14
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                    Case dbHDW(j).bit15
                        Parameter(i).linkStatus = "InUsed"
                        Exit For
                End Select
            Next
        Next
        'Debug.Print(UBound(dbHDW) & " >>>")
    End Sub

    Private Sub BuildToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuildToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor
        Scanner = New LexicalAnalysis(Editor.Text)
        Syntax = New SyntaxAnalysis
        MarkLinkStatusParameter()
        CompileWindowEditor()

        TabPageError.Text = "(" & IdxError & ") Errors"
        Me.lbError.Items.Clear()
        For i As Integer = 0 To IdxError - 1 Step 1
            Me.lbError.Items.Add(Error_List(i))
        Next
        If IdxError = 0 Then
            SaveProjectToolStripMenuItem_Click(sender, e)
        End If
        Me.Cursor = Cursors.Default
        findLine()
    End Sub

    Private Sub MakeHexFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeHexFileToolStripMenuItem.Click
        bCompiled = True
        If bCompiled Then
            CodeCompiled()
        End If
    End Sub

    Private Sub IOConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IOConfigurationToolStripMenuItem.Click
        frmAssignIO.ShowDialog()
    End Sub

#Region "   Route Table"
    Dim row_index As Integer = 0
    Dim row_pos As Integer
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            DataGridView1.Rows.Add()
            DataGridView1.Rows(row_index).Cells(1).Value = "Normal (N)"
            row_index += 1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If row_pos >= 0 And DataGridView1.RowCount > 0 Then
                DataGridView1.Rows.RemoveAt(row_pos)
                row_index -= 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Try
            DataGridView1.Rows.Insert(row_pos, 1)
            DataGridView1.Rows(row_pos).Cells(1).Value = "Normal (N)"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        row_pos = e.RowIndex
    End Sub
#End Region

#Region "Modular HDW"

    Private Sub fill_dbHDW(ByVal adr As Integer, ByVal index As Integer, ByVal value As String)
        Select Case index
            Case 0 : dbHDW(adr).bit0 = value
            Case 1 : dbHDW(adr).bit1 = value
            Case 2 : dbHDW(adr).bit2 = value
            Case 3 : dbHDW(adr).bit3 = value
            Case 4 : dbHDW(adr).bit4 = value
            Case 5 : dbHDW(adr).bit5 = value
            Case 6 : dbHDW(adr).bit6 = value
            Case 7 : dbHDW(adr).bit7 = value
            Case 8 : dbHDW(adr).bit8 = value
            Case 9 : dbHDW(adr).bit9 = value
            Case 10 : dbHDW(adr).bit10 = value
            Case 11 : dbHDW(adr).bit11 = value
            Case 12 : dbHDW(adr).bit12 = value
            Case 13 : dbHDW(adr).bit13 = value
            Case 14 : dbHDW(adr).bit14 = value
            Case 15 : dbHDW(adr).bit15 = value
        End Select
    End Sub

    Private Sub LinkTo(ByVal type As String)
        Dim adrCard As Integer
        Dim adrCoupler As Integer
        If txtGroups.Text.Contains("sVCM") Then
            adrCoupler = CInt(Mid(txtGroups.Text, 2, 3))
        Else
            adrCoupler = 0
        End If

        If txtName.Text.Contains("VIM") Then
            Me.GetStatusIO = "Input"
        ElseIf txtName.Text.Contains("VOM") Then
            Me.GetStatusIO = "Output"
        Else
            Me.GetStatusIO = Nothing
        End If

        Select Case type
            Case "Add Link"
                Dim frm As New frmVarContent
                frm.ShowDialog()

                adrCard = CInt(Mid(txtAddress.Text, 2, 2))

                Dim bufVar As String = ListView1.SelectedItems.Item(0).SubItems(3).Text
                If bufVar = String.Empty Then
                    For i As Integer = 0 To UBound(Parameter) - 1
                        If Parameter(i).Name = frm.GetVariable Then
                            Parameter(i).linkStatus = "InUsed"
                            Exit For
                        End If
                    Next
                Else
                    Dim Count As Integer = 0
                    For i As Integer = 0 To UBound(Parameter) - 1
                        If Parameter(i).Name = bufVar And Parameter(i).linkStatus <> String.Empty Then
                            Parameter(i).linkStatus = String.Empty
                            Count += 1
                        ElseIf Parameter(i).Name = frm.GetVariable And Parameter(i).linkStatus = String.Empty Then
                            Parameter(i).linkStatus = "InUsed"
                            Count += 1
                        End If
                        If Count = 2 Then Exit For
                    Next
                End If

                Dim idx As Integer = ListView1.SelectedItems.Item(0).Index
                If frm.GetVariable <> String.Empty Then
                    ListView1.SelectedItems.Item(0).SubItems(3).Text = frm.GetVariable
                    For i As Integer = 0 To UBound(dbHDW) - 1
                        If dbHDW(i).coupler = adrCoupler Then
                            If dbHDW(i).address = adrCard And dbHDW(i).status = slotStatus.boooked Then
                                fill_dbHDW(i, idx, frm.GetVariable)
                                Exit For
                            End If
                        End If
                    Next
                End If

            Case "Delete Link"
                Dim idx As Integer = ListView1.SelectedItems.Item(0).Index
                Dim bufVar As String = ListView1.SelectedItems.Item(0).SubItems(3).Text
                ListView1.SelectedItems.Item(0).SubItems(3).Text = ""

                adrCard = CInt(Mid(txtAddress.Text, 2, 2))

                For i As Integer = 0 To UBound(dbHDW) - 1
                    If dbHDW(i).coupler = adrCoupler Then
                        If dbHDW(i).address = adrCard And dbHDW(i).status = slotStatus.boooked Then
                            fill_dbHDW(i, idx, "")
                            Exit For
                        End If
                    End If
                Next

                For i As Integer = 0 To UBound(Parameter) - 1
                    If Parameter(i).Name = bufVar And Parameter(i).linkStatus <> String.Empty Then
                        Parameter(i).linkStatus = String.Empty
                        Exit For
                    End If
                Next

            Case "Delete All"
                Dim result As DialogResult = MessageBox.Show("Are you sure want to delete all links variable...!!!", "Warning...!!!", MessageBoxButtons.YesNo)

                adrCard = CInt(Mid(txtAddress.Text, 2, 2))

                If result = Windows.Forms.DialogResult.Yes Then
                    For i As Integer = 0 To UBound(dbHDW) - 1
                        If dbHDW(i).coupler = adrCoupler Then
                            If dbHDW(i).address = adrCard And dbHDW(i).status = slotStatus.boooked Then
                                For j As Integer = 0 To 15
                                    For k As Integer = 0 To UBound(Parameter) - 1
                                        If ListView1.Items(j).SubItems(3).Text = Parameter(k).Name Then
                                            Parameter(k).linkStatus = String.Empty
                                            Exit For
                                        End If
                                    Next
                                    ListView1.Items(j).SubItems(3).Text = ""
                                    fill_dbHDW(i, j, "")
                                Next
                                Exit For
                            End If
                        End If
                    Next
                End If

            Case "ComLinkToLCP"
                Dim frm As New frmVarContent
                frm.ShowDialog()

                Dim idx As Integer = lvToLCP.SelectedItems.Item(0).Index

                If frm.GetVariable <> String.Empty Then
                    lvToLCP.SelectedItems.Item(0).SubItems(1).Text = frm.GetVariable
                    dbComVtl(idx) = frm.GetVariable
                End If

            Case "ComLinkFromLCP"
                Dim frm As New frmVarContent
                frm.ShowDialog()

                Dim idx As Integer = lvFromLCP.SelectedItems.Item(0).Index

                If frm.GetVariable <> String.Empty Then
                    lvFromLCP.SelectedItems.Item(0).SubItems(1).Text = frm.GetVariable
                    dbComNVtl(idx) = frm.GetVariable
                End If

            Case "Delete Com Vital"
                Dim idx As Integer = lvToLCP.SelectedItems.Item(0).Index
                lvToLCP.SelectedItems.Item(0).SubItems(1).Text = ""
                dbComVtl(idx) = ""

            Case "Delete All Com Vital"
                Dim result As DialogResult = MessageBox.Show("Are you sure want to delete all links Comm variable...!!!", "Warning...!!!", MessageBoxButtons.YesNo)

                If result = Windows.Forms.DialogResult.Yes Then
                    For i As Integer = 0 To 511
                        lvToLCP.Items(i).SubItems(1).Text = ""
                        dbComVtl(i) = ""
                    Next
                End If

            Case "Delete Com Non Vital"
                Dim idx As Integer = lvFromLCP.SelectedItems.Item(0).Index
                lvFromLCP.SelectedItems.Item(0).SubItems(1).Text = ""
                dbComNVtl(idx) = ""

            Case "Delete All Com Non Vital"
                Dim result As DialogResult = MessageBox.Show("Are you sure want to delete all links Comm variable...!!!", "Warning...!!!", MessageBoxButtons.YesNo)

                If result = Windows.Forms.DialogResult.Yes Then
                    For i As Integer = 0 To 511
                        lvFromLCP.Items(i).SubItems(1).Text = ""
                        dbComNVtl(i) = ""
                    Next
                End If
        End Select
    End Sub


    Private Sub DeleteAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAllToolStripMenuItem.Click
        LinkTo("Delete All")
    End Sub

    Private Sub DeleteLinkVariableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteLinkVariableToolStripMenuItem.Click
        LinkTo("Delete Link")
    End Sub

    Private Sub LinkToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkToToolStripMenuItem.Click
        LinkTo("Add Link")
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        If e.Button = MouseButtons.Right Then
            ListView1.ContextMenuStrip = cmsLink
            Dim bufVar As String = ListView1.SelectedItems.Item(0).SubItems(3).Text
            If bufVar = String.Empty Then
                LinkToToolStripMenuItem.Enabled = True
                DeleteLinkVariableToolStripMenuItem.Enabled = False
            Else
                LinkToToolStripMenuItem.Enabled = False
                DeleteLinkVariableToolStripMenuItem.Enabled = True
            End If
        End If
    End Sub


    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        'LinkTo("Add Link")
    End Sub

    Dim bufDataEachAddress(17) As String
    Private Sub getDataEachAddress(ByVal adrCoupler As Integer, ByVal adrCard As Integer)
        For i As Integer = 0 To UBound(dbHDW) - 1
            If adrCoupler = dbHDW(i).coupler And adrCard = dbHDW(i).address And dbHDW(i).status = slotStatus.boooked Then
                bufDataEachAddress(0) = dbHDW(i).coupler
                bufDataEachAddress(1) = dbHDW(i).address
                bufDataEachAddress(2) = dbHDW(i).bit0
                bufDataEachAddress(3) = dbHDW(i).bit1
                bufDataEachAddress(4) = dbHDW(i).bit2
                bufDataEachAddress(5) = dbHDW(i).bit3
                bufDataEachAddress(6) = dbHDW(i).bit4
                bufDataEachAddress(7) = dbHDW(i).bit5
                bufDataEachAddress(8) = dbHDW(i).bit6
                bufDataEachAddress(9) = dbHDW(i).bit7
                bufDataEachAddress(10) = dbHDW(i).bit8
                bufDataEachAddress(11) = dbHDW(i).bit9
                bufDataEachAddress(12) = dbHDW(i).bit10
                bufDataEachAddress(13) = dbHDW(i).bit11
                bufDataEachAddress(14) = dbHDW(i).bit12
                bufDataEachAddress(15) = dbHDW(i).bit13
                bufDataEachAddress(16) = dbHDW(i).bit14
                bufDataEachAddress(17) = dbHDW(i).bit15
                Exit For
            End If
        Next
    End Sub

    Private Sub Update_Devices(ByVal device As String, ByVal parent As String)
        Dim group As String
        Dim adrCard, adrCoupler As Integer
        txtName.Text = Mid(device, 6, device.Length - 5)
        If parent.Contains("sVCM") Then
            If device.Contains("VIM") Then
                txtType.Text = "Bool"
                txtGroups.Text = parent
                group = "Input"
                txtAddress.Text = Mid(device, 1, 4)
                adrCoupler = CInt(Mid(txtGroups.Text, 2, 3))
                adrCard = CInt(Mid(txtAddress.Text, 2, 2))
                getDataEachAddress(adrCoupler, adrCard)
                update_dbIO("Bool", group, adrCoupler, adrCard)

            ElseIf device.Contains("VOM") Then
                txtType.Text = "Bool"
                txtGroups.Text = parent
                group = "Output"
                txtAddress.Text = Mid(device, 1, 4)
                adrCoupler = CInt(Mid(txtGroups.Text, 2, 3))
                adrCard = CInt(Mid(txtAddress.Text, 2, 2))
                getDataEachAddress(adrCoupler, adrCard)
                update_dbIO("Bool", group, adrCoupler, adrCard)
            End If


        Else
            If device.Contains("VIM") Then
                txtType.Text = "Bool"
                txtGroups.Text = "Vital Control Module"
                group = "Input"
                txtAddress.Text = Mid(device, 1, 4)
                adrCoupler = 0
                adrCard = CInt(Mid(txtAddress.Text, 2, 2))
                getDataEachAddress(adrCoupler, adrCard)
                update_dbIO("Bool", group, adrCoupler, adrCard)

            ElseIf device.Contains("VOM") Then
                txtType.Text = "Bool"
                txtGroups.Text = "Vital Control Module"
                group = "Output"
                txtAddress.Text = Mid(device, 1, 4)
                adrCoupler = 0
                adrCard = CInt(Mid(txtAddress.Text, 2, 2))
                getDataEachAddress(adrCoupler, adrCard)
                update_dbIO("Bool", group, adrCoupler, adrCard)

            Else
                txtType.Text = "Coupler"
                txtGroups.Text = "Simplified Vital Control Module"
                group = "Coupler"
                txtAddress.Text = Mid(device, 1, 5)
                update_dbIO("Bool", group, 0, 0)

            End If
        End If
    End Sub

    Private Sub update_dbIO(ByVal type As String, ByVal group As String, ByVal adrCoupler As Integer, ByVal adrCard As Integer)
        If group = "Input" Or group = "Output" Then
            ListView1.View = View.Details
            ListView1.GridLines = True
            ListView1.FullRowSelect = True

            ListView1.Items.Clear()
            Dim str As String() = New String(3) {}
            Dim item As ListViewItem
            bufDataEachAddress(0) = adrCoupler.ToString
            bufDataEachAddress(1) = adrCard.ToString
            For i As Integer = 1 To 16
                str(0) = i
                str(1) = type
                str(2) = group
                str(3) = bufDataEachAddress(i + 1)
                item = New ListViewItem(str)
                ListView1.Items.Add(item)
            Next
        Else
            ListView1.Items.Clear()
        End If

    End Sub

    Private Sub setActivePanel(ByVal active As String)
        Select Case active
            Case "panelDevice"
                panelDevice.Visible = True
                panelDevice.Dock = DockStyle.Fill
                panelCommunication.Visible = False
                panelDevice.Location = New Point(199, 3)
            Case "panelCommunication"
                panelDevice.Visible = False
                panelCommunication.Visible = True
                panelCommunication.Location = New Point(199, 3)
        End Select
    End Sub

    Private Sub treeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles treeView1.NodeMouseClick
        treeView1.BeginUpdate()
        treeView1.SelectedNode = e.Node
        If (e.Node.Level = 1) Then
            If e.Node.Text.Equals("I/O Devices") Then
                setActivePanel("panelDevice")
                GetCouplerAddress = 0
                device_status = deviceStatus.IO
                e.Node.ContextMenuStrip = cmsDevices
                AppendDeviceToolStrip.Enabled = True
                deleteToolStrip.Enabled = False
            ElseIf e.Node.Text.Equals("Communication") Then
                setActivePanel("panelCommunication")
                'e.Node.ContextMenuStrip = cmsMapping
            End If
        ElseIf (e.Node.Level = 2) Then
            Dim txtNode As String = e.Node.Text
            If txtNode.Contains("VIM") Then
                setActivePanel("panelDevice")
                deleteToolStrip.Enabled = True
                device_status = deviceStatus.IO
                e.Node.ContextMenuStrip = cmsDevices
                AppendDeviceToolStrip.Enabled = False
                Update_Devices(e.Node.Text, e.Node.Parent.Text)

            ElseIf txtNode.Contains("VOM") Then
                setActivePanel("panelDevice")
                deleteToolStrip.Enabled = True
                device_status = deviceStatus.IO
                e.Node.ContextMenuStrip = cmsDevices
                AppendDeviceToolStrip.Enabled = False
                Update_Devices(e.Node.Text, e.Node.Parent.Text)

            ElseIf txtNode.Contains("sVCM") Then
                setActivePanel("panelDevice")
                deleteToolStrip.Enabled = True
                device_status = deviceStatus.Coupler
                GetCouplerAddress = CInt(Mid(e.Node.Text, 2, 3))
                e.Node.ContextMenuStrip = cmsDevices
                AppendDeviceToolStrip.Enabled = True
                Update_Devices(e.Node.Text, e.Node.Parent.Text)
            End If

        ElseIf (e.Node.Level = 3) Then
            e.Node.ContextMenuStrip = cmsDevices
            AppendDeviceToolStrip.Enabled = False
            deleteToolStrip.Enabled = True

            Dim txtNode As String = Mid(e.Node.Text, 6, 4)
            deleteToolStrip.Enabled = True
            Select Case txtNode
                Case "VIM "
                    e.Node.ContextMenuStrip = cmsDevices
                    AppendDeviceToolStrip.Enabled = False
                    Update_Devices(e.Node.Text, e.Node.Parent.Text)
                Case "VOM "
                    e.Node.ContextMenuStrip = cmsDevices
                    AppendDeviceToolStrip.Enabled = False
                    Update_Devices(e.Node.Text, e.Node.Parent.Text)
            End Select
        End If
        treeView1.EndUpdate()
    End Sub


    Private Sub AppendDeviceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendDeviceToolStrip.Click
        Dim frm As New frmInsertDevice
        frm.ShowDialog()
        frm.Close()
        Dim nod As New TreeNode
        If frm.NodeName <> String.Empty Then
            nod.Name = frm.NodeName
            nod.Tag = frm.NodeTag
            nod.Text = frm.NodeText

            treeView1.SelectedNode.Nodes.Add(nod)
            treeView1.ExpandAll()
            treeView1.Sort()
            Update_Devices(nod.Text, nod.Parent.Text)
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        treeView1.Sort()
        treeView1.ExpandAll()
    End Sub

    Private Sub deleteToolStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteToolStrip.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure want to delete this device...!!!", "Delete...", MessageBoxButtons.YesNo)
        If result = Windows.Forms.DialogResult.Yes Then
            Select Case device_status
                Case deviceStatus.IO
                    Dim idx As Integer = CInt(Mid(treeView1.SelectedNode.Text, 2, 2))
                    For i As Integer = 0 To UBound(dbHDW) - 1
                        If dbHDW(i).address = idx Then
                            dbHDW(i).status = slotStatus.deleted
                        End If
                    Next
                    treeView1.SelectedNode.Remove()
                    ' delete the content of variale link
                    For i As Integer = 0 To UBound(Parameter) - 1
                        For j As Integer = 0 To UBound(dbHDW) - 1
                            If dbHDW(j).coupler = 0 Then
                                Select Case Parameter(i).Name
                                    Case dbHDW(j).bit0
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit1
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit2
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit3
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit4
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit5
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit6
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit7
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit8
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit9
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit10
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit11
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit12
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit13
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit14
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                    Case dbHDW(j).bit15
                                        Parameter(i).linkStatus = String.Empty
                                        Exit For
                                End Select
                            End If
                        Next
                    Next

                Case deviceStatus.Coupler
                    Dim parent As String = treeView1.SelectedNode.Parent.Text
                    If parent.Contains("sVCM") Then
                        Dim idxCoupler As Integer = CInt(Mid(treeView1.SelectedNode.Parent.Text, 2, 3))
                        Dim idxCard As Integer = CInt(Mid(treeView1.SelectedNode.Text, 2, 2))
                        'delete one card from coupler
                        For i As Integer = 0 To UBound(dbHDW) - 1
                            If dbHDW(i).coupler = idxCoupler Then
                                If dbHDW(i).address = idxCard Then
                                    dbHDW(i).status = slotStatus.deleted
                                End If
                            End If
                        Next

                        For i As Integer = 0 To UBound(dbCoupler) - 1
                            If dbCoupler(i).address = idxCard Then
                                dbCoupler(i).status = slotStatus.deleted
                            End If
                        Next
                    Else
                        'delete all cards from coupler
                        Dim idxCoupler As Integer = CInt(Mid(treeView1.SelectedNode.Text, 2, 3))
                        For i As Integer = 0 To UBound(dbHDW) - 1
                            If dbHDW(i).coupler = idxCoupler Then
                                dbHDW(i).status = slotStatus.deleted
                            End If
                        Next

                        For i As Integer = 0 To UBound(dbCoupler) - 1
                            If dbCoupler(i).address = idxCoupler Then
                                dbCoupler(i).status = slotStatus.deleted
                            End If
                        Next
                    End If

                    treeView1.SelectedNode.Remove()
            End Select

            'update data to the last cursor

            Dim idx_child As Integer = 0
            For Each child As TreeNode In treeView1.Nodes(0).Nodes(1).Nodes
                idx_child += 1
            Next
            If idx_child > 0 Then
                Update_Devices(treeView1.SelectedNode.Text, treeView1.SelectedNode.Parent.Text)
            Else
                'clear informastion I/O device
                txtName.Text = ""
                txtType.Text = ""
                txtGroups.Text = ""
                txtAddress.Text = ""
                ListView1.Items.Clear()
            End If
        End If
    End Sub

    Private Function GetNode(ByVal text As String, ByVal parentCollection As TreeNodeCollection) As TreeNode

        Dim ret As TreeNode
        Dim child As TreeNode

        For Each child In parentCollection 'step through the parentcollection
            If child.Text = text Then
                ret = child
            ElseIf child.GetNodeCount(False) > 0 Then ' if there is child items then call this function recursively
                ret = GetNode(text, child.Nodes)
            End If

            If Not ret Is Nothing Then Exit For 'if something was found, exit out of the for loop

        Next

        Return ret

    End Function

    Private Sub createTreesWhenOpenFile()
        Dim sText As String = ""
        Dim adrCard As Integer
        Dim adrCoupler As Integer

        For i As Integer = 0 To UBound(dbHDW) - 1
            If dbHDW(i).coupler = 0 Then
                Dim nod As New TreeNode
                adrCoupler = dbHDW(i).coupler
                adrCard = dbHDW(i).address
                Select Case dbHDW(i).InOut
                    Case 1 'input
                        sText = "[" & String.Format("{0:00}", adrCard) & "] VIM - 16 Channel"
                    Case 2 'output
                        sText = "[" & String.Format("{0:00}", adrCard) & "] VOM - 16 Channel"
                End Select
                nod.Text = sText
                treeView1.Nodes(0).Nodes(1).Nodes.Add(nod)
            Else
                Dim count As Integer = 0

                adrCoupler = dbHDW(i).coupler
                adrCard = dbHDW(i).address
                If UBound(dbCoupler) = 0 Then
                    Dim nod As New TreeNode
                    dbCoupler(0).address = adrCoupler
                    dbCoupler(0).status = slotStatus.boooked
                    ReDim Preserve dbCoupler(UBound(dbCoupler) + 1)
                    nod.Text = "{" & String.Format("{0:000}", adrCoupler) & "} sVCM"
                    treeView1.Nodes(0).Nodes(1).Nodes.Add(nod)

                Else
                    For j As Integer = 0 To UBound(dbCoupler) - 1
                        If dbCoupler(j).address = adrCoupler Then
                            count += 1
                            Exit For
                        End If
                    Next
                    If count = 0 Then
                        Dim nod As New TreeNode
                        dbCoupler(UBound(dbCoupler)).address = adrCoupler
                        dbCoupler(UBound(dbCoupler)).status = slotStatus.boooked
                        ReDim Preserve dbCoupler(UBound(dbCoupler) + 1)
                        nod.Text = "{" & String.Format("{0:000}", CInt(adrCoupler)) & "} sVCM"
                        nod.Tag = adrCoupler
                        treeView1.Nodes(0).Nodes(1).Nodes.Add(nod)
                    End If

                End If

                Dim childNode As New TreeNode
                treeView1.SelectedNode = GetNode("{" & String.Format("{0:000}", adrCoupler) & "} sVCM", treeView1.Nodes(0).Nodes(1).Nodes)
                treeView1.Select()

                Dim txt As String = ""
                Select Case dbHDW(i).InOut
                    Case 1
                        txt = "[" & String.Format("{0:00}", adrCard) & "] VIM - 16 Channel"

                    Case 2
                        txt = "[" & String.Format("{0:00}", adrCard) & "] VOM - 16 Channel"
                End Select
                childNode.Text = txt
                treeView1.SelectedNode.Nodes.Add(childNode)
            End If
        Next
        treeView1.Sort()
        treeView1.ExpandAll()
    End Sub

#End Region

    Private Sub AddressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddressToolStripMenuItem.Click
        Dim frm As New frmOpcode
        frm.ShowDialog()
    End Sub


#Region "Vital Communication"

    'Dim lvActive As String
    'Private Sub lvFromLCP_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvFromLCP.MouseClick
    '    lvActive = lvFromLCP.Name
    'End Sub

    'Private Sub lvToLCP_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvToLCP.MouseClick
    '    lvActive = lvToLCP.Name
    'End Sub

    'Private Sub lvToLCP_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvToLCP.MouseDoubleClick
    '    LinkTo("ComLinkToLCP")
    'End Sub

    'Private Sub lvFromLCP_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvFromLCP.MouseDoubleClick
    '    LinkTo("ComLinkFromLCP")
    'End Sub

    'Private Sub DeleteVtlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteVtlToolStripMenuItem.Click
    '    LinkTo("Delete Com Vital")
    'End Sub

    'Private Sub DeleteAllVtlToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAllVtlToolStripMenuItem1.Click
    '    LinkTo("Delete All Com Vital")
    'End Sub

    'Private Sub DeleteNvtlToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteNvtlToolStripMenuItem2.Click
    '    LinkTo("Delete Com Non Vital")
    'End Sub

    'Private Sub DeleteAllNvtlToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAllNvtlToolStripMenuItem1.Click
    '    LinkTo("Delete All Com Non Vital")
    'End Sub

    'Private Sub btUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUp.Click

    'End Sub

    'Private Sub btDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDown.Click

    'End Sub

    'Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
    '    Select Case lvActive
    '        Case lvToLCP.Name

    '        Case lvFromLCP.Name


    '    End Select
    'End Sub

    'Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click

    'End Sub

    'Private Sub btInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInsert.Click

    'End Sub
#End Region

#Region "Interlocking Table Generator"
    Private Sub findLine()
        Dim trackPos As New ArrayList
        For i As Integer = 0 To UBound(ObjRec)
            If ObjRec(i).OnVisible = True Then
                If ObjRec(i).Name = "Track" Then
                    Dim yPos As Integer = ObjRec(i).Top
                    If Not trackPos.Contains(yPos) Then
                        trackPos.Add(yPos)
                    End If
                End If
            End If
        Next

        'Debug.Print(trackPos.Count & " = line")
    End Sub

#End Region

    Private Sub SERVERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SERVERToolStripMenuItem.Click
        'Server.ShowDialog()
    End Sub

    Private Sub CLIENTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLIENTToolStripMenuItem.Click
        'Client.ShowDialog()
    End Sub

    Private Sub UDPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UDPToolStripMenuItem.Click
        frmUDP.ShowDialog()
    End Sub
End Class