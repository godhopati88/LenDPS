<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssignIO
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.dName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dBit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.bAdd = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btOk = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.16529!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.83471!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.78931!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.21068!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(484, 351)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel4.Location = New System.Drawing.Point(3, 293)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(139, 54)
        Me.Panel4.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(149, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(332, 284)
        Me.Panel2.TabIndex = 6
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dName, Me.dType, Me.dAddress, Me.dBit})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(324, 275)
        Me.DataGridView1.TabIndex = 0
        '
        'dName
        '
        Me.dName.HeaderText = "Variable Name"
        Me.dName.Name = "dName"
        '
        'dType
        '
        Me.dType.HeaderText = "I / O"
        Me.dType.Items.AddRange(New Object() {"VIM", "VOM", "VCom", "NVCom"})
        Me.dType.Name = "dType"
        Me.dType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dType.Width = 75
        '
        'dAddress
        '
        Me.dAddress.HeaderText = "Address"
        Me.dAddress.Name = "dAddress"
        Me.dAddress.Width = 50
        '
        'dBit
        '
        Me.dBit.HeaderText = "Bit"
        Me.dBit.Name = "dBit"
        Me.dBit.Width = 50
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel1.Controls.Add(Me.btnInsert)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.bAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(140, 284)
        Me.Panel1.TabIndex = 7
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(3, 83)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(133, 34)
        Me.btnInsert.TabIndex = 3
        Me.btnInsert.Text = "Insert"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(3, 43)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(133, 34)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'bAdd
        '
        Me.bAdd.Location = New System.Drawing.Point(3, 3)
        Me.bAdd.Name = "bAdd"
        Me.bAdd.Size = New System.Drawing.Size(133, 34)
        Me.bAdd.TabIndex = 1
        Me.bAdd.Text = "Add"
        Me.bAdd.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel3.Controls.Add(Me.btOk)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(149, 293)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(332, 55)
        Me.Panel3.TabIndex = 8
        '
        'btOk
        '
        Me.btOk.Location = New System.Drawing.Point(3, 3)
        Me.btOk.Name = "btOk"
        Me.btOk.Size = New System.Drawing.Size(324, 46)
        Me.btOk.TabIndex = 2
        Me.btOk.Text = "Ok"
        Me.btOk.UseVisualStyleBackColor = True
        '
        'frmAssignIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(484, 351)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmAssignIO"
        Me.Text = "I/O Configuration"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents bAdd As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btOk As System.Windows.Forms.Button
    Friend WithEvents dName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dBit As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
