<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Server
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ConnectionCountLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.PortTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.StartStopButton = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.txtSend = New System.Windows.Forms.TextBox()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectionCountLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 345)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(390, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ConnectionCountLabel
        '
        Me.ConnectionCountLabel.Name = "ConnectionCountLabel"
        Me.ConnectionCountLabel.Size = New System.Drawing.Size(83, 17)
        Me.ConnectionCountLabel.Text = "0 Connections"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.PortTextBox, Me.StartStopButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(4, 0, 1, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(390, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel1.Text = "Port:"
        '
        'PortTextBox
        '
        Me.PortTextBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PortTextBox.Name = "PortTextBox"
        Me.PortTextBox.Size = New System.Drawing.Size(64, 25)
        Me.PortTextBox.Text = "200"
        Me.PortTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StartStopButton
        '
        Me.StartStopButton.CheckOnClick = True
        Me.StartStopButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StartStopButton.Name = "StartStopButton"
        Me.StartStopButton.Size = New System.Drawing.Size(39, 22)
        Me.StartStopButton.Text = "Start"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.RichTextBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSend)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdSend)
        Me.SplitContainer1.Size = New System.Drawing.Size(390, 320)
        Me.SplitContainer1.SplitterDistance = 273
        Me.SplitContainer1.TabIndex = 6
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(390, 273)
        Me.RichTextBox1.TabIndex = 7
        Me.RichTextBox1.Text = ""
        '
        'txtSend
        '
        Me.txtSend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSend.Location = New System.Drawing.Point(0, 0)
        Me.txtSend.Multiline = True
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(315, 43)
        Me.txtSend.TabIndex = 1
        '
        'cmdSend
        '
        Me.cmdSend.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdSend.Location = New System.Drawing.Point(315, 0)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(75, 43)
        Me.cmdSend.TabIndex = 0
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'Server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 367)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Server"
        Me.Text = "Server"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ConnectionCountLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PortTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents StartStopButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents txtSend As System.Windows.Forms.TextBox
End Class
