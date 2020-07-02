<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTerminal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.rtbTerminal = New System.Windows.Forms.RichTextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 412)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(621, 25)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(60, 20)
        Me.ToolStripStatusLabel1.Text = "Status : "
        '
        'tsStatus
        '
        Me.tsStatus.Name = "tsStatus"
        Me.tsStatus.Size = New System.Drawing.Size(70, 20)
        Me.tsStatus.Text = "Time Out"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.rtbTerminal)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClear)
        Me.SplitContainer1.Size = New System.Drawing.Size(621, 412)
        Me.SplitContainer1.SplitterDistance = 328
        Me.SplitContainer1.TabIndex = 1
        '
        'rtbTerminal
        '
        Me.rtbTerminal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbTerminal.Location = New System.Drawing.Point(0, 0)
        Me.rtbTerminal.Name = "rtbTerminal"
        Me.rtbTerminal.Size = New System.Drawing.Size(621, 328)
        Me.rtbTerminal.TabIndex = 0
        Me.rtbTerminal.Text = ""
        '
        'btnClear
        '
        Me.btnClear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClear.Location = New System.Drawing.Point(0, 0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(621, 80)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "Clear Message"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'frmTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 437)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmTerminal"
        Me.Text = "Communication Terminal"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents rtbTerminal As RichTextBox
    Friend WithEvents btnClear As Button
    Friend WithEvents tsStatus As ToolStripStatusLabel
End Class
