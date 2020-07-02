Public Class ExpressionNode
    Private Enum Precedence
        None = 10
        Multiple = 9
        Plus = 8
    End Enum

    Private Expression As String
    Private LeftChild As ExpressionNode
    Private RightChild As ExpressionNode
    Private op As String

    'bool ---- true ----- compile process
    '     ---- false ---- run time process
    Public Sub New(ByVal new_expression As String)
        Expression = new_expression
        LeftChild = Nothing
        RightChild = Nothing

        'rev.. 15 april 2015
        If bCompiled Then
            ParseExpression()
            IdxBranch += 1
            ReDim Preserve Branch(IdxBranch)
        Else
            ParseExpression()
        End If
    End Sub

    Public ReadOnly Property Text() As String
        Get
            If op = "" Then Return Expression
            Return op
        End Get
    End Property


    Private Sub ParseExpression()
        If Expression.Length = 0 Then
            Expression = "0" : Exit Sub
        End If

        Dim best_prec As Precedence = Precedence.None
        Dim open_parens As Integer = 0
        Dim best_i As Integer = -1

        For i As Integer = 0 To Expression.Length - 1
            Dim ch As String = Expression.Substring(i, 1)
            Select Case ch
                Case "(" : open_parens += 1
                Case ")" : open_parens -= 1
                Case Else
                    If open_parens = 0 Then
                        If ch = "+" Or ch = "*" Then
                            Select Case ch
                                Case "*"
                                    If best_prec > Precedence.Multiple Then
                                        best_prec = Precedence.Multiple
                                        best_i = i
                                    End If
                                Case "+"
                                    If best_prec > Precedence.Plus Then
                                        best_prec = Precedence.Plus
                                        best_i = i
                                    End If
                            End Select
                        End If
                    End If
            End Select
        Next i

        If best_prec < Precedence.None Then
            Dim lexpr As String = Expression.Substring(0, best_i)
            Dim rexpr As String = Expression.Substring(best_i + 1)
            op = Expression.Substring(best_i, 1)

            LeftChild = New ExpressionNode(lexpr)
            RightChild = New ExpressionNode(rexpr)

            'rev.. 15 april 2015
            '--------- for compiler only,, simulator is not included -----------
            If bCompiled Then
                Branch(IdxBranch).Left = lexpr
                Branch(IdxBranch).Right = rexpr
                Branch(IdxBranch).Operand = op
            End If
            Exit Sub
        End If

        If Expression.StartsWith("(") AndAlso Expression.EndsWith(")") Then
            op = "( )"
            LeftChild = New ExpressionNode(Expression.Substring(1, Expression.Length - 2))
            Exit Sub
        End If
    End Sub

    Public Function Evaluate() As Boolean
        If op = "" Then
            Return GetDataVar(Expression)
        Else
            Select Case op.ToLower()
                Case "*" : Return LeftChild.Evaluate() And RightChild.Evaluate()
                Case "+" : Return LeftChild.Evaluate() Or RightChild.Evaluate()
                Case "( )" : Return LeftChild.Evaluate()
            End Select
        End If
    End Function
End Class
