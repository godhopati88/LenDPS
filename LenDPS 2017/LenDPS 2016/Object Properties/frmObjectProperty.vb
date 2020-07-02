Imports Railway

Public Class frmObjectProperty

    Private Sub frmObjectProperty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case ObjRec(IndexObj).Name
            Case "Signal" : Signal_Properties()
            Case "PointMachine" : PointMachine_Properties()
            Case "Track" : Track_Properties()
            Case "Label" : Label_properties()
            Case "CheckBox" : CheckBox_Properties()
            Case "Counter" : Counter_Properties()
            Case "Buzzer" : Buzzer_Properties()
            Case "Shape" : Shape_Properties()
            Case "Button" : ButtonProperties()
        End Select
    End Sub

    Private Sub btOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click
        Write_properties()
        Me.Close()
    End Sub

    Private Sub SetLabel(ByVal s1 As String, ByVal s2 As String, ByVal s3 As String, ByVal s4 As String, ByVal s5 As String)
        lbl1.Text = s1
        lbl2.Text = s2
        lbl3.Text = s3
        lbl4.Text = s4
        lbl5.Text = s5
    End Sub

    Private Sub SetButtonColor(ByVal b1 As Boolean, ByVal b2 As Boolean, ByVal b3 As Boolean, ByVal b4 As Boolean, ByVal b5 As Boolean)
        cbInput.Enabled = False
        tbColor1.Enabled = b1 : btColor1.Enabled = b1 : tagId1.Enabled = b1
        tbColor2.Enabled = b2 : btColor2.Enabled = b2 : tagId2.Enabled = b2
        tbColor3.Enabled = b3 : btColor3.Enabled = b3 : tagId3.Enabled = b3
        tbColor4.Enabled = b4 : btColor4.Enabled = b4 : tagId4.Enabled = b4
        tbColor5.Enabled = b5 : btColor5.Enabled = b5 : tagId5.Enabled = b5
    End Sub

    Private Sub btColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btColor1.Click, btColor2.Click, btColor3.Click, btColor4.Click, btColor5.Click
        Dim ColorDlg As New ColorDialog
        Dim cMyCustomColors(15) As Color
        Dim index As Integer

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

        For index = 0 To cMyCustomColors.Length - 1
            'cast to integer
            colorBlue = cMyCustomColors(index).B
            colorGreen = cMyCustomColors(index).G
            colorRed = cMyCustomColors(index).R

            'shift the bits
            iMyCustomColor = colorBlue << 16 Or colorGreen << 8 Or colorRed

            iMyCustomColors(index) = iMyCustomColor
        Next

        ColorDlg.CustomColors = iMyCustomColors

        index = Integer.Parse(CType(sender, Button).Tag)
        If ColorDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Select Case index
                Case 1 : tbColor1.BackColor = ColorDlg.Color
                Case 2 : tbColor2.BackColor = ColorDlg.Color
                Case 3 : tbColor3.BackColor = ColorDlg.Color
                Case 4 : tbColor4.BackColor = ColorDlg.Color
                Case 5 : tbColor5.BackColor = ColorDlg.Color
            End Select
        End If
    End Sub

    Private Sub Write_properties()
        Select Case ObjRec(IndexObj).Name
            Case "Signal" : Write_Signal_Properties()
            Case "PointMachine" : Write_PointMachine_Properties()
            Case "Track" : Write_Track_Properties()
            Case "Label" : Write_Label_properties()
            Case "CheckBox" : Write_CheckBox_Properties()
            Case "Counter" : Write_Counter_Properties()
            Case "Buzzer" : Write_Buzzer_Properties()
            Case "Shape" : Write_Shape_Properties()
            Case "Button" : Write_Button_Properties()
        End Select
    End Sub

#Region "       Signal Properties"
    Private Sub Signal_Properties()
        tbColor1.BackColor = AnyObj(IndexObj).mSignal.TagId1Color
        tbColor2.BackColor = AnyObj(IndexObj).mSignal.TagId2Color
        tbColor3.BackColor = AnyObj(IndexObj).mSignal.TagId3Color
        tbColor4.BackColor = AnyObj(IndexObj).mSignal.TagId4Color

        Select Case AnyObj(IndexObj).mSignal.Type
            Case Signal.eType.DistanceSignal
                Me.Text = "Signal - Distance Signal Properties"
                SetLabel("Signal Lamp", "Not Used", "Not Used", "Not Used", "Not Used")
                SetButtonColor(True, False, False, False, False)
                tagId1.Text = AnyObj(IndexObj).mSignal.TagTx1

            Case Signal.eType.HomeSigal
                Me.Text = "Signal - Home Signal Properties"
                SetLabel("Emergency Lamp", "Signal Lamp 1", "Signal Lamp 2", "Signal Lamp 3", "Not Used")
                SetButtonColor(True, True, True, True, False)
                tagId1.Text = AnyObj(IndexObj).mSignal.TagTx1
                tagId2.Text = AnyObj(IndexObj).mSignal.TagTx2
                tagId3.Text = AnyObj(IndexObj).mSignal.TagTx3
                tagId4.Text = AnyObj(IndexObj).mSignal.TagTx4

            Case Signal.eType.ShuntSignal
                Me.Text = "Signal - Shunt Signal Properties"
                SetLabel("Shunt Signal 1", "Shunt Signal 2", "Not Used", "Not Used", "Not Used")
                SetButtonColor(True, True, False, False, False)
                tagId1.Text = AnyObj(IndexObj).mSignal.TagTx1
                tagId2.Text = AnyObj(IndexObj).mSignal.TagTx2

            Case Signal.eType.StartingSignal
                Me.Text = "Signal - Starting Signal Properties"
                SetLabel("Emergency Lamp", "Signal Lamp 1", "Signal Lamp 2", "Not Used", "Not Used")
                SetButtonColor(True, True, True, False, False)
                tagId1.Text = AnyObj(IndexObj).mSignal.TagTx1
                tagId2.Text = AnyObj(IndexObj).mSignal.TagTx2
                tagId3.Text = AnyObj(IndexObj).mSignal.TagTx3

            Case Signal.eType.StartingSignalWithShunt
                Me.Text = "Signal - Starting(Shunt) Signal Properties"
                SetLabel("Emergency Lamp", "Signal Lamp 1", "Signal Lamp 2", "Shunt Signal", "Not Used")
                SetButtonColor(True, True, True, True, False)
                tagId1.Text = AnyObj(IndexObj).mSignal.TagTx1
                tagId2.Text = AnyObj(IndexObj).mSignal.TagTx2
                tagId3.Text = AnyObj(IndexObj).mSignal.TagTx3
                tagId4.Text = AnyObj(IndexObj).mSignal.TagTx4

        End Select
    End Sub

    Private Sub Write_Signal_Properties()
        AnyObj(IndexObj).mSignal.TagId1Color = tbColor1.BackColor
        AnyObj(IndexObj).mSignal.TagId2Color = tbColor2.BackColor
        AnyObj(IndexObj).mSignal.TagId3Color = tbColor3.BackColor
        AnyObj(IndexObj).mSignal.TagId4Color = tbColor4.BackColor

        Select Case AnyObj(IndexObj).mSignal.Type
            Case Signal.eType.DistanceSignal
                AnyObj(IndexObj).mSignal.TagTx1 = Trim(tagId1.Text)
                AnyObj(IndexObj).mSignal.TagTx2 = ""
                AnyObj(IndexObj).mSignal.TagTx3 = ""
                AnyObj(IndexObj).mSignal.TagTx4 = ""
            Case Signal.eType.HomeSigal
                AnyObj(IndexObj).mSignal.TagTx1 = Trim(tagId1.Text)
                AnyObj(IndexObj).mSignal.TagTx2 = Trim(tagId2.Text)
                AnyObj(IndexObj).mSignal.TagTx3 = Trim(tagId3.Text)
                AnyObj(IndexObj).mSignal.TagTx4 = Trim(tagId4.Text)
            Case Signal.eType.ShuntSignal
                AnyObj(IndexObj).mSignal.TagTx1 = Trim(tagId1.Text)
                AnyObj(IndexObj).mSignal.TagTx2 = Trim(tagId2.Text)
                AnyObj(IndexObj).mSignal.TagTx3 = ""
                AnyObj(IndexObj).mSignal.TagTx4 = ""
            Case Signal.eType.StartingSignal
                AnyObj(IndexObj).mSignal.TagTx1 = Trim(tagId1.Text)
                AnyObj(IndexObj).mSignal.TagTx2 = Trim(tagId2.Text)
                AnyObj(IndexObj).mSignal.TagTx3 = Trim(tagId3.Text)
                AnyObj(IndexObj).mSignal.TagTx4 = ""
            Case Signal.eType.StartingSignalWithShunt
                AnyObj(IndexObj).mSignal.TagTx1 = Trim(tagId1.Text)
                AnyObj(IndexObj).mSignal.TagTx2 = Trim(tagId2.Text)
                AnyObj(IndexObj).mSignal.TagTx3 = Trim(tagId3.Text)
                AnyObj(IndexObj).mSignal.TagTx4 = Trim(tagId4.Text)
        End Select

        UpdateObj(AnyObj(IndexObj).mSignal.Name, IndexObj)
    End Sub
#End Region

#Region "       Point Machine Properties"
    Private Sub PointMachine_Properties()
        Me.Text = "Point Machine Properties"
        tbColor1.BackColor = AnyObj(IndexObj).mPointMachine.TagId1Color
        tbColor2.BackColor = AnyObj(IndexObj).mPointMachine.TagId2Color
        tbColor3.BackColor = AnyObj(IndexObj).mPointMachine.TagId3Color
        tbColor4.BackColor = AnyObj(IndexObj).mPointMachine.TagId4Color
        tbColor5.BackColor = AnyObj(IndexObj).mPointMachine.TagId5Color

        SetLabel("Normal(1)", "Normal(2)", "Reverse(1)", "Reverse(2)", "Track Wesel")
        SetButtonColor(True, True, True, True, True)
        tagId1.Text = AnyObj(IndexObj).mPointMachine.TagTx1
        tagId2.Text = AnyObj(IndexObj).mPointMachine.TagTx2
        tagId3.Text = AnyObj(IndexObj).mPointMachine.TagTx3
        tagId4.Text = AnyObj(IndexObj).mPointMachine.TagTx4
        tagId5.Text = AnyObj(IndexObj).mPointMachine.TagTx5
    End Sub

    Private Sub Write_PointMachine_Properties()
        AnyObj(IndexObj).mPointMachine.TagId1Color = tbColor1.BackColor
        AnyObj(IndexObj).mPointMachine.TagId2Color = tbColor2.BackColor
        AnyObj(IndexObj).mPointMachine.TagId3Color = tbColor3.BackColor
        AnyObj(IndexObj).mPointMachine.TagId4Color = tbColor4.BackColor
        AnyObj(IndexObj).mPointMachine.TagId5Color = tbColor5.BackColor

        AnyObj(IndexObj).mPointMachine.TagTx1 = Trim(tagId1.Text)
        AnyObj(IndexObj).mPointMachine.TagTx2 = Trim(tagId2.Text)
        AnyObj(IndexObj).mPointMachine.TagTx3 = Trim(tagId3.Text)
        AnyObj(IndexObj).mPointMachine.TagTx4 = Trim(tagId4.Text)
        AnyObj(IndexObj).mPointMachine.TagTx5 = Trim(tagId5.Text)
        UpdateObj(AnyObj(IndexObj).mPointMachine.Name, IndexObj)
    End Sub
#End Region

#Region "       Track Properties"
    Private Sub Track_Properties()
        Me.Text = "Track Properties"
        tbColor1.BackColor = AnyObj(IndexObj).mTrack.TagId1Color
        tbColor2.BackColor = AnyObj(IndexObj).mTrack.TagId2Color
        tbColor3.BackColor = AnyObj(IndexObj).mTrack.TagId3Color
        tbColor4.BackColor = AnyObj(IndexObj).mTrack.TagId4Color

        SetLabel("Track Lamp(1)", "Track Lamp(2)", "Not Used", "Not Used", "Not Used")
        SetButtonColor(True, True, False, False, False) : cbInput.Enabled = True
        tagId1.Text = AnyObj(IndexObj).mTrack.TagTx1
        tagId2.Text = AnyObj(IndexObj).mTrack.TagTx2
        tagId3.Text = AnyObj(IndexObj).mTrack.TagTx3
        tagId4.Text = AnyObj(IndexObj).mTrack.TagTx4
        tagIdInput.Text = AnyObj(IndexObj).mTrack.TagTx
        cbInput.Checked = AnyObj(IndexObj).mTrack.TagIdVal
    End Sub

    Private Sub Write_Track_Properties()
        AnyObj(IndexObj).mTrack.TagId1Color = tbColor1.BackColor
        AnyObj(IndexObj).mTrack.TagId2Color = tbColor2.BackColor
        AnyObj(IndexObj).mTrack.TagId3Color = tbColor3.BackColor
        AnyObj(IndexObj).mTrack.TagId4Color = tbColor4.BackColor

        AnyObj(IndexObj).mTrack.TagTx1 = Trim(tagId1.Text)
        AnyObj(IndexObj).mTrack.TagTx2 = Trim(tagId2.Text)
        AnyObj(IndexObj).mTrack.TagTx3 = Trim(tagId3.Text)
        AnyObj(IndexObj).mTrack.TagTx4 = Trim(tagId4.Text)
        AnyObj(IndexObj).mTrack.TagTx = Trim(tagIdInput.Text)
        AnyObj(IndexObj).mTrack.TagIdVal = cbInput.Checked
        UpdateObj(AnyObj(IndexObj).mTrack.Name, IndexObj)
    End Sub
#End Region

#Region "       Label Properties"
    Private Sub Label_properties()
        Me.Text = "Label Properties"
        tbColor1.BackColor = AnyObj(IndexObj).mLabel.TagId1Color
        tbColor2.BackColor = AnyObj(IndexObj).mLabel.TagId2Color

        SetLabel("Color Animation(1)", "Color Animation(2)", "Not Used", "Not Used", "Not Used")
        SetButtonColor(True, True, False, False, False)
        tagId1.Text = AnyObj(IndexObj).mLabel.TagTx1
        tagId2.Text = AnyObj(IndexObj).mLabel.TagTx2
    End Sub

    Private Sub Write_Label_properties()
        AnyObj(IndexObj).mLabel.TagId1Color = tbColor1.BackColor
        AnyObj(IndexObj).mLabel.TagId2Color = tbColor2.BackColor

        AnyObj(IndexObj).mLabel.TagTx1 = Trim(tagId1.Text)
        AnyObj(IndexObj).mLabel.TagTx2 = Trim(tagId2.Text)
        UpdateObj(AnyObj(IndexObj).mLabel.Name, IndexObj)
    End Sub
#End Region

#Region "       Check Box Properties"
    Private Sub CheckBox_Properties()
        Me.Text = "Check Box Properties"
        SetButtonColor(False, False, False, False, False)
        cbInput.Enabled = True
        cbInput.Checked = AnyObj(IndexObj).mCheckBox.Checked
        tagIdInput.Text = AnyObj(IndexObj).mCheckBox.TagTx
    End Sub

    Private Sub Write_CheckBox_Properties()
        AnyObj(IndexObj).mCheckBox.Checked = Convert.ToBoolean(cbInput.Checked.ToString)
        AnyObj(IndexObj).mCheckBox.TagIdVal = Convert.ToBoolean(cbInput.Checked.ToString)
        AnyObj(IndexObj).mCheckBox.TagTx = Trim(tagIdInput.Text)

        UpdateObj(AnyObj(IndexObj).mCheckBox.Name, IndexObj)
    End Sub
#End Region

#Region "       Counter Properties"
    Private Sub Counter_Properties()
        Me.Text = "Counter Properties"

    End Sub

    Private Sub Write_Counter_Properties()

    End Sub
#End Region

#Region "       Buzzer Properties"
    Private Sub Buzzer_Properties()
        Me.Text = "Push Button Properties"
        tbColor1.BackColor = AnyObj(IndexObj).mBuzzer.TagId1Color
        tbColor2.BackColor = AnyObj(IndexObj).mBuzzer.TagId2Color

        SetLabel("Color Animation(1)", "Color Animation(2)", "Not Used", "Not Used", "Not Used")
        SetButtonColor(True, True, False, False, False)
        tagId1.Text = AnyObj(IndexObj).mBuzzer.TagTx1
        tagId2.Text = AnyObj(IndexObj).mBuzzer.TagTx2
    End Sub

    Private Sub Write_Buzzer_Properties()
        AnyObj(IndexObj).mBuzzer.TagId1Color = tbColor1.BackColor
        AnyObj(IndexObj).mBuzzer.TagId2Color = tbColor2.BackColor

        AnyObj(IndexObj).mBuzzer.TagTx1 = tagId1.Text
        AnyObj(IndexObj).mBuzzer.TagTx2 = tagId2.Text
        UpdateObj(AnyObj(IndexObj).mBuzzer.Name, IndexObj)
    End Sub
#End Region

#Region "       Shape Properties"
    Private Sub Shape_Properties()
        Me.Text = "Shape Properties"
        tbColor1.BackColor = AnyObj(IndexObj).mShapes.TagId1Color
        tbColor2.BackColor = AnyObj(IndexObj).mShapes.TagId2Color

        SetLabel("Color Animation(1)", "Color Animation(2)", "Not Used", "Not Used", "Not Used")
        SetButtonColor(True, True, False, False, False)
        tagId1.Text = AnyObj(IndexObj).mShapes.TagTx1
        tagId2.Text = AnyObj(IndexObj).mShapes.TagTx2
    End Sub

    Private Sub Write_Shape_Properties()
        AnyObj(IndexObj).mShapes.TagId1Color = tbColor1.BackColor
        AnyObj(IndexObj).mShapes.TagId2Color = tbColor2.BackColor

        AnyObj(IndexObj).mShapes.TagTx1 = tagId1.Text
        AnyObj(IndexObj).mShapes.TagTx2 = tagId2.Text
        UpdateObj(AnyObj(IndexObj).mShapes.Name, IndexObj)
    End Sub
#End Region

#Region "       Button Properties"
    Private Sub ButtonProperties()
        Me.Text = "Button Properties"
        tbColor1.BackColor = AnyObj(IndexObj).mButton.TagId1Color
        tbColor2.BackColor = AnyObj(IndexObj).mButton.TagId2Color

        SetLabel("Color Animation(1)", "Color Animation(2)", "Not Used", "Not Used", "Not Used")
        SetButtonColor(True, True, False, False, False) : cbInput.Enabled = True
        cbInput.Checked = AnyObj(IndexObj).mButton.OnToggle
        tagId1.Text = AnyObj(IndexObj).mButton.TagTx1
        tagId2.Text = AnyObj(IndexObj).mButton.TagTx2
        tagIdInput.Text = AnyObj(IndexObj).mButton.TagTx
    End Sub

    Private Sub Write_Button_Properties()
        AnyObj(IndexObj).mButton.TagId1Color = tbColor1.BackColor
        AnyObj(IndexObj).mButton.TagId2Color = tbColor2.BackColor
        AnyObj(IndexObj).mButton.OnToggle = cbInput.Checked
        AnyObj(IndexObj).mButton.TagIdVal = cbInput.Checked
        AnyObj(IndexObj).mButton.TagTx = Trim(tagIdInput.Text)

        AnyObj(IndexObj).mButton.TagTx1 = Trim(tagId1.Text)
        AnyObj(IndexObj).mButton.TagTx2 = Trim(tagId2.Text)
        UpdateObj(AnyObj(IndexObj).mButton.Name, IndexObj)
    End Sub

    Private Sub varInUsed(ByVal varIn As String)
        Dim bufVar As String = varIn
        If bufVar = String.Empty Then
            For i As Integer = 0 To UBound(Parameter) - 1
                If Parameter(i).Name = varIn Then
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
                ElseIf Parameter(i).Name = varIn And Parameter(i).linkStatus = String.Empty Then
                    Parameter(i).linkStatus = "InUsed"
                    Count += 1
                End If
                If Count = 2 Then Exit For
            Next
        End If
    End Sub

    Private Sub tagIdInput_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tagIdInput.MouseDoubleClick
        VarStatus = sVarSelectStatus.hmi
        ioStatus = sIO.input
        Dim frm As New frmVarContent
        frm.ShowDialog()
        If frm.GetVariable <> String.Empty Then tagIdInput.Text = frm.GetVariable()

    End Sub

    Private Sub tagId1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tagId1.MouseDoubleClick
        VarStatus = sVarSelectStatus.hmi
        ioStatus = sIO.output
        Dim frm As New frmVarContent
        frm.ShowDialog()
        If frm.GetVariable <> String.Empty Then tagId1.Text = frm.GetVariable()
    End Sub

    Private Sub tagId2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tagId2.MouseDoubleClick
        VarStatus = sVarSelectStatus.hmi
        ioStatus = sIO.output
        Dim frm As New frmVarContent
        frm.ShowDialog()
        If frm.GetVariable <> String.Empty Then tagId2.Text = frm.GetVariable()
    End Sub


#End Region

End Class