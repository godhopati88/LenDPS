
#Region "     class library"

#Region "     imports"

Imports System.Runtime.InteropServices

#End Region

Public Class ControlHandler

#Region "     global variables"
    Private horizontalMidPoint As Integer
    Private verticalMidPoint As Integer
    Private locations() As Point

    Public Structure boundControl
        Public mControl As Control
        Public mParent As Control
        Public Sub New(ByVal parent As Control, ByVal control As Control)
            mParent = parent
            mControl = control
        End Sub
    End Structure

    Private activeControl As Control = Nothing
    Private activeControlParent As Control = Nothing

#End Region

#Region "     properties"

    Private _boundControls As New List(Of boundControl)
    Public ReadOnly Property boundControls() As List(Of boundControl)
        Get
            Return _boundControls
        End Get
    End Property

    Private _boundingRectangle As Rectangle
    Public Property boundingRectangle() As Rectangle
        Get
            Return _boundingRectangle
        End Get
        Set(ByVal value As Rectangle)
            _boundingRectangle = value
        End Set
    End Property

    Private _canDeselect As Boolean = True
    Public Property canDeselect() As Boolean
        Get
            Return _canDeselect
        End Get
        Set(ByVal value As Boolean)
            _canDeselect = value
        End Set
    End Property

#End Region

#Region "     initialize"
    Public Sub bindControls(ByVal index As Integer)
        Dim ctrl As Control = _boundControls(index).mControl
        AddHandler ctrl.MouseDown, AddressOf mControl_mousedown
        AddHandler ctrl.Paint, AddressOf mControl_Paint
        AddHandler ctrl.Resize, AddressOf mControl_Resize
        AddHandler ctrl.Move, AddressOf mControl_Move
        Dim parent As Control = _boundControls(index).mParent
    End Sub

#End Region

#Region "     drag handles"

    Public Sub deselectAll()
        If activeControl IsNot Nothing And canDeselect Then
            activeControl = Nothing
            boundingRectangle = Nothing
            For x As Integer = 0 To 8
                pb(x).Dispose()
            Next
            activeControlParent.Invalidate()
        End If
    End Sub

    Private pb(8) As PictureBox

    Private Sub addDragHandles()
        Dim sizeCursor() As Cursor = {Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE, _
        Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE}

        Dim smConstants() As Integer = {HTTOPLEFT, HTTOP, HTTOPRIGHT, HTRIGHT, HTBOTTOMRIGHT, _
            HTBOTTOM, HTBOTTOMLEFT, HTLEFT}

        For x As Integer = 1 To 8
            pb(x - 1) = New PictureBox
            With pb(x - 1)
                .BackColor = Color.White
                .Size = New Size(6, 6)
                .BorderStyle = BorderStyle.FixedSingle
                .Location = locations(x - 1)
                .Cursor = sizeCursor(x - 1)
                .Tag = smConstants(x - 1)
                activeControlParent.Controls.Add(pb(x - 1))
                .BringToFront()
                AddHandler .MouseDown, AddressOf pbsMouseDown
                AddHandler .MouseMove, AddressOf pbsMouseMove
                AddHandler .MouseUp, AddressOf pbsMouseUp
            End With
        Next
        pb(8) = New PictureBox
        pb(8).Size = New Size(15, 15)
        pb(8).BorderStyle = BorderStyle.None
        pb(8).Location = locations(8)
        pb(8).Cursor = Cursors.SizeAll
        'pb(8).Image = New System.Drawing.Bitmap(Mid(App_Path, 1, Len(App_Path) - 10) & "Class of Railway Object\move.jpg")
        pb(8).Image = New System.Drawing.Bitmap("move.jpg")
        activeControlParent.Controls.Add(pb(8))
        pb(8).BringToFront()


        'AddHandler pb(8).MouseDown, AddressOf move_mousedown
        'AddHandler pb(8).MouseMove, AddressOf move_mousemove
        AddHandler pb(8).MouseDown, AddressOf startDrag
        AddHandler pb(8).MouseMove, AddressOf whileDragging
        AddHandler pb(8).MouseUp, AddressOf endDrag
    End Sub

#End Region

#Region "     resize handles"

    Private mouseOnHandle As Boolean = False

    Private Sub pbsMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            mouseOnHandle = True
        End If
    End Sub

    Private Sub pbsMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        mouseOnHandle = False
    End Sub

    Private Sub pbsMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If mouseOnHandle Then
            ReleaseCapture()
            'resize from any positions of object
            SendMessage(activeControl.Handle, WM_NCLBUTTONDOWN, CInt(DirectCast(sender, PictureBox).Tag), 0)
            'force the object move like snap to grid
            Dim c As Control = CType(activeControl, Control)
            Select Case CInt(DirectCast(sender, PictureBox).Tag)
                Case HTBOTTOM
                    Dim y As Integer
                    y = GridSpacing * ((activeControl.Top + activeControl.Height + e.Y) \ GridSpacing) + GridSpacing
                    activeControl.Height = y - activeControl.Top
                    'Debug.Print("Bottom")

                Case HTBOTTOMLEFT
                    Dim x, w, y As Integer
                    x = GridSpacing * ((activeControl.Left + e.X) \ GridSpacing)
                    w = GridSpacing * (activeControl.Width \ GridSpacing) + GridSpacing
                    y = GridSpacing * ((activeControl.Top + activeControl.Height + e.Y) \ GridSpacing) + GridSpacing
                    activeControl.Height = y - activeControl.Top
                    activeControl.Left = x
                    activeControl.Width = w

                Case HTBOTTOMRIGHT
                    Dim x, y As Integer
                    x = GridSpacing * ((activeControl.Left + activeControl.Width + e.X) \ GridSpacing) + GridSpacing
                    activeControl.Width = x - activeControl.Left
                    y = GridSpacing * ((activeControl.Top + activeControl.Height + e.Y) \ GridSpacing) + GridSpacing
                    activeControl.Height = y - activeControl.Top

                Case HTLEFT
                    Dim x, w As Integer
                    x = GridSpacing * ((activeControl.Left + e.X) \ GridSpacing)
                    w = GridSpacing * (activeControl.Width \ GridSpacing) + GridSpacing
                    activeControl.Left = x
                    activeControl.Width = w
                    'Debug.Print("4" & " " & x & " " & w)

                Case HTRIGHT
                    Dim x As Integer
                    x = GridSpacing * ((activeControl.Left + activeControl.Width + e.X) \ GridSpacing) + GridSpacing
                    activeControl.Width = x - activeControl.Left
                    'Debug.Print("5" & "  " & activeControl.Left + activeControl.Width + e.X & " " & x)

                Case HTTOP
                    Dim y, h As Integer
                    y = GridSpacing * ((activeControl.Top + e.Y) \ GridSpacing)
                    h = GridSpacing * ((activeControl.Height - e.Y) \ GridSpacing) + GridSpacing
                    activeControl.Top = y
                    activeControl.Height = h
                    'Debug.Print("6" & " " & y & " " & h)

                Case HTTOPLEFT
                    Dim x, w, y, h As Integer
                    x = GridSpacing * ((activeControl.Left + e.X) \ GridSpacing)
                    w = GridSpacing * (activeControl.Width \ GridSpacing) + GridSpacing

                    y = GridSpacing * ((activeControl.Top + e.Y) \ GridSpacing)
                    h = GridSpacing * ((activeControl.Height - e.Y) \ GridSpacing) + GridSpacing

                    activeControl.Left = x
                    activeControl.Width = w
                    activeControl.Top = y
                    activeControl.Height = h

                Case HTTOPRIGHT
                    Dim x, y, h As Integer
                    x = GridSpacing * ((activeControl.Left + activeControl.Width + e.X) \ GridSpacing) + GridSpacing
                    activeControl.Width = x - activeControl.Left
                    y = GridSpacing * ((activeControl.Top + e.Y) \ GridSpacing)
                    h = GridSpacing * ((activeControl.Height - e.Y) \ GridSpacing) + GridSpacing
                    activeControl.Top = y
                    activeControl.Height = h
                    Debug.Print("8")
            End Select
            If GetCapture = 0 Then mouseOnHandle = False
        End If
    End Sub

#Region "     move resize handles"

    Private Sub paintresize()

        horizontalMidPoint = CInt(activeControl.Left + (activeControl.Width / 2))
        verticalMidPoint = CInt(activeControl.Top + (activeControl.Height / 2))

        locations = New Point() _
        {New Point(activeControl.Left - 3, activeControl.Top - 3), New Point(horizontalMidPoint - 3, activeControl.Top - 3), _
        New Point(activeControl.Right - 2, activeControl.Top - 3), New Point(activeControl.Right - 2, verticalMidPoint - 3), _
        New Point(activeControl.Right - 2, activeControl.Bottom - 2), New Point(horizontalMidPoint - 3, activeControl.Bottom - 2), _
        New Point(activeControl.Left - 3, activeControl.Bottom - 2), New Point(activeControl.Left - 3, verticalMidPoint - 3), _
        New Point(activeControl.Left + 9, activeControl.Top - 10)}

        For x As Integer = 0 To 8
            pb(x).Location = locations(x)
        Next

    End Sub

#End Region

#End Region

#Region "     move handle"

    Private mouseOnMove As Boolean = False

    Private Sub move_mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        mouseOnMove = True
        UpdateObj(activeControl.Name, activeControl.Tag)
        IndexObj = activeControl.Tag
    End Sub

    Private Sub move_mousemove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If mouseOnMove Then
            ReleaseCapture()
            SendMessage(activeControl.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
            If GetCapture = 0 Then
                mouseOnMove = False
                For x As Integer = 0 To 8
                    pb(x).BringToFront()
                Next
            End If
        End If
        UpdateObj(activeControl.Name, activeControl.Tag)
        IndexObj = activeControl.Tag
    End Sub

#End Region

#Region "     control eventHandlers"

    Private Sub mControl_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        If sender Is activeControl Then
            drawBoundingRectangle()
            paintresize()
        End If
    End Sub

    Private Sub mControl_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        activeControl.Invalidate()
        drawBoundingRectangle()
        paintresize()
        UpdateObj(activeControl.Name, activeControl.Tag)
        IndexObj = activeControl.Tag
        DisplayObjectProperties(activeControl)
    End Sub

    Private Sub mControl_Move(ByVal sender As Object, ByVal e As System.EventArgs)
        activeControl.Invalidate()
        drawBoundingRectangle()
        paintresize()
    End Sub

    Private Sub mControl_mousedown(ByVal sender As Object, ByVal e As System.EventArgs)

        If activeControlParent IsNot Nothing Then activeControlParent.Invalidate()

        Dim newCtrl As Control = DirectCast(sender, Control)

        horizontalMidPoint = CInt(newCtrl.Left + (newCtrl.Width / 2))
        verticalMidPoint = CInt(newCtrl.Top + (newCtrl.Height / 2))

        locations = New Point() _
        {New Point(newCtrl.Left - 3, newCtrl.Top - 3), New Point(horizontalMidPoint - 3, newCtrl.Top - 3), _
        New Point(newCtrl.Right - 2, newCtrl.Top - 3), New Point(newCtrl.Right - 2, verticalMidPoint - 3), _
        New Point(newCtrl.Right - 2, newCtrl.Bottom - 2), New Point(horizontalMidPoint - 3, newCtrl.Bottom - 2), _
        New Point(newCtrl.Left - 3, newCtrl.Bottom - 2), New Point(newCtrl.Left - 3, verticalMidPoint - 3), _
        New Point(newCtrl.Left + 9, newCtrl.Top - 10)}

        If activeControl IsNot Nothing Then
            For x As Integer = 0 To 8
                pb(x).Dispose()
            Next
        End If
        activeControl = newCtrl
        For x As Integer = 0 To _boundControls.Count - 1
            If _boundControls(x).mControl Is activeControl Then
                activeControlParent = _boundControls(x).mParent
                Exit For
            End If
        Next

        'Debug.Print(activeControl.Tag)
        'Debug.Print(activeControl.BackColor.ToArgb)
        'Debug.Print(activeControl.Font.Name)

        UpdateObj(activeControl.Name, activeControl.Tag)
        IndexObj = activeControl.Tag
        drawBoundingRectangle()
        addDragHandles()
    End Sub

#End Region

#Region "     set activeControl bounding rectangle"

    Private Sub drawBoundingRectangle()
        Dim r As Rectangle = activeControl.Bounds
        r.Inflate(1, 1)
        boundingRectangle = r
        activeControlParent.Invalidate()
    End Sub

#End Region

#Region "     Moving Object Handler"
    ' True while we are drawing the new line.
    Private mDragging As Boolean

    Dim X0, X1, Y0, Y1
    '---------------- handler moving Object
    Private Sub startDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        mDragging = True

        X0 = e.X : Y0 = e.Y
        SnapToGrid(X0, Y0)
        UpdateObj(activeControl.Name, activeControl.Tag)
        IndexObj = activeControl.Tag
    End Sub

    Private Sub whileDragging(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        X1 = e.X : Y1 = e.Y
        SnapToGrid(X1, Y1)
        If mDragging = True Then
            activeControl.Location = New Point(activeControl.Location.X + X1 - X0, activeControl.Location.Y + Y1 - Y0)
            UpdateObj(activeControl.Name, activeControl.Tag)
            activeControl.Refresh()
        End If

    End Sub

    Private Sub endDrag(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mDragging = False
        UpdateObj(activeControl.Name, activeControl.Tag)
        IndexObj = activeControl.Tag
        DisplayObjectProperties(activeControl)
    End Sub

#End Region

#Region "    Functions and Constants "

    <DllImport("user32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Public Declare Function GetCapture Lib "user32" Alias "GetCapture" () As Integer

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTBORDER As Integer = 18
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14

#End Region

End Class

#End Region

