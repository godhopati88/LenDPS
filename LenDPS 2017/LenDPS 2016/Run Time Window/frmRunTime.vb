Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text.ASCIIEncoding
Imports Railway


Public Class frmRunTime
    Dim m_ExpressionTree As ExpressionTree = Nothing
    Dim newResult(0) As Boolean
    Dim newResultTime(0) As Boolean
    Dim pbCounter(0) As Integer
    Dim DataCounter(0) As Integer

    Dim onPush As Boolean
    Dim countPush As Integer = 0
    Dim idxPush As Integer = -1

    Dim firstPair As Integer = -1
    Dim secondPair As Integer = -1
    Dim onPair As Boolean
    Dim onWaiting As Boolean
    Dim countPair As Integer = 0

    Private tt As New ToolTip()

    Dim train1 As LabelName
    Dim tick As UInt16
    Dim sock As New Sockets.UdpClient(0)
    Dim sockRecv As New Sockets.UdpClient(0)

    ' timeout connection variable
    Dim rxFlag As Boolean = False
    Dim cTicks As Integer = 0
    Dim ticks As Integer = 0
    Dim cTicksMax As Integer = 20
    Dim bsFlag As Boolean = False

    Private Sub frmRunTime_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ReDim AnyRunObj(0)
        ReDim pbCounter(0)
        Me.Runtime.Enabled = False
        Me.Delay.Enabled = False
        frmDaftarVariable.Close()
        sock.Close()
        sockRecv.Close() 'add new
    End Sub

    Private Sub frmRunTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        'Me.WindowState = FormWindowState.Maximized
        Me.BackColor = frmMain.WdwContainer.BackColor
        loadLayout()
        Me.Runtime.Enabled = True
        Me.Delay.Enabled = True
        Me.Visible = True
        ReDim newResult(IdxEquation - 1)
        ReDim newResultTime(IdxTime - 1)
        sock = New Sockets.UdpClient(setUdp.LocalPort)
        sockRecv = New System.Net.Sockets.UdpClient(3000)
        udpInit()
        'udpCom.Enabled = True

        'For i As Integer = 0 To IdxParam - 1
        '    Debug.Print(Parameter(i).Name & " : " & Parameter(i).Type)
        'Next
        'train1 = findTrain()
    End Sub

    Private Sub CheckInitVariable(ByVal name As String)
        For i As Integer = 0 To UBound(Parameter) - 1
            If name = Parameter(i).Name Then
                Parameter(i).value = True
                Exit For
            End If
        Next
    End Sub

    Private Sub loadLayout()
        For i As Integer = 1 To UBound(ObjRec)
            If ObjRec(i).OnVisible Then
                Select Case ObjRec(i).Name
                    Case "Signal" : AddSignal(Me.pRunMainWdw, i)
                    Case "PointMachine" : AddPointMachine(Me.pRunMainWdw, i)
                    Case "Track"
                        AddTrack(Me.pRunMainWdw, i)
                        EksekusiVariableAnimasi(ObjRec(i).TagTx1, True)
                    Case "Label" : AddLabel(Me.pRunMainWdw, i)
                    Case "CheckBox" : AddCheckBox(Me.pRunMainWdw, i)
                    Case "Counter" : AddCounter(Me.pRunMainWdw, i)
                    Case "Buzzer" : AddBuzzer(Me.pRunMainWdw, i)
                    Case "EquipmentName" : AddEquipmentName(Me.pRunMainWdw, i)
                    Case "PictureBox" : AddPictureBox(Me.pRunMainWdw, i)
                    Case "Shape" : AddShape(Me.pRunMainWdw, i)
                    Case "Button" : AddButton(Me.pRunMainWdw, i)
                        If ObjRec(i).Type = Buttons.eType.PushButton Then
                            pbCounter(UBound(pbCounter)) = AnyRunObj(UBound(AnyRunObj)).mButton.Tag
                            ReDim Preserve pbCounter(UBound(pbCounter) + 1)
                        End If
                End Select
            End If
            If (ObjRec(i).Active) Then
                CheckInitVariable(ObjRec(i).TagTx)
            End If
        Next
        ReDim DataCounter(UBound(pbCounter) - 1)
    End Sub

#Region "       Load Object"
    Private Sub AddSignal(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mSignal = New Signal
        f.Controls.Add(AnyRunObj(ObjIndex).mSignal)
        With AnyRunObj(ObjIndex).mSignal
            .Name = "Signal"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Height = ObjRec(index).Height
            .Diameter = ObjRec(index).Diameter
            .ShuntThickness = ObjRec(index).Thickness
            .Type = ObjRec(index).Type
            .Group = ObjRec(index).Group
            .SignalPosition = ObjRec(index).Direction
            .TextPosition = ObjRec(index).TextPosition
            .TextName = ObjRec(index).Text
            .OnRunTime = True
            .Font = New Font(ObjRec(index).fName, ObjRec(index).fSize, ObjRec(index).fStyle)
            .Visible = ObjRec(index).OnVisible
            .Tag = ObjIndex
            '------------ Object Color ----------
            .Idx1Color = ObjRec(index).IdColor1
            .Idx2Color = ObjRec(index).IdColor2
            .Idx3Color = ObjRec(index).IdColor3
            .Idx4Color = ObjRec(index).IdColor4
            .Idx5Color = ObjRec(index).IdColor5
            '------------ Run Time --------------
            .TagId1Color = ObjRec(index).TagId1Color
            .TagId2Color = ObjRec(index).TagId2Color
            .TagId3Color = ObjRec(index).TagId3Color
            .TagId4Color = ObjRec(index).TagId4Color
            .TagId1Val = ObjRec(index).TagId1Val
            .TagId2Val = ObjRec(index).TagId2Val
            .TagId3Val = ObjRec(index).TagId3Val
            .TagId4Val = ObjRec(index).TagId4Val
            .TagTx1 = ObjRec(index).TagTx1
            .TagTx2 = ObjRec(index).TagTx2
            .TagTx3 = ObjRec(index).TagTx3
            .TagTx4 = ObjRec(index).TagTx4
        End With
    End Sub

    Private Sub AddPointMachine(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mPointMachine = New PointMachine
        f.Controls.Add(AnyRunObj(ObjIndex).mPointMachine)
        With AnyRunObj(ObjIndex).mPointMachine
            .Name = "PointMachine"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Height = ObjRec(index).Height
            .Type = ObjRec(index).Type
            .TextName = ObjRec(index).Text
            .Thickness = ObjRec(index).Thickness
            .Group = ObjRec(index).Group
            .OnRunTime = True
            .Visible = ObjRec(index).OnVisible
            .Tag = ObjIndex
            '.ShowObject = PointMachine.eShow.None
            '-------- Font -----------
            .Font = New Font(ObjRec(index).fName, ObjRec(index).fSize, ObjRec(index).fStyle)
            '------------ Object Color ----------
            .Idx1Color = ObjRec(index).IdColor1
            .Idx2Color = ObjRec(index).IdColor2
            .Idx3Color = ObjRec(index).IdColor3
            .Idx4Color = ObjRec(index).IdColor4
            .Idx5Color = ObjRec(index).IdColor5
            '------------ Run Time --------------
            .TagId1Color = ObjRec(index).TagId1Color
            .TagId2Color = ObjRec(index).TagId2Color
            .TagId3Color = ObjRec(index).TagId3Color
            .TagId4Color = ObjRec(index).TagId4Color
            .TagId5Color = ObjRec(index).TagId5Color
            .TagId1Val = ObjRec(index).TagId1Val
            .TagId2Val = ObjRec(index).TagId2Val
            .TagId3Val = ObjRec(index).TagId3Val
            .TagId4Val = ObjRec(index).TagId4Val
            .TagId5Val = ObjRec(index).TagId5Val
            .TagTx1 = ObjRec(index).TagTx1
            .TagTx2 = ObjRec(index).TagTx2
            .TagTx3 = ObjRec(index).TagTx3
            .TagTx4 = ObjRec(index).TagTx4
            .TagTx5 = ObjRec(index).TagTx5
            '------------------------------------
        End With
    End Sub

    Private Sub AddTrack(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mTrack = New Track
        f.Controls.Add(AnyRunObj(ObjIndex).mTrack)
        With AnyRunObj(ObjIndex).mTrack
            .Name = "Track"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Height = ObjRec(index).Height
            .Type = ObjRec(index).Type
            .LinePosition = ObjRec(index).Direction
            .TextName = ObjRec(index).Text
            .TextPosition = ObjRec(index).TextPosition
            .Group = ObjRec(index).Group
            .Font = New Font(ObjRec(index).fName, ObjRec(index).fSize, ObjRec(index).fStyle)
            .Thickness = ObjRec(index).Thickness
            .OnRunTime = True
            .Visible = ObjRec(index).OnVisible
            .Tag = ObjIndex
            '------------ Object Color ----------
            .Idx1Color = ObjRec(index).IdColor1
            .Idx2Color = ObjRec(index).IdColor2
            .Idx3Color = ObjRec(index).IdColor3
            .Idx4Color = ObjRec(index).IdColor4
            .Idx5Color = ObjRec(index).IdColor5
            '------------ Run Time --------------
            .TagId1Color = ObjRec(index).TagId1Color
            .TagId2Color = ObjRec(index).TagId2Color
            .TagId3Color = ObjRec(index).TagId3Color
            .TagId4Color = ObjRec(index).TagId4Color
            .TagId1Val = ObjRec(index).TagId1Val
            .TagId2Val = ObjRec(index).TagId2Val
            .TagId3Val = ObjRec(index).TagId3Val
            .TagId4Val = ObjRec(index).TagId4Val
            .TagTx1 = ObjRec(index).TagTx1
            .TagTx2 = ObjRec(index).TagTx2
            .TagTx3 = ObjRec(index).TagTx3
            .TagTx4 = ObjRec(index).TagTx4
            .TagTx = ObjRec(index).TagTx
            .TagIdVal = ObjRec(index).TagIdVal
            '------------------------------------
            AddHandler .Click, AddressOf Track_Click
            'AddHandler .MouseHover, AddressOf Track_MouseHover
        End With
    End Sub

    Private Sub AddLabel(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mLabel = New LabelName
        f.Controls.Add(AnyRunObj(ObjIndex).mLabel)
        With AnyRunObj(ObjIndex).mLabel
            .Name = "Label"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Height = ObjRec(index).Height
            .TextName = ObjRec(index).Text
            .Font = New Font(ObjRec(index).fName, ObjRec(index).fSize, ObjRec(index).fStyle)
            .Group = ObjRec(index).Group
            .Type = ObjRec(index).Type
            .OnRunTime = True
            .Visible = ObjRec(index).OnVisible
            .Tag = ObjIndex
            '------------ Object Color ----------
            .Idx1Color = ObjRec(index).IdColor1
            .Idx2Color = ObjRec(index).IdColor2
            .Idx3Color = ObjRec(index).IdColor3
            '------------ Run Time --------------
            .TagId1Color = ObjRec(index).TagId1Color
            .TagId2Color = ObjRec(index).TagId2Color
            .TagId1Val = ObjRec(index).TagId1Val
            .TagId2Val = ObjRec(index).TagId2Val
            .TagTx1 = ObjRec(index).TagTx1
            .TagTx2 = ObjRec(index).TagTx2
            '------------------------------------
        End With
    End Sub

    Private Sub AddCheckBox(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mCheckBox = New ckBox
        f.Controls.Add(AnyRunObj(ObjIndex).mCheckBox)
        With AnyRunObj(ObjIndex).mCheckBox
            .Name = "CheckBox"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Height = ObjRec(index).Height
            .TextName = ObjRec(index).Text
            .Font = New Font(ObjRec(index).fName, ObjRec(index).fSize, ObjRec(index).fStyle)
            .Checked = ObjRec(index).Active
            .Group = ObjRec(index).Group
            .OnRunTime = True
            .Visible = ObjRec(index).OnVisible
            .Tag = ObjIndex
            '------------ Object Color ----------
            .Idx1Color = ObjRec(index).IdColor1
            .Idx2Color = ObjRec(index).IdColor2
            .TagTx = ObjRec(index).TagTx
            .TagIdVal = ObjRec(index).TagIdVal
            AddHandler .Click, AddressOf CheckBox_Click
        End With
    End Sub

    Private Sub AddCounter(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mCounter = New Counter
        f.Controls.Add(AnyRunObj(ObjIndex).mCounter)
        With AnyRunObj(ObjIndex).mCounter
            .Name = "Counter"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Height = ObjRec(index).Height
            .Group = ObjRec(index).Group
            .OnRunTime = True
            .Visible = ObjRec(index).OnVisible
            .Tag = ObjIndex
            '------------ Object Color ----------
            .Idx1Color = ObjRec(index).IdColor1
            .Idx2Color = ObjRec(index).IdColor2
            .Idx3Color = ObjRec(index).IdColor3
            '------------------------------------
        End With
    End Sub

    Private Sub AddBuzzer(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mBuzzer = New Buzzer
        f.Controls.Add(AnyRunObj(ObjIndex).mBuzzer)
        With AnyRunObj(ObjIndex).mBuzzer
            .Name = "Buzzer"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Height = ObjRec(index).Height
            .Group = ObjRec(index).Group
            .OnRunTime = True
            .Visible = ObjRec(index).OnVisible
            .Tag = ObjIndex
            '------------ Object Color ----------
            .Idx1Color = ObjRec(index).IdColor1
            .Idx2Color = ObjRec(index).IdColor2
            .Idx3Color = ObjRec(index).IdColor3
            '------------ Run Time --------------
            .TagId1Color = ObjRec(index).TagId1Color
            .TagId2Color = ObjRec(index).TagId2Color
            .TagId1Val = ObjRec(index).TagId1Val
            .TagId2Val = ObjRec(index).TagId2Val
            .TagTx1 = ObjRec(index).TagTx1
            .TagTx2 = ObjRec(index).TagTx2
            '------------------------------------
        End With
    End Sub

    Private Sub AddEquipmentName(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mEquipmentName = New EquipmentName
        f.Controls.Add(AnyRunObj(ObjIndex).mEquipmentName)
        With AnyRunObj(ObjIndex).mEquipmentName
            .Name = "EquipmentName"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Left = ObjRec(index).Height
            .Visible = ObjRec(index).OnVisible
            .Tag = ObjIndex
        End With
    End Sub

    Private Sub AddPictureBox(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mPictureBox = New PictureBox
        f.Controls.Add(AnyRunObj(ObjIndex).mPictureBox)
        With AnyRunObj(ObjIndex).mPictureBox
            .Name = "PictureBox"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Height = ObjRec(index).Height
            .Visible = ObjRec(index).OnVisible
            .Tag = ObjIndex
        End With
    End Sub

    Private Sub AddShape(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mShapes = New Shapes
        f.Controls.Add(AnyRunObj(ObjIndex).mShapes)
        With AnyRunObj(ObjIndex).mShapes
            .Name = "Shape"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Height = ObjRec(index).Height
            .Shape = ObjRec(index).Type
            .Diameter = ObjRec(index).Diameter
            .Direction = ObjRec(index).Direction
            .OnRunTime = True
            .Group = ObjRec(index).Group
            .Visible = ObjRec(index).OnVisible
            .Tag = ObjIndex
            '------------ Object Color ----------
            .Idx1Color = ObjRec(index).IdColor1
            .Idx2Color = ObjRec(index).IdColor2
            .Idx3Color = ObjRec(index).IdColor3
            '------------ Run Time --------------
            .TagId1Color = ObjRec(index).TagId1Color
            .TagId2Color = ObjRec(index).TagId2Color
            .TagId1Val = ObjRec(index).TagId1Val
            .TagId2Val = ObjRec(index).TagId2Val
            .TagTx1 = ObjRec(index).TagTx1
            .TagTx2 = ObjRec(index).TagTx2
            '------------------------------------
        End With
    End Sub

    Private Sub AddButton(ByVal f As Panel, ByVal index As Integer)
        Dim ObjIndex As Integer

        ObjIndex = UBound(AnyRunObj) + 1
        ReDim Preserve AnyRunObj(ObjIndex)

        AnyRunObj(ObjIndex).mButton = New Buttons
        f.Controls.Add(AnyRunObj(ObjIndex).mButton)
        With AnyRunObj(ObjIndex).mButton
            .Name = "ToggleButton"
            .Top = ObjRec(index).Top
            .Left = ObjRec(index).Left
            .Width = ObjRec(index).Width
            .Height = ObjRec(index).Height
            .TextName = ObjRec(index).Text
            .Font = New Font(ObjRec(index).fName, ObjRec(index).fSize, ObjRec(index).fStyle)
            .OnToggle = ObjRec(index).Active
            .OnRunTime = True
            .Group = ObjRec(index).Group
            .Visible = ObjRec(index).OnVisible
            .Type = ObjRec(index).Type
            .Shape = ObjRec(index).Direction
            .Tag = ObjIndex
            '------------ Object Color ----------
            .Idx1Color = ObjRec(index).IdColor1
            .Idx2Color = ObjRec(index).IdColor2
            .Idx3Color = ObjRec(index).IdColor3
            '------------ Run Time --------------
            .TagId1Color = ObjRec(index).TagId1Color
            .TagId2Color = ObjRec(index).TagId2Color
            .TagIdVal = ObjRec(index).TagIdVal
            .TagId1Val = ObjRec(index).TagId1Val
            .TagId2Val = ObjRec(index).TagId2Val
            .TagTx = ObjRec(index).TagTx
            .TagTx1 = ObjRec(index).TagTx1
            .TagTx2 = ObjRec(index).TagTx2
            '------------------------------------
            AddHandler .Click, AddressOf Buttons_Click
        End With
    End Sub
#End Region

    Dim idx_flagpair As Integer = 0
    Dim idx_TimeOutPair As Integer = 0
    Private Sub Runtime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Runtime.Tick
        'check timeout connection
        If Not rxFlag Then cTicks += 1
        If cTicks >= cTicksMax Then
            cTicks = cTicksMax
            'Debug.Print("timeout connection...!!!")
            lostConnection()
            bsFlag = True
        Else
            If bsFlag Then
                clearBlueScreen()
                bsFlag = False
            End If
            'cTicks = 0

            Dim result(0) As Boolean
            '-------- Tick -----------
            tick = tick Xor 1 << 0
            'Debug.Print("detak : " & tick & "normal connection...!!!")
            '-------- Boolean Equation ---------------
            ReDim result(IdxEquation - 1)
            For i As Integer = 0 To IdxEquation - 1
                ' eksekusi parse tree
                m_ExpressionTree = New ExpressionTree(Equation_list(i))

                ' save the result
                result(i) = m_ExpressionTree.Evaluate()

                If newResult(i) <> result(i) Then
                    newResult(i) = result(i)
                    setdatavar(Result_List(i), result(i))
                    EksekusiVariableAnimasi(Result_List(i), result(i))
                    'Debug.Print(Result_List(i))
                    ' eksekusi IO
                End If
            Next

            '-------- Timer Equation ---------------
            ReDim result(IdxTime - 1)
            For i As Integer = 0 To IdxTime - 1
                ' parse tree
                m_ExpressionTree = New ExpressionTree(TimeList(i).equation)
                'save the result
                result(i) = m_ExpressionTree.Evaluate()
                If result(i) Then
                    TimeList(i).status = True
                Else
                    TimeList(i).status = False
                    TimeList(i).count = 0

                    If newResultTime(i) <> result(i) Then
                        newResultTime(i) = result(i)
                        setdatavar(TimeList(i).varresult, False)
                        EksekusiVariableAnimasi(TimeList(i).varresult, False)
                    End If
                End If
            Next


            '-------- Push Button Time Out ------------
            'For i As Integer = 0 To UBound(pbCounter) - 1
            '    If AnyRunObj(pbCounter(i)).mButton.OnToggle Then
            '        DataCounter(i) += 1
            '    Else
            '        If DataCounter(i) > 6 Then
            '            setdatavar(AnyRunObj(pbCounter(i)).mButton.TagTx, False)
            '            EksekusiVariableAnimasi(AnyRunObj(pbCounter(i)).mButton.TagTx, False)
            '            DataCounter(i) = 0
            '        End If
            '    End If
            'Next

            ' push button
            If onPush Then
                countPush += 1
                If countPush = 4 Then
                    'release push button
                    AnyRunObj(idxPush).mButton.OnToggle = False
                    setdatavar(AnyRunObj(idxPush).mButton.TagTx, False)
                End If
            End If

            ' pair button 
            If onWaiting Then
                countPair += 1
                If countPair = 8 Then
                    'release pairing buttton
                    AnyRunObj(firstPair).mButton.OnToggle = False
                    AnyRunObj(secondPair).mButton.OnToggle = False
                    onWaiting = False
                    'set var
                    setdatavar(AnyRunObj(firstPair).mButton.TagTx, False)
                    setdatavar(AnyRunObj(secondPair).mButton.TagTx, False)
                End If
            End If

            If frmDaftarVariable.Visible Then frmDaftarVariable.VScrollBar1_Scroll()

            'update IO
            For i As Integer = 0 To IdxParam - 1
                If Parameter(i).Type = TokenList.T_VitalInput Then
                    EksekusiVariableAnimasi(Parameter(i).Name, Parameter(i).value)
                End If
            Next

            'automatic train moving
            'train1.Left = train1.Left + 1
            'If train1.Left = 1400 Then
            '    train1.Left = 16
            'End If

        End If
        rxFlag = False
        'Communication 
        writeUdp()
    End Sub


    Private Sub Delay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delay.Tick
        Dim result(0) As Boolean

        ReDim result(IdxTime - 1)
        For i As Integer = 0 To IdxTime - 1
            If TimeList(i).status Then
                TimeList(i).count = IIf(TimeList(i).count >= TimeList(i).overflow, TimeList(i).overflow, TimeList(i).count + 1)
            End If

            If TimeList(i).count = TimeList(i).overflow Then
                result(i) = True
                If newResultTime(i) <> result(i) Then
                    newResultTime(i) = result(i)
                    setdatavar(TimeList(i).varresult, result(i))
                    EksekusiVariableAnimasi(TimeList(i).varresult, result(i))
                End If
            End If
        Next
        If frmDaftarVariable.Visible Then frmDaftarVariable.VScrollBar1_Scroll()
    End Sub

    Private Sub EksekusiWesel(ByVal index As Integer)
        Try
            If (AnyRunObj(index).mPointMachine.TagId1Val Or AnyRunObj(index).mPointMachine.TagId2Val) And (AnyRunObj(index).mPointMachine.TagId3Val Or AnyRunObj(index).mPointMachine.TagId4Val) Then
                AnyRunObj(index).mPointMachine.ShowObject = PointMachine.eShow.Both
            ElseIf (AnyRunObj(index).mPointMachine.TagId1Val Or AnyRunObj(index).mPointMachine.TagId2Val) Then
                AnyRunObj(index).mPointMachine.ShowObject = PointMachine.eShow.Normal
            ElseIf (AnyRunObj(index).mPointMachine.TagId3Val Or AnyRunObj(index).mPointMachine.TagId4Val) Then
                AnyRunObj(index).mPointMachine.ShowObject = PointMachine.eShow.Reverse
            Else
                AnyRunObj(index).mPointMachine.ShowObject = PointMachine.eShow.None
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub EksekusiVariableAnimasi(ByVal s As String, ByVal Value As Boolean)
        For i As Integer = 1 To UBound(AnyRunObj)
            Select Case ObjRec(i).Name
                Case "Signal"
                    If ObjRec(i).TagTx1 = s Then AnyRunObj(i).mSignal.TagId1Val = Value
                    If ObjRec(i).TagTx2 = s Then AnyRunObj(i).mSignal.TagId2Val = Value
                    If ObjRec(i).TagTx3 = s Then AnyRunObj(i).mSignal.TagId3Val = Value
                    If ObjRec(i).TagTx4 = s Then AnyRunObj(i).mSignal.TagId4Val = Value
                Case "PointMachine"
                    If ObjRec(i).TagTx1 <> "" Then
                        If ObjRec(i).TagTx1 = s Then AnyRunObj(i).mPointMachine.TagId1Val = Value
                    End If

                    If ObjRec(i).TagTx2 <> "" Then
                        If ObjRec(i).TagTx2 = s Then AnyRunObj(i).mPointMachine.TagId2Val = Value
                    End If

                    If ObjRec(i).TagTx3 <> "" Then
                        If ObjRec(i).TagTx3 = s Then AnyRunObj(i).mPointMachine.TagId3Val = Value
                    End If
                    If ObjRec(i).TagTx4 <> "" Then
                        If ObjRec(i).TagTx4 = s Then AnyRunObj(i).mPointMachine.TagId4Val = Value
                    End If

                    If ObjRec(i).TagTx5 <> "" Then
                        If ObjRec(i).TagTx5 = s Then AnyRunObj(i).mPointMachine.TagId5Val = Value
                    End If
                    EksekusiWesel(i)
                Case "Track"
                    If ObjRec(i).TagTx = s Then AnyRunObj(i).mTrack.TagIdVal = Value
                    If ObjRec(i).TagTx1 = s Then AnyRunObj(i).mTrack.TagId1Val = Value
                    If ObjRec(i).TagTx2 = s Then AnyRunObj(i).mTrack.TagId2Val = Value
                    If ObjRec(i).TagTx3 = s Then AnyRunObj(i).mTrack.TagId3Val = Value
                    If ObjRec(i).TagTx4 = s Then AnyRunObj(i).mTrack.TagId4Val = Value
                Case "Shape"
                    If ObjRec(i).TagTx1 = s Then AnyRunObj(i).mShapes.TagId1Val = Value
                    If ObjRec(i).TagTx2 = s Then AnyRunObj(i).mShapes.TagId2Val = Value
                Case "Label"
                    If ObjRec(i).TagTx1 = s Then AnyRunObj(i).mLabel.TagId1Val = Value
                    If ObjRec(i).TagTx2 = s Then AnyRunObj(i).mLabel.TagId2Val = Value
                Case "Button"
                    If ObjRec(i).TagTx = s Then AnyRunObj(i).mButton.TagIdVal = Value
                    If ObjRec(i).TagTx1 = s Then AnyRunObj(i).mButton.TagId1Val = Value
                    If ObjRec(i).TagTx2 = s Then AnyRunObj(i).mButton.TagId2Val = Value
                Case "CheckBox"
                    If ObjRec(i).TagTx = s Then AnyRunObj(i).mCheckBox.TagIdVal = Value
                Case "Buzzer"
                    If ObjRec(i).TagTx1 = s Then AnyRunObj(i).mBuzzer.TagId1Val = Value
                    If ObjRec(i).TagTx2 = s Then AnyRunObj(i).mBuzzer.TagId2Val = Value
            End Select
        Next
    End Sub

    Private Sub setdatavar(ByVal s As String, ByVal value As Boolean)
        For i As Integer = 0 To IdxParam - 1
            If Parameter(i).Name = s Then
                Parameter(i).value = value
                Exit For
            End If
        Next
    End Sub

#Region "Handler Object"
    Dim bTrack As Track
    Private Sub Track_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        bTrack = DirectCast(sender, Track)
        If bTrack.OnRunTime And bTrack.TagTx <> "" Then
            If bTrack.OnToggle Then
                Select Case bTrack.TagTx
                    Case bTrack.TagTx1
                        bTrack.TagId1Val = Not bTrack.OnToggle
                        EksekusiVariableAnimasi(bTrack.TagTx1, Not bTrack.OnToggle)
                        setdatavar(bTrack.TagTx1, Not bTrack.OnToggle)
                        If frmDaftarVariable.Visible Then frmDaftarVariable.VScrollBar1_Scroll() 'link to variable 

                    Case bTrack.TagTx2
                        bTrack.TagId2Val = Not bTrack.OnToggle
                        EksekusiVariableAnimasi(bTrack.TagTx2, Not bTrack.OnToggle)
                        setdatavar(bTrack.TagTx2, Not bTrack.OnToggle)
                        If frmDaftarVariable.Visible Then frmDaftarVariable.VScrollBar1_Scroll() ' link to variable 

                        'Case Else
                        '    setdatavar(bTrack.TagTx, Not bTrack.OnToggle)
                End Select
                bTrack.OnToggle = False
            Else
                Select Case bTrack.TagTx
                    Case bTrack.TagTx1
                        bTrack.TagId1Val = Not bTrack.OnToggle
                        EksekusiVariableAnimasi(bTrack.TagTx1, Not bTrack.OnToggle)
                        setdatavar(bTrack.TagTx1, Not bTrack.OnToggle)
                        If frmDaftarVariable.Visible Then frmDaftarVariable.VScrollBar1_Scroll() ' link to variable 

                    Case bTrack.TagTx2
                        bTrack.TagId2Val = Not bTrack.OnToggle
                        setdatavar(bTrack.TagTx2, Not bTrack.OnToggle)
                        EksekusiVariableAnimasi(bTrack.TagTx2, Not bTrack.OnToggle)
                        If frmDaftarVariable.Visible Then frmDaftarVariable.VScrollBar1_Scroll() ' link to variable 
                        'Case Else
                        '    setdatavar(bTrack.TagTx, Not bTrack.OnToggle)
                End Select
                bTrack.OnToggle = True
            End If
        End If
    End Sub

    'Private Sub Track_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
    '    bTrack = DirectCast(sender, Track)
    '    tt.SetToolTip(bTrack, "Track" & bTrack.TagTx)
    'End Sub

    Dim bCheckBox As ckBox
    Private Sub CheckBox_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        bCheckBox = DirectCast(sender, ckBox)

        If bCheckBox.Checked Then
            bCheckBox.Checked = False : bCheckBox.TagIdVal = False
        Else
            bCheckBox.Checked = True : bCheckBox.TagIdVal = True
        End If
        EksekusiVariableAnimasi(bCheckBox.TagTx, bCheckBox.TagIdVal)
        setdatavar(bCheckBox.TagTx, bCheckBox.Checked)
    End Sub

    Dim bButton As Buttons
    Private Sub Buttons_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        bButton = DirectCast(sender, Buttons)
        Select Case bButton.Type
            Case Buttons.eType.PushButton
                bButton.OnToggle = True
                countPush = 0 : idxPush = bButton.Tag : onPush = True
                setdatavar(bButton.TagTx, True)
                EksekusiVariableAnimasi(bButton.TagTx, bButton.TagIdVal)

            Case Buttons.eType.ToggleButton
                If bButton.OnToggle Then bButton.OnToggle = False : bButton.TagIdVal = False Else bButton.OnToggle = True : bButton.TagIdVal = True
                setdatavar(bButton.TagTx, bButton.TagIdVal)

            Case Buttons.eType.PairButton
                If onPair Then
                    onPair = False
                    If bButton.Tag = firstPair Then
                        bButton.OnToggle = False
                        firstPair = -1
                        'set var
                        bButton.TagIdVal = False
                        setdatavar(bButton.TagTx, bButton.TagIdVal)
                    Else
                        bButton.OnToggle = True
                        countPair = 0
                        secondPair = bButton.Tag
                        onWaiting = True
                        'set var
                        bButton.TagIdVal = True
                        setdatavar(bButton.TagTx, bButton.TagIdVal)
                    End If
                Else
                    If bButton.OnToggle = False Then
                        bButton.OnToggle = True
                        firstPair = bButton.Tag
                        onPair = True
                        'set var
                        bButton.TagIdVal = True
                        setdatavar(bButton.TagTx, bButton.TagIdVal)
                    End If
                End If
        End Select
    End Sub

    Private Sub DaftarVariableToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DaftarVariableToolStripMenuItem1.Click
        frmDaftarVariable.Show()
    End Sub

    Private Sub TerminalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminalToolStripMenuItem.Click
        frmTerminal.Show()
    End Sub

#End Region

#Region "Communication"

    Private Sub udpInit()
        Try

            sock.Connect(setUdp.Ip, setUdp.Port)
        Catch ex As Exception
            MessageBox.Show("Cannot Connect to UDP server...!")
        End Try
    End Sub
    Private Sub readUdp()
        Try
            'Dim remoteIpEndPoint As New IPEndPoint(IPAddress.Any, setUdp.LocalPort)
            Dim remoteIpEndPoint As New IPEndPoint(IPAddress.Any, 3000)
            Dim recvBytes As Byte() = sockRecv.Receive(remoteIpEndPoint)

            'Debug.Print("data = : " & System.Text.Encoding.Unicode.GetString(recvBytes) & vbCrLf)

            Dim bits As New BitArray(recvBytes)
            'Dim dataBits As Boolean()

            Dim crc As Boolean = checkCrc16Kermit(recvBytes)
            If crc Then
                rxFlag = True
                cTicks = 0
                'dataBits = swapBits(bits, bits.Length)
                For i As Integer = 0 To IdxParam - 1
                    If Parameter(i).Type = TokenList.T_VitalInput Then
                        'Parameter(i).value = dataBits(i)
                        Parameter(i).value = bits(i)
                    End If
                Next
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub writeUdp()
        Try

            Dim sizeBool As Integer = 0
            For i As Integer = 0 To IdxParam - 1
                If Parameter(i).Type = TokenList.T_VitalOutput Then
                    sizeBool += 1
                End If
            Next
            Dim newSize As Integer = (sizeBool) \ 8

            If (sizeBool) Mod 8 > 0 Then
                newSize += 1
            End If

            Dim bools((newSize * 8) - 1 + 8 + 16) As Boolean
            bools(7) = CBool(tick)

            Dim idx As Integer = 8
            For i As Integer = 0 To IdxParam - 1
                If Parameter(i).Type = TokenList.T_VitalOutput Then
                    bools(idx) = Parameter(i).value
                    idx += 1
                End If
            Next

            Dim dataBits As Boolean()
            'dataBits = swapBits(bools, bools.Length)
            dataBits = bools
            Dim bits As New BitArray(dataBits)
            Dim bytes() As Byte = ConvertToByte(bits)
            Dim getCrc As Integer = getCrc16Kermit(bytes.Length - 3, bytes)
            bytes(bytes.Length - 3) = (getCrc And &HFF00) >> 8
            bytes(bytes.Length - 2) = getCrc And &HFF

            'Debug.Print("ready to read...")

            sock.Send(bytes, bytes.Length - 1)
            'sock.BeginReceive(New AsyncCallback(AddressOf readUdp), vbNull)
            sockRecv.BeginReceive(New AsyncCallback(AddressOf readUdp), vbNull)

        Catch ex As Exception

        End Try

    End Sub

    Private Function ConvertToByte(bits As BitArray) As Byte()
        Dim bytes() As Byte
        Dim sizeBytes As Integer
        Dim sizeBits As Integer

        sizeBits = bits.Count() - 1
        sizeBytes = sizeBits / 8

        Dim j As Integer = 0
        bytes = New Byte(sizeBytes) {}
        For i As Integer = 0 To sizeBytes
            bits.CopyTo(bytes, 0)
        Next

        Return bytes
    End Function

    Private Function swapBits(myList As IEnumerable, myLength As Integer) As Boolean()
        Dim i As Integer = 8
        Dim idx As Integer = 0
        Dim obj As [Object]
        Dim mybool(myLength) As Boolean

        For Each obj In myList
            If i <= 0 Then
                i = 8
                Console.WriteLine()
                idx = idx + 1
            End If
            i -= 1

            mybool((idx * 8) + i) = obj
        Next obj

        Return mybool

    End Function
#End Region

#Region "automatic train moving"
    Private Function findTrain() As LabelName
        Dim train As New LabelName
        For i As Integer = 1 To UBound(AnyRunObj)
            If ObjRec(i).Name = "Label" Then
                If ObjRec(i).Text = "T" Then
                    train = AnyRunObj(i).mLabel
                    Exit For
                End If
            End If
        Next
        Return train
    End Function
#End Region

#Region "create blue screen"
    Private Sub clearBlueScreen()
        For i As Integer = 0 To UBound(AnyRunObj)
            Select Case ObjRec(i).Name
                Case "Signal"
                    AnyRunObj(i).mSignal.TagId1Color = AnyObj(i).mSignal.TagId1Color
                    AnyRunObj(i).mSignal.TagId2Color = AnyObj(i).mSignal.TagId2Color
                    AnyRunObj(i).mSignal.TagId3Color = AnyObj(i).mSignal.TagId3Color
                    AnyRunObj(i).mSignal.TagId4Color = AnyObj(i).mSignal.TagId4Color

                Case "Track"
                    AnyRunObj(i).mTrack.TagId1Color = AnyObj(i).mTrack.TagId1Color

                Case "PointMachine"
                    If ObjRec(i).TagTx1 <> "" Then
                        AnyRunObj(i).mPointMachine.TagId1Color = AnyObj(i).mPointMachine.TagId1Color
                        AnyRunObj(i).mPointMachine.TagId1Val = AnyObj(i).mPointMachine.TagId1Val
                    End If

                    If ObjRec(i).TagTx2 <> "" Then
                        AnyRunObj(i).mPointMachine.TagId2Color = AnyObj(i).mPointMachine.TagId2Color
                        AnyRunObj(i).mPointMachine.TagId2Val = AnyObj(i).mPointMachine.TagId2Val
                    End If

                    If ObjRec(i).TagTx3 <> "" Then
                        AnyRunObj(i).mPointMachine.TagId3Color = AnyObj(i).mPointMachine.TagId3Color
                        AnyRunObj(i).mPointMachine.TagId3Val = AnyObj(i).mPointMachine.TagId3Val
                    End If

                    If ObjRec(i).TagTx4 <> "" Then
                        AnyRunObj(i).mPointMachine.TagId4Color = AnyObj(i).mPointMachine.TagId4Color
                        AnyRunObj(i).mPointMachine.TagId4Val = AnyObj(i).mPointMachine.TagId4Val
                    End If

                Case "Shape"
                    AnyRunObj(i).mShapes.TagId1Color = AnyObj(i).mShapes.TagId1Color
                    AnyRunObj(i).mShapes.TagId2Color = AnyObj(i).mShapes.TagId2Color

                Case "Button"
                    AnyRunObj(i).mButton.TagId1Color = AnyObj(i).mButton.TagId1Color
            End Select
        Next
    End Sub

    Private Sub lostConnection()
        For i As Integer = 1 To UBound(AnyRunObj)
            Select Case ObjRec(i).Name
                Case "Signal"
                    AnyRunObj(i).mSignal.TagId1Color = Color.Blue
                    AnyRunObj(i).mSignal.TagId1Val = True
                    AnyRunObj(i).mSignal.TagId2Color = Color.Blue
                    AnyRunObj(i).mSignal.TagId2Val = True
                    AnyRunObj(i).mSignal.TagId3Color = Color.Blue
                    AnyRunObj(i).mSignal.TagId3Val = True
                    AnyRunObj(i).mSignal.TagId4Color = Color.Blue
                    AnyRunObj(i).mSignal.TagId4Val = True

                Case "Track"
                    AnyRunObj(i).mTrack.TagId1Color = Color.Blue
                    AnyRunObj(i).mTrack.TagId1Val = True

                Case "PointMachine"
                    If ObjRec(i).TagTx1 <> "" Then
                        AnyRunObj(i).mPointMachine.TagId1Color = Color.Blue
                        AnyRunObj(i).mPointMachine.TagId1Val = True
                    End If

                    If ObjRec(i).TagTx2 <> "" Then
                        AnyRunObj(i).mPointMachine.TagId2Color = Color.Blue
                        AnyRunObj(i).mPointMachine.TagId2Val = True
                    End If

                    If ObjRec(i).TagTx3 <> "" Then
                        AnyRunObj(i).mPointMachine.TagId3Color = Color.Blue
                        AnyRunObj(i).mPointMachine.TagId3Val = True
                    End If

                    If ObjRec(i).TagTx4 <> "" Then
                        AnyRunObj(i).mPointMachine.TagId4Color = Color.Blue
                        AnyRunObj(i).mPointMachine.TagId4Val = True
                    End If

                Case "Shape"
                    AnyRunObj(i).mShapes.TagId1Color = Color.Blue
                    AnyRunObj(i).mShapes.TagId1Val = True
                    AnyRunObj(i).mShapes.TagId2Color = Color.Blue
                    AnyRunObj(i).mShapes.TagId2Val = True

                Case "Button"
                    AnyRunObj(i).mButton.TagId1Color = Color.Blue
                    AnyRunObj(i).mButton.TagId1Val = True
                    AnyRunObj(i).mButton.TagId2Color = Color.Blue
                    AnyRunObj(i).mButton.TagId2Val = True
            End Select
        Next
    End Sub
#End Region
End Class