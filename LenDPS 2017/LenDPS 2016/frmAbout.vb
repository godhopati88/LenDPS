Public Class frmAbout

    Private Sub btOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click
        Me.Close()
    End Sub

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
    End Sub
End Class