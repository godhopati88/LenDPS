Imports System.Windows.Forms.Form
Imports FastColoredTextBoxNS
Imports Railway


Module mdlMainProgram
    Public pathLocation As String = ""

#Region "       Global Initialization Window Container"
    Structure Coordinat
        Dim X As Integer
        Dim Y As Integer
    End Structure
    Public winCoordinat As Coordinat

    Structure ObjType
        Dim mSignal As Signal
        Dim mPointMachine As PointMachine
        Dim mTrack As Track
        Dim mBuzzer As Buzzer
        Dim mCheckBox As ckBox
        Dim mCounter As Counter
        Dim mEquipmentName As EquipmentName
        Dim mLabel As LabelName
        Dim mPictureBox As PictureBox
        Dim mShapes As Shapes
        Dim mButton As Buttons
    End Structure
    Public AnyObj(0) As ObjType
    Public AnyRunObj(0) As ObjType 

    Structure ObjProperties
        Dim Name As String
        Dim Text As String
        Dim Width As Integer
        Dim Height As Integer
        Dim Top As Integer
        Dim Left As Integer
        Dim Group As Integer
        Dim OnRunTime As Boolean
        Dim OnVisible As Boolean
        Dim Active As Boolean
        Dim Visible As Boolean
        '-------------------------
        Dim IdColor1 As Color       ' Background Color
        Dim IdColor2 As Color       ' Object Color
        Dim IdColor3 As Color       ' Text Color
        Dim IdColor4 As Color       ' Signal Color
        Dim IdColor5 As Color       ' Optional
        '------- Run Time --------
        Dim TagId1Color As Color
        Dim TagId2Color As Color
        Dim TagId3Color As Color
        Dim TagId4Color As Color
        Dim TagId5Color As Color
        Dim TagIdVal As Boolean
        Dim TagId1Val As Boolean
        Dim TagId2Val As Boolean
        Dim TagId3Val As Boolean
        Dim TagId4Val As Boolean
        Dim TagId5Val As Boolean
        Dim TagTx As String
        Dim TagTx1 As String
        Dim TagTx2 As String
        Dim TagTx3 As String
        Dim TagTx4 As String
        Dim TagTx5 As String
        '-------------------------
        Dim Diameter As Integer
        Dim Thickness As Integer
        Dim Type As Integer
        Dim Direction As Integer
        Dim TextPosition As Integer
        '------- Font -------------
        Dim fName As String
        Dim fSize As Integer
        Dim fStyle As Drawing.FontStyle  ' --------> 0 = Reguler || 1 = Bold || 2 = Italic || 4 = Underline || 8 = StrickOut 
    End Structure
    Public ObjRec(0) As ObjProperties
    Public ObjProp As ObjProperties

    Public IndexObj As Integer = 0

    Public GridSpacing As Integer

    Enum IdObj
        None = 0
        Signal = 1
        PoinMachine = 2
        Track = 3
        Label = 4
        CheckBox = 5
        Counter = 6
        Buzzer = 7
        EquipmentName = 8
        PictureBox = 9
        Shapes = 10
        Buttons = 11
    End Enum
    Public IdObject As IdObj
#End Region

#Region "       Global Initialization Compiler Modul"
    Public Scanner As LexicalAnalysis
    Public Syntax As SyntaxAnalysis
    Public CodeGen As CodeGenerator

    Public bCompiled As Boolean

#Region "String Code"
    Public stringCode As String = "**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                     VITAL INPUT SECTION                              " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                                                                      " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                     VITAL OUTPUT SECTION                             " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                                                                      " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                     VITAL COMMUNICATION SECTION                      " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                                                                      " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                   NONVITAL COMMUNICATION SECTION                     " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                                                                      " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                     BOOLEAN PARAMETER SECTION                        " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"A B C D E F G H                                                       " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
" *                                                                    " & vbCrLf & _
"                     TIMER PARAMETER SECTION                          " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                                                                      " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                     BOOLEAN EQUATION SECTION                         " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"BOOL A          = (B * .N.C * .N.D * (E + F) * (G + A + H))           " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************" & vbCrLf & _
"*                                                                     " & vbCrLf & _
"                     END BOOLEAN EQUATION SECTION                     " & vbCrLf & _
"*                                                                     " & vbCrLf & _
"**********************************************************************"
#End Region

    Enum TokenList
        T_None = -1
        T_Letter = 1
        T_Number = 2
        T_Space = 3
        T_Lparen = 4
        T_Rparen = 5
        T_Assign = 6
        T_Add = 7
        T_Multiple = 8
        T_OPL = 9     ' Logic OPerator
        T_UnknownLetter = 10
        T_And = 11
        T_Or = 12

        T_Variable = 31
        T_Value = 32
        T_Bool = 33
        T_Time = 34
        T_Application = 35
        T_If = 36
        T_Delay = 37
        T_Seconds = 28
        T_Minutes = 39
        T_Status = 40
        T_Goto = 41
        T_Else = 42
        T_Jump = 43

        T_Expression = 61
        T_Operator = 62
        T_OperatorL = 63
        T_Keyword = 64

        T_Equation = 91
        T_Integer = 100
        T_Boolean = 101
        T_Timer = 102
        T_Latch = 103
        T_VitalInput = 104
        T_VitalOutput = 105
        T_VitalCom = 106
        T_NVitalCom = 107
    End Enum
    Public Tokens As TokenList = TokenList.T_None

    Structure Token_Table
        Dim Line As Long
        Dim Token As Integer
        Dim Lexeme As String
        Dim Symbol As Integer
        Dim Type As Integer
    End Structure
    Public T_Token(0) As Token_Table

    Structure Param
        Dim Name As String
        Dim value As Boolean
        Dim IntVal As Integer
        Dim Type As Integer
        Dim OpCode As String
        Dim status As Boolean
        Dim linkStatus As String
    End Structure
    Public Parameter(0) As Param

    Structure Time_Delay
        Dim count As Integer
        Dim overflow As Integer
        Dim varresult As String
        Dim equation As String
        Dim status As Boolean
        Dim tempAddress As String
        Dim countAddress As String
    End Structure
    Public TimeList(0) As Time_Delay

    Public Error_List(0) As String
    Public Equation_list(0) As String
    Public Result_List(0) As String
    Public JumpList As New ArrayList
    Public IdxError, IdxParam, IdxEquation, IdxTime, IdxResult, IdxBranch As Integer
    Public TimeExist As Boolean = False

#End Region

    Enum eEquationType
        NONE = 0
        BOOL = 1
        TIMER = 2
    End Enum
    Public EquType As eEquationType = eEquationType.NONE

    Structure eEquation
        Dim Type As eEquationType
        Dim Expression As String
        Dim Result As String
    End Structure
    Public dbEquation(0) As eEquation

    Structure child
        Dim Left As String
        Dim Right As String
        Dim Operand As String
    End Structure
    Public Branch(0) As child
    Public Temp(0) As child

    Structure sUdp
        Dim Ip As String
        Dim Port As Integer
        Dim LocalPort As Integer
    End Structure
    Public setUdp As sUdp


#Region "Global Initialization Form Variable Content"
    Enum sVarSelectStatus
        none = 0
        hmi = 1
        io_cbi = 2
    End Enum
    Public VarStatus As sVarSelectStatus = sVarSelectStatus.none

    Enum sIO
        none = 0
        input = 1
        output = 2
    End Enum
    Public ioStatus As sIO = sIO.none
#End Region

#Region "       Global Initialization Hardware Configuration"
    Structure sHdw
        Dim Name As String
        Dim Type As String
        Dim Port As String
        Dim Bit As String
    End Structure
    Public DataHdw(0) As sHdw

    Public Enum slotStatus
        free = 0
        boooked = 1
        deleted = 2
    End Enum

    Public Enum deviceStatus
        None = 0
        VIM = 1
        VOM = 2
        sVCM = 3
        sVIM = 4
        sVOM = 5
        IO = 6
        Coupler = 7
    End Enum
    Public device_status As deviceStatus = deviceStatus.None

    Structure sDbHDW
        Dim coupler As Integer  '(0: Master) (1-31: coupler Address)
        Dim address As Integer
        Dim device As deviceStatus
        Dim status As slotStatus
        Dim InOut As slotStatus
        Dim bit0 As String
        Dim bit1 As String
        Dim bit2 As String
        Dim bit3 As String
        Dim bit4 As String
        Dim bit5 As String
        Dim bit6 As String
        Dim bit7 As String
        Dim bit8 As String
        Dim bit9 As String
        Dim bit10 As String
        Dim bit11 As String
        Dim bit12 As String
        Dim bit13 As String
        Dim bit14 As String
        Dim bit15 As String
    End Structure
    Public dbHDW(0) As sDbHDW

    Structure sDbCoupler
        Dim address As Integer
        Dim status As slotStatus
    End Structure
    Public dbCoupler(0) As sDbCoupler

    Public dbComVtl(512) As String
    Public dbComNVtl(512) As String

    Structure bufOpcode
        Dim name As String
        Dim opcode As String
    End Structure
    Public dbIO(0) As bufOpcode
#End Region

#Region "       Modul Editor"

#Region "       Update Object Property"
    Public Sub UpdateObj(ByVal type As String, ByVal index As Integer)
        Select Case type
            Case "Signal"
                ObjRec(index).Name = AnyObj(index).mSignal.Name
                ObjRec(index).Top = AnyObj(index).mSignal.Top
                ObjRec(index).Left = AnyObj(index).mSignal.Left
                ObjRec(index).Width = AnyObj(index).mSignal.Width
                ObjRec(index).Height = AnyObj(index).mSignal.Height
                ObjRec(index).Type = AnyObj(index).mSignal.Type
                ObjRec(index).Text = AnyObj(index).mSignal.TextName
                ObjRec(index).TextPosition = AnyObj(index).mSignal.TextPosition
                ObjRec(index).Direction = AnyObj(index).mSignal.SignalPosition
                ObjRec(index).Diameter = AnyObj(index).mSignal.Diameter
                ObjRec(index).Thickness = AnyObj(index).mSignal.ShuntThickness
                ObjRec(index).Group = AnyObj(index).mSignal.Group
                'ObjRec(index).Visible = AnyObj(index).mSignal.Visible
                ObjRec(index).OnVisible = AnyObj(index).mSignal.OnVisible
                '---------- Font -------
                ObjRec(index).fName = AnyObj(index).mSignal.Font.Name
                ObjRec(index).fSize = AnyObj(index).mSignal.Font.Size
                ObjRec(index).fStyle = AnyObj(index).mSignal.Font.Style
                '--------------------
                ObjRec(index).IdColor1 = AnyObj(index).mSignal.Idx1Color
                ObjRec(index).IdColor2 = AnyObj(index).mSignal.Idx2Color
                ObjRec(index).IdColor3 = AnyObj(index).mSignal.Idx3Color
                ObjRec(index).IdColor4 = AnyObj(index).mSignal.Idx4Color
                ObjRec(index).IdColor5 = AnyObj(index).mSignal.Idx5Color
                '------------ Run Time Object ---------------
                ObjRec(index).TagId1Color = AnyObj(index).mSignal.TagId1Color
                ObjRec(index).TagId2Color = AnyObj(index).mSignal.TagId2Color
                ObjRec(index).TagId3Color = AnyObj(index).mSignal.TagId3Color
                ObjRec(index).TagId4Color = AnyObj(index).mSignal.TagId4Color
                ObjRec(index).TagId1Val = AnyObj(index).mSignal.TagId1Val
                ObjRec(index).TagId2Val = AnyObj(index).mSignal.TagId2Val
                ObjRec(index).TagId3Val = AnyObj(index).mSignal.TagId3Val
                ObjRec(index).TagId4Val = AnyObj(index).mSignal.TagId4Val
                ObjRec(index).TagTx = ""
                ObjRec(index).TagTx1 = AnyObj(index).mSignal.TagTx1
                ObjRec(index).TagTx2 = AnyObj(index).mSignal.TagTx2
                ObjRec(index).TagTx3 = AnyObj(index).mSignal.TagTx3
                ObjRec(index).TagTx4 = AnyObj(index).mSignal.TagTx4
                ObjRec(index).TagTx5 = ""
                '--------------------------------------------

            Case "PointMachine"
                ObjRec(index).Name = AnyObj(index).mPointMachine.Name
                ObjRec(index).Top = AnyObj(index).mPointMachine.Top
                ObjRec(index).Left = AnyObj(index).mPointMachine.Left
                ObjRec(index).Width = AnyObj(index).mPointMachine.Width
                ObjRec(index).Height = AnyObj(index).mPointMachine.Height
                ObjRec(index).Type = AnyObj(index).mPointMachine.Type
                ObjRec(index).Text = AnyObj(index).mPointMachine.TextName
                ObjRec(index).Thickness = AnyObj(index).mPointMachine.Thickness
                ObjRec(index).Group = AnyObj(index).mPointMachine.Group
                'ObjRec(index).Visible = AnyObj(index).mPointMachine.Visible
                ObjRec(index).OnVisible = AnyObj(index).mPointMachine.OnVisible
                '---------- Font -------
                ObjRec(index).fName = AnyObj(index).mPointMachine.Font.Name
                ObjRec(index).fSize = AnyObj(index).mPointMachine.Font.Size
                ObjRec(index).fStyle = AnyObj(index).mPointMachine.Font.Style
                '--------------------
                ObjRec(index).IdColor1 = AnyObj(index).mPointMachine.Idx1Color
                ObjRec(index).IdColor2 = AnyObj(index).mPointMachine.Idx2Color
                ObjRec(index).IdColor3 = AnyObj(index).mPointMachine.Idx3Color
                ObjRec(index).IdColor4 = AnyObj(index).mPointMachine.Idx4Color
                ObjRec(index).IdColor5 = AnyObj(index).mPointMachine.Idx5Color
                '------------ Run Time Object ---------------
                ObjRec(index).TagId1Color = AnyObj(index).mPointMachine.TagId1Color
                ObjRec(index).TagId2Color = AnyObj(index).mPointMachine.TagId2Color
                ObjRec(index).TagId3Color = AnyObj(index).mPointMachine.TagId3Color
                ObjRec(index).TagId4Color = AnyObj(index).mPointMachine.TagId4Color
                ObjRec(index).TagId5Color = AnyObj(index).mPointMachine.TagId5Color
                ObjRec(index).TagId1Val = AnyObj(index).mPointMachine.TagId1Val
                ObjRec(index).TagId2Val = AnyObj(index).mPointMachine.TagId2Val
                ObjRec(index).TagId3Val = AnyObj(index).mPointMachine.TagId3Val
                ObjRec(index).TagId4Val = AnyObj(index).mPointMachine.TagId4Val
                ObjRec(index).TagId5Val = AnyObj(index).mPointMachine.TagId5Val
                ObjRec(index).TagTx = ""
                ObjRec(index).TagTx1 = AnyObj(index).mPointMachine.TagTx1
                ObjRec(index).TagTx2 = AnyObj(index).mPointMachine.TagTx2
                ObjRec(index).TagTx3 = AnyObj(index).mPointMachine.TagTx3
                ObjRec(index).TagTx4 = AnyObj(index).mPointMachine.TagTx4
                ObjRec(index).TagTx5 = AnyObj(index).mPointMachine.TagTx5
                '--------------------------------------------

            Case "Track"
                ObjRec(index).Name = AnyObj(index).mTrack.Name
                ObjRec(index).Top = AnyObj(index).mTrack.Top
                ObjRec(index).Left = AnyObj(index).mTrack.Left
                ObjRec(index).Width = AnyObj(index).mTrack.Width
                ObjRec(index).Height = AnyObj(index).mTrack.Height
                ObjRec(index).Type = AnyObj(index).mTrack.Type
                ObjRec(index).Text = AnyObj(index).mTrack.TextName
                ObjRec(index).Thickness = AnyObj(index).mTrack.Thickness
                ObjRec(index).TextPosition = AnyObj(index).mTrack.TextPosition
                ObjRec(index).Direction = AnyObj(index).mTrack.LinePosition
                ObjRec(index).Group = AnyObj(index).mTrack.Group
                'ObjRec(index).Visible = AnyObj(index).mTrack.Visible
                ObjRec(index).OnVisible = AnyObj(index).mTrack.OnVisible
                '---------- Font -------
                ObjRec(index).fName = AnyObj(index).mTrack.Font.Name
                ObjRec(index).fSize = AnyObj(index).mTrack.Font.Size
                ObjRec(index).fStyle = AnyObj(index).mTrack.Font.Style
                '--------------------
                ObjRec(index).IdColor1 = AnyObj(index).mTrack.Idx1Color
                ObjRec(index).IdColor2 = AnyObj(index).mTrack.Idx2Color
                ObjRec(index).IdColor3 = AnyObj(index).mTrack.Idx3Color
                ObjRec(index).IdColor4 = AnyObj(index).mTrack.Idx4Color
                ObjRec(index).IdColor5 = AnyObj(index).mTrack.Idx5Color
                '------------ Run Time Object ---------------
                ObjRec(index).TagId1Color = AnyObj(index).mTrack.TagId1Color
                ObjRec(index).TagId2Color = AnyObj(index).mTrack.TagId2Color
                ObjRec(index).TagId3Color = AnyObj(index).mTrack.TagId3Color
                ObjRec(index).TagId4Color = AnyObj(index).mTrack.TagId4Color
                ObjRec(index).TagIdVal = AnyObj(index).mTrack.TagIdVal
                ObjRec(index).TagId1Val = AnyObj(index).mTrack.TagId1Val
                ObjRec(index).TagId2Val = AnyObj(index).mTrack.TagId2Val
                ObjRec(index).TagId3Val = AnyObj(index).mTrack.TagId3Val
                ObjRec(index).TagId4Val = AnyObj(index).mTrack.TagId4Val
                ObjRec(index).TagTx = AnyObj(index).mTrack.TagTx
                ObjRec(index).TagTx1 = AnyObj(index).mTrack.TagTx1
                ObjRec(index).TagTx2 = AnyObj(index).mTrack.TagTx2
                ObjRec(index).TagTx3 = AnyObj(index).mTrack.TagTx3
                ObjRec(index).TagTx4 = AnyObj(index).mTrack.TagTx4
                ObjRec(index).TagTx5 = ""
                '--------------------------------------------
            Case "Label"
                ObjRec(index).Name = AnyObj(index).mLabel.Name
                ObjRec(index).Top = AnyObj(index).mLabel.Top
                ObjRec(index).Left = AnyObj(index).mLabel.Left
                ObjRec(index).Width = AnyObj(index).mLabel.Width
                ObjRec(index).Height = AnyObj(index).mLabel.Height
                'ObjRec(index).Visible = AnyObj(index).mLabel.Visible
                ObjRec(index).OnVisible = AnyObj(index).mLabel.OnVisible
                '---------------------------------------------
                ObjRec(index).Text = AnyObj(index).mLabel.TextName
                ObjRec(index).Group = AnyObj(index).mLabel.Group
                ObjRec(index).Type = AnyObj(index).mLabel.Type
                '---------- Font -------
                ObjRec(index).fName = AnyObj(index).mLabel.Font.Name
                ObjRec(index).fSize = AnyObj(index).mLabel.Font.Size
                ObjRec(index).fStyle = AnyObj(index).mLabel.Font.Style
                '--------------------
                ObjRec(index).IdColor1 = AnyObj(index).mLabel.Idx1Color
                ObjRec(index).IdColor2 = AnyObj(index).mLabel.Idx2Color
                ObjRec(index).IdColor3 = AnyObj(index).mLabel.Idx3Color
                '------------ Run Time Object ---------------
                ObjRec(index).TagId1Color = AnyObj(index).mLabel.TagId1Color
                ObjRec(index).TagId2Color = AnyObj(index).mLabel.TagId2Color
                ObjRec(index).TagId1Val = AnyObj(index).mLabel.TagId1Val
                ObjRec(index).TagId2Val = AnyObj(index).mLabel.TagId2Val
                ObjRec(index).TagTx = ""
                ObjRec(index).TagTx1 = AnyObj(index).mLabel.TagTx1
                ObjRec(index).TagTx2 = AnyObj(index).mLabel.TagTx2
                ObjRec(index).TagTx3 = ""
                ObjRec(index).TagTx4 = ""
                ObjRec(index).TagTx5 = ""
                '--------------------------------------------

            Case "CheckBox"
                ObjRec(index).Name = AnyObj(index).mCheckBox.Name
                ObjRec(index).Top = AnyObj(index).mCheckBox.Top
                ObjRec(index).Left = AnyObj(index).mCheckBox.Left
                ObjRec(index).Width = AnyObj(index).mCheckBox.Width
                ObjRec(index).Height = AnyObj(index).mCheckBox.Height
                'ObjRec(index).Visible = AnyObj(index).mCheckBox.Visible
                ObjRec(index).OnVisible = AnyObj(index).mCheckBox.OnVisible
                '-----------------------------------------------
                ObjRec(index).Text = AnyObj(index).mCheckBox.TextName
                ObjRec(index).OnRunTime = AnyObj(index).mCheckBox.OnRunTime
                ObjRec(index).Active = AnyObj(index).mCheckBox.Checked
                ObjRec(index).Group = AnyObj(index).mCheckBox.Group
                '---------- Font -------
                ObjRec(index).fName = AnyObj(index).mCheckBox.Font.Name
                ObjRec(index).fSize = AnyObj(index).mCheckBox.Font.Size
                ObjRec(index).fStyle = AnyObj(index).mCheckBox.Font.Style
                '------------------ Color -----------------------
                ObjRec(index).IdColor1 = AnyObj(index).mCheckBox.Idx1Color
                ObjRec(index).IdColor2 = AnyObj(index).mCheckBox.Idx2Color
                ObjRec(index).TagIdVal = AnyObj(index).mCheckBox.TagIdVal
                ObjRec(index).TagTx = AnyObj(index).mCheckBox.TagTx
                ObjRec(index).TagTx1 = ""
                ObjRec(index).TagTx2 = ""
                ObjRec(index).TagTx3 = ""
                ObjRec(index).TagTx4 = ""
                ObjRec(index).TagTx5 = ""

            Case "Shape"
                ObjRec(index).Name = AnyObj(index).mShapes.Name
                ObjRec(index).Top = AnyObj(index).mShapes.Top
                ObjRec(index).Left = AnyObj(index).mShapes.Left
                ObjRec(index).Width = AnyObj(index).mShapes.Width
                ObjRec(index).Height = AnyObj(index).mShapes.Height
                ObjRec(index).Diameter = AnyObj(index).mShapes.Diameter
                ObjRec(index).Group = AnyObj(index).mShapes.Group
                'ObjRec(index).Visible = AnyObj(index).mShapes.Visible
                ObjRec(index).OnVisible = AnyObj(index).mShapes.OnVisible
                ObjRec(index).Text = ""
                ObjRec(index).TextPosition = 0
                ObjRec(index).Type = AnyObj(index).mShapes.Shape
                ObjRec(index).Direction = AnyObj(index).mShapes.Direction
                '---------- Font -------
                ObjRec(index).fName = AnyObj(index).mShapes.Font.Name
                ObjRec(index).fSize = AnyObj(index).mShapes.Font.Size
                ObjRec(index).fStyle = AnyObj(index).mShapes.Font.Style
                '--------------------
                ObjRec(index).IdColor1 = AnyObj(index).mShapes.Idx1Color
                ObjRec(index).IdColor2 = AnyObj(index).mShapes.Idx2Color
                ObjRec(index).IdColor3 = AnyObj(index).mShapes.Idx3Color
                '------------ Run Time Object ---------------
                ObjRec(index).TagId1Color = AnyObj(index).mShapes.TagId1Color
                ObjRec(index).TagId2Color = AnyObj(index).mShapes.TagId2Color
                ObjRec(index).TagId1Val = AnyObj(index).mShapes.TagId1Val
                ObjRec(index).TagId2Val = AnyObj(index).mShapes.TagId2Val
                ObjRec(index).TagTx = ""
                ObjRec(index).TagTx1 = AnyObj(index).mShapes.TagTx1
                ObjRec(index).TagTx2 = AnyObj(index).mShapes.TagTx2
                ObjRec(index).TagTx3 = ""
                ObjRec(index).TagTx4 = ""
                ObjRec(index).TagTx5 = ""
                '--------------------------------------------

            Case "Button"
                ObjRec(index).Name = AnyObj(index).mButton.Name
                ObjRec(index).Top = AnyObj(index).mButton.Top
                ObjRec(index).Left = AnyObj(index).mButton.Left
                ObjRec(index).Width = AnyObj(index).mButton.Width
                ObjRec(index).Height = AnyObj(index).mButton.Height
                ObjRec(index).Text = AnyObj(index).mButton.TextName
                ObjRec(index).Group = AnyObj(index).mButton.Group
                'ObjRec(index).Visible = AnyObj(index).mButton.Visible
                ObjRec(index).OnVisible = AnyObj(index).mButton.OnVisible
                ObjRec(index).Type = AnyObj(index).mButton.Type
                ObjRec(index).Direction = AnyObj(index).mButton.Shape
                '---------- Font -------
                ObjRec(index).fName = AnyObj(index).mButton.Font.Name
                ObjRec(index).fSize = AnyObj(index).mButton.Font.Size
                ObjRec(index).fStyle = AnyObj(index).mButton.Font.Style
                '-------------------- 
                ObjRec(index).IdColor1 = AnyObj(index).mButton.Idx1Color
                ObjRec(index).IdColor2 = AnyObj(index).mButton.Idx2Color
                ObjRec(index).IdColor3 = AnyObj(index).mButton.Idx3Color
                '------------ Run Time Object ---------------
                ObjRec(index).TagId1Color = AnyObj(index).mButton.TagId1Color
                ObjRec(index).TagId2Color = AnyObj(index).mButton.TagId2Color
                ObjRec(index).TagIdVal = AnyObj(index).mButton.TagIdVal
                ObjRec(index).TagId1Val = AnyObj(index).mButton.TagId1Val
                ObjRec(index).TagId2Val = AnyObj(index).mButton.TagId2Val
                ObjRec(index).TagTx = AnyObj(index).mButton.TagTx
                ObjRec(index).TagTx1 = AnyObj(index).mButton.TagTx1
                ObjRec(index).TagTx2 = AnyObj(index).mButton.TagTx2
                ObjRec(index).TagTx3 = ""
                ObjRec(index).TagTx4 = ""
                ObjRec(index).TagTx5 = ""
                ObjRec(index).Active = AnyObj(index).mButton.OnToggle
                '--------------------------------------------

            Case "Counter"
                ObjRec(index).Name = AnyObj(index).mCounter.Name
                ObjRec(index).Top = AnyObj(index).mCounter.Top
                ObjRec(index).Left = AnyObj(index).mCounter.Left
                ObjRec(index).Width = AnyObj(index).mCounter.Width
                ObjRec(index).Height = AnyObj(index).mCounter.Height
                'ObjRec(index).Visible = AnyObj(index).mCounter.Visible
                ObjRec(index).OnVisible = AnyObj(index).mCounter.OnVisible
                ObjRec(index).Text = ""
                ObjRec(index).TextPosition = 0
                '---------- Font -------
                ObjRec(index).fName = AnyObj(index).mCounter.Font.Name
                ObjRec(index).fSize = AnyObj(index).mCounter.Font.Size
                ObjRec(index).fStyle = AnyObj(index).mCounter.Font.Style
                '--------------------
                ObjRec(index).IdColor1 = AnyObj(index).mCounter.Idx1Color
                ObjRec(index).IdColor2 = AnyObj(index).mCounter.Idx2Color
                ObjRec(index).IdColor3 = AnyObj(index).mCounter.Idx3Color
                ObjRec(index).TagTx = ""
                ObjRec(index).TagTx1 = ""
                ObjRec(index).TagTx2 = ""
                ObjRec(index).TagTx3 = ""
                ObjRec(index).TagTx4 = ""
                ObjRec(index).TagTx5 = ""

            Case "Buzzer"
                ObjRec(index).Name = AnyObj(index).mBuzzer.Name
                ObjRec(index).Top = AnyObj(index).mBuzzer.Top
                ObjRec(index).Left = AnyObj(index).mBuzzer.Left
                ObjRec(index).Width = AnyObj(index).mBuzzer.Width
                ObjRec(index).Height = AnyObj(index).mBuzzer.Height
                ObjRec(index).Group = AnyObj(index).mBuzzer.Group
                'ObjRec(index).Visible = AnyObj(index).mBuzzer.Visible
                ObjRec(index).OnVisible = AnyObj(index).mBuzzer.OnVisible
                ObjRec(index).Text = ""
                ObjRec(index).TextPosition = 0
                '---------- Font -------
                ObjRec(index).fName = AnyObj(index).mBuzzer.Font.Name
                ObjRec(index).fSize = AnyObj(index).mBuzzer.Font.Size
                ObjRec(index).fStyle = AnyObj(index).mBuzzer.Font.Style
                '--------------------
                ObjRec(index).IdColor1 = AnyObj(index).mBuzzer.Idx1Color
                ObjRec(index).IdColor2 = AnyObj(index).mBuzzer.Idx2Color
                ObjRec(index).IdColor3 = AnyObj(index).mBuzzer.Idx3Color
                '------------ Run Time Object ---------------
                ObjRec(index).TagId1Color = AnyObj(index).mBuzzer.TagId1Color
                ObjRec(index).TagId2Color = AnyObj(index).mBuzzer.TagId2Color
                ObjRec(index).TagId1Val = AnyObj(index).mBuzzer.TagId1Val
                ObjRec(index).TagId2Val = AnyObj(index).mBuzzer.TagId2Val
                ObjRec(index).TagTx = ""
                ObjRec(index).TagTx1 = AnyObj(index).mBuzzer.TagTx1
                ObjRec(index).TagTx2 = AnyObj(index).mBuzzer.TagTx2
                ObjRec(index).TagTx3 = ""
                ObjRec(index).TagTx4 = ""
                ObjRec(index).TagTx5 = ""
                '--------------------------------------------

            Case "EquipmentName"
                ObjRec(index).Name = AnyObj(index).mEquipmentName.Name
                ObjRec(index).Top = AnyObj(index).mEquipmentName.Top
                ObjRec(index).Left = AnyObj(index).mEquipmentName.Left
                ObjRec(index).Width = AnyObj(index).mEquipmentName.Width
                ObjRec(index).Height = AnyObj(index).mEquipmentName.Height
                'ObjRec(index).Visible = AnyObj(index).mEquipmentName.Visible
                ObjRec(index).OnVisible = AnyObj(index).mEquipmentName.OnVisible

            Case "PictureBox"
                ObjRec(index).Name = AnyObj(index).mPictureBox.Name
                ObjRec(index).Top = AnyObj(index).mPictureBox.Top
                ObjRec(index).Left = AnyObj(index).mPictureBox.Left
                ObjRec(index).Width = AnyObj(index).mPictureBox.Width
                ObjRec(index).Height = AnyObj(index).mPictureBox.Height
                'ObjRec(index).Visible = AnyObj(index).mPictureBox.Visible
        End Select
    End Sub
#End Region

#Region "       Object Copy"
    Public Sub CopyObject(ByVal type As String)
        Select Case type
            Case "Signal"
                ObjProp.Width = AnyObj(IndexObj).mSignal.Width
                ObjProp.Height = AnyObj(IndexObj).mSignal.Height
                ObjProp.Diameter = AnyObj(IndexObj).mSignal.Diameter
                ObjProp.Thickness = AnyObj(IndexObj).mSignal.ShuntThickness
                ObjProp.Type = AnyObj(IndexObj).mSignal.Type
                ObjProp.Group = AnyObj(IndexObj).mSignal.Group
                ObjProp.Direction = AnyObj(IndexObj).mSignal.SignalPosition
                ObjProp.TextPosition = AnyObj(IndexObj).mSignal.TextPosition
                ObjProp.Text = AnyObj(IndexObj).mSignal.TextName
                'ObjProp.Visible = AnyObj(IndexObj).mSignal.Visible
                ObjProp.OnVisible = AnyObj(IndexObj).mSignal.OnVisible
                '---------------- Font -----------
                ObjProp.fName = AnyObj(IndexObj).mSignal.Font.Name
                ObjProp.fSize = AnyObj(IndexObj).mSignal.Font.Size
                ObjProp.fStyle = AnyObj(IndexObj).mSignal.Font.Style
                '---------------- Color -----------
                ObjProp.IdColor1 = AnyObj(IndexObj).mSignal.Idx1Color
                ObjProp.IdColor2 = AnyObj(IndexObj).mSignal.Idx2Color
                ObjProp.IdColor3 = AnyObj(IndexObj).mSignal.Idx3Color
                ObjProp.IdColor4 = AnyObj(IndexObj).mSignal.Idx4Color
                ObjProp.IdColor5 = AnyObj(IndexObj).mSignal.Idx5Color
                '------------ Run Time Object ---------------
                ObjProp.TagId1Color = AnyObj(IndexObj).mSignal.TagId1Color
                ObjProp.TagId2Color = AnyObj(IndexObj).mSignal.TagId2Color
                ObjProp.TagId3Color = AnyObj(IndexObj).mSignal.TagId3Color
                ObjProp.TagId4Color = AnyObj(IndexObj).mSignal.TagId4Color
                ObjProp.TagId1Val = AnyObj(IndexObj).mSignal.TagId1Val
                ObjProp.TagId2Val = AnyObj(IndexObj).mSignal.TagId2Val
                ObjProp.TagId3Val = AnyObj(IndexObj).mSignal.TagId3Val
                ObjProp.TagId4Val = AnyObj(IndexObj).mSignal.TagId4Val
                '--------------------------------------------

            Case "PointMachine"
                ObjProp.Width = AnyObj(IndexObj).mPointMachine.Width
                ObjProp.Height = AnyObj(IndexObj).mPointMachine.Height
                ObjProp.Thickness = AnyObj(IndexObj).mPointMachine.Thickness
                ObjProp.Type = AnyObj(IndexObj).mPointMachine.Type
                ObjProp.Text = AnyObj(IndexObj).mPointMachine.TextName
                'ObjProp.Visible = AnyObj(IndexObj).mPointMachine.Visible
                ObjProp.OnVisible = AnyObj(IndexObj).mPointMachine.OnVisible
                ObjProp.Group = AnyObj(IndexObj).mPointMachine.Group
                '---------------- Font -----------
                ObjProp.fName = AnyObj(IndexObj).mPointMachine.Font.Name
                ObjProp.fSize = AnyObj(IndexObj).mPointMachine.Font.Size
                ObjProp.fStyle = AnyObj(IndexObj).mPointMachine.Font.Style
                '--------------- Color
                ObjProp.IdColor1 = AnyObj(IndexObj).mPointMachine.Idx1Color
                ObjProp.IdColor2 = AnyObj(IndexObj).mPointMachine.Idx2Color
                ObjProp.IdColor3 = AnyObj(IndexObj).mPointMachine.Idx3Color
                ObjProp.IdColor4 = AnyObj(IndexObj).mPointMachine.Idx4Color
                ObjProp.IdColor5 = AnyObj(IndexObj).mPointMachine.Idx5Color
                '------------ Run Time Object ---------------
                ObjProp.TagId1Color = AnyObj(IndexObj).mPointMachine.TagId1Color
                ObjProp.TagId2Color = AnyObj(IndexObj).mPointMachine.TagId2Color
                ObjProp.TagId3Color = AnyObj(IndexObj).mPointMachine.TagId3Color
                ObjProp.TagId4Color = AnyObj(IndexObj).mPointMachine.TagId4Color
                ObjProp.TagId5Color = AnyObj(IndexObj).mPointMachine.TagId5Color
                ObjProp.TagId1Val = AnyObj(IndexObj).mPointMachine.TagId1Val
                ObjProp.TagId2Val = AnyObj(IndexObj).mPointMachine.TagId2Val
                ObjProp.TagId3Val = AnyObj(IndexObj).mPointMachine.TagId3Val
                ObjProp.TagId4Val = AnyObj(IndexObj).mPointMachine.TagId4Val
                ObjProp.TagId5Val = AnyObj(IndexObj).mPointMachine.TagId5Val
                '--------------------------------------------

            Case "Track"
                ObjProp.Width = AnyObj(IndexObj).mTrack.Width
                ObjProp.Height = AnyObj(IndexObj).mTrack.Height
                ObjProp.Type = AnyObj(IndexObj).mTrack.Type
                ObjProp.Thickness = AnyObj(IndexObj).mTrack.Thickness
                ObjProp.Direction = AnyObj(IndexObj).mTrack.LinePosition
                ObjProp.Text = AnyObj(IndexObj).mTrack.TextName
                ObjProp.TextPosition = AnyObj(IndexObj).mTrack.TextPosition
                'ObjProp.Visible = AnyObj(IndexObj).mTrack.Visible
                ObjProp.OnVisible = AnyObj(IndexObj).mTrack.OnVisible
                ObjProp.Group = AnyObj(IndexObj).mTrack.Group
                '---------------- Font -----------
                ObjProp.fName = AnyObj(IndexObj).mTrack.Font.Name
                ObjProp.fSize = AnyObj(IndexObj).mTrack.Font.Size
                ObjProp.fStyle = AnyObj(IndexObj).mTrack.Font.Style
                '--------------- Color
                ObjProp.IdColor1 = AnyObj(IndexObj).mTrack.Idx1Color
                ObjProp.IdColor2 = AnyObj(IndexObj).mTrack.Idx2Color
                ObjProp.IdColor3 = AnyObj(IndexObj).mTrack.Idx3Color
                ObjProp.IdColor4 = AnyObj(IndexObj).mTrack.Idx4Color
                ObjProp.IdColor5 = AnyObj(IndexObj).mTrack.Idx5Color
                '------------ Run Time Object ---------------
                ObjProp.TagId1Color = AnyObj(IndexObj).mTrack.TagId1Color
                ObjProp.TagId2Color = AnyObj(IndexObj).mTrack.TagId2Color
                ObjProp.TagId3Color = AnyObj(IndexObj).mTrack.TagId3Color
                ObjProp.TagId4Color = AnyObj(IndexObj).mTrack.TagId4Color
                ObjProp.TagId1Val = AnyObj(IndexObj).mTrack.TagId1Val
                ObjProp.TagId2Val = AnyObj(IndexObj).mTrack.TagId2Val
                ObjProp.TagId3Val = AnyObj(IndexObj).mTrack.TagId3Val
                ObjProp.TagId4Val = AnyObj(IndexObj).mTrack.TagId4Val
                '--------------------------------------------

            Case "Label"
                ObjProp.Width = AnyObj(IndexObj).mLabel.Width
                ObjProp.Height = AnyObj(IndexObj).mLabel.Height
                ObjProp.Type = AnyObj(IndexObj).mLabel.Type
                ObjProp.Text = AnyObj(IndexObj).mLabel.TextName
                'ObjProp.Visible = AnyObj(IndexObj).mLabel.Visible
                ObjProp.OnVisible = AnyObj(IndexObj).mLabel.OnVisible
                ObjProp.Group = AnyObj(IndexObj).mLabel.Group
                '---------------- Font -----------
                ObjProp.fName = AnyObj(IndexObj).mLabel.Font.Name
                ObjProp.fSize = AnyObj(IndexObj).mLabel.Font.Size
                ObjProp.fStyle = AnyObj(IndexObj).mLabel.Font.Style
                '--------------- Color
                ObjProp.IdColor1 = AnyObj(IndexObj).mLabel.Idx1Color
                ObjProp.IdColor2 = AnyObj(IndexObj).mLabel.Idx2Color
                ObjProp.IdColor3 = AnyObj(IndexObj).mLabel.Idx3Color
                '------------ Run Time Object ---------------
                ObjProp.TagId1Color = AnyObj(IndexObj).mLabel.TagId1Color
                ObjProp.TagId2Color = AnyObj(IndexObj).mLabel.TagId2Color
                ObjProp.TagId1Val = AnyObj(IndexObj).mLabel.TagId1Val
                ObjProp.TagId2Val = AnyObj(IndexObj).mLabel.TagId2Val
                '--------------------------------------------

            Case "CheckBox"
                ObjProp.Width = AnyObj(IndexObj).mCheckBox.Width
                ObjProp.Height = AnyObj(IndexObj).mCheckBox.Height
                ObjProp.Text = AnyObj(IndexObj).mCheckBox.TextName
                'ObjProp.Visible = AnyObj(IndexObj).mCheckBox.Visible
                ObjProp.OnVisible = AnyObj(IndexObj).mCheckBox.OnVisible
                ObjProp.Group = AnyObj(IndexObj).mCheckBox.Group
                ObjProp.Active = AnyObj(IndexObj).mCheckBox.Checked
                '---------------- Font -----------
                ObjProp.fName = AnyObj(IndexObj).mCheckBox.Font.Name
                ObjProp.fSize = AnyObj(IndexObj).mCheckBox.Font.Size
                ObjProp.fStyle = AnyObj(IndexObj).mCheckBox.Font.Style
                '--------------- Color
                ObjProp.IdColor1 = AnyObj(IndexObj).mCheckBox.Idx1Color
                ObjProp.IdColor2 = AnyObj(IndexObj).mCheckBox.Idx2Color

            Case "Shape"
                ObjProp.Width = AnyObj(IndexObj).mShapes.Width
                ObjProp.Height = AnyObj(IndexObj).mShapes.Height
                ObjProp.Diameter = AnyObj(IndexObj).mShapes.Diameter
                'ObjProp.Visible = AnyObj(IndexObj).mShapes.Visible
                ObjProp.OnVisible = AnyObj(IndexObj).mShapes.OnVisible
                ObjProp.Group = AnyObj(IndexObj).mShapes.Group
                ObjProp.Type = AnyObj(IndexObj).mShapes.Shape
                ObjProp.Direction = AnyObj(IndexObj).mShapes.Direction
                '---------------- Font -----------
                ObjProp.fName = AnyObj(IndexObj).mShapes.Font.Name
                ObjProp.fSize = AnyObj(IndexObj).mShapes.Font.Size
                ObjProp.fStyle = AnyObj(IndexObj).mShapes.Font.Style
                '--------------- Color
                ObjProp.IdColor1 = AnyObj(IndexObj).mShapes.Idx1Color
                ObjProp.IdColor2 = AnyObj(IndexObj).mShapes.Idx2Color
                ObjProp.IdColor3 = AnyObj(IndexObj).mShapes.Idx3Color
                '------------ Run Time Object ---------------
                ObjProp.TagId1Color = AnyObj(IndexObj).mShapes.TagId1Color
                ObjProp.TagId2Color = AnyObj(IndexObj).mShapes.TagId2Color
                ObjProp.TagId1Val = AnyObj(IndexObj).mShapes.TagId1Val
                ObjProp.TagId2Val = AnyObj(IndexObj).mShapes.TagId2Val
                '--------------------------------------------

            Case "Button"
                ObjProp.Width = AnyObj(IndexObj).mButton.Width
                ObjProp.Height = AnyObj(IndexObj).mButton.Height
                ObjProp.Text = AnyObj(IndexObj).mButton.TextName
                'ObjProp.Visible = AnyObj(IndexObj).mButton.Visible
                ObjProp.OnVisible = AnyObj(IndexObj).mButton.OnVisible
                ObjProp.Group = AnyObj(IndexObj).mButton.Group
                ObjProp.Active = AnyObj(IndexObj).mButton.OnToggle
                ObjProp.Type = AnyObj(IndexObj).mButton.Type
                ObjProp.Direction = AnyObj(IndexObj).mButton.Shape
                '---------------- Font -----------
                ObjProp.fName = AnyObj(IndexObj).mButton.Font.Name
                ObjProp.fSize = AnyObj(IndexObj).mButton.Font.Size
                ObjProp.fStyle = AnyObj(IndexObj).mButton.Font.Style
                '--------------- Color
                ObjProp.IdColor1 = AnyObj(IndexObj).mButton.Idx1Color
                ObjProp.IdColor2 = AnyObj(IndexObj).mButton.Idx2Color
                ObjProp.IdColor3 = AnyObj(IndexObj).mButton.Idx3Color
                '------------ Run Time Object ---------------
                ObjProp.TagId1Color = AnyObj(IndexObj).mButton.TagId1Color
                ObjProp.TagId2Color = AnyObj(IndexObj).mButton.TagId2Color
                ObjProp.TagId1Val = AnyObj(IndexObj).mButton.TagId1Val
                ObjProp.TagId2Val = AnyObj(IndexObj).mButton.TagId2Val
                '--------------------------------------------

            Case "Counter"
                ObjProp.Width = AnyObj(IndexObj).mCounter.Width
                ObjProp.Height = AnyObj(IndexObj).mCounter.Height
                'ObjProp.Visible = AnyObj(IndexObj).mCounter.Visible
                ObjProp.OnVisible = AnyObj(IndexObj).mCounter.OnVisible
                ObjProp.Group = AnyObj(IndexObj).mCounter.Group
                '---------------- Font -----------
                ObjProp.fName = AnyObj(IndexObj).mCounter.Font.Name
                ObjProp.fSize = AnyObj(IndexObj).mCounter.Font.Size
                ObjProp.fStyle = AnyObj(IndexObj).mCounter.Font.Style
                '--------------- Color
                ObjProp.IdColor1 = AnyObj(IndexObj).mCounter.Idx1Color
                ObjProp.IdColor2 = AnyObj(IndexObj).mCounter.Idx2Color
                ObjProp.IdColor3 = AnyObj(IndexObj).mCounter.Idx3Color

            Case "Buzzer"
                ObjProp.Width = AnyObj(IndexObj).mBuzzer.Width
                ObjProp.Height = AnyObj(IndexObj).mBuzzer.Height
                'ObjProp.Visible = AnyObj(IndexObj).mBuzzer.Visible
                ObjProp.OnVisible = AnyObj(IndexObj).mBuzzer.OnVisible
                ObjProp.Group = AnyObj(IndexObj).mBuzzer.Group
                '---------------- Font -----------
                ObjProp.fName = AnyObj(IndexObj).mBuzzer.Font.Name
                ObjProp.fSize = AnyObj(IndexObj).mBuzzer.Font.Size
                ObjProp.fStyle = AnyObj(IndexObj).mBuzzer.Font.Style
                '--------------- Color
                ObjProp.IdColor1 = AnyObj(IndexObj).mBuzzer.Idx1Color
                ObjProp.IdColor2 = AnyObj(IndexObj).mBuzzer.Idx2Color
                ObjProp.IdColor3 = AnyObj(IndexObj).mBuzzer.Idx3Color
                '------------ Run Time Object ---------------
                ObjProp.TagId1Color = AnyObj(IndexObj).mBuzzer.TagId1Color
                ObjProp.TagId2Color = AnyObj(IndexObj).mBuzzer.TagId2Color
                ObjProp.TagId1Val = AnyObj(IndexObj).mBuzzer.TagId1Val
                ObjProp.TagId2Val = AnyObj(IndexObj).mBuzzer.TagId2Val
                '--------------------------------------------

            Case "EquipmentName"

            Case "PictureBox"

        End Select
    End Sub

#End Region

#Region "       Default Object Properties"
    Public Sub ObjectDefault(ByVal id As IdObj)
        Select Case id
            Case IdObj.Signal
                ObjProp.Width = GridSpacing * 6 '60
                ObjProp.Height = GridSpacing * 3 '30
                ObjProp.Type = Signal.eType.HomeSigal
                ObjProp.Text = "J10"
                ObjProp.TextPosition = Signal.eTextPosition.Down
                ObjProp.Direction = Signal.ePosition.Left
                ObjProp.Diameter = GridSpacing ' 10
                ObjProp.Thickness = 3
                ObjProp.Group = Signal.eGroup.Vital
                ObjProp.OnRunTime = False
                ObjProp.OnVisible = True
                'ObjProp.Visible = True
                '-------- Font ----------- 
                ObjProp.fName = "Arial"
                ObjProp.fSize = 6
                ObjProp.fStyle = 0
                '---------- Object Color ------------- 
                ObjProp.IdColor1 = Color.Silver
                ObjProp.IdColor2 = Color.Black
                ObjProp.IdColor3 = Color.Black
                ObjProp.IdColor4 = Color.DimGray
                ObjProp.IdColor5 = Color.DimGray
                '----------- Run Time ----------------
                ObjProp.TagId1Color = Color.Red
                ObjProp.TagId2Color = Color.Red
                ObjProp.TagId3Color = Color.Red
                ObjProp.TagId4Color = Color.Red
                ObjProp.TagId1Val = False
                ObjProp.TagId2Val = False
                ObjProp.TagId3Val = False
                ObjProp.TagId4Val = False
                ObjProp.TagTx1 = ""
                ObjProp.TagTx2 = ""
                ObjProp.TagTx3 = ""
                ObjProp.TagTx4 = ""

            Case IdObj.PoinMachine
                ObjProp.Width = GridSpacing * 3 ' 30
                ObjProp.Height = GridSpacing * 3 ' 30
                ObjProp.Type = PointMachine.eType.LeftUp
                ObjProp.Text = "P11"
                ObjProp.Thickness = GridSpacing ' 10
                ObjProp.Group = PointMachine.eGroup.Vital
                ObjProp.OnRunTime = False
                ObjProp.OnVisible = True
                'ObjProp.Visible = True
                '-------- Font -----------
                ObjProp.fName = "Arial"
                ObjProp.fSize = 6
                ObjProp.fStyle = 0
                '---------- Object Color ------------- 
                ObjProp.IdColor1 = Color.Silver
                ObjProp.IdColor2 = Color.Black
                ObjProp.IdColor3 = Color.DimGray
                ObjProp.IdColor4 = Color.Blue
                ObjProp.IdColor5 = Color.Green
                '----------- Run Time ----------------
                ObjProp.TagId1Color = Color.Red
                ObjProp.TagId2Color = Color.Yellow
                ObjProp.TagId3Color = Color.Red
                ObjProp.TagId4Color = Color.Yellow
                ObjProp.TagId5Color = Color.Gray
                ObjProp.TagId1Val = False
                ObjProp.TagId2Val = False
                ObjProp.TagId3Val = False
                ObjProp.TagId4Val = False
                ObjProp.TagId5Val = False
                ObjProp.TagTx1 = ""
                ObjProp.TagTx2 = ""
                ObjProp.TagTx3 = ""
                ObjProp.TagTx4 = ""
                ObjProp.TagTx5 = ""

            Case IdObj.Track
                ObjProp.Width = GridSpacing * 10 '100
                ObjProp.Height = GridSpacing * 2 '20:
                ObjProp.Type = Track.eType.StraightLine
                ObjProp.Text = "12T"
                ObjProp.TextPosition = Track.eTextPosition.Down
                ObjProp.Direction = Track.eLinePosition.None
                ObjProp.OnRunTime = False
                ObjProp.Group = PointMachine.eGroup.Vital
                ObjProp.Thickness = 10
                ObjProp.OnVisible = True
                'ObjProp.Visible = True
                '-------- Font -----------
                ObjProp.fName = "Arial"
                ObjProp.fSize = 6
                ObjProp.fStyle = 0
                '---------- Object Color ------------- 
                ObjProp.IdColor1 = Color.Silver
                ObjProp.IdColor2 = Color.Black
                ObjProp.IdColor3 = Color.DimGray
                ObjProp.IdColor4 = Color.White
                ObjProp.IdColor5 = Color.White
                '----------- Run Time ----------------
                ObjProp.TagId1Color = Color.Red
                ObjProp.TagId2Color = Color.Yellow
                ObjProp.TagId3Color = Color.White
                ObjProp.TagId4Color = Color.White
                ObjProp.TagId1Val = False
                ObjProp.TagId2Val = False
                ObjProp.TagId3Val = False
                ObjProp.TagId4Val = False
                ObjProp.TagTx1 = ""
                ObjProp.TagTx2 = ""
                ObjProp.TagTx3 = ""
                ObjProp.TagTx4 = ""
                ObjProp.TagIdVal = False
                ObjProp.TagTx = ""

            Case IdObj.Shapes
                ObjProp.Width = GridSpacing * 2 ' 20
                ObjProp.Height = GridSpacing * 2 ' 20
                ObjProp.Diameter = GridSpacing ' 10
                ObjProp.Group = Shapes.eGruop.Vital
                ObjProp.Type = Shapes.eShape.Circle
                ObjProp.Direction = Shapes.eDirection.Right
                ObjProp.OnRunTime = False
                ObjProp.OnVisible = True
                'ObjProp.Visible = True
                '------------- Object Color --------------
                ObjProp.IdColor1 = Color.Silver
                ObjProp.IdColor2 = Color.Black
                ObjProp.IdColor3 = Color.Blue
                '------------- Run Time ------------------
                ObjProp.TagId1Color = Color.Red
                ObjProp.TagId2Color = Color.Yellow
                ObjProp.TagId1Val = False
                ObjProp.TagId2Val = False
                ObjProp.TagTx1 = ""
                ObjProp.TagTx2 = ""

            Case IdObj.Label
                ObjProp.Width = GridSpacing * 6 ' 60
                ObjProp.Height = GridSpacing * 3 ' 30
                ObjProp.Text = "Label"
                'ObjProp.TextFont = New Font("Arial", 8, Drawing.FontStyle.Regular)
                ObjProp.OnRunTime = False
                ObjProp.Type = LabelName.eType.Fixed3D
                ObjProp.Group = LabelName.eGruop.Vital
                ObjProp.OnVisible = True
                'ObjProp.Visible = True
                '-------- Font -----------
                ObjProp.fName = "Arial"
                ObjProp.fSize = 6
                ObjProp.fStyle = 0
                '------------- Object Color --------------
                ObjProp.IdColor1 = Color.DarkGray
                ObjProp.IdColor2 = Color.Black
                ObjProp.IdColor3 = Color.LightGray
                '------------- Run Time ------------------
                ObjProp.TagId1Color = Color.Red
                ObjProp.TagId2Color = Color.Yellow
                ObjProp.TagId1Val = False
                ObjProp.TagId2Val = False
                ObjProp.TagTx1 = ""
                ObjProp.TagTx2 = ""

            Case IdObj.CheckBox
                ObjProp.Width = GridSpacing * 8 ' 80
                ObjProp.Height = GridSpacing * 2 ' 20
                ObjProp.Text = "Check Box"
                ObjProp.OnRunTime = False
                ObjProp.Active = False
                ObjProp.Group = ckBox.eGruop.Vital
                ObjProp.OnVisible = True
                'ObjProp.Visible = True
                '-------- Font -----------
                ObjProp.fName = "Arial"
                ObjProp.fSize = 6
                ObjProp.fStyle = 0
                '---------- Object Color ------------- 
                ObjProp.IdColor1 = Color.Silver
                ObjProp.IdColor2 = Color.Black
                ObjProp.TagTx = ""
                ObjProp.TagIdVal = False

            Case IdObj.Buttons
                ObjProp.Width = GridSpacing * 7 ' 70
                ObjProp.Height = GridSpacing * 3 ' 30
                ObjProp.Text = "Buttons"
                'ObjProp.TextFont = New Font("Arial", 8, Drawing.FontStyle.Regular)
                ObjProp.Group = Buttons.eGruop.Vital
                ObjProp.OnRunTime = False
                ObjProp.Active = False
                ObjProp.OnVisible = True
                'ObjProp.Visible = True
                ObjProp.Type = Buttons.eType.ToggleButton
                ObjProp.Direction = Buttons.eShape.Rectangle
                '-------- Font -----------
                ObjProp.fName = "Arial"
                ObjProp.fSize = 6
                ObjProp.fStyle = 0
                '------------- Object Color --------------
                ObjProp.IdColor1 = Color.Silver
                ObjProp.IdColor2 = Color.Black
                ObjProp.IdColor3 = Color.Gray
                '------------- Run Time ------------------
                ObjProp.TagId1Color = Color.Red
                ObjProp.TagId2Color = Color.Yellow
                ObjProp.TagIdVal = False
                ObjProp.TagId1Val = False
                ObjProp.TagId2Val = False
                ObjProp.TagTx = ""
                ObjProp.TagTx1 = ""
                ObjProp.TagTx2 = ""

            Case IdObj.Counter
                ObjProp.Width = GridSpacing * 7 ' 70
                ObjProp.Height = GridSpacing * 3 ' 30
                ObjProp.Group = Counter.eGruop.Vital
                ObjProp.OnRunTime = False  'ObjProp.OnRunTime
                ObjProp.OnVisible = True
                'ObjProp.Visible = True
                '------------- Object Color --------------
                ObjProp.IdColor1 = Color.DimGray
                ObjProp.IdColor2 = Color.Black
                ObjProp.IdColor3 = Color.Green

            Case IdObj.Buzzer
                ObjProp.Width = GridSpacing * 3 ' 30
                ObjProp.Height = GridSpacing * 3 ' 30
                ObjProp.Group = Buzzer.eGruop.Vital
                ObjProp.OnRunTime = False
                ObjProp.OnVisible = True
                'ObjProp.Visible = True
                '------------- Object Color --------------
                ObjProp.IdColor1 = Color.LightGray
                ObjProp.IdColor2 = Color.Black
                ObjProp.IdColor3 = Color.Black
                '------------- Run Time ------------------
                ObjProp.TagId1Color = Color.Red
                ObjProp.TagId2Color = Color.Yellow
                ObjProp.TagId1Val = False
                ObjProp.TagId2Val = False
                ObjProp.TagTx1 = ""
                ObjProp.TagTx2 = ""

            Case IdObj.EquipmentName
                ObjProp.Width = GridSpacing * 5 ' 50
                ObjProp.Height = GridSpacing * 2 ' 20
                'ObjProp.Visible = True

            Case IdObj.PictureBox
                ObjProp.Width = GridSpacing * 5 ' 50
                ObjProp.Height = GridSpacing * 5 '50
                'ObjProp.Visible = True

        End Select
    End Sub
#End Region

#Region "       Display Object Properties"
    Public Sub DisplayObjectProperties(ByVal ctrl As Control)
        frmMain.tbY.Text = ctrl.Top
        frmMain.tbX.Text = ctrl.Left
        frmMain.tbW.Text = ctrl.Width
        frmMain.tbH.Text = ctrl.Height
        frmMain.tbName.Text = ctrl.Name
        frmMain.lbDir.Text = "Direction"
        Select Case ctrl.Name
            Case "Signal"

                frmMain.txDiameter.Text = AnyObj(IndexObj).mSignal.Diameter.ToString
                frmMain.txIdColor1.BackColor = AnyObj(IndexObj).mSignal.Idx1Color
                frmMain.txColor.BackColor = AnyObj(IndexObj).mSignal.Idx2Color
                frmMain.txIdColor2.BackColor = AnyObj(IndexObj).mSignal.Idx3Color
                frmMain.txIdColor3.BackColor = AnyObj(IndexObj).mSignal.Idx4Color
                frmMain.txIdColor4.BackColor = AnyObj(IndexObj).mSignal.Idx5Color

                frmMain.cbType.Items.Clear()
                frmMain.cbType.Items.Insert(0, "DistanceSignal") : frmMain.cbType.Items.Insert(1, "HomeSigal")
                frmMain.cbType.Items.Insert(2, "StartingSignal") : frmMain.cbType.Items.Insert(3, "ShuntSignal")
                frmMain.cbType.Items.Insert(4, "StartingSignalWithShunt")
                frmMain.cbType.SelectedIndex = AnyObj(IndexObj).mSignal.Type

                frmMain.cbDirection.Items.Clear()
                frmMain.cbDirection.Items.Insert(0, "Left") : frmMain.cbDirection.Items.Insert(1, "Right")
                frmMain.cbDirection.SelectedIndex = AnyObj(IndexObj).mSignal.SignalPosition

                frmMain.cbTextPos.Items.Clear()
                frmMain.cbTextPos.Items.Insert(0, "Top") : frmMain.cbTextPos.Items.Insert(1, "Bottom")
                frmMain.cbTextPos.SelectedIndex = AnyObj(IndexObj).mSignal.TextPosition

                frmMain.txThickness.Text = AnyObj(IndexObj).mSignal.ShuntThickness
                frmMain.tbNameObject.Text = AnyObj(IndexObj).mSignal.TextName
                frmMain.txFont.Text = AnyObj(IndexObj).mSignal.Font.Name & ", " & AnyObj(IndexObj).mSignal.Font.Style.ToString & ", " & AnyObj(IndexObj).mSignal.Font.Size.ToString

            Case "PointMachine"
                frmMain.txThickness.Text = AnyObj(IndexObj).mPointMachine.Thickness
                frmMain.txColor.BackColor = AnyObj(IndexObj).mPointMachine.Idx2Color
                frmMain.txIdColor1.BackColor = AnyObj(IndexObj).mPointMachine.Idx1Color
                frmMain.txIdColor2.BackColor = AnyObj(IndexObj).mPointMachine.Idx3Color
                frmMain.txIdColor3.BackColor = AnyObj(IndexObj).mPointMachine.Idx4Color
                frmMain.txIdColor4.BackColor = AnyObj(IndexObj).mPointMachine.Idx5Color

                frmMain.cbType.Items.Clear()
                frmMain.cbType.Items.Insert(0, "RightUp") : frmMain.cbType.Items.Insert(1, "RightDown")
                frmMain.cbType.Items.Insert(2, "LeftUp") : frmMain.cbType.Items.Insert(3, "LeftDown")
                frmMain.cbType.SelectedIndex = AnyObj(IndexObj).mPointMachine.Type

                frmMain.cbDirection.Items.Clear()
                frmMain.cbTextPos.Items.Clear()
                frmMain.tbNameObject.Text = AnyObj(IndexObj).mPointMachine.TextName
                frmMain.txFont.Text = AnyObj(IndexObj).mPointMachine.Font.Name & ", " & AnyObj(IndexObj).mPointMachine.Font.Style.ToString & ", " & AnyObj(IndexObj).mPointMachine.Font.Size.ToString


            Case "Track"
                frmMain.txThickness.Text = AnyObj(IndexObj).mTrack.Thickness
                frmMain.txColor.BackColor = AnyObj(IndexObj).mTrack.Idx2Color
                frmMain.txIdColor1.BackColor = AnyObj(IndexObj).mTrack.Idx1Color
                frmMain.txIdColor2.BackColor = AnyObj(IndexObj).mTrack.Idx3Color
                frmMain.txIdColor3.BackColor = AnyObj(IndexObj).mTrack.Idx4Color
                frmMain.txIdColor4.BackColor = AnyObj(IndexObj).mTrack.Idx5Color

                frmMain.cbType.Items.Clear()
                frmMain.cbType.Items.Insert(0, "StraightLine") : frmMain.cbType.Items.Insert(1, "RightSlash")
                frmMain.cbType.Items.Insert(2, "LeftSlash")

                frmMain.cbDirection.Items.Clear()
                frmMain.cbDirection.Items.Insert(0, "None") : frmMain.cbDirection.Items.Insert(1, "Top") : frmMain.cbDirection.Items.Insert(2, "Bottom")
                frmMain.cbDirection.SelectedIndex = AnyObj(IndexObj).mTrack.LinePosition

                frmMain.cbTextPos.Items.Clear()
                frmMain.cbTextPos.Items.Insert(0, "Top") : frmMain.cbTextPos.Items.Insert(1, "Bottom")
                frmMain.cbTextPos.SelectedIndex = AnyObj(IndexObj).mTrack.TextPosition

                frmMain.cbType.SelectedIndex = AnyObj(IndexObj).mTrack.Type
                frmMain.tbNameObject.Text = AnyObj(IndexObj).mTrack.TextName
                frmMain.txFont.Text = AnyObj(IndexObj).mTrack.Font.Name & ", " & AnyObj(IndexObj).mTrack.Font.Style.ToString & ", " & AnyObj(IndexObj).mTrack.Font.Size.ToString

            Case "Label"
                frmMain.tbNameObject.Text = AnyObj(IndexObj).mLabel.TextName
                frmMain.txFont.Text = AnyObj(IndexObj).mLabel.Font.Name & ", " & AnyObj(IndexObj).mLabel.Font.Style.ToString & ", " & AnyObj(IndexObj).mLabel.Font.Size.ToString
                frmMain.txColor.BackColor = AnyObj(IndexObj).mLabel.Idx2Color
                frmMain.txIdColor1.BackColor = AnyObj(IndexObj).mLabel.Idx1Color
                frmMain.txIdColor2.BackColor = AnyObj(IndexObj).mLabel.Idx3Color
                frmMain.txIdColor3.BackColor = Color.White
                frmMain.txIdColor4.BackColor = Color.White

                frmMain.cbDirection.Items.Clear()
                frmMain.cbTextPos.Items.Clear()
                frmMain.cbType.Items.Clear()
                frmMain.cbType.Items.Insert(0, "FixedSingle") : frmMain.cbType.Items.Insert(1, "Fixed3D")
                frmMain.cbType.SelectedIndex = AnyObj(IndexObj).mLabel.Type

                frmMain.txDiameter.Text = ""
                frmMain.txThickness.Text = ""

            Case "CheckBox"
                frmMain.tbNameObject.Text = AnyObj(IndexObj).mCheckBox.TextName
                frmMain.txFont.Text = AnyObj(IndexObj).mCheckBox.Font.Name & ", " & AnyObj(IndexObj).mCheckBox.Font.Style.ToString & ", " & AnyObj(IndexObj).mCheckBox.Font.Size.ToString
                frmMain.txColor.BackColor = AnyObj(IndexObj).mCheckBox.Idx2Color
                frmMain.txIdColor1.BackColor = AnyObj(IndexObj).mCheckBox.Idx1Color
                frmMain.txIdColor2.BackColor = Color.White
                frmMain.txIdColor3.BackColor = Color.White
                frmMain.txIdColor4.BackColor = Color.White

                frmMain.cbDirection.Items.Clear()
                frmMain.cbTextPos.Items.Clear()
                frmMain.cbType.Items.Clear()

                frmMain.txDiameter.Text = ""
                frmMain.txThickness.Text = ""

            Case "Buzzer"
                frmMain.tbNameObject.Text = ""
                frmMain.txFont.Text = ""
                frmMain.txColor.BackColor = Color.White
                frmMain.txIdColor1.BackColor = AnyObj(IndexObj).mBuzzer.Idx1Color
                frmMain.txIdColor2.BackColor = AnyObj(IndexObj).mBuzzer.Idx3Color
                frmMain.txIdColor3.BackColor = Color.White
                frmMain.txIdColor4.BackColor = Color.White

                frmMain.cbDirection.Items.Clear()
                frmMain.cbTextPos.Items.Clear()
                frmMain.cbType.Items.Clear()

                frmMain.txDiameter.Text = ""
                frmMain.txThickness.Text = ""

            Case "Shape"
                frmMain.tbNameObject.Text = ""
                frmMain.txFont.Text = ""
                frmMain.txColor.BackColor = Color.White
                frmMain.txIdColor1.BackColor = AnyObj(IndexObj).mShapes.Idx1Color
                frmMain.txIdColor2.BackColor = AnyObj(IndexObj).mShapes.Idx3Color
                frmMain.txIdColor3.BackColor = Color.White
                frmMain.txIdColor4.BackColor = Color.White

                frmMain.cbTextPos.Items.Clear()
                frmMain.cbType.Items.Clear()
                frmMain.cbType.Items.Insert(0, "Circle") : frmMain.cbType.Items.Insert(1, "Triangle")
                frmMain.cbType.SelectedIndex = AnyObj(IndexObj).mShapes.Shape

                frmMain.cbDirection.Items.Clear()
                If AnyObj(IndexObj).mShapes.Shape = Shapes.eShape.Triangle Then
                    frmMain.cbDirection.Items.Insert(0, "Top") : frmMain.cbDirection.Items.Insert(1, "Bottom")
                    frmMain.cbDirection.Items.Insert(2, "Left") : frmMain.cbDirection.Items.Insert(3, "Right")
                    frmMain.cbDirection.SelectedIndex = AnyObj(IndexObj).mShapes.Direction
                End If

                frmMain.txDiameter.Text = AnyObj(IndexObj).mShapes.Diameter
                frmMain.txThickness.Text = ""

            Case "Counter"
                frmMain.tbNameObject.Text = ""
                frmMain.txFont.Text = ""
                frmMain.txColor.BackColor = Color.White
                frmMain.txIdColor1.BackColor = AnyObj(IndexObj).mCounter.Idx1Color
                frmMain.txIdColor2.BackColor = AnyObj(IndexObj).mCounter.Idx3Color
                frmMain.txIdColor3.BackColor = Color.White
                frmMain.txIdColor4.BackColor = Color.White

                frmMain.cbDirection.Items.Clear()
                frmMain.cbTextPos.Items.Clear()
                frmMain.cbType.Items.Clear()

                frmMain.txDiameter.Text = ""
                frmMain.txThickness.Text = ""

            Case "Button"
                frmMain.tbNameObject.Text = AnyObj(IndexObj).mButton.TextName
                frmMain.txFont.Text = AnyObj(IndexObj).mButton.Font.Name & ", " & AnyObj(IndexObj).mButton.Font.Style.ToString & ", " & AnyObj(IndexObj).mButton.Font.Size.ToString
                frmMain.txColor.BackColor = AnyObj(IndexObj).mButton.Idx2Color
                frmMain.txIdColor1.BackColor = AnyObj(IndexObj).mButton.Idx1Color
                frmMain.txIdColor2.BackColor = AnyObj(IndexObj).mButton.Idx3Color
                frmMain.txIdColor3.BackColor = Color.White
                frmMain.txIdColor4.BackColor = Color.White
                frmMain.lbDir.Text = "Shape"

                frmMain.cbTextPos.Items.Clear()
                frmMain.cbType.Items.Clear()
                frmMain.cbType.Items.Insert(0, "Toggle Button") : frmMain.cbType.Items.Insert(1, "Push Button") : frmMain.cbType.Items.Insert(2, "Pair Button")
                frmMain.cbType.SelectedIndex = AnyObj(IndexObj).mButton.Type

                frmMain.cbDirection.Items.Clear()
                If AnyObj(IndexObj).mButton.Type = Buttons.eType.PairButton Then
                    frmMain.cbDirection.Items.Insert(0, "Rectangle") : frmMain.cbDirection.Items.Insert(1, "Circle")
                    frmMain.cbDirection.Items.Insert(2, "TriangleLeft") : frmMain.cbDirection.Items.Insert(3, "TriangleRight")
                    frmMain.cbDirection.SelectedIndex = AnyObj(IndexObj).mButton.Shape
                    frmMain.txFont.Text = "" : frmMain.tbNameObject.Text = ""
                End If

                frmMain.txDiameter.Text = ""
                frmMain.txThickness.Text = ""
        End Select
    End Sub
#End Region

#Region "       Snap to Grid Procedure"
    Public Sub SnapToGrid(ByRef X As Integer, ByRef Y As Integer)
        X = GridSpacing * (X \ GridSpacing)
        Y = GridSpacing * (Y \ GridSpacing)
    End Sub

    Public Function SnapGrid(ByVal xy As Integer) As Integer
        SnapGrid = GridSpacing * (xy \ GridSpacing)
    End Function
#End Region

#Region "       Get Directory Procedure"
    Public Function App_Path() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function

    Public Function findPath(ByVal source As String) As String
        Dim pos As Integer = 1
        Dim pathSource As String = ""
        If source <> "" Then
            For i As Integer = source.Length To 1 Step -1
                If Mid(source, i, 1) = "\" Then
                    pos = i
                    Exit For
                End If
            Next
            pathSource = Mid(source, 1, pos)
        Else
            pathSource = ""
        End If
        Return pathSource
    End Function
#End Region

#End Region

#Region "       Modul Compiler"

    Public Sub error_add(ByVal er As String)
        Error_List(IdxError) = er
        IdxError += 1
        ReDim Preserve Error_List(IdxError)
    End Sub

    Public Function GetDataVar(ByVal var As String) As Boolean
        Dim invert As Boolean

        ' if a variable ".N." maka invert nilainya
        If Microsoft.VisualBasic.Left(var, 1) = "." Then
            var = Mid(var, 4)
            invert = True
        Else
            var = var
            invert = False
        End If

        Select Case var
            Case "TRUE" : Return True
            Case "FALSE" : Return False
            Case Else
                For i As Integer = 0 To IdxParam - 1 Step 1
                    If Parameter(i).Name = var Then
                        If invert Then : Return Not Parameter(i).value
                        Else : Return Parameter(i).value
                        End If
                        Exit For
                    End If
                Next
        End Select
    End Function

    Public Sub SemanticCheck(ByVal var As String, ByVal line As Integer)
        Dim invert As Boolean

        If Microsoft.VisualBasic.Left(var, 1) = "." Then
            var = Mid(var, 4)
            invert = True
        Else
            var = var
            invert = False
        End If

        If var = "TRUE" Or var = "PERMONE" Then
        ElseIf var = "FALSE" Or var = "PERZERO" Then
        Else
            For i As Integer = 0 To IdxParam - 1 Step 1
                If Parameter(i).Name = var Then
                    Exit For
                End If
                If i = IdxParam - 1 Then error_add("error : variable ' " & var & " ' belum didefinisi --> line : " & line)
            Next

        End If
    End Sub
#End Region

#Region "crc16"
    Public Function getOriginalData(ParamArray bytes() As Byte) As Byte()
        Console.WriteLine(bytes.Length)
        ReDim Preserve bytes(bytes.Length - 2)
        Return bytes
    End Function


    Public Function checkCrc16Kermit(ParamArray bytes() As Byte) As Boolean
        Dim ret As UInt16
        Dim msb, lsb As UInt16

        msb = bytes(bytes.Length - 2) << 8
        lsb = bytes(bytes.Length - 1)

        ret = getCrc16Kermit(bytes.Length - 2, bytes)

        If (msb << 8 Or lsb) = ret Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function getCrc16Kermit(ByVal size As Integer, ParamArray data() As Byte) As Integer
        Dim valuehex As Integer ' = &H0
        Dim CRC As Integer ' = &H0
        Dim i As Integer


        CRC = 0
        valuehex = 0
        For i = 0 To size - 1
            valuehex = ((data(i) Xor CRC) And &H0F) * &H1081
            CRC = CRC >> 4
            CRC = CRC Xor valuehex
            valuehex = ((data(i) >> 4) Xor (CRC And &H00FF)) And &H0F
            CRC = CRC >> 4
            CRC = CRC Xor (valuehex * &H1081)
        Next i

        Return ((CRC And &HFF) << 8) Or ((CRC And &HFF00) >> 8)

    End Function

#End Region


End Module
