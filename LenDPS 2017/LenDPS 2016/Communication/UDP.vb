Public Class frmUDP

    Private Sub LoadUdpSetting()
        txtIp.Text = setUdp.Ip
        txtPort.Text = setUdp.Port
        txtLocalPort.Text = setUdp.LocalPort
    End Sub
    Public Sub saveUdpSetting()
        setUdp.Ip = txtIp.Text
        setUdp.Port = CInt(txtPort.Text)
        setUdp.LocalPort = CInt(txtLocalPort.Text)
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        saveUdpSetting()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmUDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUdpSetting()
    End Sub
End Class