Imports Railway

Public Class SyntaxAnalysis
    Dim m_grammar As Grammar

    Private Sub Check(ByVal var As String, ByVal lexeme As String, ByVal line As Integer)
        Dim count As Integer = 0
        For i As Integer = 0 To UBound(Parameter)
            If var = Parameter(i).Name Then
                count += 1
                Exit For
            End If
        Next
        If count = 0 Then
            error_add("Error : Undefine Variable '" & lexeme & "' --> line : " & line)
        End If
    End Sub

    Public Sub New()
        Dim i As Long
        Tokens = TokenList.T_None
        ReDim dbEquation(0)

        i = Scanner.equation_Section(0)
        ' Equation syntax checking
        While (i <= Scanner.equation_Section(1))
            Select Case T_Token(i).Symbol
                Case TokenList.T_Bool         ' Squences: <BOOL> <EXPRESSION> <ASSIGN> <PERSAMAAN>
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Expression Then
                        error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    Else
                        If TimeExist = True Then
                            TimeList(IdxTime).varresult = T_Token(i).Lexeme
                            Check(TimeList(IdxTime).varresult, T_Token(i).Lexeme, T_Token(i).Line)
                        Else
                            Result_List(IdxResult) = T_Token(i).Lexeme
                            '-------------------- 
                            Check(Result_List(IdxResult), T_Token(i).Lexeme, T_Token(i).Line)
                            IdxResult += 1
                            ReDim Preserve Result_List(IdxResult)
                        End If
                    End If
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Assign Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    i += 1
                    If T_Token(i).Symbol = TokenList.T_Operator Then
                        error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    Else
                        'Debug.Print(i)
                        m_grammar = New Grammar(i, TokenList.T_Equation)
                        i = m_grammar.Index
                        ReDim Preserve dbEquation(UBound(dbEquation) + 1)
                    End If

                    If T_Token(i).Symbol <> TokenList.T_Expression And T_Token(i).Symbol <> TokenList.T_Rparen Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    Tokens = TokenList.T_Bool

                    '*** REV 14 MEI 2014
                Case TokenList.T_Time     ' Squences: <TIME> <DELAY> <ASSIGN> <EXPRESSION> <SECONDS/MINUTES>
                    Dim temporary_time As Integer
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Delay Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Assign Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Expression Then
                        error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    Else
                        temporary_time = T_Token(i).Lexeme
                    End If
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Seconds And T_Token(i).Symbol <> TokenList.T_Minutes Then
                        error_add("Error : ' " & T_Token(i).Lexeme & " is not declared " & " ' --> line : " & T_Token(i).Line)
                    Else
                        If T_Token(i).Symbol = TokenList.T_Seconds Then TimeList(IdxTime).overflow = temporary_time
                        If T_Token(i).Symbol = TokenList.T_Minutes Then TimeList(IdxTime).overflow = temporary_time * 60
                        TimeExist = True
                    End If
                    Tokens = TokenList.T_Time

                Case TokenList.T_Application       ' Squences: <APPLICATION> <ASSIGN> <STATEMENT> OR <(> <STATEMENT> <)>
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Assign Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    Dim parenthesis As Integer = 0
                    While 1
                        i += 1
                        If T_Token(i).Line <> T_Token(i - 1).Line Then i -= 1 : Exit While
                        If T_Token(i).Symbol = TokenList.T_Expression Or T_Token(i).Symbol = TokenList.T_Lparen Or T_Token(i).Symbol = TokenList.T_Rparen Then
                            Select Case T_Token(i).Symbol
                                Case TokenList.T_Lparen : parenthesis += 1
                                Case TokenList.T_Rparen : parenthesis -= 1
                            End Select
                        Else
                            error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                        End If
                    End While

                    If parenthesis > 0 Then error_add("Error : ' ( ' --> line : " & T_Token(i).Line)
                    If parenthesis < 0 Then error_add("Error : ' ) ' --> line : " & T_Token(i).Line)
                    Tokens = TokenList.T_Application

                Case TokenList.T_If      ' Squences: <IF> <(> <EXPRESSION> <OP_LOGIC> <EXPRESSION> <)> <STATEMENT>
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Lparen Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Expression Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_OperatorL Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Expression And T_Token(i).Symbol <> TokenList.T_Status Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    i += 1
                    If T_Token(i).Symbol <> TokenList.T_Rparen Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    i += 1
                    If T_Token(i).Symbol = TokenList.T_Goto Then
                        i += 1
                        If T_Token(i).Symbol = TokenList.T_Expression Then
                            JumpList.Add(T_Token(i).Lexeme & ":")
                        Else
                            error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                        End If

                    ElseIf T_Token(i).Symbol = TokenList.T_Bool Then
                        i -= 1
                        Exit Select
                    ElseIf T_Token(i).Symbol = TokenList.T_Expression Then
                        i += 1
                        If T_Token(i).Symbol <> TokenList.T_Assign Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                        i += 1
                        If T_Token(i).Symbol = TokenList.T_Operator Then
                            error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                        Else
                            m_grammar = New Grammar(i, TokenList.T_Equation)
                            i = m_grammar.Index
                        End If

                        If T_Token(i).Symbol <> TokenList.T_Expression And T_Token(i).Symbol <> TokenList.T_Rparen Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    End If
                    Tokens = TokenList.T_If

                Case TokenList.T_Else
                    If T_Token(i).Symbol = TokenList.T_Goto Then
                        i += 1
                        If T_Token(i).Symbol = TokenList.T_Expression Then
                            JumpList.Add(T_Token(i).Lexeme & ":")
                        Else
                            error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                        End If
                    ElseIf T_Token(i).Symbol = TokenList.T_Bool Then
                        i -= 1
                        Exit Select
                    ElseIf T_Token(i).Symbol = TokenList.T_Expression Then
                        i += 1
                        If T_Token(i).Symbol <> TokenList.T_Assign Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                        i += 1
                        If T_Token(i).Symbol = TokenList.T_Operator Then
                            error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                        Else
                            m_grammar = New Grammar(i, TokenList.T_Equation)
                            i = m_grammar.Index
                        End If

                        If T_Token(i).Symbol <> TokenList.T_Expression And T_Token(i).Symbol <> TokenList.T_Rparen Then error_add("Error : ' " & T_Token(i).Lexeme & " ' --> line : " & T_Token(i).Line)
                    End If
                    Tokens = TokenList.T_Else
            End Select
            i += 1
        End While
    End Sub
End Class
