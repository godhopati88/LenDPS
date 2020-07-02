
Public Class frmInsertDevice
    Private mNodeName As String
    Private mNodeText As String
    Private mNodeTag As String

    Dim nodName, nodText, nodTag As String

#Region "Class Property"
    Public Property NodeName() As String
        Get
            Return mNodeName
        End Get
        Set(ByVal value As String)
            mNodeName = value
        End Set
    End Property

    Public Property NodeText() As String
        Get
            Return mNodeText
        End Get
        Set(ByVal value As String)
            mNodeText = value
        End Set
    End Property

    Public Property NodeTag() As String
        Get
            Return mNodeTag
        End Get
        Set(ByVal value As String)
            mNodeTag = value
        End Set
    End Property
#End Region

    Private Sub UpdateData()
        If nodName <> NodeName Then
            NodeName = nodName
            If nodText = "sVCM" Then
                NodeText = "{" & String.Format("{0:000}", CInt(tbAdrs.Text)) & "} " & nodText
            Else
                NodeText = "[" & String.Format("{0:00}", CInt(tbAdrs.Text)) & "] " & nodText
            End If
            NodeTag = nodTag
        End If

    End Sub

    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Node.Text <> String.Empty And tbAdrs.Text <> String.Empty Then
            nodName = e.Node.Name
            nodText = e.Node.Text
            nodTag = e.Node.Tag
        Else
            MessageBox.Show("No data")
        End If
    End Sub

    Private Sub init_dbHDW(ByVal idx As Integer)
        dbHDW(idx).bit0 = ""
        dbHDW(idx).bit1 = ""
        dbHDW(idx).bit2 = ""
        dbHDW(idx).bit3 = ""
        dbHDW(idx).bit4 = ""
        dbHDW(idx).bit5 = ""
        dbHDW(idx).bit6 = ""
        dbHDW(idx).bit7 = ""
        dbHDW(idx).bit8 = ""
        dbHDW(idx).bit9 = ""
        dbHDW(idx).bit10 = ""
        dbHDW(idx).bit11 = ""
        dbHDW(idx).bit12 = ""
        dbHDW(idx).bit13 = ""
        dbHDW(idx).bit14 = ""
        dbHDW(idx).bit15 = ""
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim err As Integer = 0
        Dim errC As Integer = 0
        Dim adr As Integer = CInt(Trim(tbAdrs.Text))

        If adr = 0 Then
            MessageBox.Show("...!!!", "Error", MessageBoxButtons.OK)
            Exit Sub
        End If

        Select Case device_status
            Case deviceStatus.IO
                Dim sDevice As String = TreeView1.SelectedNode.Text
                Select Case sDevice
                    Case "sVCM"
                        If UBound(dbCoupler) = 0 Then
                            dbCoupler(0).address = adr
                            dbCoupler(0).status = slotStatus.boooked
                            ReDim Preserve dbCoupler(UBound(dbCoupler) + 1)
                            UpdateData()
                            Me.Close()
                        Else
                            For i As Integer = 0 To UBound(dbCoupler) - 1
                                If dbCoupler(i).address = adr And dbCoupler(i).status = slotStatus.boooked Then
                                    errC += 1
                                    Exit For
                                End If
                            Next

                            If errC > 0 Then
                                MessageBox.Show("Duplicated Coupler Address...!!!!!", "Warning", MessageBoxButtons.OK)
                            Else
                                dbCoupler(UBound(dbCoupler)).address = adr
                                dbCoupler(UBound(dbCoupler)).status = slotStatus.boooked
                                ReDim Preserve dbCoupler(UBound(dbCoupler) + 1)
                                UpdateData()
                                Me.Close()
                            End If
                        End If

                    Case Else   '--------------- VIOM -------------
                        If UBound(dbHDW) = 0 Then
                            dbHDW(0).address = adr
                            dbHDW(0).coupler = 0
                            dbHDW(0).status = slotStatus.boooked
                            dbHDW(0).InOut = TreeView1.SelectedNode.Tag
                            init_dbHDW(0)
                            ReDim Preserve dbHDW(UBound(dbHDW) + 1)
                            UpdateData()
                            Me.Close()
                        Else
                            For i As Integer = 0 To UBound(dbHDW) - 1 '**
                                If dbHDW(i).coupler = 0 Then
                                    If adr = dbHDW(i).address And dbHDW(i).status = slotStatus.boooked Then
                                        err += 1
                                        Exit For
                                    End If
                                End If
                            Next

                            If err > 0 Then
                                MessageBox.Show("Duplicated Address...!!!!!", "Warning", MessageBoxButtons.OK)
                            Else
                                With dbHDW(UBound(dbHDW))
                                    .address = adr
                                    .coupler = 0
                                    .InOut = TreeView1.SelectedNode.Tag
                                    .status = slotStatus.boooked
                                End With
                                init_dbHDW(UBound(dbHDW))
                                ReDim Preserve dbHDW(UBound(dbHDW) + 1)
                                UpdateData()
                                Me.Close()
                            End If
                        End If
                End Select

            Case deviceStatus.Coupler
                Dim idxCoupler As Integer = frmMain.GetCouplerAddress
                If UBound(dbHDW) = 0 Then
                    dbHDW(0).address = adr
                    dbHDW(0).coupler = idxCoupler
                    dbHDW(0).InOut = TreeView1.SelectedNode.Tag
                    dbHDW(0).status = slotStatus.boooked
                    init_dbHDW(0)
                    ReDim Preserve dbHDW(UBound(dbHDW) + 1)
                    UpdateData()
                    Me.Close()
                Else
                    Dim idxAdrCoupler As Integer = 0
                    For i As Integer = 0 To UBound(dbHDW) - 1
                        If dbHDW(i).coupler = idxCoupler Then
                            If adr = dbHDW(i).address And dbHDW(i).status = slotStatus.boooked Then
                                idxAdrCoupler += 1
                                Exit For
                            End If
                        End If
                    Next

                    If idxAdrCoupler > 0 Then
                        MessageBox.Show("Duplicated Address on Coupler...!!!!!", "Warning", MessageBoxButtons.OK)
                    Else
                        With dbHDW(UBound(dbHDW))
                            .address = adr
                            .coupler = idxCoupler
                            .status = slotStatus.boooked
                            .InOut = TreeView1.SelectedNode.Tag
                        End With
                        init_dbHDW(UBound(dbHDW))
                        ReDim Preserve dbHDW(UBound(dbHDW) + 1)
                        UpdateData()
                        Me.Close()
                    End If
                End If
        End Select

        
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub frmInsertDevice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TreeView1.ExpandAll()
    End Sub

    Private Sub tbAdrs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbAdrs.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub
End Class