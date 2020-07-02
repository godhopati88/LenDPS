Imports Railway


Public Class clsLoadObject
    Inherits System.Collections.CollectionBase

#Region "   Load Vital Object to Vital Editor"
    Public Function LoadSignal(ByVal f As winContainer) As Signal
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mSignal = New Signal
        Me.List.Add(AnyObj(ObjIndex).mSignal)
        f.Controls.Add(AnyObj(ObjIndex).mSignal)
        With AnyObj(ObjIndex).mSignal
            .Name = "Signal"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Height = ObjProp.Height
            .Diameter = ObjProp.Diameter
            .ShuntThickness = ObjProp.Thickness
            .Tag = ObjIndex
            .Type = ObjProp.Type
            .Group = ObjProp.Group
            .SignalPosition = ObjProp.Direction
            .TextPosition = ObjProp.TextPosition
            .TextName = ObjProp.Text
            .OnRunTime = ObjProp.OnRunTime
            .Font = New Font(ObjProp.fName, ObjProp.fSize, ObjProp.fStyle)
            '.Visible = ObjProp.Visible
            .OnVisible = ObjProp.OnVisible
            '------------ Object Color ----------
            .Idx1Color = ObjProp.IdColor1
            .Idx2Color = ObjProp.IdColor2
            .Idx3Color = ObjProp.IdColor3
            .Idx4Color = ObjProp.IdColor4
            .Idx5Color = ObjProp.IdColor5
            '------------ Run Time --------------
            .TagId1Color = ObjProp.TagId1Color
            .TagId2Color = ObjProp.TagId2Color
            .TagId3Color = ObjProp.TagId3Color
            .TagId4Color = ObjProp.TagId4Color
            .TagId1Val = ObjProp.TagId1Val
            .TagId2Val = ObjProp.TagId2Val
            .TagId3Val = ObjProp.TagId3Val
            .TagId4Val = ObjProp.TagId4Val
            .TagTx1 = ObjProp.TagTx1
            .TagTx2 = ObjProp.TagTx2
            .TagTx3 = ObjProp.TagTx3
            .TagTx4 = ObjProp.TagTx4
            '------------------------------------
            AddHandler .MouseClick, AddressOf Signal_Click
            AddHandler .MouseDoubleClick, AddressOf Signal_DoubleClick
        End With
        UpdateObj(AnyObj(ObjIndex).mSignal.Name, ObjIndex)
        Return AnyObj(ObjIndex).mSignal
    End Function

    Public Function LoadPointMachine(ByVal f As winContainer) As PointMachine
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mPointMachine = New PointMachine
        Me.List.Add(AnyObj(ObjIndex).mPointMachine)
        f.Controls.Add(AnyObj(ObjIndex).mPointMachine)
        With AnyObj(ObjIndex).mPointMachine
            .Name = "PointMachine"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Height = ObjProp.Height
            .Tag = ObjIndex
            .Type = ObjProp.Type
            .TextName = ObjProp.Text
            .Thickness = ObjProp.Thickness
            .Group = ObjProp.Group
            .OnRunTime = ObjProp.OnRunTime
            '.Visible = ObjProp.Visible
            .OnVisible = ObjProp.OnVisible
            '-------- Font -----------
            .Font = New Font(ObjProp.fName, ObjProp.fSize, ObjProp.fStyle)
            '------------ Object Color ----------
            .Idx1Color = ObjProp.IdColor1
            .Idx2Color = ObjProp.IdColor2
            .Idx3Color = ObjProp.IdColor3
            .Idx4Color = ObjProp.IdColor4
            .Idx5Color = ObjProp.IdColor5
            '------------ Run Time --------------
            .TagId1Color = ObjProp.TagId1Color
            .TagId2Color = ObjProp.TagId2Color
            .TagId3Color = ObjProp.TagId3Color
            .TagId4Color = ObjProp.TagId4Color
            .TagId5Color = ObjProp.TagId5Color
            .TagId1Val = ObjProp.TagId1Val
            .TagId2Val = ObjProp.TagId2Val
            .TagId3Val = ObjProp.TagId3Val
            .TagId4Val = ObjProp.TagId4Val
            .TagId5Val = ObjProp.TagId5Val
            .TagTx1 = ObjProp.TagTx1
            .TagTx2 = ObjProp.TagTx2
            .TagTx3 = ObjProp.TagTx3
            .TagTx4 = ObjProp.TagTx4
            .TagTx5 = ObjProp.TagTx5
            '------------------------------------
            AddHandler .MouseClick, AddressOf PointMachine_Click
            AddHandler .MouseDoubleClick, AddressOf PointMachine_DoubleClick
        End With
        UpdateObj(AnyObj(ObjIndex).mPointMachine.Name, ObjIndex)
        Return AnyObj(ObjIndex).mPointMachine
    End Function

    Public Function LoadTrack(ByVal f As winContainer) As Track
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mTrack = New Track
        Me.List.Add(AnyObj(ObjIndex).mTrack)
        f.Controls.Add(AnyObj(ObjIndex).mTrack)
        With AnyObj(ObjIndex).mTrack
            .Name = "Track"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Height = ObjProp.Height
            .Tag = ObjIndex
            .Type = ObjProp.Type
            .LinePosition = ObjProp.Direction
            .TextName = ObjProp.Text
            .TextPosition = ObjProp.TextPosition
            .Group = ObjProp.Group
            .Font = New Font(ObjProp.fName, ObjProp.fSize, ObjProp.fStyle)
            .Thickness = ObjProp.Thickness
            .OnRunTime = ObjProp.OnRunTime
            '.Visible = ObjProp.Visible
            .OnVisible = ObjProp.OnVisible
            '------------ Object Color ----------
            .Idx1Color = ObjProp.IdColor1
            .Idx2Color = ObjProp.IdColor2
            .Idx3Color = ObjProp.IdColor3
            .Idx4Color = ObjProp.IdColor4
            .Idx5Color = ObjProp.IdColor5
            '------------ Run Time --------------
            .TagId1Color = ObjProp.TagId1Color
            .TagId2Color = ObjProp.TagId2Color
            .TagId3Color = ObjProp.TagId3Color
            .TagId4Color = ObjProp.TagId4Color
            .TagId1Val = ObjProp.TagId1Val
            .TagId2Val = ObjProp.TagId2Val
            .TagId3Val = ObjProp.TagId3Val
            .TagId4Val = ObjProp.TagId4Val
            .TagTx1 = ObjProp.TagTx1
            .TagTx2 = ObjProp.TagTx2
            .TagTx3 = ObjProp.TagTx3
            .TagTx4 = ObjProp.TagTx4
            .TagIdVal = ObjProp.TagIdVal
            .TagTx = ObjProp.TagTx
            '------------------------------------
            AddHandler .MouseClick, AddressOf Track_Click
            AddHandler .MouseDoubleClick, AddressOf Track_DoubleClick
        End With
        UpdateObj(AnyObj(ObjIndex).mTrack.Name, ObjIndex)
        Return AnyObj(ObjIndex).mTrack
    End Function

    Public Function LoadShapes(ByVal f As winContainer) As Shapes
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mShapes = New Shapes
        Me.List.Add(AnyObj(ObjIndex).mShapes)
        f.Controls.Add(AnyObj(ObjIndex).mShapes)
        With AnyObj(ObjIndex).mShapes
            .Name = "Shape"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Height = ObjProp.Height
            .Tag = ObjIndex
            .Diameter = ObjProp.Diameter
            .Shape = ObjProp.Type
            .Direction = ObjProp.Direction
            .Group = ObjProp.Group
            .OnRunTime = ObjProp.OnRunTime
            '.Visible = ObjProp.Visible
            .OnVisible = ObjProp.OnVisible
            '------------ Object Color ----------
            .Idx1Color = ObjProp.IdColor1
            .Idx2Color = ObjProp.IdColor2
            .Idx3Color = ObjProp.IdColor3
            '------------ Run Time --------------
            .TagId1Color = ObjProp.TagId1Color
            .TagId2Color = ObjProp.TagId2Color
            .TagId1Val = ObjProp.TagId1Val
            .TagId2Val = ObjProp.TagId2Val
            .TagTx1 = ObjProp.TagTx1
            .TagTx2 = ObjProp.TagTx2
            AddHandler .MouseClick, AddressOf Shape_Click
            AddHandler .MouseDoubleClick, AddressOf Shape_DoubleClick
            '------------------------------------
        End With
        UpdateObj(AnyObj(ObjIndex).mShapes.Name, ObjIndex)
        Return AnyObj(ObjIndex).mShapes
    End Function

    Public Function LoadLabel(ByVal f As winContainer) As LabelName
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mLabel = New LabelName
        Me.List.Add(AnyObj(ObjIndex).mLabel)
        f.Controls.Add(AnyObj(ObjIndex).mLabel)
        With AnyObj(ObjIndex).mLabel
            .Name = "Label"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Height = ObjProp.Height
            .Tag = ObjIndex
            .TextName = ObjProp.Text
            .Font = New Font(ObjProp.fName, ObjProp.fSize, ObjProp.fStyle)
            .Group = ObjProp.Group
            .Type = ObjProp.Type
            .OnRunTime = ObjProp.OnRunTime
            '.Visible = ObjProp.Visible
            .OnVisible = ObjProp.OnVisible
            '------------ Object Color ----------
            .Idx1Color = ObjProp.IdColor1
            .Idx2Color = ObjProp.IdColor2
            .Idx3Color = ObjProp.IdColor3
            '------------ Run Time --------------
            .TagId1Color = ObjProp.TagId1Color
            .TagId2Color = ObjProp.TagId2Color
            .TagId1Val = ObjProp.TagId1Val
            .TagId2Val = ObjProp.TagId2Val
            .TagTx1 = ObjProp.TagTx1
            .TagTx2 = ObjProp.TagTx2
            '------------------------------------
            AddHandler .MouseClick, AddressOf Label_Click
            AddHandler .MouseDoubleClick, AddressOf Label_DoubleClick
        End With
        UpdateObj(AnyObj(ObjIndex).mLabel.Name, ObjIndex)
        Return AnyObj(ObjIndex).mLabel
    End Function

    Public Function LoadCheckBox(ByVal f As winContainer) As ckBox
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mCheckBox = New ckBox
        Me.List.Add(AnyObj(ObjIndex).mCheckBox)
        f.Controls.Add(AnyObj(ObjIndex).mCheckBox)
        With AnyObj(ObjIndex).mCheckBox
            .Name = "CheckBox"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Height = ObjProp.Height
            .Tag = ObjIndex
            .TextName = ObjProp.Text
            .Font = New Font(ObjProp.fName, ObjProp.fSize, ObjProp.fStyle)
            .Checked = ObjProp.Active
            .Group = ObjProp.Group
            .OnRunTime = ObjProp.OnRunTime
            '.Visible = ObjProp.Visible
            .OnVisible = ObjProp.OnVisible
            '------------ Object Color ----------
            .Idx1Color = ObjProp.IdColor1
            .Idx2Color = ObjProp.IdColor2
            .TagTx = ObjProp.TagTx
            .TagIdVal = ObjProp.TagIdVal
            AddHandler .MouseClick, AddressOf CheckBox_Click
            AddHandler .MouseDoubleClick, AddressOf CkBox_DoubleClick
        End With
        UpdateObj(AnyObj(ObjIndex).mCheckBox.Name, ObjIndex)
        Return AnyObj(ObjIndex).mCheckBox
    End Function

    Public Function LoadButton(ByVal f As winContainer) As Buttons
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mButton = New Buttons
        Me.List.Add(AnyObj(ObjIndex).mButton)
        f.Controls.Add(AnyObj(ObjIndex).mButton)
        With AnyObj(ObjIndex).mButton
            .Name = "Button"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Height = ObjProp.Height
            .Tag = ObjIndex
            .TextName = ObjProp.Text
            .Font = New Font(ObjProp.fName, ObjProp.fSize, ObjProp.fStyle)
            .OnRunTime = ObjProp.OnRunTime
            .Group = ObjProp.Group
            '.Visible = ObjProp.Visible
            .OnVisible = ObjProp.OnVisible
            .Type = ObjProp.Type
            .Shape = ObjProp.Direction
            .OnToggle = ObjProp.Active
            '------------ Object Color ----------
            .Idx1Color = ObjProp.IdColor1
            .Idx2Color = ObjProp.IdColor2
            .Idx3Color = ObjProp.IdColor3
            '------------ Run Time --------------
            .TagId1Color = ObjProp.TagId1Color
            .TagId2Color = ObjProp.TagId2Color
            .TagIdVal = ObjProp.TagIdVal
            .TagId1Val = ObjProp.TagId1Val
            .TagId2Val = ObjProp.TagId2Val
            .TagTx = ObjProp.TagTx
            .TagTx1 = ObjProp.TagTx1
            .TagTx2 = ObjProp.TagTx2
            '------------------------------------
            AddHandler .MouseClick, AddressOf Buttons_Click
            AddHandler .MouseDoubleClick, AddressOf Buttons_DoubleClick
        End With
        UpdateObj(AnyObj(ObjIndex).mButton.Name, ObjIndex)
        Return AnyObj(ObjIndex).mButton
    End Function

    Public Function LoadCounter(ByVal f As winContainer) As Counter
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mCounter = New Counter
        Me.List.Add(AnyObj(ObjIndex).mCounter)
        f.Controls.Add(AnyObj(ObjIndex).mCounter)
        With AnyObj(ObjIndex).mCounter
            .Name = "Counter"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Height = ObjProp.Height
            .Tag = ObjIndex
            .Group = ObjProp.Group
            .OnRunTime = ObjProp.OnRunTime
            '.Visible = ObjProp.Visible
            .OnVisible = ObjProp.OnVisible
            '------------ Object Color ----------
            .Idx1Color = ObjProp.IdColor1
            .Idx2Color = ObjProp.IdColor2
            .Idx3Color = ObjProp.IdColor3
            '------------------------------------
            AddHandler .MouseClick, AddressOf Counter_Click
            AddHandler .MouseDoubleClick, AddressOf Counter_DoubleClick
        End With
        UpdateObj(AnyObj(ObjIndex).mCounter.Name, ObjIndex)
        Return AnyObj(ObjIndex).mCounter
    End Function

    Public Function LoadBuzzer(ByVal f As winContainer) As Buzzer
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mBuzzer = New Buzzer
        Me.List.Add(AnyObj(ObjIndex).mBuzzer)
        f.Controls.Add(AnyObj(ObjIndex).mBuzzer)
        With AnyObj(ObjIndex).mBuzzer
            .Name = "Buzzer"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Height = ObjProp.Height
            .Tag = ObjIndex
            .Group = ObjProp.Group
            .OnRunTime = ObjProp.OnRunTime
            '.Visible = ObjProp.Visible
            .OnVisible = ObjProp.OnVisible
            '------------ Object Color ----------
            .Idx1Color = ObjProp.IdColor1
            .Idx2Color = ObjProp.IdColor2
            .Idx3Color = ObjProp.IdColor3
            '------------ Run Time --------------
            .TagId1Color = ObjProp.TagId1Color
            .TagId2Color = ObjProp.TagId2Color
            .TagId1Val = ObjProp.TagId1Val
            .TagId2Val = ObjProp.TagId2Val
            .TagTx1 = ObjProp.TagTx1
            .TagTx2 = ObjProp.TagTx2
            '------------------------------------
            AddHandler .MouseClick, AddressOf Buzzer_Click
            AddHandler .MouseDoubleClick, AddressOf Buzzer_DoubleClick
        End With
        UpdateObj(AnyObj(ObjIndex).mBuzzer.Name, ObjIndex)
        Return AnyObj(ObjIndex).mBuzzer
    End Function

    Public Function LoadEquipmentName(ByVal f As winContainer) As EquipmentName
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mEquipmentName = New EquipmentName
        Me.List.Add(AnyObj(ObjIndex).mEquipmentName)
        f.Controls.Add(AnyObj(ObjIndex).mEquipmentName)
        With AnyObj(ObjIndex).mEquipmentName
            .Name = "EquipmentName"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Left = ObjProp.Height
            .Tag = ObjIndex
            '.Visible = ObjProp.Visible
            .OnVisible = ObjProp.OnVisible
        End With
        UpdateObj(AnyObj(ObjIndex).mEquipmentName.Name, ObjIndex)
        Return AnyObj(ObjIndex).mEquipmentName
    End Function

    Public Function LoadPictureBox(ByVal f As winContainer) As PictureBox
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyObj) + 1
        ReDim Preserve AnyObj(ObjIndex)
        ReDim Preserve ObjRec(ObjIndex)

        AnyObj(ObjIndex).mPictureBox = New PictureBox
        Me.List.Add(AnyObj(ObjIndex).mPictureBox)
        f.Controls.Add(AnyObj(ObjIndex).mPictureBox)
        With AnyObj(ObjIndex).mPictureBox
            .Name = "PictureBox"
            .Top = winCoordinat.Y
            .Left = winCoordinat.X
            .Width = ObjProp.Width
            .Height = ObjProp.Height
            .Tag = ObjIndex
            '.Visible = ObjProp.Visible
            '.OnVisible = ObjProp.OnVisible
        End With
        UpdateObj(AnyObj(ObjIndex).mPictureBox.Name, ObjIndex)
        Return AnyObj(ObjIndex).mPictureBox
    End Function
#End Region

#Region "       Remove Object"
    Public Sub Remove(ByVal f As PictureBox, ByVal index As Integer)
        If Me.Count > 0 Then
            f.Controls.Remove(Me(index - 1))
        End If
    End Sub
#End Region

#Region "       Handler Object"
    Private Sub Signal_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DisplayObjectProperties(AnyObj(IndexObj).mSignal)
    End Sub

    Private Sub Signal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim f As New frmObjectProperty
        IndexObj = CInt(CType(sender, Signal).Tag)

        f.ShowDialog()
    End Sub

    Private Sub Signal_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Signal_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PointMachine_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DisplayObjectProperties(AnyObj(IndexObj).mPointMachine)
    End Sub

    Private Sub PointMachine_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim f As New frmObjectProperty
        IndexObj = CInt(CType(sender, PointMachine).Tag)

        f.ShowDialog()
    End Sub

    Private Sub Track_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DisplayObjectProperties(AnyObj(IndexObj).mTrack)
    End Sub

    Private Sub Track_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim f As New frmObjectProperty
        IndexObj = CInt(CType(sender, Track).Tag)

        f.ShowDialog()
    End Sub

    Private Sub Label_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DisplayObjectProperties(AnyObj(IndexObj).mLabel)
    End Sub

    Private Sub Label_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim f As New frmObjectProperty
        IndexObj = CInt(CType(sender, LabelName).Tag)

        f.ShowDialog()
    End Sub

    Private Sub CheckBox_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DisplayObjectProperties(AnyObj(IndexObj).mCheckBox)
    End Sub

    Private Sub CkBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim f As New frmObjectProperty
        IndexObj = CInt(CType(sender, ckBox).Tag)

        f.ShowDialog()
    End Sub

    Private Sub Buzzer_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DisplayObjectProperties(AnyObj(IndexObj).mBuzzer)
    End Sub

    Private Sub Buzzer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim f As New frmObjectProperty
        IndexObj = CInt(CType(sender, Buzzer).Tag)

        f.ShowDialog()
    End Sub

    Private Sub Shape_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DisplayObjectProperties(AnyObj(IndexObj).mShapes)
    End Sub

    Private Sub Shape_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim f As New frmObjectProperty
        IndexObj = CInt(CType(sender, Shapes).Tag)

        f.ShowDialog()
    End Sub

    Private Sub Counter_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DisplayObjectProperties(AnyObj(IndexObj).mCounter)
    End Sub

    Private Sub Counter_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim f As New frmObjectProperty
        IndexObj = CInt(CType(sender, Counter).Tag)

        f.ShowDialog()
    End Sub

    Private Sub Buttons_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        DisplayObjectProperties(AnyObj(IndexObj).mButton)
    End Sub

    Private Sub Buttons_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim f As New frmObjectProperty
        IndexObj = CInt(CType(sender, Buttons).Tag)

        f.ShowDialog()
    End Sub
#End Region


End Class
