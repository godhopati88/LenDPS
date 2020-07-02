<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetWindow
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbW = New System.Windows.Forms.TextBox
        Me.tbH = New System.Windows.Forms.TextBox
        Me.btCancel = New System.Windows.Forms.Button
        Me.btOk = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.btOk)
        Me.Panel1.Controls.Add(Me.btCancel)
        Me.Panel1.Controls.Add(Me.tbH)
        Me.Panel1.Controls.Add(Me.tbW)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(175, 90)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Width"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Height"
        '
        'tbW
        '
        Me.tbW.Location = New System.Drawing.Point(59, 7)
        Me.tbW.Name = "tbW"
        Me.tbW.Size = New System.Drawing.Size(106, 20)
        Me.tbW.TabIndex = 2
        '
        'tbH
        '
        Me.tbH.Location = New System.Drawing.Point(59, 31)
        Me.tbH.Name = "tbH"
        Me.tbH.Size = New System.Drawing.Size(106, 20)
        Me.tbH.TabIndex = 3
        '
        'btCancel
        '
        Me.btCancel.Location = New System.Drawing.Point(59, 57)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(50, 23)
        Me.btCancel.TabIndex = 4
        Me.btCancel.Text = "Cancel"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'btOk
        '
        Me.btOk.Location = New System.Drawing.Point(115, 57)
        Me.btOk.Name = "btOk"
        Me.btOk.Size = New System.Drawing.Size(50, 23)
        Me.btOk.TabIndex = 5
        Me.btOk.Text = "OK"
        Me.btOk.UseVisualStyleBackColor = True
        '
        'frmSetWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(201, 117)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmSetWindow"
        Me.Text = "Window Setting"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents tbH As System.Windows.Forms.TextBox
    Friend WithEvents tbW As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btOk As System.Windows.Forms.Button
End Class
