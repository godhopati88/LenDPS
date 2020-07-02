Public Class frmDaftarVariable
    Private Const Max_Row = 15
    Dim Max_Var As Integer
    Dim txNumber(14), txName(14), txType(14) As TextBox
    Dim cbNil(14) As CheckBox
    Dim cb As CheckBox

    Private Sub Init()
        txNumber(0) = txtAddress1 : txNumber(1) = txtAddress2 : txNumber(2) = txtAddress3 : txNumber(3) = txtAddress4 : txNumber(4) = txtAddress5
        txNumber(5) = txtAddress6 : txNumber(6) = txtAddress7 : txNumber(7) = txtAddress8 : txNumber(8) = txtAddress9 : txNumber(9) = txtAddress10
        txNumber(10) = txtAddress11 : txNumber(11) = txtAddress12 : txNumber(12) = txtAddress13 : txNumber(13) = txtAddress14 : txNumber(14) = txtAddress15

        txType(0) = txtType1 : txType(1) = txtType2 : txType(2) = txtType3 : txType(3) = txtType4 : txType(4) = txtType5
        txType(5) = txtType6 : txType(6) = txtType7 : txType(7) = txtType8 : txType(8) = txtType9 : txType(9) = txtType10
        txType(10) = txtType11 : txType(11) = txtType12 : txType(12) = txtType13 : txType(13) = txtType14 : txType(14) = txtType15

        txName(0) = txtVar1 : txName(1) = txtVar2 : txName(2) = txtVar3 : txName(3) = txtVar4 : txName(4) = txtVar5
        txName(5) = txtVar6 : txName(6) = txtVar7 : txName(7) = txtVar8 : txName(8) = txtVar9 : txName(9) = txtVar10
        txName(10) = txtVar11 : txName(11) = txtVar12 : txName(12) = txtVar13 : txName(13) = txtVar14 : txName(14) = txtVar15

        cbNil(0) = cbNil1 : cbNil(1) = cbNil2 : cbNil(2) = cbNil3 : cbNil(3) = cbNil4 : cbNil(4) = cbNil5
        cbNil(5) = cbNil6 : cbNil(6) = cbNil7 : cbNil(7) = cbNil8 : cbNil(8) = cbNil9 : cbNil(9) = cbNil10
        cbNil(10) = cbNil11 : cbNil(11) = cbNil12 : cbNil(12) = cbNil13 : cbNil(13) = cbNil14 : cbNil(14) = cbNil15

        For i As Integer = 0 To 9
            cbFind.Items.Insert(i, "")
        Next
    End Sub

    Private Sub frmDaftarVariable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Max_Var = UBound(Parameter)
        Init()
        VScrollBar1.Maximum = Max_Var - Max_Row
        VScrollBar1_Scroll()
    End Sub

    Public Sub VScrollBar1_Scroll() Handles VScrollBar1.Scroll
        If Max_Var >= Max_Row Then
            For i As Integer = 1 To Max_Row
                txNumber(i - 1).Text = CStr(i + VScrollBar1.Value)
                txName(i - 1).Text = Parameter(i - 1 + VScrollBar1.Value).Name
                cbNil(i - 1).Checked = Parameter(i - 1 + VScrollBar1.Value).value
                Select Case Parameter(i - 1 + VScrollBar1.Value).Type
                    Case TokenList.T_Boolean : txType(i - 1).Text = "BOOL"
                    Case TokenList.T_Timer : txType(i - 1).Text = "TIMER"
                    Case TokenList.T_VitalInput : txType(i - 1).Text = "VDI"
                    Case TokenList.T_VitalOutput : txType(i - 1).Text = "VDO"
                    Case TokenList.T_NVitalCom : txType(i - 1).Text = "VC From"
                    Case TokenList.T_VitalCom : txType(i - 1).Text = "VC To"
                End Select
            Next
        Else
            For i As Integer = 0 To Max_Var - 1
                txNumber(i).Text = CStr(i + 1)
                txName(i).Text = Parameter(i).Name
                cbNil(i).Checked = Parameter(i).value
                Select Case Parameter(i).Type
                    Case TokenList.T_Boolean : txType(i).Text = "BOOL"
                    Case TokenList.T_Timer : txType(i).Text = "TIMER"
                    Case TokenList.T_VitalInput : txType(i - 1).Text = "VDI"
                    Case TokenList.T_VitalOutput : txType(i - 1).Text = "VDO"
                    Case TokenList.T_NVitalCom : txType(i - 1).Text = "VC From"
                    Case TokenList.T_VitalCom : txType(i - 1).Text = "VC To"
                End Select
            Next
        End If
    End Sub

    Private Sub Find()
        Dim z As Integer
        Dim ss As String

        z = Find_Idx_Name(UCase(cbFind.Text))
        If z > VScrollBar1.Maximum Then
            VScrollBar1.Value = VScrollBar1.Maximum : VScrollBar1_Scroll()
        Else
            If z >= 0 Then VScrollBar1.Value = z : VScrollBar1_Scroll()
        End If

        For i As Integer = 0 To 9
            If cbFind.Items.Item(i) = UCase(cbFind.Text) Then
                cbFind.SelectedIndex = i : Exit Sub
            End If
        Next
        ss = UCase(cbFind.Text)
        For i As Integer = 8 To 0 Step -1
            cbFind.Items.Item(i + 1) = cbFind.Items.Item(i)
        Next
        cbFind.Items.Item(0) = ss
        cbFind.SelectedIndex = 0
    End Sub

    Private Function Find_Idx_Name(ByVal a As String) As Integer
        Dim w As Integer
        a = Trim("" & a)
        w = Len(a)
        Find_Idx_Name = -1
        For i As Integer = 0 To UBound(Parameter) - 1
            If Parameter(i).Name = a Then Find_Idx_Name = i : Exit Function
        Next
        If a = "" Then Find_Idx_Name = -1
        If a = "" Or Find_Idx_Name = -1 Then
            MessageBox.Show("Variable is not found")
        End If
    End Function

    Private Sub cbFind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbFind.KeyDown
        If e.KeyCode = Keys.Enter Then Find()
    End Sub

    Private Sub cb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNil1.CheckedChanged, cbNil2.CheckedChanged, cbNil3.CheckedChanged, cbNil4.CheckedChanged, cbNil5.CheckedChanged, cbNil6.CheckedChanged, cbNil7.CheckedChanged, cbNil8.CheckedChanged, cbNil9.CheckedChanged, cbNil10.CheckedChanged, cbNil11.CheckedChanged, cbNil12.CheckedChanged, cbNil13.CheckedChanged, cbNil14.CheckedChanged, cbNil15.CheckedChanged
        Dim index As Integer

        index = CInt(Mid(sender.name, 6))
        cb = DirectCast(sender, CheckBox)
        If Max_Var >= Max_Row Then
            Parameter(index - 1 + VScrollBar1.Value).value = cb.Checked
            frmRunTime.EksekusiVariableAnimasi(Parameter(index - 1 + VScrollBar1.Value).Name, cb.Checked)
        Else
            Parameter(index - 1).value = cb.Checked
            frmRunTime.EksekusiVariableAnimasi(Parameter(index - 1).Name, cb.Checked)
        End If

    End Sub

    Private Function GetControlByName(ByVal pobjParent As Control, ByVal pstrCtlName As String) As Control
        Dim objCtl As Control

        For Each objCtl In pobjParent.Controls
            If objCtl.Name = pstrCtlName Then
                Return (objCtl)
            End If
        Next
        ' if control is not found
        Return Nothing

    End Function
End Class