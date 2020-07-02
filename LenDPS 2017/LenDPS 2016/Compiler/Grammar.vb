Imports Railway

Public Class Grammar
    Public Index As Long
    Dim list_grammar As ArrayList
    Dim p_grammar As ExpressionTree

    Public Sub New(ByVal starts As Long, ByVal type As Integer)
        Index = starts
        Check()
    End Sub

    Private Sub Check()
        Dim a, p As Long
        Dim c As Long = 0
        Dim s As Integer = 0
        Dim y As String = ""
        Dim Eror As Boolean = False
        Dim open_k As Integer = 0

        a = Index
        For Me.Index = a To Scanner.equation_Section(1) Step 1
            If c <> T_token(Index).line Then
                c = T_token(Index).line
                s = Index
                If s > 2 And T_Token(s - 1).Symbol = TokenList.T_Expression Or T_Token(s - 1).Symbol = TokenList.T_Rparen Then Exit For
            End If
            If Index > Scanner.equation_Section(1) Then
                Exit For
            ElseIf T_Token(Index).Symbol = TokenList.T_Bool Or T_Token(Index).Symbol = TokenList.T_Time Or T_Token(Index).Symbol = TokenList.T_Application Or T_Token(Index).Symbol = TokenList.T_If Then
                Exit For
            ElseIf T_Token(Index).Symbol = TokenList.T_Lparen Then
                open_k += 1
                p = Index
            ElseIf T_Token(Index).Symbol = TokenList.T_Rparen Then
                open_k -= 1
                If open_k < 0 Then
                    error_add("Error : ' " & T_Token(Index).Lexeme & " ' terlalu banyak --> line : " & T_Token(Index).Line)
                    Eror = True
                End If
            End If

            ' Equation 
            Select Case T_token(Index).symbol
                Case TokenList.T_Operator
                    If T_Token(Index + 1).Symbol = TokenList.T_Operator Or T_Token(Index + 1).Symbol = TokenList.T_Rparen Then
                        error_add("Error : ' " & T_Token(Index).Lexeme & " ' terlalu banyak --> line : " & T_Token(Index).Line)
                        Eror = True
                    End If

                Case TokenList.T_Expression
                    If Index + 1 > Scanner.equation_Section(1) Then Exit Select
                    If T_Token(Index + 1).Symbol = TokenList.T_Expression Or T_Token(Index + 1).Symbol = TokenList.T_Lparen Then
                        error_add("Error : ' " & T_Token(Index).Lexeme & " ' terlalu banyak --> line : " & T_Token(Index).Line)
                        Eror = True
                    End If

                Case TokenList.T_Lparen
                    If T_Token(Index + 1).Symbol = TokenList.T_Rparen Or T_Token(Index + 1).Symbol = TokenList.T_Operator Then
                        error_add("Error : ' " & T_Token(Index).Lexeme & " ' terlalu banyak --> line : " & T_Token(Index).Line)
                        Eror = True
                    End If

                Case TokenList.T_Rparen
                    If Index + 1 > Scanner.equation_Section(1) Then Exit Select
                    If T_Token(Index + 1).Symbol = TokenList.T_Lparen Or T_Token(Index + 1).Symbol = TokenList.T_Expression Then
                        If jumplist.Contains(T_Token(Index + 1).Lexeme) Then
                        Else
                            error_add("Error : ' " & T_Token(Index).Lexeme & " ' terlalu banyak --> line : " & T_Token(Index).Line)
                            Eror = True
                        End If
                    End If
            End Select

            If T_Token(Index).Token = TokenList.T_Variable Then
                SemanticCheck(T_Token(Index).Lexeme, T_Token(Index).Line)
            End If
            y = y + T_token(Index).lexeme

        Next Index
        Index -= 1

        If timeExist Then
            timeExist = False
            TimeList(IdxTime).equation = y
            dbEquation(UBound(dbEquation)).Type = eEquationType.TIMER
            IdxTime += 1
            ReDim Preserve TimeList(IdxTime)
        Else
            Equation_list(IdxEquation) = y
            dbEquation(UBound(dbEquation)).Type = eEquationType.BOOL
            IdxEquation += 1
            ReDim Preserve Equation_list(IdxEquation)
        End If
        dbEquation(UBound(dbEquation)).Expression = y

        ' To Ensure there is no error on parenthesis
        If open_k > 0 Then
            error_add("Error : ' " & T_Token(Index).Lexeme & " Too much --> line : " & T_Token(Index).Line)
            Eror = True
        End If

        ' If No ERROR make PARSE TREE
        If Eror = False Then
            'Debug.Print(y)
            p_grammar = New ExpressionTree(y)
        End If
    End Sub
End Class
