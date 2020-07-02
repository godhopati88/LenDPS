<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("I/O Devices")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Communication")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("I/O - Configuration", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProjectAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuildToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuildToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MakeHexFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UDPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCPIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SERVERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CLIENTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MODBUSTCPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SERVERToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CLIENTToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.IOConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutDPSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.FindToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RunToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.StopToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tbGridSizeToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.LineToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DotToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.NoGridToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.cmsLayoutEditor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsBooleanTextEditor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DsfdfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsDevices = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AppendDeviceToolStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.deleteToolStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsComVtl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteVtlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAllVtlToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsLink = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LinkToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteLinkVariableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsComNVtl = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteNvtlToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAllNvtlToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.pProperties = New System.Windows.Forms.Panel()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btIdColor4 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txIdColor4 = New System.Windows.Forms.TextBox()
        Me.btIdColor2 = New System.Windows.Forms.Button()
        Me.txIdColor2 = New System.Windows.Forms.TextBox()
        Me.btIdColor3 = New System.Windows.Forms.Button()
        Me.btIdColor1 = New System.Windows.Forms.Button()
        Me.txIdColor3 = New System.Windows.Forms.TextBox()
        Me.txIdColor1 = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.pType = New System.Windows.Forms.Panel()
        Me.pSize = New System.Windows.Forms.Panel()
        Me.txThickness = New System.Windows.Forms.TextBox()
        Me.txDiameter = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbDirection = New System.Windows.Forms.ComboBox()
        Me.lbDir = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.pGeometri = New System.Windows.Forms.Panel()
        Me.tbH = New System.Windows.Forms.TextBox()
        Me.tbW = New System.Windows.Forms.TextBox()
        Me.tbX = New System.Windows.Forms.TextBox()
        Me.tbY = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pTextID = New System.Windows.Forms.Panel()
        Me.btFont = New System.Windows.Forms.Button()
        Me.btTextColor = New System.Windows.Forms.Button()
        Me.cbTextPos = New System.Windows.Forms.ComboBox()
        Me.txColor = New System.Windows.Forms.TextBox()
        Me.txFont = New System.Windows.Forms.TextBox()
        Me.tbNameObject = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pMenu = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.pbPairButton = New System.Windows.Forms.PictureBox()
        Me.pbToggleButton = New System.Windows.Forms.PictureBox()
        Me.pbPushButton = New System.Windows.Forms.PictureBox()
        Me.pbCounter = New System.Windows.Forms.PictureBox()
        Me.pbButton = New System.Windows.Forms.PictureBox()
        Me.pbShape = New System.Windows.Forms.PictureBox()
        Me.pbBuzzer = New System.Windows.Forms.PictureBox()
        Me.pbLabel = New System.Windows.Forms.PictureBox()
        Me.pbCheckBox = New System.Windows.Forms.PictureBox()
        Me.pbTrack = New System.Windows.Forms.PictureBox()
        Me.pbPointMachine = New System.Windows.Forms.PictureBox()
        Me.pbSignal = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pContainer = New System.Windows.Forms.Panel()
        Me.WdwContainer = New Railway.winContainer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Editor = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.clmRoute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.clmSignal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmWesel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTrack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmApproachTrack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.panelDevice = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtGroups = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.panelCommunication = New System.Windows.Forms.Panel()
        Me.btInsert = New System.Windows.Forms.Button()
        Me.btDelete = New System.Windows.Forms.Button()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.btDown = New System.Windows.Forms.Button()
        Me.btUp = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lvFromLCP = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lvToLCP = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.treeView1 = New System.Windows.Forms.TreeView()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPageError = New System.Windows.Forms.TabPage()
        Me.lbError = New System.Windows.Forms.ListBox()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.cmsLayoutEditor.SuspendLayout()
        Me.cmsBooleanTextEditor.SuspendLayout()
        Me.cmsDevices.SuspendLayout()
        Me.cmsComVtl.SuspendLayout()
        Me.cmsLink.SuspendLayout()
        Me.cmsComNVtl.SuspendLayout()
        Me.pProperties.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pType.SuspendLayout()
        Me.pSize.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.pGeometri.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pTextID.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pMenu.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.pbPairButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbToggleButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPushButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCounter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbShape, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBuzzer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCheckBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTrack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPointMachine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSignal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pContainer.SuspendLayout()
        CType(Me.WdwContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.panelDevice.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.panelCommunication.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPageError.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.BuildToolStripMenuItem, Me.EditToolStripMenuItem, Me.DebugToolStripMenuItem, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1461, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ToolStripMenuItem4, Me.OpenToolStripMenuItem, Me.ToolStripMenuItem5, Me.SaveProjectToolStripMenuItem, Me.SaveProjectAsToolStripMenuItem, Me.ToolStripMenuItem7, Me.CloseToolStripMenuItem, Me.ToolStripMenuItem8})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(223, 26)
        Me.NewToolStripMenuItem.Text = "&New Project"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(220, 6)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(223, 26)
        Me.OpenToolStripMenuItem.Text = "&Open Project"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(220, 6)
        '
        'SaveProjectToolStripMenuItem
        '
        Me.SaveProjectToolStripMenuItem.Image = CType(resources.GetObject("SaveProjectToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveProjectToolStripMenuItem.Name = "SaveProjectToolStripMenuItem"
        Me.SaveProjectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveProjectToolStripMenuItem.Size = New System.Drawing.Size(223, 26)
        Me.SaveProjectToolStripMenuItem.Text = "&Save Project"
        '
        'SaveProjectAsToolStripMenuItem
        '
        Me.SaveProjectAsToolStripMenuItem.Name = "SaveProjectAsToolStripMenuItem"
        Me.SaveProjectAsToolStripMenuItem.Size = New System.Drawing.Size(223, 26)
        Me.SaveProjectAsToolStripMenuItem.Text = "Save Project As..."
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(220, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(223, 26)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(220, 6)
        '
        'BuildToolStripMenuItem
        '
        Me.BuildToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuildToolStripMenuItem1, Me.MakeHexFileToolStripMenuItem})
        Me.BuildToolStripMenuItem.Name = "BuildToolStripMenuItem"
        Me.BuildToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.BuildToolStripMenuItem.Text = "Build"
        '
        'BuildToolStripMenuItem1
        '
        Me.BuildToolStripMenuItem1.Image = CType(resources.GetObject("BuildToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.BuildToolStripMenuItem1.Name = "BuildToolStripMenuItem1"
        Me.BuildToolStripMenuItem1.Size = New System.Drawing.Size(177, 26)
        Me.BuildToolStripMenuItem1.Text = "Build"
        '
        'MakeHexFileToolStripMenuItem
        '
        Me.MakeHexFileToolStripMenuItem.Name = "MakeHexFileToolStripMenuItem"
        Me.MakeHexFileToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.MakeHexFileToolStripMenuItem.Text = "Make Hex File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem1, Me.CopyToolStripMenuItem1, Me.PasteToolStripMenuItem1, Me.ToolStripMenuItem9, Me.FToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(47, 24)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CutToolStripMenuItem1
        '
        Me.CutToolStripMenuItem1.Image = CType(resources.GetObject("CutToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.CutToolStripMenuItem1.Name = "CutToolStripMenuItem1"
        Me.CutToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem1.Size = New System.Drawing.Size(169, 26)
        Me.CutToolStripMenuItem1.Text = "Cut"
        '
        'CopyToolStripMenuItem1
        '
        Me.CopyToolStripMenuItem1.Image = CType(resources.GetObject("CopyToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem1.Name = "CopyToolStripMenuItem1"
        Me.CopyToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem1.Size = New System.Drawing.Size(169, 26)
        Me.CopyToolStripMenuItem1.Text = "Copy"
        '
        'PasteToolStripMenuItem1
        '
        Me.PasteToolStripMenuItem1.Image = CType(resources.GetObject("PasteToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem1.Name = "PasteToolStripMenuItem1"
        Me.PasteToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem1.Size = New System.Drawing.Size(169, 26)
        Me.PasteToolStripMenuItem1.Text = "Paste"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(166, 6)
        '
        'FToolStripMenuItem
        '
        Me.FToolStripMenuItem.Image = CType(resources.GetObject("FToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FToolStripMenuItem.Name = "FToolStripMenuItem"
        Me.FToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FToolStripMenuItem.Size = New System.Drawing.Size(169, 26)
        Me.FToolStripMenuItem.Text = "Find"
        '
        'DebugToolStripMenuItem
        '
        Me.DebugToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunToolStripMenuItem})
        Me.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem"
        Me.DebugToolStripMenuItem.Size = New System.Drawing.Size(66, 24)
        Me.DebugToolStripMenuItem.Text = "Debug"
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.RunToolStripMenuItem.Text = "Run"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingToolStripMenuItem, Me.IOConfigurationToolStripMenuItem, Me.AddressToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(76, 24)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UDPToolStripMenuItem, Me.TCPIPToolStripMenuItem, Me.MODBUSTCPToolStripMenuItem})
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(200, 26)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'UDPToolStripMenuItem
        '
        Me.UDPToolStripMenuItem.Name = "UDPToolStripMenuItem"
        Me.UDPToolStripMenuItem.Size = New System.Drawing.Size(174, 26)
        Me.UDPToolStripMenuItem.Text = "UDP"
        '
        'TCPIPToolStripMenuItem
        '
        Me.TCPIPToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SERVERToolStripMenuItem, Me.CLIENTToolStripMenuItem})
        Me.TCPIPToolStripMenuItem.Name = "TCPIPToolStripMenuItem"
        Me.TCPIPToolStripMenuItem.Size = New System.Drawing.Size(174, 26)
        Me.TCPIPToolStripMenuItem.Text = "TCP/IP"
        '
        'SERVERToolStripMenuItem
        '
        Me.SERVERToolStripMenuItem.Name = "SERVERToolStripMenuItem"
        Me.SERVERToolStripMenuItem.Size = New System.Drawing.Size(135, 26)
        Me.SERVERToolStripMenuItem.Text = "SERVER"
        '
        'CLIENTToolStripMenuItem
        '
        Me.CLIENTToolStripMenuItem.Name = "CLIENTToolStripMenuItem"
        Me.CLIENTToolStripMenuItem.Size = New System.Drawing.Size(135, 26)
        Me.CLIENTToolStripMenuItem.Text = "CLIENT"
        '
        'MODBUSTCPToolStripMenuItem
        '
        Me.MODBUSTCPToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SERVERToolStripMenuItem1, Me.CLIENTToolStripMenuItem1})
        Me.MODBUSTCPToolStripMenuItem.Name = "MODBUSTCPToolStripMenuItem"
        Me.MODBUSTCPToolStripMenuItem.Size = New System.Drawing.Size(174, 26)
        Me.MODBUSTCPToolStripMenuItem.Text = "MODBUS TCP"
        '
        'SERVERToolStripMenuItem1
        '
        Me.SERVERToolStripMenuItem1.Name = "SERVERToolStripMenuItem1"
        Me.SERVERToolStripMenuItem1.Size = New System.Drawing.Size(135, 26)
        Me.SERVERToolStripMenuItem1.Text = "SERVER"
        '
        'CLIENTToolStripMenuItem1
        '
        Me.CLIENTToolStripMenuItem1.Name = "CLIENTToolStripMenuItem1"
        Me.CLIENTToolStripMenuItem1.Size = New System.Drawing.Size(135, 26)
        Me.CLIENTToolStripMenuItem1.Text = "CLIENT"
        '
        'IOConfigurationToolStripMenuItem
        '
        Me.IOConfigurationToolStripMenuItem.Name = "IOConfigurationToolStripMenuItem"
        Me.IOConfigurationToolStripMenuItem.Size = New System.Drawing.Size(200, 26)
        Me.IOConfigurationToolStripMenuItem.Text = "I/O Configuration"
        '
        'AddressToolStripMenuItem
        '
        Me.AddressToolStripMenuItem.Name = "AddressToolStripMenuItem"
        Me.AddressToolStripMenuItem.Size = New System.Drawing.Size(200, 26)
        Me.AddressToolStripMenuItem.Text = "Address"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutDPSToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutDPSToolStripMenuItem
        '
        Me.AboutDPSToolStripMenuItem.Name = "AboutDPSToolStripMenuItem"
        Me.AboutDPSToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.AboutDPSToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.AboutDPSToolStripMenuItem.Text = "About DPS"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripSeparator1, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.FindToolStripButton, Me.ToolStripSeparator2, Me.RunToolStripButton, Me.StopToolStripButton, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.tbGridSizeToolStripTextBox, Me.LineToolStripButton, Me.DotToolStripButton, Me.NoGridToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1461, 27)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.NewToolStripButton.Text = "New"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.OpenToolStripButton.Text = "Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.SaveToolStripButton.Text = "Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.CutToolStripButton.Text = "Cut"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.CopyToolStripButton.Text = "Copy"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.PasteToolStripButton.Text = "Paste"
        '
        'FindToolStripButton
        '
        Me.FindToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FindToolStripButton.Image = CType(resources.GetObject("FindToolStripButton.Image"), System.Drawing.Image)
        Me.FindToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FindToolStripButton.Name = "FindToolStripButton"
        Me.FindToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.FindToolStripButton.Text = "Find"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'RunToolStripButton
        '
        Me.RunToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RunToolStripButton.Image = CType(resources.GetObject("RunToolStripButton.Image"), System.Drawing.Image)
        Me.RunToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RunToolStripButton.Name = "RunToolStripButton"
        Me.RunToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.RunToolStripButton.Text = "Run"
        '
        'StopToolStripButton
        '
        Me.StopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StopToolStripButton.Image = CType(resources.GetObject("StopToolStripButton.Image"), System.Drawing.Image)
        Me.StopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StopToolStripButton.Name = "StopToolStripButton"
        Me.StopToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.StopToolStripButton.Text = "Stop"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(68, 24)
        Me.ToolStripLabel1.Text = "Grid Size"
        '
        'tbGridSizeToolStripTextBox
        '
        Me.tbGridSizeToolStripTextBox.Name = "tbGridSizeToolStripTextBox"
        Me.tbGridSizeToolStripTextBox.Size = New System.Drawing.Size(32, 27)
        '
        'LineToolStripButton
        '
        Me.LineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LineToolStripButton.Image = CType(resources.GetObject("LineToolStripButton.Image"), System.Drawing.Image)
        Me.LineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LineToolStripButton.Name = "LineToolStripButton"
        Me.LineToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.LineToolStripButton.Text = "Line Grid"
        '
        'DotToolStripButton
        '
        Me.DotToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DotToolStripButton.Image = CType(resources.GetObject("DotToolStripButton.Image"), System.Drawing.Image)
        Me.DotToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DotToolStripButton.Name = "DotToolStripButton"
        Me.DotToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.DotToolStripButton.Text = "Dot Grid"
        '
        'NoGridToolStripButton
        '
        Me.NoGridToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NoGridToolStripButton.Image = CType(resources.GetObject("NoGridToolStripButton.Image"), System.Drawing.Image)
        Me.NoGridToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NoGridToolStripButton.Name = "NoGridToolStripButton"
        Me.NoGridToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.NoGridToolStripButton.Text = "No Grid"
        '
        'cmsLayoutEditor
        '
        Me.cmsLayoutEditor.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsLayoutEditor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.ViewCodeToolStripMenuItem, Me.ToolStripMenuItem1, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripMenuItem2, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem3, Me.PropertiesToolStripMenuItem})
        Me.cmsLayoutEditor.Name = "ContextMenuStrip1"
        Me.cmsLayoutEditor.Size = New System.Drawing.Size(154, 204)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Image = CType(resources.GetObject("RefreshToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(153, 26)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ViewCodeToolStripMenuItem
        '
        Me.ViewCodeToolStripMenuItem.Image = CType(resources.GetObject("ViewCodeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ViewCodeToolStripMenuItem.Name = "ViewCodeToolStripMenuItem"
        Me.ViewCodeToolStripMenuItem.Size = New System.Drawing.Size(153, 26)
        Me.ViewCodeToolStripMenuItem.Text = "View Code"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(150, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = CType(resources.GetObject("CutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(153, 26)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(153, 26)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(153, 26)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(150, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(153, 26)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(150, 6)
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Image = CType(resources.GetObject("PropertiesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(153, 26)
        Me.PropertiesToolStripMenuItem.Text = "Properties"
        '
        'cmsBooleanTextEditor
        '
        Me.cmsBooleanTextEditor.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsBooleanTextEditor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DsfdfToolStripMenuItem, Me.ToolStripMenuItem10, Me.CutToolStripMenuItem2, Me.CopyToolStripMenuItem2, Me.PasteToolStripMenuItem2, Me.DeleteToolStripMenuItem1, Me.ToolStripMenuItem11, Me.FindToolStripMenuItem, Me.ToolStripMenuItem12, Me.SelectAllToolStripMenuItem})
        Me.cmsBooleanTextEditor.Name = "ContextMenuStrip2"
        Me.cmsBooleanTextEditor.Size = New System.Drawing.Size(197, 204)
        '
        'DsfdfToolStripMenuItem
        '
        Me.DsfdfToolStripMenuItem.Image = CType(resources.GetObject("DsfdfToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DsfdfToolStripMenuItem.Name = "DsfdfToolStripMenuItem"
        Me.DsfdfToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.DsfdfToolStripMenuItem.Size = New System.Drawing.Size(196, 26)
        Me.DsfdfToolStripMenuItem.Text = "Undo"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(193, 6)
        '
        'CutToolStripMenuItem2
        '
        Me.CutToolStripMenuItem2.Image = CType(resources.GetObject("CutToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.CutToolStripMenuItem2.Name = "CutToolStripMenuItem2"
        Me.CutToolStripMenuItem2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem2.Size = New System.Drawing.Size(196, 26)
        Me.CutToolStripMenuItem2.Text = "Cut"
        '
        'CopyToolStripMenuItem2
        '
        Me.CopyToolStripMenuItem2.Image = CType(resources.GetObject("CopyToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem2.Name = "CopyToolStripMenuItem2"
        Me.CopyToolStripMenuItem2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem2.Size = New System.Drawing.Size(196, 26)
        Me.CopyToolStripMenuItem2.Text = "Copy"
        '
        'PasteToolStripMenuItem2
        '
        Me.PasteToolStripMenuItem2.Image = CType(resources.GetObject("PasteToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem2.Name = "PasteToolStripMenuItem2"
        Me.PasteToolStripMenuItem2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem2.Size = New System.Drawing.Size(196, 26)
        Me.PasteToolStripMenuItem2.Text = "Paste"
        '
        'DeleteToolStripMenuItem1
        '
        Me.DeleteToolStripMenuItem1.Image = CType(resources.GetObject("DeleteToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        Me.DeleteToolStripMenuItem1.Size = New System.Drawing.Size(196, 26)
        Me.DeleteToolStripMenuItem1.Text = "Delete"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(193, 6)
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Image = CType(resources.GetObject("FindToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(196, 26)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(193, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(196, 26)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'cmsDevices
        '
        Me.cmsDevices.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsDevices.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppendDeviceToolStrip, Me.deleteToolStrip})
        Me.cmsDevices.Name = "cmsDevices"
        Me.cmsDevices.Size = New System.Drawing.Size(190, 52)
        '
        'AppendDeviceToolStrip
        '
        Me.AppendDeviceToolStrip.Name = "AppendDeviceToolStrip"
        Me.AppendDeviceToolStrip.Size = New System.Drawing.Size(189, 24)
        Me.AppendDeviceToolStrip.Text = "Append Device..."
        '
        'deleteToolStrip
        '
        Me.deleteToolStrip.Name = "deleteToolStrip"
        Me.deleteToolStrip.Size = New System.Drawing.Size(189, 24)
        Me.deleteToolStrip.Text = "Delete..."
        '
        'cmsComVtl
        '
        Me.cmsComVtl.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsComVtl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteVtlToolStripMenuItem, Me.DeleteAllVtlToolStripMenuItem1})
        Me.cmsComVtl.Name = "cmsMapping"
        Me.cmsComVtl.Size = New System.Drawing.Size(152, 52)
        '
        'DeleteVtlToolStripMenuItem
        '
        Me.DeleteVtlToolStripMenuItem.Name = "DeleteVtlToolStripMenuItem"
        Me.DeleteVtlToolStripMenuItem.Size = New System.Drawing.Size(151, 24)
        Me.DeleteVtlToolStripMenuItem.Text = "Delete..."
        '
        'DeleteAllVtlToolStripMenuItem1
        '
        Me.DeleteAllVtlToolStripMenuItem1.Name = "DeleteAllVtlToolStripMenuItem1"
        Me.DeleteAllVtlToolStripMenuItem1.Size = New System.Drawing.Size(151, 24)
        Me.DeleteAllVtlToolStripMenuItem1.Text = "Delete all..."
        '
        'cmsLink
        '
        Me.cmsLink.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsLink.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LinkToToolStripMenuItem, Me.DeleteLinkVariableToolStripMenuItem, Me.DeleteAllToolStripMenuItem})
        Me.cmsLink.Name = "cmsLink"
        Me.cmsLink.Size = New System.Drawing.Size(220, 76)
        '
        'LinkToToolStripMenuItem
        '
        Me.LinkToToolStripMenuItem.Name = "LinkToToolStripMenuItem"
        Me.LinkToToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.LinkToToolStripMenuItem.Text = "Link to..."
        '
        'DeleteLinkVariableToolStripMenuItem
        '
        Me.DeleteLinkVariableToolStripMenuItem.Name = "DeleteLinkVariableToolStripMenuItem"
        Me.DeleteLinkVariableToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.DeleteLinkVariableToolStripMenuItem.Text = "Delete Link Variable..."
        '
        'DeleteAllToolStripMenuItem
        '
        Me.DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem"
        Me.DeleteAllToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.DeleteAllToolStripMenuItem.Text = "Delete All Variables"
        '
        'cmsComNVtl
        '
        Me.cmsComNVtl.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsComNVtl.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteNvtlToolStripMenuItem2, Me.DeleteAllNvtlToolStripMenuItem1})
        Me.cmsComNVtl.Name = "cmsComNVtl"
        Me.cmsComNVtl.Size = New System.Drawing.Size(152, 52)
        '
        'DeleteNvtlToolStripMenuItem2
        '
        Me.DeleteNvtlToolStripMenuItem2.Name = "DeleteNvtlToolStripMenuItem2"
        Me.DeleteNvtlToolStripMenuItem2.Size = New System.Drawing.Size(151, 24)
        Me.DeleteNvtlToolStripMenuItem2.Text = "Delete..."
        '
        'DeleteAllNvtlToolStripMenuItem1
        '
        Me.DeleteAllNvtlToolStripMenuItem1.Name = "DeleteAllNvtlToolStripMenuItem1"
        Me.DeleteAllNvtlToolStripMenuItem1.Size = New System.Drawing.Size(151, 24)
        Me.DeleteAllNvtlToolStripMenuItem1.Text = "Delete all..."
        '
        'pProperties
        '
        Me.pProperties.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pProperties.Controls.Add(Me.tbName)
        Me.pProperties.Controls.Add(Me.Panel7)
        Me.pProperties.Controls.Add(Me.Panel3)
        Me.pProperties.Controls.Add(Me.Panel1)
        Me.pProperties.Controls.Add(Me.pMenu)
        Me.pProperties.Dock = System.Windows.Forms.DockStyle.Right
        Me.pProperties.Location = New System.Drawing.Point(1146, 55)
        Me.pProperties.Margin = New System.Windows.Forms.Padding(4)
        Me.pProperties.Name = "pProperties"
        Me.pProperties.Padding = New System.Windows.Forms.Padding(4)
        Me.pProperties.Size = New System.Drawing.Size(315, 975)
        Me.pProperties.TabIndex = 9
        '
        'tbName
        '
        Me.tbName.BackColor = System.Drawing.SystemColors.Window
        Me.tbName.Location = New System.Drawing.Point(8, 345)
        Me.tbName.Margin = New System.Windows.Forms.Padding(4)
        Me.tbName.Name = "tbName"
        Me.tbName.ReadOnly = True
        Me.tbName.Size = New System.Drawing.Size(299, 22)
        Me.tbName.TabIndex = 19
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gray
        Me.Panel7.Controls.Add(Me.Label10)
        Me.Panel7.Location = New System.Drawing.Point(8, 316)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(300, 31)
        Me.Panel7.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(5, 4)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(162, 25)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Object Properties"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(7, 16)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(301, 33)
        Me.Panel3.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 5)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.pType)
        Me.Panel1.Controls.Add(Me.pGeometri)
        Me.Panel1.Controls.Add(Me.pTextID)
        Me.Panel1.Location = New System.Drawing.Point(8, 369)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 427)
        Me.Panel1.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.btIdColor4)
        Me.Panel5.Controls.Add(Me.Label19)
        Me.Panel5.Controls.Add(Me.txIdColor4)
        Me.Panel5.Controls.Add(Me.btIdColor2)
        Me.Panel5.Controls.Add(Me.txIdColor2)
        Me.Panel5.Controls.Add(Me.btIdColor3)
        Me.Panel5.Controls.Add(Me.btIdColor1)
        Me.Panel5.Controls.Add(Me.txIdColor3)
        Me.Panel5.Controls.Add(Me.txIdColor1)
        Me.Panel5.Controls.Add(Me.Panel10)
        Me.Panel5.Controls.Add(Me.Label24)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 421)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(279, 176)
        Me.Panel5.TabIndex = 19
        '
        'btIdColor4
        '
        Me.btIdColor4.Location = New System.Drawing.Point(240, 135)
        Me.btIdColor4.Margin = New System.Windows.Forms.Padding(4)
        Me.btIdColor4.Name = "btIdColor4"
        Me.btIdColor4.Size = New System.Drawing.Size(28, 26)
        Me.btIdColor4.TabIndex = 24
        Me.btIdColor4.Tag = "4"
        Me.btIdColor4.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DimGray
        Me.Label19.Location = New System.Drawing.Point(5, 70)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 25)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Object"
        '
        'txIdColor4
        '
        Me.txIdColor4.Location = New System.Drawing.Point(143, 135)
        Me.txIdColor4.Margin = New System.Windows.Forms.Padding(4)
        Me.txIdColor4.Name = "txIdColor4"
        Me.txIdColor4.Size = New System.Drawing.Size(107, 22)
        Me.txIdColor4.TabIndex = 23
        '
        'btIdColor2
        '
        Me.btIdColor2.Location = New System.Drawing.Point(241, 70)
        Me.btIdColor2.Margin = New System.Windows.Forms.Padding(4)
        Me.btIdColor2.Name = "btIdColor2"
        Me.btIdColor2.Size = New System.Drawing.Size(28, 26)
        Me.btIdColor2.TabIndex = 21
        Me.btIdColor2.Tag = "2"
        Me.btIdColor2.UseVisualStyleBackColor = True
        '
        'txIdColor2
        '
        Me.txIdColor2.Location = New System.Drawing.Point(144, 70)
        Me.txIdColor2.Margin = New System.Windows.Forms.Padding(4)
        Me.txIdColor2.Name = "txIdColor2"
        Me.txIdColor2.Size = New System.Drawing.Size(105, 22)
        Me.txIdColor2.TabIndex = 20
        '
        'btIdColor3
        '
        Me.btIdColor3.Location = New System.Drawing.Point(240, 103)
        Me.btIdColor3.Margin = New System.Windows.Forms.Padding(4)
        Me.btIdColor3.Name = "btIdColor3"
        Me.btIdColor3.Size = New System.Drawing.Size(28, 26)
        Me.btIdColor3.TabIndex = 22
        Me.btIdColor3.Tag = "3"
        Me.btIdColor3.UseVisualStyleBackColor = True
        '
        'btIdColor1
        '
        Me.btIdColor1.Location = New System.Drawing.Point(241, 38)
        Me.btIdColor1.Margin = New System.Windows.Forms.Padding(4)
        Me.btIdColor1.Name = "btIdColor1"
        Me.btIdColor1.Size = New System.Drawing.Size(28, 26)
        Me.btIdColor1.TabIndex = 19
        Me.btIdColor1.Tag = "1"
        Me.btIdColor1.UseVisualStyleBackColor = True
        '
        'txIdColor3
        '
        Me.txIdColor3.Location = New System.Drawing.Point(143, 103)
        Me.txIdColor3.Margin = New System.Windows.Forms.Padding(4)
        Me.txIdColor3.Name = "txIdColor3"
        Me.txIdColor3.Size = New System.Drawing.Size(107, 22)
        Me.txIdColor3.TabIndex = 18
        '
        'txIdColor1
        '
        Me.txIdColor1.Location = New System.Drawing.Point(144, 38)
        Me.txIdColor1.Margin = New System.Windows.Forms.Padding(4)
        Me.txIdColor1.Name = "txIdColor1"
        Me.txIdColor1.Size = New System.Drawing.Size(105, 22)
        Me.txIdColor1.TabIndex = 18
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Gray
        Me.Panel10.Controls.Add(Me.Label22)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(279, 31)
        Me.Panel10.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(5, 4)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 25)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Color"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DimGray
        Me.Label24.Location = New System.Drawing.Point(5, 38)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(117, 25)
        Me.Label24.TabIndex = 11
        Me.Label24.Text = "Background"
        '
        'pType
        '
        Me.pType.BackColor = System.Drawing.Color.Silver
        Me.pType.Controls.Add(Me.pSize)
        Me.pType.Controls.Add(Me.cbDirection)
        Me.pType.Controls.Add(Me.lbDir)
        Me.pType.Controls.Add(Me.Panel9)
        Me.pType.Controls.Add(Me.Label11)
        Me.pType.Controls.Add(Me.cbType)
        Me.pType.Dock = System.Windows.Forms.DockStyle.Top
        Me.pType.Location = New System.Drawing.Point(0, 275)
        Me.pType.Margin = New System.Windows.Forms.Padding(4)
        Me.pType.Name = "pType"
        Me.pType.Size = New System.Drawing.Size(279, 146)
        Me.pType.TabIndex = 18
        '
        'pSize
        '
        Me.pSize.Controls.Add(Me.txThickness)
        Me.pSize.Controls.Add(Me.txDiameter)
        Me.pSize.Controls.Add(Me.Label18)
        Me.pSize.Controls.Add(Me.Label9)
        Me.pSize.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pSize.Location = New System.Drawing.Point(0, 112)
        Me.pSize.Margin = New System.Windows.Forms.Padding(4)
        Me.pSize.Name = "pSize"
        Me.pSize.Size = New System.Drawing.Size(279, 34)
        Me.pSize.TabIndex = 2
        '
        'txThickness
        '
        Me.txThickness.Location = New System.Drawing.Point(245, 4)
        Me.txThickness.Margin = New System.Windows.Forms.Padding(4)
        Me.txThickness.Name = "txThickness"
        Me.txThickness.Size = New System.Drawing.Size(25, 22)
        Me.txThickness.TabIndex = 15
        '
        'txDiameter
        '
        Me.txDiameter.Location = New System.Drawing.Point(104, 4)
        Me.txDiameter.Margin = New System.Windows.Forms.Padding(4)
        Me.txDiameter.Name = "txDiameter"
        Me.txDiameter.Size = New System.Drawing.Size(25, 22)
        Me.txDiameter.TabIndex = 14
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DimGray
        Me.Label18.Location = New System.Drawing.Point(136, 5)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(102, 25)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "Thickness"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(4, 5)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 25)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Diameter"
        '
        'cbDirection
        '
        Me.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDirection.FormattingEnabled = True
        Me.cbDirection.Location = New System.Drawing.Point(108, 74)
        Me.cbDirection.Margin = New System.Windows.Forms.Padding(4)
        Me.cbDirection.Name = "cbDirection"
        Me.cbDirection.Size = New System.Drawing.Size(156, 24)
        Me.cbDirection.TabIndex = 14
        '
        'lbDir
        '
        Me.lbDir.AutoSize = True
        Me.lbDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDir.ForeColor = System.Drawing.Color.DimGray
        Me.lbDir.Location = New System.Drawing.Point(5, 75)
        Me.lbDir.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbDir.Name = "lbDir"
        Me.lbDir.Size = New System.Drawing.Size(88, 25)
        Me.lbDir.TabIndex = 13
        Me.lbDir.Text = "Direction"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Gray
        Me.Panel9.Controls.Add(Me.Label23)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(279, 31)
        Me.Panel9.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(5, 4)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(57, 25)
        Me.Label23.TabIndex = 1
        Me.Label23.Text = "Type"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(5, 38)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 25)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Type"
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(108, 38)
        Me.cbType.Margin = New System.Windows.Forms.Padding(4)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(156, 24)
        Me.cbType.TabIndex = 12
        '
        'pGeometri
        '
        Me.pGeometri.BackColor = System.Drawing.Color.Silver
        Me.pGeometri.Controls.Add(Me.tbH)
        Me.pGeometri.Controls.Add(Me.tbW)
        Me.pGeometri.Controls.Add(Me.tbX)
        Me.pGeometri.Controls.Add(Me.tbY)
        Me.pGeometri.Controls.Add(Me.Label8)
        Me.pGeometri.Controls.Add(Me.Label7)
        Me.pGeometri.Controls.Add(Me.Label6)
        Me.pGeometri.Controls.Add(Me.Label5)
        Me.pGeometri.Controls.Add(Me.Label4)
        Me.pGeometri.Controls.Add(Me.Label3)
        Me.pGeometri.Controls.Add(Me.Panel4)
        Me.pGeometri.Dock = System.Windows.Forms.DockStyle.Top
        Me.pGeometri.Location = New System.Drawing.Point(0, 167)
        Me.pGeometri.Margin = New System.Windows.Forms.Padding(4)
        Me.pGeometri.Name = "pGeometri"
        Me.pGeometri.Size = New System.Drawing.Size(279, 108)
        Me.pGeometri.TabIndex = 17
        Me.pGeometri.Tag = "4"
        '
        'tbH
        '
        Me.tbH.Location = New System.Drawing.Point(209, 76)
        Me.tbH.Margin = New System.Windows.Forms.Padding(4)
        Me.tbH.Name = "tbH"
        Me.tbH.Size = New System.Drawing.Size(39, 22)
        Me.tbH.TabIndex = 11
        '
        'tbW
        '
        Me.tbW.Location = New System.Drawing.Point(121, 76)
        Me.tbW.Margin = New System.Windows.Forms.Padding(4)
        Me.tbW.Name = "tbW"
        Me.tbW.Size = New System.Drawing.Size(39, 22)
        Me.tbW.TabIndex = 10
        Me.tbW.Tag = "3"
        '
        'tbX
        '
        Me.tbX.Location = New System.Drawing.Point(121, 41)
        Me.tbX.Margin = New System.Windows.Forms.Padding(4)
        Me.tbX.Name = "tbX"
        Me.tbX.Size = New System.Drawing.Size(39, 22)
        Me.tbX.TabIndex = 9
        Me.tbX.Tag = "1"
        '
        'tbY
        '
        Me.tbY.Location = New System.Drawing.Point(209, 41)
        Me.tbY.Margin = New System.Windows.Forms.Padding(4)
        Me.tbY.Name = "tbY"
        Me.tbY.Size = New System.Drawing.Size(39, 22)
        Me.tbY.TabIndex = 8
        Me.tbY.Tag = "2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(177, 76)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 25)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "H"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(88, 76)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 25)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "W"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(177, 41)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 25)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Y"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(92, 41)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 25)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "X"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(33, 76)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(5, 41)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Position"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gray
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(279, 31)
        Me.Panel4.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Geometri"
        '
        'pTextID
        '
        Me.pTextID.BackColor = System.Drawing.Color.Silver
        Me.pTextID.Controls.Add(Me.btFont)
        Me.pTextID.Controls.Add(Me.btTextColor)
        Me.pTextID.Controls.Add(Me.cbTextPos)
        Me.pTextID.Controls.Add(Me.txColor)
        Me.pTextID.Controls.Add(Me.txFont)
        Me.pTextID.Controls.Add(Me.tbNameObject)
        Me.pTextID.Controls.Add(Me.Label17)
        Me.pTextID.Controls.Add(Me.Label16)
        Me.pTextID.Controls.Add(Me.Label14)
        Me.pTextID.Controls.Add(Me.Label13)
        Me.pTextID.Controls.Add(Me.Panel6)
        Me.pTextID.Dock = System.Windows.Forms.DockStyle.Top
        Me.pTextID.Location = New System.Drawing.Point(0, 0)
        Me.pTextID.Margin = New System.Windows.Forms.Padding(4)
        Me.pTextID.Name = "pTextID"
        Me.pTextID.Size = New System.Drawing.Size(279, 167)
        Me.pTextID.TabIndex = 13
        '
        'btFont
        '
        Me.btFont.Location = New System.Drawing.Point(240, 71)
        Me.btFont.Margin = New System.Windows.Forms.Padding(4)
        Me.btFont.Name = "btFont"
        Me.btFont.Size = New System.Drawing.Size(28, 26)
        Me.btFont.TabIndex = 17
        Me.btFont.UseVisualStyleBackColor = True
        '
        'btTextColor
        '
        Me.btTextColor.Location = New System.Drawing.Point(143, 102)
        Me.btTextColor.Margin = New System.Windows.Forms.Padding(4)
        Me.btTextColor.Name = "btTextColor"
        Me.btTextColor.Size = New System.Drawing.Size(28, 26)
        Me.btTextColor.TabIndex = 16
        Me.btTextColor.UseVisualStyleBackColor = True
        '
        'cbTextPos
        '
        Me.cbTextPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTextPos.FormattingEnabled = True
        Me.cbTextPos.Location = New System.Drawing.Point(108, 133)
        Me.cbTextPos.Margin = New System.Windows.Forms.Padding(4)
        Me.cbTextPos.Name = "cbTextPos"
        Me.cbTextPos.Size = New System.Drawing.Size(159, 24)
        Me.cbTextPos.TabIndex = 15
        '
        'txColor
        '
        Me.txColor.Location = New System.Drawing.Point(108, 102)
        Me.txColor.Margin = New System.Windows.Forms.Padding(4)
        Me.txColor.Name = "txColor"
        Me.txColor.Size = New System.Drawing.Size(39, 22)
        Me.txColor.TabIndex = 14
        '
        'txFont
        '
        Me.txFont.Location = New System.Drawing.Point(108, 71)
        Me.txFont.Margin = New System.Windows.Forms.Padding(4)
        Me.txFont.Name = "txFont"
        Me.txFont.Size = New System.Drawing.Size(140, 22)
        Me.txFont.TabIndex = 12
        '
        'tbNameObject
        '
        Me.tbNameObject.Location = New System.Drawing.Point(108, 41)
        Me.tbNameObject.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNameObject.Name = "tbNameObject"
        Me.tbNameObject.Size = New System.Drawing.Size(159, 22)
        Me.tbNameObject.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DimGray
        Me.Label17.Location = New System.Drawing.Point(5, 134)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 25)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Position"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(5, 102)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 25)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Color"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(5, 71)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 25)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Font"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(4, 41)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 25)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Text"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Gray
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(279, 31)
        Me.Panel6.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(5, 4)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 25)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Text ID"
        '
        'pMenu
        '
        Me.pMenu.AutoScroll = True
        Me.pMenu.BackColor = System.Drawing.Color.DarkGray
        Me.pMenu.Controls.Add(Me.Panel8)
        Me.pMenu.Location = New System.Drawing.Point(7, 49)
        Me.pMenu.Margin = New System.Windows.Forms.Padding(4)
        Me.pMenu.Name = "pMenu"
        Me.pMenu.Size = New System.Drawing.Size(300, 257)
        Me.pMenu.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.pbPairButton)
        Me.Panel8.Controls.Add(Me.pbToggleButton)
        Me.Panel8.Controls.Add(Me.pbPushButton)
        Me.Panel8.Controls.Add(Me.pbCounter)
        Me.Panel8.Controls.Add(Me.pbButton)
        Me.Panel8.Controls.Add(Me.pbShape)
        Me.Panel8.Controls.Add(Me.pbBuzzer)
        Me.Panel8.Controls.Add(Me.pbLabel)
        Me.Panel8.Controls.Add(Me.pbCheckBox)
        Me.Panel8.Controls.Add(Me.pbTrack)
        Me.Panel8.Controls.Add(Me.pbPointMachine)
        Me.Panel8.Controls.Add(Me.pbSignal)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(279, 337)
        Me.Panel8.TabIndex = 2
        '
        'pbPairButton
        '
        Me.pbPairButton.BackColor = System.Drawing.Color.Silver
        Me.pbPairButton.Location = New System.Drawing.Point(187, 254)
        Me.pbPairButton.Margin = New System.Windows.Forms.Padding(4)
        Me.pbPairButton.Name = "pbPairButton"
        Me.pbPairButton.Size = New System.Drawing.Size(80, 74)
        Me.pbPairButton.TabIndex = 34
        Me.pbPairButton.TabStop = False
        Me.pbPairButton.Tag = "12"
        '
        'pbToggleButton
        '
        Me.pbToggleButton.BackColor = System.Drawing.Color.Silver
        Me.pbToggleButton.Location = New System.Drawing.Point(97, 254)
        Me.pbToggleButton.Margin = New System.Windows.Forms.Padding(4)
        Me.pbToggleButton.Name = "pbToggleButton"
        Me.pbToggleButton.Size = New System.Drawing.Size(80, 74)
        Me.pbToggleButton.TabIndex = 33
        Me.pbToggleButton.TabStop = False
        Me.pbToggleButton.Tag = "11"
        '
        'pbPushButton
        '
        Me.pbPushButton.BackColor = System.Drawing.Color.Silver
        Me.pbPushButton.Location = New System.Drawing.Point(8, 254)
        Me.pbPushButton.Margin = New System.Windows.Forms.Padding(4)
        Me.pbPushButton.Name = "pbPushButton"
        Me.pbPushButton.Size = New System.Drawing.Size(80, 74)
        Me.pbPushButton.TabIndex = 32
        Me.pbPushButton.TabStop = False
        Me.pbPushButton.Tag = "10"
        '
        'pbCounter
        '
        Me.pbCounter.BackColor = System.Drawing.Color.Silver
        Me.pbCounter.Image = CType(resources.GetObject("pbCounter.Image"), System.Drawing.Image)
        Me.pbCounter.Location = New System.Drawing.Point(187, 171)
        Me.pbCounter.Margin = New System.Windows.Forms.Padding(4)
        Me.pbCounter.Name = "pbCounter"
        Me.pbCounter.Size = New System.Drawing.Size(80, 74)
        Me.pbCounter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbCounter.TabIndex = 31
        Me.pbCounter.TabStop = False
        Me.pbCounter.Tag = "9"
        '
        'pbButton
        '
        Me.pbButton.BackColor = System.Drawing.Color.Silver
        Me.pbButton.Image = CType(resources.GetObject("pbButton.Image"), System.Drawing.Image)
        Me.pbButton.Location = New System.Drawing.Point(97, 171)
        Me.pbButton.Margin = New System.Windows.Forms.Padding(4)
        Me.pbButton.Name = "pbButton"
        Me.pbButton.Size = New System.Drawing.Size(80, 74)
        Me.pbButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbButton.TabIndex = 30
        Me.pbButton.TabStop = False
        Me.pbButton.Tag = "8"
        '
        'pbShape
        '
        Me.pbShape.BackColor = System.Drawing.Color.Silver
        Me.pbShape.Image = CType(resources.GetObject("pbShape.Image"), System.Drawing.Image)
        Me.pbShape.Location = New System.Drawing.Point(8, 171)
        Me.pbShape.Margin = New System.Windows.Forms.Padding(4)
        Me.pbShape.Name = "pbShape"
        Me.pbShape.Size = New System.Drawing.Size(80, 74)
        Me.pbShape.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbShape.TabIndex = 29
        Me.pbShape.TabStop = False
        Me.pbShape.Tag = "7"
        '
        'pbBuzzer
        '
        Me.pbBuzzer.BackColor = System.Drawing.Color.Silver
        Me.pbBuzzer.Image = CType(resources.GetObject("pbBuzzer.Image"), System.Drawing.Image)
        Me.pbBuzzer.Location = New System.Drawing.Point(187, 89)
        Me.pbBuzzer.Margin = New System.Windows.Forms.Padding(4)
        Me.pbBuzzer.Name = "pbBuzzer"
        Me.pbBuzzer.Size = New System.Drawing.Size(80, 74)
        Me.pbBuzzer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbBuzzer.TabIndex = 28
        Me.pbBuzzer.TabStop = False
        Me.pbBuzzer.Tag = "6"
        '
        'pbLabel
        '
        Me.pbLabel.BackColor = System.Drawing.Color.Silver
        Me.pbLabel.Image = CType(resources.GetObject("pbLabel.Image"), System.Drawing.Image)
        Me.pbLabel.Location = New System.Drawing.Point(97, 89)
        Me.pbLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.pbLabel.Name = "pbLabel"
        Me.pbLabel.Size = New System.Drawing.Size(80, 74)
        Me.pbLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbLabel.TabIndex = 27
        Me.pbLabel.TabStop = False
        Me.pbLabel.Tag = "5"
        '
        'pbCheckBox
        '
        Me.pbCheckBox.BackColor = System.Drawing.Color.Silver
        Me.pbCheckBox.Image = CType(resources.GetObject("pbCheckBox.Image"), System.Drawing.Image)
        Me.pbCheckBox.Location = New System.Drawing.Point(8, 89)
        Me.pbCheckBox.Margin = New System.Windows.Forms.Padding(4)
        Me.pbCheckBox.Name = "pbCheckBox"
        Me.pbCheckBox.Size = New System.Drawing.Size(80, 74)
        Me.pbCheckBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbCheckBox.TabIndex = 26
        Me.pbCheckBox.TabStop = False
        Me.pbCheckBox.Tag = "4"
        '
        'pbTrack
        '
        Me.pbTrack.BackColor = System.Drawing.Color.Silver
        Me.pbTrack.Image = CType(resources.GetObject("pbTrack.Image"), System.Drawing.Image)
        Me.pbTrack.Location = New System.Drawing.Point(185, 6)
        Me.pbTrack.Margin = New System.Windows.Forms.Padding(4)
        Me.pbTrack.Name = "pbTrack"
        Me.pbTrack.Size = New System.Drawing.Size(80, 74)
        Me.pbTrack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbTrack.TabIndex = 25
        Me.pbTrack.TabStop = False
        Me.pbTrack.Tag = "3"
        '
        'pbPointMachine
        '
        Me.pbPointMachine.BackColor = System.Drawing.Color.Silver
        Me.pbPointMachine.Image = CType(resources.GetObject("pbPointMachine.Image"), System.Drawing.Image)
        Me.pbPointMachine.Location = New System.Drawing.Point(96, 6)
        Me.pbPointMachine.Margin = New System.Windows.Forms.Padding(4)
        Me.pbPointMachine.Name = "pbPointMachine"
        Me.pbPointMachine.Size = New System.Drawing.Size(80, 74)
        Me.pbPointMachine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbPointMachine.TabIndex = 24
        Me.pbPointMachine.TabStop = False
        Me.pbPointMachine.Tag = "2"
        '
        'pbSignal
        '
        Me.pbSignal.BackColor = System.Drawing.Color.Silver
        Me.pbSignal.Image = CType(resources.GetObject("pbSignal.Image"), System.Drawing.Image)
        Me.pbSignal.Location = New System.Drawing.Point(7, 6)
        Me.pbSignal.Margin = New System.Windows.Forms.Padding(4)
        Me.pbSignal.Name = "pbSignal"
        Me.pbSignal.Size = New System.Drawing.Size(80, 74)
        Me.pbSignal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbSignal.TabIndex = 23
        Me.pbSignal.TabStop = False
        Me.pbSignal.Tag = "1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 55)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1146, 975)
        Me.SplitContainer1.SplitterDistance = 775
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 10
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1146, 775)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Gray
        Me.TabPage1.Controls.Add(Me.pContainer)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1138, 746)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Layout Editor"
        '
        'pContainer
        '
        Me.pContainer.AutoScroll = True
        Me.pContainer.Controls.Add(Me.WdwContainer)
        Me.pContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pContainer.Location = New System.Drawing.Point(4, 4)
        Me.pContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.pContainer.Name = "pContainer"
        Me.pContainer.Size = New System.Drawing.Size(1130, 738)
        Me.pContainer.TabIndex = 0
        '
        'WdwContainer
        '
        Me.WdwContainer.BackColor = System.Drawing.Color.Silver
        Me.WdwContainer.ContextMenuStrip = Me.cmsLayoutEditor
        Me.WdwContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WdwContainer.Grid = 10
        Me.WdwContainer.Location = New System.Drawing.Point(0, 0)
        Me.WdwContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.WdwContainer.Name = "WdwContainer"
        Me.WdwContainer.ShowGrid = True
        Me.WdwContainer.Size = New System.Drawing.Size(1130, 738)
        Me.WdwContainer.Style = Railway.winContainer.eStyle.Line
        Me.WdwContainer.TabIndex = 0
        Me.WdwContainer.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.Editor)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1138, 746)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Boolean Text Editor"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Editor
        '
        Me.Editor.AutoScrollMinSize = New System.Drawing.Size(632, 1159)
        Me.Editor.BackBrush = Nothing
        Me.Editor.ContextMenuStrip = Me.cmsBooleanTextEditor
        Me.Editor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Editor.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Editor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Editor.Location = New System.Drawing.Point(4, 4)
        Me.Editor.Margin = New System.Windows.Forms.Padding(4)
        Me.Editor.Name = "Editor"
        Me.Editor.Paddings = New System.Windows.Forms.Padding(0)
        Me.Editor.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Editor.Size = New System.Drawing.Size(1126, 734)
        Me.Editor.TabIndex = 0
        Me.Editor.Text = resources.GetString("Editor.Text")
        '
        'TabPage3
        '
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage3.Controls.Add(Me.Panel12)
        Me.TabPage3.Controls.Add(Me.Splitter1)
        Me.TabPage3.Controls.Add(Me.Panel11)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Size = New System.Drawing.Size(1138, 746)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Automatic Route Control"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.DarkGray
        Me.Panel12.Controls.Add(Me.DataGridView1)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(88, 4)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(1042, 734)
        Me.Panel12.TabIndex = 6
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmRoute, Me.clmType, Me.clmSignal, Me.clmWesel, Me.clmTrack, Me.clmApproachTrack})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1042, 734)
        Me.DataGridView1.TabIndex = 2
        '
        'clmRoute
        '
        Me.clmRoute.HeaderText = "Route"
        Me.clmRoute.Name = "clmRoute"
        '
        'clmType
        '
        Me.clmType.HeaderText = "Type"
        Me.clmType.Items.AddRange(New Object() {"Normal (N)", "Emergency (E)", "Shunt (S)"})
        Me.clmType.Name = "clmType"
        Me.clmType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'clmSignal
        '
        Me.clmSignal.HeaderText = "Signal"
        Me.clmSignal.Name = "clmSignal"
        Me.clmSignal.Width = 75
        '
        'clmWesel
        '
        Me.clmWesel.HeaderText = "Point Lock"
        Me.clmWesel.Name = "clmWesel"
        Me.clmWesel.Width = 200
        '
        'clmTrack
        '
        Me.clmTrack.HeaderText = "Track Route"
        Me.clmTrack.Name = "clmTrack"
        Me.clmTrack.Width = 400
        '
        'clmApproachTrack
        '
        Me.clmApproachTrack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.clmApproachTrack.HeaderText = "ApproachTrack"
        Me.clmApproachTrack.Name = "clmApproachTrack"
        Me.clmApproachTrack.ReadOnly = True
        Me.clmApproachTrack.Width = 134
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(84, 4)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(4)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 734)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.LightGray
        Me.Panel11.Controls.Add(Me.btnInsert)
        Me.Panel11.Controls.Add(Me.btnDelete)
        Me.Panel11.Controls.Add(Me.btnAdd)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.Location = New System.Drawing.Point(4, 4)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(80, 734)
        Me.Panel11.TabIndex = 0
        '
        'btnInsert
        '
        Me.btnInsert.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsert.Location = New System.Drawing.Point(4, 180)
        Me.btnInsert.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(72, 49)
        Me.btnInsert.TabIndex = 2
        Me.btnInsert.Text = "Insert"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(4, 123)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 49)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(4, 70)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(72, 49)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.panelDevice)
        Me.TabPage4.Controls.Add(Me.panelCommunication)
        Me.TabPage4.Controls.Add(Me.treeView1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage4.Size = New System.Drawing.Size(1138, 746)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Hardware Configuration"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'panelDevice
        '
        Me.panelDevice.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelDevice.Controls.Add(Me.ListView1)
        Me.panelDevice.Controls.Add(Me.GroupBox1)
        Me.panelDevice.Location = New System.Drawing.Point(365, 4)
        Me.panelDevice.Margin = New System.Windows.Forms.Padding(4)
        Me.panelDevice.Name = "panelDevice"
        Me.panelDevice.Size = New System.Drawing.Size(725, 598)
        Me.panelDevice.TabIndex = 14
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView1.Location = New System.Drawing.Point(16, 186)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(688, 394)
        Me.ListView1.TabIndex = 9
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "No."
        Me.ColumnHeader5.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Type"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "In/Out"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Linked to"
        Me.ColumnHeader4.Width = 250
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.txtAddress)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtType)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtGroups)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(480, 160)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " General "
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(103, 23)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(368, 22)
        Me.txtName.TabIndex = 4
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(8, 123)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 17)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Address :"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(103, 119)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(368, 22)
        Me.txtAddress.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(8, 90)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 17)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Groups :"
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(103, 55)
        Me.txtType.Margin = New System.Windows.Forms.Padding(4)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(368, 22)
        Me.txtType.TabIndex = 5
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 59)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 17)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Type :"
        '
        'txtGroups
        '
        Me.txtGroups.Location = New System.Drawing.Point(103, 86)
        Me.txtGroups.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGroups.Name = "txtGroups"
        Me.txtGroups.Size = New System.Drawing.Size(368, 22)
        Me.txtGroups.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 27)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 17)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Name :"
        '
        'panelCommunication
        '
        Me.panelCommunication.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelCommunication.Controls.Add(Me.btInsert)
        Me.panelCommunication.Controls.Add(Me.btDelete)
        Me.panelCommunication.Controls.Add(Me.btAdd)
        Me.panelCommunication.Controls.Add(Me.btDown)
        Me.panelCommunication.Controls.Add(Me.btUp)
        Me.panelCommunication.Controls.Add(Me.GroupBox3)
        Me.panelCommunication.Controls.Add(Me.Label26)
        Me.panelCommunication.Controls.Add(Me.GroupBox2)
        Me.panelCommunication.Location = New System.Drawing.Point(564, 164)
        Me.panelCommunication.Margin = New System.Windows.Forms.Padding(4)
        Me.panelCommunication.Name = "panelCommunication"
        Me.panelCommunication.Size = New System.Drawing.Size(737, 598)
        Me.panelCommunication.TabIndex = 13
        '
        'btInsert
        '
        Me.btInsert.Location = New System.Drawing.Point(333, 370)
        Me.btInsert.Margin = New System.Windows.Forms.Padding(4)
        Me.btInsert.Name = "btInsert"
        Me.btInsert.Size = New System.Drawing.Size(72, 28)
        Me.btInsert.TabIndex = 7
        Me.btInsert.Text = "Insert"
        Me.btInsert.UseVisualStyleBackColor = True
        '
        'btDelete
        '
        Me.btDelete.Location = New System.Drawing.Point(333, 335)
        Me.btDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(72, 28)
        Me.btDelete.TabIndex = 6
        Me.btDelete.Text = "Delete"
        Me.btDelete.UseVisualStyleBackColor = True
        '
        'btAdd
        '
        Me.btAdd.Location = New System.Drawing.Point(333, 299)
        Me.btAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(72, 28)
        Me.btAdd.TabIndex = 5
        Me.btAdd.Text = "Add"
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'btDown
        '
        Me.btDown.Location = New System.Drawing.Point(333, 222)
        Me.btDown.Margin = New System.Windows.Forms.Padding(4)
        Me.btDown.Name = "btDown"
        Me.btDown.Size = New System.Drawing.Size(72, 28)
        Me.btDown.TabIndex = 4
        Me.btDown.Text = "Down"
        Me.btDown.UseVisualStyleBackColor = True
        '
        'btUp
        '
        Me.btUp.Location = New System.Drawing.Point(333, 186)
        Me.btUp.Margin = New System.Windows.Forms.Padding(4)
        Me.btUp.Name = "btUp"
        Me.btUp.Size = New System.Drawing.Size(72, 28)
        Me.btUp.TabIndex = 3
        Me.btUp.Text = "Up"
        Me.btUp.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lvFromLCP)
        Me.GroupBox3.Location = New System.Drawing.Point(413, 94)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(308, 482)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Data From LCP "
        '
        'lvFromLCP
        '
        Me.lvFromLCP.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvFromLCP.Location = New System.Drawing.Point(8, 23)
        Me.lvFromLCP.Margin = New System.Windows.Forms.Padding(4)
        Me.lvFromLCP.Name = "lvFromLCP"
        Me.lvFromLCP.Size = New System.Drawing.Size(291, 451)
        Me.lvFromLCP.TabIndex = 1
        Me.lvFromLCP.UseCompatibleStateImageBehavior = False
        Me.lvFromLCP.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "No."
        Me.ColumnHeader7.Width = 40
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Variable"
        Me.ColumnHeader8.Width = 175
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(216, 21)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(306, 26)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "VITAL COMMUNICATION"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lvToLCP)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 94)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(308, 482)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " Data To LCP "
        '
        'lvToLCP
        '
        Me.lvToLCP.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader6})
        Me.lvToLCP.Location = New System.Drawing.Point(8, 23)
        Me.lvToLCP.Margin = New System.Windows.Forms.Padding(4)
        Me.lvToLCP.Name = "lvToLCP"
        Me.lvToLCP.Size = New System.Drawing.Size(291, 451)
        Me.lvToLCP.TabIndex = 10
        Me.lvToLCP.UseCompatibleStateImageBehavior = False
        Me.lvToLCP.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "No."
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Variable"
        Me.ColumnHeader6.Width = 175
        '
        'treeView1
        '
        Me.treeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.treeView1.Location = New System.Drawing.Point(4, 4)
        Me.treeView1.Margin = New System.Windows.Forms.Padding(4)
        Me.treeView1.Name = "treeView1"
        TreeNode1.Name = "nodDevice"
        TreeNode1.Text = "I/O Devices"
        TreeNode2.Name = "nodCommunication"
        TreeNode2.Text = "Communication"
        TreeNode3.Name = "Node3"
        TreeNode3.Text = "I/O - Configuration"
        Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3})
        Me.treeView1.Size = New System.Drawing.Size(260, 738)
        Me.treeView1.TabIndex = 10
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPageError)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(0, 0)
        Me.TabControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1146, 195)
        Me.TabControl2.TabIndex = 4
        '
        'TabPageError
        '
        Me.TabPageError.Controls.Add(Me.lbError)
        Me.TabPageError.Location = New System.Drawing.Point(4, 25)
        Me.TabPageError.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPageError.Name = "TabPageError"
        Me.TabPageError.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPageError.Size = New System.Drawing.Size(1138, 166)
        Me.TabPageError.TabIndex = 0
        Me.TabPageError.Text = "Errors"
        Me.TabPageError.UseVisualStyleBackColor = True
        '
        'lbError
        '
        Me.lbError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbError.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbError.ForeColor = System.Drawing.Color.Black
        Me.lbError.FormattingEnabled = True
        Me.lbError.ItemHeight = 19
        Me.lbError.Location = New System.Drawing.Point(4, 4)
        Me.lbError.Margin = New System.Windows.Forms.Padding(4)
        Me.lbError.Name = "lbError"
        Me.lbError.Size = New System.Drawing.Size(1130, 158)
        Me.lbError.TabIndex = 20
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1461, 1030)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.pProperties)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.Text = "Len DPS"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmsLayoutEditor.ResumeLayout(False)
        Me.cmsBooleanTextEditor.ResumeLayout(False)
        Me.cmsDevices.ResumeLayout(False)
        Me.cmsComVtl.ResumeLayout(False)
        Me.cmsLink.ResumeLayout(False)
        Me.cmsComNVtl.ResumeLayout(False)
        Me.pProperties.ResumeLayout(False)
        Me.pProperties.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pType.ResumeLayout(False)
        Me.pType.PerformLayout()
        Me.pSize.ResumeLayout(False)
        Me.pSize.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.pGeometri.ResumeLayout(False)
        Me.pGeometri.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pTextID.ResumeLayout(False)
        Me.pTextID.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pMenu.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.pbPairButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbToggleButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPushButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCounter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbShape, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBuzzer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCheckBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTrack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPointMachine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSignal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.pContainer.ResumeLayout(False)
        CType(Me.WdwContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.panelDevice.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.panelCommunication.ResumeLayout(False)
        Me.panelCommunication.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPageError.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveProjectAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BuildToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuildToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MakeHexFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebugToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IOConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutDPSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FindToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RunToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents StopToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tbGridSizeToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents LineToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DotToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NoGridToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmsLayoutEditor As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsBooleanTextEditor As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DsfdfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsDevices As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AppendDeviceToolStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents deleteToolStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsComVtl As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteVtlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllVtlToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsLink As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LinkToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteLinkVariableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsComNVtl As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteNvtlToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteAllNvtlToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pProperties As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents pContainer As System.Windows.Forms.Panel
    Friend WithEvents WdwContainer As Railway.winContainer
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Editor As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents clmRoute As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents clmSignal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmWesel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTrack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmApproachTrack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents panelDevice As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtGroups As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents panelCommunication As System.Windows.Forms.Panel
    Friend WithEvents btInsert As System.Windows.Forms.Button
    Friend WithEvents btDelete As System.Windows.Forms.Button
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents btDown As System.Windows.Forms.Button
    Friend WithEvents btUp As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lvFromLCP As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lvToLCP As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents treeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageError As System.Windows.Forms.TabPage
    Friend WithEvents lbError As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pMenu As System.Windows.Forms.Panel
    Friend WithEvents tbName As System.Windows.Forms.TextBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btIdColor4 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txIdColor4 As System.Windows.Forms.TextBox
    Friend WithEvents btIdColor2 As System.Windows.Forms.Button
    Friend WithEvents txIdColor2 As System.Windows.Forms.TextBox
    Friend WithEvents btIdColor3 As System.Windows.Forms.Button
    Friend WithEvents btIdColor1 As System.Windows.Forms.Button
    Friend WithEvents txIdColor3 As System.Windows.Forms.TextBox
    Friend WithEvents txIdColor1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents pType As System.Windows.Forms.Panel
    Friend WithEvents pSize As System.Windows.Forms.Panel
    Friend WithEvents txThickness As System.Windows.Forms.TextBox
    Friend WithEvents txDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbDirection As System.Windows.Forms.ComboBox
    Friend WithEvents lbDir As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents pGeometri As System.Windows.Forms.Panel
    Friend WithEvents tbH As System.Windows.Forms.TextBox
    Friend WithEvents tbW As System.Windows.Forms.TextBox
    Friend WithEvents tbX As System.Windows.Forms.TextBox
    Friend WithEvents tbY As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pTextID As System.Windows.Forms.Panel
    Friend WithEvents btFont As System.Windows.Forms.Button
    Friend WithEvents btTextColor As System.Windows.Forms.Button
    Friend WithEvents cbTextPos As System.Windows.Forms.ComboBox
    Friend WithEvents txColor As System.Windows.Forms.TextBox
    Friend WithEvents txFont As System.Windows.Forms.TextBox
    Friend WithEvents tbNameObject As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents pbPairButton As System.Windows.Forms.PictureBox
    Friend WithEvents pbToggleButton As System.Windows.Forms.PictureBox
    Friend WithEvents pbPushButton As System.Windows.Forms.PictureBox
    Friend WithEvents pbCounter As System.Windows.Forms.PictureBox
    Friend WithEvents pbButton As System.Windows.Forms.PictureBox
    Friend WithEvents pbShape As System.Windows.Forms.PictureBox
    Friend WithEvents pbBuzzer As System.Windows.Forms.PictureBox
    Friend WithEvents pbLabel As System.Windows.Forms.PictureBox
    Friend WithEvents pbCheckBox As System.Windows.Forms.PictureBox
    Friend WithEvents pbTrack As System.Windows.Forms.PictureBox
    Friend WithEvents pbPointMachine As System.Windows.Forms.PictureBox
    Friend WithEvents pbSignal As System.Windows.Forms.PictureBox
    Friend WithEvents TCPIPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SERVERToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CLIENTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MODBUSTCPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SERVERToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CLIENTToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UDPToolStripMenuItem As ToolStripMenuItem
End Class
