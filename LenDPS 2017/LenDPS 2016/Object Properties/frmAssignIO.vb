Imports System.IO

Public Class frmAssignIO
    Dim idxRow As Integer
    Dim index As Integer

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        index = e.RowIndex
    End Sub

    Private Sub bAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAdd.Click
        Try
            If index = 0 Then idxRow = 1 Else idxRow += 1
            DataGridView1.Rows.Add()
            DataGridView1.Rows(idxRow - 1).Cells(1).Value = "VIM"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Try
            DataGridView1.Rows.Insert(index, 1)
            DataGridView1.Rows(index).Cells(1).Value = "VOM"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If index >= 0 And DataGridView1.RowCount > 0 Then
                DataGridView1.Rows.RemoveAt(index)
                idxRow -= 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click
        Debug.Print("index -> " & idxRow)
    End Sub
End Class