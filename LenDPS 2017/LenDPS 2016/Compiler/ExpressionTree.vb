Public Class ExpressionTree
    Public Root As ExpressionNode

    Public Sub New(ByVal expression As String)
        Root = New ExpressionNode(expression.Trim())
    End Sub

    Public Function Evaluate() As Boolean
        Return Root.Evaluate
    End Function
End Class
