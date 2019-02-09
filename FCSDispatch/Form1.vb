Public Class Form1
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    'Background color and other color stuff
    Dim click1 As Boolean = False
    Dim click2 As Boolean = False

    'Bool for image changes
    Dim num As Boolean

    'Bool for panel hiding
    Dim hider As Boolean


    Dim resourcePath As String

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - mousey
            Me.Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If MsgBox("Are you sure you want to exit?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Application.Exit()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    'Hide panel
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        'Change eye to closed or open
        If num = False Then
            PictureBox7.Image = My.Resources.view
            num = True
        Else
            PictureBox7.Image = My.Resources.hide
            num = False
        End If
        'Actually hide the panel
        If hider = False Then
            Panel2.Visible = True
            hider = True
        Else
            Panel2.Visible = False
            hider = False
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Region = New Region(New RectangleF(Me.TabPage1.Left, Me.TabPage1.Top, Me.TabPage1.Width, Me.TabPage1.Height))
    End Sub
End Class
