Imports Railway

Public Class frmOpcode
    Private index As Integer = 1

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        init()
        make_table()
        fill_table()

    End Sub

    Private Sub init()
        For i As Integer = 0 To 9
            cbData.Items.Insert(i, "")
        Next
    End Sub

    Private Sub make_table()
        lvVariable.Items.Clear()
        lvVariable.Columns.Add("No.", 50, HorizontalAlignment.Left)
        lvVariable.Columns.Add("Variable Name", 100, HorizontalAlignment.Left)
        lvVariable.Columns.Add("Address", 100, HorizontalAlignment.Center)
        lvVariable.Columns.Add("Type", 50, HorizontalAlignment.Center)
        lvVariable.Columns.Add("Time (s)", 50, HorizontalAlignment.Center)
        lvVariable.Columns.Add("Temp Timer", 100, HorizontalAlignment.Center)
        lvVariable.Columns.Add("Count Timer", 100, HorizontalAlignment.Center)
        lvVariable.GridLines = True
        lvVariable.View = View.Details
        lvVariable.FullRowSelect = True
    End Sub

    Private Sub fill_table()
        For i As Integer = 0 To UBound(Parameter) - 1
            Dim lst As New ListViewItem

            lst.Text = CStr(i + 1)
            lst.SubItems.Add(Parameter(i).Name)
            lst.SubItems.Add(Parameter(i).OpCode)
            lst.SubItems.Add("BOOL")
            For j As Integer = 0 To IdxTime - 1
                If Parameter(i).Name = TimeList(j).varresult Then
                    lst.SubItems.Add(TimeList(j).overflow.ToString)
                    lst.SubItems.Add(TimeList(j).tempAddress)
                    lst.SubItems.Add(TimeList(j).countAddress)
                    Exit For
                End If
            Next
            lvVariable.Items.Add(lst)
        Next
    End Sub

    Private Sub search_in_table(ByVal data As String, ByVal idx As Integer)
        Dim maxVar As Integer = lvVariable.Items.Count
        Dim valid As Boolean

        If maxVar > 0 Then
            For i As Integer = 0 To maxVar - 1
                Try
                    If data = lvVariable.Items(i).SubItems(idx).Text Then
                        lvVariable.Items(i).Selected = True
                        lvVariable.Focus()
                        lvVariable.EnsureVisible(i)
                        valid = True
                        Exit For
                    End If
                Catch ex As Exception
                    MessageBox.Show("Can't find '" & data & "'")
                    Exit Sub
                End Try
            Next
            If Not valid Then
                MessageBox.Show("Can't find '" & data & "'")
            End If
        End If
    End Sub

    Private Sub cb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTempTimer.Click, cbAddress.Click, cbVar.Click, cbTempCount.Click
        Select Case sender.name
            Case "cbVar"
                index = 1
                cbAddress.Checked = False
                cbTempCount.Checked = False
                cbTempTimer.Checked = False
            Case "cbAddress"
                index = 2
                cbVar.Checked = False
                cbTempCount.Checked = False
                cbTempTimer.Checked = False
            Case "cbTempCount"
                index = 6
                cbVar.Checked = False
                cbAddress.Checked = False
                cbTempTimer.Checked = False
            Case "cbTempTimer"
                index = 5
                cbVar.Checked = False
                cbAddress.Checked = False
                cbTempCount.Checked = False
            Case Else
                index = 0
        End Select
    End Sub

    Private Sub variable_list_in_comboBox()
        Dim ss As String
        For i As Integer = 0 To 9
            If cbData.Items.Item(i) = UCase(cbData.Text) Then
                cbData.SelectedIndex = i
                Exit Sub
            End If
        Next

        ss = UCase(cbData.Text)
        For i As Integer = 8 To 0 Step -1
            cbData.Items.Item(i + 1) = cbData.Items.Item(i)
        Next

        cbData.Items.Item(0) = ss
        cbData.SelectedIndex = 0
    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearch.Click
        lvVariable.MultiSelect = False
        lvVariable.FullRowSelect = True
        If index <> 0 Then search_in_table(cbData.Text, index) : variable_list_in_comboBox()
    End Sub

    Private Sub cbData_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles cbData.PreviewKeyDown
        lvVariable.MultiSelect = False
        lvVariable.FullRowSelect = True
        If e.KeyData = Keys.Enter Then
            If index <> 0 Then search_in_table(cbData.Text, index) : variable_list_in_comboBox()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class