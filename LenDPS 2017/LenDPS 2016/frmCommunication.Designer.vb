<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommunication
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCommunication))
        Me.tcTcp = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        'Me.winSockTcp = New AxMSWinsockLib.AxWinsock()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.txtSend = New System.Windows.Forms.TextBox()
        Me.txtReceive = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtClientConnect = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnListen = New System.Windows.Forms.Button()
        Me.tpSerial = New System.Windows.Forms.TabPage()
        Me.tcTcp.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        'CType(Me.winSockTcp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcTcp
        '
        Me.tcTcp.Controls.Add(Me.TabPage1)
        Me.tcTcp.Controls.Add(Me.tpSerial)
        Me.tcTcp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcTcp.Location = New System.Drawing.Point(0, 0)
        Me.tcTcp.Name = "tcTcp"
        Me.tcTcp.SelectedIndex = 0
        Me.tcTcp.Size = New System.Drawing.Size(607, 321)
        Me.tcTcp.TabIndex = 0
        '
        'TabPage1
        '
        ' Me.TabPage1.Controls.Add(Me.winSockTcp)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.txtReceive)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(599, 295)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TCP Server"
        Me.TabPage1.UseVisualStyleBackColor = True
        ''
        ''winSockTcp
        ''
        'Me.winSockTcp.Enabled = True
        'Me.winSockTcp.Location = New System.Drawing.Point(285, 133)
        'Me.winSockTcp.Name = "winSockTcp"
        'Me.winSockTcp.OcxState = CType(resources.GetObject("winSockTcp.OcxState"), System.Windows.Forms.AxHost.State)
        'Me.winSockTcp.Size = New System.Drawing.Size(28, 28)
        'Me.winSockTcp.TabIndex = 22
        ''
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnSend)
        Me.GroupBox3.Controls.Add(Me.txtSend)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 234)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(581, 52)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Send Data "
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(502, 17)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 1
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(6, 19)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(490, 20)
        Me.txtSend.TabIndex = 0
        '
        'txtReceive
        '
        Me.txtReceive.Location = New System.Drawing.Point(11, 22)
        Me.txtReceive.Multiline = True
        Me.txtReceive.Name = "txtReceive"
        Me.txtReceive.Size = New System.Drawing.Size(410, 206)
        Me.txtReceive.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Receive Data"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtClientConnect)
        Me.GroupBox2.Location = New System.Drawing.Point(427, 85)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(165, 143)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " Client connect status "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Client Count : 0"
        '
        'txtClientConnect
        '
        Me.txtClientConnect.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientConnect.Location = New System.Drawing.Point(9, 19)
        Me.txtClientConnect.Multiline = True
        Me.txtClientConnect.Name = "txtClientConnect"
        Me.txtClientConnect.ReadOnly = True
        Me.txtClientConnect.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtClientConnect.Size = New System.Drawing.Size(150, 99)
        Me.txtClientConnect.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPort)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnListen)
        Me.GroupBox1.Location = New System.Drawing.Point(427, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(165, 73)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Server Status "
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(9, 42)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(71, 20)
        Me.txtPort.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Port"
        '
        'btnListen
        '
        Me.btnListen.Location = New System.Drawing.Point(86, 40)
        Me.btnListen.Name = "btnListen"
        Me.btnListen.Size = New System.Drawing.Size(75, 23)
        Me.btnListen.TabIndex = 0
        Me.btnListen.Text = "Listen"
        Me.btnListen.UseVisualStyleBackColor = True
        '
        'tpSerial
        '
        Me.tpSerial.Location = New System.Drawing.Point(4, 22)
        Me.tpSerial.Name = "tpSerial"
        Me.tpSerial.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSerial.Size = New System.Drawing.Size(599, 295)
        Me.tpSerial.TabIndex = 1
        Me.tpSerial.Text = "Serial"
        Me.tpSerial.UseVisualStyleBackColor = True
        '
        'frmCommunication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 321)
        Me.Controls.Add(Me.tcTcp)
        Me.Name = "frmCommunication"
        Me.Text = "Com Setting"
        Me.tcTcp.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        'CType(Me.winSockTcp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcTcp As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tpSerial As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnListen As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClientConnect As System.Windows.Forms.TextBox
    Friend WithEvents txtReceive As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents txtSend As System.Windows.Forms.TextBox
    'Friend WithEvents winSockTcp As AxMSWinsockLib.AxWinsock
End Class
