<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpcode
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btSearch = New System.Windows.Forms.Button()
        Me.cbData = New System.Windows.Forms.ComboBox()
        Me.cbTempCount = New System.Windows.Forms.CheckBox()
        Me.cbTempTimer = New System.Windows.Forms.CheckBox()
        Me.cbAddress = New System.Windows.Forms.CheckBox()
        Me.cbVar = New System.Windows.Forms.CheckBox()
        Me.lvVariable = New System.Windows.Forms.ListView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(611, 455)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.lvVariable)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(603, 429)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Variable"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 313)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(597, 113)
        Me.Panel1.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(517, 70)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 32)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btSearch)
        Me.GroupBox1.Controls.Add(Me.cbData)
        Me.GroupBox1.Controls.Add(Me.cbTempCount)
        Me.GroupBox1.Controls.Add(Me.cbTempTimer)
        Me.GroupBox1.Controls.Add(Me.cbAddress)
        Me.GroupBox1.Controls.Add(Me.cbVar)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(214, 101)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Find "
        '
        'btSearch
        '
        Me.btSearch.Location = New System.Drawing.Point(133, 63)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(75, 32)
        Me.btSearch.TabIndex = 2
        Me.btSearch.Text = "Search"
        Me.btSearch.UseVisualStyleBackColor = True
        '
        'cbData
        '
        Me.cbData.FormattingEnabled = True
        Me.cbData.Location = New System.Drawing.Point(6, 70)
        Me.cbData.Name = "cbData"
        Me.cbData.Size = New System.Drawing.Size(121, 21)
        Me.cbData.TabIndex = 1
        '
        'cbTempCount
        '
        Me.cbTempCount.AutoSize = True
        Me.cbTempCount.Location = New System.Drawing.Point(83, 42)
        Me.cbTempCount.Name = "cbTempCount"
        Me.cbTempCount.Size = New System.Drawing.Size(125, 17)
        Me.cbTempCount.TabIndex = 1
        Me.cbTempCount.Text = "Temp Count Address"
        Me.cbTempCount.UseVisualStyleBackColor = True
        '
        'cbTempTimer
        '
        Me.cbTempTimer.AutoSize = True
        Me.cbTempTimer.Location = New System.Drawing.Point(83, 19)
        Me.cbTempTimer.Name = "cbTempTimer"
        Me.cbTempTimer.Size = New System.Drawing.Size(123, 17)
        Me.cbTempTimer.TabIndex = 1
        Me.cbTempTimer.Text = "Temp Timer Address"
        Me.cbTempTimer.UseVisualStyleBackColor = True
        '
        'cbAddress
        '
        Me.cbAddress.AutoSize = True
        Me.cbAddress.Location = New System.Drawing.Point(6, 42)
        Me.cbAddress.Name = "cbAddress"
        Me.cbAddress.Size = New System.Drawing.Size(64, 17)
        Me.cbAddress.TabIndex = 1
        Me.cbAddress.Text = "Address"
        Me.cbAddress.UseVisualStyleBackColor = True
        '
        'cbVar
        '
        Me.cbVar.AutoSize = True
        Me.cbVar.Checked = True
        Me.cbVar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbVar.Location = New System.Drawing.Point(6, 19)
        Me.cbVar.Name = "cbVar"
        Me.cbVar.Size = New System.Drawing.Size(64, 17)
        Me.cbVar.TabIndex = 1
        Me.cbVar.Text = "Variable"
        Me.cbVar.UseVisualStyleBackColor = True
        '
        'lvVariable
        '
        Me.lvVariable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvVariable.Location = New System.Drawing.Point(3, 3)
        Me.lvVariable.Name = "lvVariable"
        Me.lvVariable.Size = New System.Drawing.Size(597, 304)
        Me.lvVariable.TabIndex = 0
        Me.lvVariable.UseCompatibleStateImageBehavior = False
        Me.lvVariable.View = System.Windows.Forms.View.Details
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(603, 429)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 313)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(597, 113)
        Me.Panel2.TabIndex = 0
        '
        'frmOpcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 455)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmOpcode"
        Me.Text = "frmOpcode"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lvVariable As System.Windows.Forms.ListView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbVar As System.Windows.Forms.CheckBox
    Friend WithEvents cbAddress As System.Windows.Forms.CheckBox
    Friend WithEvents cbTempTimer As System.Windows.Forms.CheckBox
    Friend WithEvents btSearch As System.Windows.Forms.Button
    Friend WithEvents cbData As System.Windows.Forms.ComboBox
    Friend WithEvents cbTempCount As System.Windows.Forms.CheckBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
