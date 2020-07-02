Imports Railway

Public Class LexicalAnalysis
    Dim Characters As Char
    Dim BuffChar As String = ""
    Dim IdxToken As Integer

    Public vitalInput_Section(2) As Integer
    Public vitalOutput_Section(2) As Integer
    Public vitalCom_Section(2) As Integer
    Public nonVitalCom_Section(2) As Integer
    Public int_Section(2) As Integer
    Public bool_Section(2) As Integer
    Public time_Section(2) As Integer
    Public current_Section(2) As Integer
    Public latch_Section(2) As Integer
    Public timex_Section(2) As Integer
    Public equation_Section(2) As Integer

    Public Sub New(ByVal Source As String)
        Dim Rows() As String
        Dim Line As Long
        Dim Comment As Char = "*"

        ReDim T_Token(0) : IdxToken = 0
        ReDim Error_List(0) : IdxError = 0
        ReDim Parameter(0) : IdxParam = 0
        ReDim Equation_list(0) : IdxEquation = 0
        ReDim Result_List(0) : IdxResult = 0
        ReDim TimeList(0) : IdxTime = 0 : TimeExist = False

        For i As Integer = 0 To 2
            vitalInput_Section(i) = 0 : vitalOutput_Section(i) = 0
            vitalCom_Section(i) = 0 : nonVitalCom_Section(i) = 0
            int_Section(i) = 0 : bool_Section(i) = 0
            time_Section(i) = 0 : current_Section(i) = 0
            latch_Section(i) = 0 : timex_Section(i) = 0
            equation_Section(i) = 0
        Next

        Line = 1
        Rows = Source.Split(Environment.NewLine)
        For Each ShowLine As String In Rows
            If InStr(ShowLine, Comment) = 1 Or InStr(ShowLine, Comment) = 2 Then
                ' 
            Else
                Lexical_Analysis(ShowLine, Line)
                'countAnimasi += 1
            End If
            Line += 1
        Next

        GetParameterSection()
        For i As Integer = 0 To IdxToken
            Select Case T_Token(i).Token
                Case TokenList.T_Variable, TokenList.T_Value : T_Token(i).Symbol = TokenList.T_Expression
                Case TokenList.T_Add, TokenList.T_Multiple : T_Token(i).Symbol = TokenList.T_Operator
                Case Else : T_Token(i).Symbol = T_Token(i).Token
            End Select
        Next
        'check duplicated variable

    End Sub

    Private Sub Parameter_Add(ByVal index As Integer, ByVal Type As TokenList)
        T_Token(index).Type = Type
        Parameter(IdxParam).Name = T_Token(index).Lexeme
        Parameter(IdxParam).Type = T_Token(index).Type
        IdxParam += 1
        ReDim Preserve Parameter(IdxParam)
    End Sub

    Private Sub Parameter_Save(ByVal begin As Integer, ByVal last As Integer, ByVal Type As TokenList)
        For i As Integer = begin To last Step 1
            If last > 0 Then
                If T_Token(i).Token = TokenList.T_Variable Then
                    For j As Integer = 0 To UBound(Parameter)
                        If T_Token(i).Lexeme = Parameter(j).Name Then
                            error_add("Error : Duplicated Variable ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                        End If
                    Next
                    Parameter_Add(i, Type)
                Else
                    error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                End If
            End If
        Next
    End Sub

    Private Sub GetParameterSection()
        For i As Integer = 0 To IdxToken - 1 Step 1
            If T_Token(i).Lexeme = "SECTION" Then
                Select Case T_Token(i - 2).Lexeme
                    Case "VITAL"
                        If T_Token(i - 1).Lexeme = "INPUT" Then
                            vitalInput_Section(0) = i + 1
                        ElseIf T_Token(i - 1).Lexeme = "OUTPUT" Then
                            vitalInput_Section(1) = i - 3
                            vitalOutput_Section(0) = i + 1
                        ElseIf T_Token(i - 1).Lexeme = "COMMUNICATION" Then
                            vitalOutput_Section(1) = i - 3
                            vitalCom_Section(0) = i + 1
                        End If

                    Case "NONVITAL"
                        If T_Token(i - 1).Lexeme = "COMMUNICATION" Then
                            vitalCom_Section(1) = i - 3
                            nonVitalCom_Section(0) = i + 1
                        End If

                    Case "INTEGER"
                        int_Section(0) = i + 1

                    Case "BOOLEAN"
                        If T_Token(i - 1).Lexeme = "EQUATION" Then
                            If T_Token(i - 3).Lexeme = "END" Then
                                equation_Section(1) = i - 4
                            Else
                                If time_Section(0) > 0 Then time_Section(1) = i - 3
                                If timex_Section(0) > 0 Then timex_Section(1) = i - 3
                                equation_Section(0) = i + 1
                            End If
                        Else
                            nonVitalCom_Section(1) = i - 3
                            int_Section(1) = i - 3
                            bool_Section(0) = i + 1
                        End If
                    Case "TIMER"
                        bool_Section(1) = i - 3
                        time_Section(0) = i + 1
                    Case "CURRENT"
                        current_Section(0) = i + 1
                    Case "SELF-LATCHED"
                        current_Section(1) = i - 3
                        latch_Section(0) = i + 1
                    Case "EXPRESSION"
                        latch_Section(1) = i - 4
                        timex_Section(0) = i + 1
                End Select
            End If
        Next

        ' Grab parameter which is found in each sections
        Parameter_Save(vitalInput_Section(0), vitalInput_Section(1), TokenList.T_VitalInput)
        Parameter_Save(vitalOutput_Section(0), vitalOutput_Section(1), TokenList.T_VitalOutput)
        Parameter_Save(vitalCom_Section(0), vitalCom_Section(1), TokenList.T_VitalCom)
        Parameter_Save(nonVitalCom_Section(0), nonVitalCom_Section(1), TokenList.T_NVitalCom)
        'Parameter_Save(int_Section(0), int_Section(1), TokenList.T_Integer)
        Parameter_Save(bool_Section(0), bool_Section(1), TokenList.T_Boolean)
        Parameter_Save(time_Section(0), time_Section(1), TokenList.T_Timer)
        Parameter_Save(current_Section(0), current_Section(1), TokenList.T_Boolean)
        Parameter_Save(latch_Section(0), latch_Section(1), TokenList.T_Latch)
        Parameter_Save(timex_Section(0), timex_Section(1), TokenList.T_Timer)
    End Sub

    Private Sub Lexical_Analysis(ByVal Sentence As String, ByVal line As Long)
        Sentence = Sentence + "  "
        For i As Integer = 1 To Len(Sentence)
            Characters = GetChar(Sentence, i)
            Select Case Characters
                Case "A" To "Z" : Tokens = TokenList.T_Letter : BuffChar = BuffChar + Characters
                    'Case "a" To "z" : Tokens = TokenList.T_SmalLetter : BuffChar = BuffChar + Characters 'MessageBox.Show("Error : Small Capital is not allowed " & "(" & line & ")") : Exit Sub
                Case "0" To "9" : Tokens = TokenList.T_Number : BuffChar = BuffChar + Characters
                Case " " : Choose(line) : Tokens = TokenList.T_Space
                Case "+"
                    Choose(line)
                    With T_Token(IdxToken)
                        .Line = line
                        .Token = TokenList.T_Add
                        .Lexeme = Characters
                    End With
                    IdxToken += 1
                    ReDim Preserve T_Token(IdxToken)
                    Tokens = TokenList.T_Add
                Case "-", ".", "/", ":", Chr(26) : BuffChar = BuffChar + Characters
                Case "*"
                    Choose(line)
                    With T_Token(IdxToken)
                        .Line = line
                        .Token = TokenList.T_Multiple
                        .Lexeme = Characters
                    End With
                    IdxToken += 1
                    ReDim Preserve T_Token(IdxToken)
                    Tokens = TokenList.T_Multiple
                Case "="
                    Choose(line)
                    If Tokens = TokenList.T_Assign Or Tokens = TokenList.T_OPL Then
                        IdxToken -= 1
                        Select Case Tokens
                            Case TokenList.T_Assign
                                With T_Token(IdxToken)
                                    .Line = line
                                    .Token = TokenList.T_OperatorL
                                    .Lexeme = "=="
                                End With
                            Case TokenList.T_OPL
                                Dim oprl As String = T_Token(IdxToken).Lexeme
                                With T_Token(IdxToken)
                                    .Line = line
                                    .Token = TokenList.T_OperatorL
                                    .Lexeme = oprl + "="
                                End With
                        End Select
                        IdxToken += 1
                        ReDim Preserve T_Token(IdxToken)
                        Tokens = TokenList.T_OperatorL
                    Else
                        With T_Token(IdxToken)
                            .Line = line
                            .Token = TokenList.T_Assign
                            .Lexeme = Characters
                        End With
                        IdxToken += 1
                        ReDim Preserve T_Token(IdxToken)
                        Tokens = TokenList.T_Assign
                    End If
                Case "<"
                    Choose(line)
                    With T_Token(IdxToken)
                        .Line = line
                        .Token = TokenList.T_OperatorL
                        .Lexeme = Characters
                    End With
                    IdxToken += 1
                    ReDim Preserve T_Token(IdxToken)
                    Tokens = TokenList.T_OPL
                Case ">"
                    Choose(line)
                    With T_Token(IdxToken)
                        .Line = line
                        .Token = TokenList.T_OperatorL
                        .Lexeme = Characters
                    End With
                    IdxToken += 1
                    ReDim Preserve T_Token(IdxToken)
                    Tokens = TokenList.T_OperatorL

                Case "("
                    Choose(line)
                    With T_Token(IdxToken)
                        .Line = line
                        .Token = TokenList.T_Lparen
                        .Lexeme = Characters
                    End With
                    IdxToken += 1
                    ReDim Preserve T_Token(IdxToken)
                    Tokens = TokenList.T_Lparen

                Case ")"
                    Choose(line)
                    With T_Token(IdxToken)
                        .Line = line
                        .Token = TokenList.T_Rparen
                        .Lexeme = Characters
                    End With
                    IdxToken += 1
                    ReDim Preserve T_Token(IdxToken)
                    Tokens = TokenList.T_Rparen
                Case vbLf
                Case Else
                    Tokens = TokenList.T_UnknownLetter : BuffChar = BuffChar + Characters
            End Select
        Next
    End Sub

    Private Sub Choose(ByVal Line As Long)
        Dim chr As Char
        Dim OkVal As Boolean = True

        Select Case BuffChar
            Case "BOOL"
                With T_Token(IdxToken)
                    .Line = Line
                    .Token = TokenList.T_Bool
                    .Lexeme = BuffChar
                End With
                BuffChar = "" : IdxToken += 1
                ReDim Preserve T_Token(IdxToken)
            Case "TIME"
                With T_Token(IdxToken)
                    .Line = Line
                    .Token = TokenList.T_Time
                    .Lexeme = BuffChar
                End With
                BuffChar = "" : IdxToken += 1
                ReDim Preserve T_Token(IdxToken)

            Case "APPLICATION"
                With T_Token(IdxToken)
                    .Line = Line
                    .Token = TokenList.T_Application
                    .Lexeme = BuffChar
                End With
                BuffChar = "" : IdxToken += 1
                ReDim Preserve T_Token(IdxToken)

            Case "IF"
                With T_Token(IdxToken)
                    .Line = Line
                    .Token = TokenList.T_If
                    .Lexeme = BuffChar
                End With
                BuffChar = "" : IdxToken += 1
                ReDim Preserve T_Token(IdxToken)

            Case "DELAY"
                With T_Token(IdxToken)
                    .Line = Line
                    .Token = TokenList.T_Delay
                    .Lexeme = BuffChar
                End With
                BuffChar = "" : IdxToken += 1
                ReDim Preserve T_Token(IdxToken)

            Case "SECONDS"
                With T_Token(IdxToken)
                    .Line = Line
                    .Token = TokenList.T_Seconds
                    .Lexeme = BuffChar
                End With
                BuffChar = "" : IdxToken += 1
                ReDim Preserve T_Token(IdxToken)

            Case "MINUTES"
                With T_Token(IdxToken)
                    .Line = Line
                    .Token = TokenList.T_Minutes
                    .Lexeme = BuffChar
                End With
                BuffChar = "" : IdxToken += 1
                ReDim Preserve T_Token(IdxToken)

            Case "GOTO"
                With T_Token(IdxToken)
                    .Line = Line
                    .Token = TokenList.T_Goto
                    .Lexeme = BuffChar
                End With
                BuffChar = "" : IdxToken += 1
                ReDim Preserve T_Token(IdxToken)

            Case "ELSE"
                With T_Token(IdxToken)
                    .Line = Line
                    .Token = TokenList.T_Else
                    .Lexeme = BuffChar
                End With
                BuffChar = "" : IdxToken += 1
                ReDim Preserve T_Token(IdxToken)
            Case Else
                Select Case Tokens
                    Case TokenList.T_UnknownLetter
                        error_add("Error : char < " & BuffChar & " > is not allowed" & "' --> line : " & Line)
                    Case TokenList.T_Letter
                        With T_Token(IdxToken)
                            .Line = Line
                            .Token = TokenList.T_Variable
                            .Lexeme = BuffChar
                        End With
                        BuffChar = "" : IdxToken += 1
                        ReDim Preserve T_Token(IdxToken)
                    Case TokenList.T_Number
                        For i As Integer = 1 To Len(BuffChar)
                            chr = GetChar(BuffChar, i)
                            If Asc(chr) >= 65 And Asc(chr) <= 90 Then
                                OkVal = False
                            End If
                        Next
                        If OkVal Then
                            With T_Token(IdxToken)
                                .Line = Line
                                .Token = TokenList.T_Value
                                .Lexeme = BuffChar
                            End With
                            BuffChar = "" : IdxToken += 1
                            ReDim Preserve T_Token(IdxToken)
                        Else
                            With T_Token(IdxToken)
                                .Line = Line
                                .Token = TokenList.T_Variable
                                .Lexeme = BuffChar
                            End With
                            BuffChar = "" : IdxToken += 1
                            ReDim Preserve T_Token(IdxToken)
                        End If
                        OkVal = True
                End Select
        End Select
    End Sub
End Class
