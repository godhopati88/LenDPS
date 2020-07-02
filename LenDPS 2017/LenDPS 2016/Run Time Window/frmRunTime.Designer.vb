<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRunTime
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
        Me.components = New System.ComponentModel.Container()
        Me.pRunMainWdw = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DaftarVariableToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Runtime = New System.Windows.Forms.Timer(Me.components)
        Me.Delay = New System.Windows.Forms.Timer(Me.components)
        Me.pRunMainWdw.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pRunMainWdw
        '
        Me.pRunMainWdw.AutoScroll = True
        Me.pRunMainWdw.Controls.Add(Me.MenuStrip1)
        Me.pRunMainWdw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pRunMainWdw.Location = New System.Drawing.Point(0, 0)
        Me.pRunMainWdw.Margin = New System.Windows.Forms.Padding(4)
        Me.pRunMainWdw.Name = "pRunMainWdw"
        Me.pRunMainWdw.Size = New System.Drawing.Size(1396, 777)
        Me.pRunMainWdw.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1396, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DaftarVariableToolStripMenuItem1, Me.TerminalToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(57, 24)
        Me.ViewToolStripMenuItem.Text = "View "
        '
        'DaftarVariableToolStripMenuItem1
        '
        Me.DaftarVariableToolStripMenuItem1.Name = "DaftarVariableToolStripMenuItem1"
        Me.DaftarVariableToolStripMenuItem1.Size = New System.Drawing.Size(184, 26)
        Me.DaftarVariableToolStripMenuItem1.Text = "Daftar Variable"
        '
        'TerminalToolStripMenuItem
        '
        Me.TerminalToolStripMenuItem.Name = "TerminalToolStripMenuItem"
        Me.TerminalToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.TerminalToolStripMenuItem.Text = "Terminal"
        '
        'Runtime
        '
        Me.Runtime.Interval = 50
        '
        'Delay
        '
        Me.Delay.Interval = 500
        '
        'frmRunTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1396, 777)
        Me.Controls.Add(Me.pRunMainWdw)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmRunTime"
        Me.Text = "Len DPS"
        Me.pRunMainWdw.ResumeLayout(False)
        Me.pRunMainWdw.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pRunMainWdw As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Runtime As System.Windows.Forms.Timer
    Friend WithEvents Delay As System.Windows.Forms.Timer
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DaftarVariableToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TerminalToolStripMenuItem As ToolStripMenuItem
End Class
