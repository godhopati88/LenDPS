<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsertDevice
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("VIM - 16 Channel")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("VOM - 16 Channel")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("sVCM")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Len VPS Interlocking", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Me.tbAdrs = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbAdrs
        '
        Me.tbAdrs.Location = New System.Drawing.Point(77, 97)
        Me.tbAdrs.Name = "tbAdrs"
        Me.tbAdrs.Size = New System.Drawing.Size(190, 20)
        Me.tbAdrs.TabIndex = 12
        Me.tbAdrs.Text = "01"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(274, 55)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 37)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(274, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(96, 37)
        Me.btnOk.TabIndex = 10
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(77, 12)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node1"
        TreeNode1.Tag = "1"
        TreeNode1.Text = "VIM - 16 Channel"
        TreeNode2.Name = "Node2"
        TreeNode2.Tag = "2"
        TreeNode2.Text = "VOM - 16 Channel"
        TreeNode3.Name = "Node3"
        TreeNode3.Tag = "3"
        TreeNode3.Text = "sVCM"
        TreeNode4.Name = "Node0"
        TreeNode4.Text = "Len VPS Interlocking"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4})
        Me.TreeView1.Size = New System.Drawing.Size(190, 80)
        Me.TreeView1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Type"
        '
        'frmInsertDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 123)
        Me.Controls.Add(Me.tbAdrs)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmInsertDevice"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbAdrs As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
