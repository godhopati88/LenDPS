Public Class frmVarContent
    Private Const Max_Row = 15
    Dim Max_Var As Integer
    Dim status As TokenList
    Dim txNumber(14), txName(14), txType(14) As TextBox


#Region "Class Properties"
    Private mGetVariable As String
    Public Property GetVariable As String
        Get
            Return mGetVariable
        End Get
        Set(ByVal value As String)
            mGetVariable = value
        End Set
    End Property

    Private mMaxVariable As Integer
    Private Property MaxVariable As Integer
        Get
            Return mMaxVariable
        End Get
        Set(ByVal value As Integer)
            mMaxVariable = value
        End Set
    End Property
#End Region

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
    End Sub

    Private Function get_amount_of_io(ByVal type As TokenList) As Integer
        Dim count As Integer = 0
        For i As Integer = 0 To UBound(Parameter) - 1
            If Parameter(i).Type = type Then
                count += 1
            End If
        Next
        Return count
    End Function

    Private Sub frmVarContent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case VarStatus
            Case sVarSelectStatus.hmi
                Select Case ioStatus
                    Case sIO.input
                        Max_Var = get_amount_of_io(TokenList.T_VitalInput)
                        VScrollBar1.Maximum = Max_Var - Max_Row
                        status = TokenList.T_VitalInput
                    Case sIO.output
                        Max_Var = get_amount_of_io(TokenList.T_VitalOutput)
                        VScrollBar1.Maximum = Max_Var - Max_Row
                        status = TokenList.T_VitalOutput
                End Select
            Case sVarSelectStatus.io_cbi
                Select Case frmMain.GetStatusIO
                    Case "Input"
                        Max_Var = get_amount_of_io(TokenList.T_VitalInput)
                        VScrollBar1.Maximum = Max_Var - Max_Row
                        status = TokenList.T_VitalInput
                    Case "Output"
                        Max_Var = get_amount_of_io(TokenList.T_VitalOutput)
                        VScrollBar1.Maximum = Max_Var - Max_Row
                        status = TokenList.T_VitalOutput
                End Select
        End Select
        Init()
        VScrollBar1_Scroll()
    End Sub

    Private Sub VScrollBar1_Scroll() Handles VScrollBar1.Scroll
        Dim index As Integer = 0
        Dim idx As Integer = 0
        Try
            If Max_Var >= Max_Row Then
                Do
                    Select Case status
                        Case TokenList.T_VitalInput
                            If Parameter(idx + VScrollBar1.Value).Type = TokenList.T_VitalInput And Parameter(idx + VScrollBar1.Value).linkStatus = String.Empty Then
                                index += 1
                                txNumber(index - 1).Text = CStr(idx + 1 + VScrollBar1.Value) 'xx
                                txName(index - 1).Text = Parameter(idx + VScrollBar1.Value).Name
                                txType(index - 1).Text = "VDI"
                            End If
                        Case TokenList.T_VitalOutput
                            If Parameter(idx + get_amount_of_io(TokenList.T_VitalInput) + VScrollBar1.Value).Type = TokenList.T_VitalOutput And Parameter(idx + get_amount_of_io(TokenList.T_VitalInput) + VScrollBar1.Value).linkStatus = String.Empty Then
                                index += 1
                                txNumber(index - 1).Text = CStr(idx + 1 + VScrollBar1.Value)
                                txName(index - 1).Text = Parameter(idx + get_amount_of_io(TokenList.T_VitalInput) + VScrollBar1.Value).Name
                                txType(index - 1).Text = "VDO"
                            End If
                    End Select
                    idx += 1
                Loop Until (index = 15)
            Else
                For i As Integer = 0 To UBound(Parameter) - 1
                    Select Case status
                        Case TokenList.T_VitalInput
                            If Parameter(i).Type = TokenList.T_VitalInput And Parameter(i).linkStatus = String.Empty Then
                                index += 1
                                txNumber(index - 1).Text = CStr(index)
                                txName(index - 1).Text = Parameter(i).Name
                                txType(index - 1).Text = "VDI"
                            End If
                        Case TokenList.T_VitalOutput
                            If Parameter(i).Type = TokenList.T_VitalOutput And Parameter(i).linkStatus = String.Empty Then
                                index += 1
                                txNumber(index - 1).Text = CStr(index)
                                txName(index - 1).Text = Parameter(i).Name
                                txType(index - 1).Text = "VDO"
                            End If
                    End Select
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txName_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles txtVar1.DoubleClick, txtVar2.DoubleClick, txtVar3.DoubleClick, txtVar4.DoubleClick, txtVar5.DoubleClick, txtVar6.DoubleClick, txtVar7.DoubleClick, txtVar8.DoubleClick, txtVar9.DoubleClick, txtVar10.DoubleClick, txtVar11.DoubleClick, txtVar12.DoubleClick, txtVar13.DoubleClick, txtVar14.DoubleClick, txtVar15.DoubleClick
        Dim txtBox As New TextBox
        txtBox = DirectCast(sender, TextBox)
        GetVariable = Trim(txtBox.Text)
        Me.Close()
    End Sub
End Class