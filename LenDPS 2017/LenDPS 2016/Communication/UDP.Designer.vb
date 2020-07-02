<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUDP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIp = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.txtLocalPort = New System.Windows.Forms.TextBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLocalPort)
        Me.GroupBox1.Controls.Add(Me.txtPort)
        Me.GroupBox1.Controls.Add(Me.txtIp)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 91)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " UDP "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Module IP "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(314, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Local port"
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(86, 22)
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(212, 22)
        Me.txtIp.TabIndex = 1
        Me.txtIp.Text = "192.168.10.40"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(354, 22)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(89, 22)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "2000"
        '
        'txtLocalPort
        '
        Me.txtLocalPort.Location = New System.Drawing.Point(86, 56)
        Me.txtLocalPort.Name = "txtLocalPort"
        Me.txtLocalPort.Size = New System.Drawing.Size(89, 22)
        Me.txtLocalPort.TabIndex = 1
        Me.txtLocalPort.Text = "0"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(366, 109)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(95, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(265, 109)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(95, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmUDP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 143)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmUDP"
        Me.Text = "UDP Communication Setting"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLocalPort As TextBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents txtIp As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
End Class
