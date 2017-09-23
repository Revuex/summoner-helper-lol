
Public Class Form1
    Dim tiklanan_nokta As Point
    Dim wc As System.Net.WebClient
    Dim fgfg As String

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        'Farenin tiklandigi noktadaki koordinatlarini alir 
        tiklanan_nokta = New Point(e.X, e.Y)
    End Sub
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        'Sol tus basili olarak hareket ettiriliyorsa formu tasir 
        If e.Button = MouseButtons.Left Then
            Dim Koordinatlar As Point
            Koordinatlar = Control.MousePosition
            Koordinatlar.Offset(-tiklanan_nokta.X, -tiklanan_nokta.Y)
            Me.Location = Koordinatlar
        End If
    End Sub
    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Timer2.Start()
        Timer3.Start()
        Dim a As String = BunifuMetroTextbox1.Text
        Dim b As String = BunifuDropdown1.selectedIndex
        My.Computer.FileSystem.WriteAllText(Application.StartupPath + "/username.txt", a, False)
        My.Computer.FileSystem.WriteAllText(Application.StartupPath + "/region.txt", b, False)
        Me.Hide()
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(30000)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(Application.StartupPath + "/username.txt") = True Then
            BunifuMetroTextbox1.Text = System.IO.File.ReadAllText(Application.StartupPath + "/username.txt", System.Text.Encoding.Unicode)
        End If

        If My.Computer.FileSystem.FileExists(Application.StartupPath + "/region.txt") = True Then
            BunifuDropdown1.selectedIndex = System.IO.File.ReadAllText(Application.StartupPath + "/region.txt", System.Text.Encoding.Default)
        End If

        Dim RastgeleSayi As New Random
        Dim OlusturulanSayi As Integer = RastgeleSayi.Next(7, 60)

        Label7.Text = OlusturulanSayi

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
       
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim isRunning As Boolean = Process.GetProcesses().Any(Function(p) p.ProcessName.Contains("LeagueOfLegends"))
        If isRunning Then
            Label9.Text = Label9.Text + 1
            If Label9.Text = 20 Then
                Timer2.Stop()
                Form2.Show()
            End If
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim isRunning As Boolean = Process.GetProcesses().Any(Function(p) p.ProcessName.Contains("LeagueClient"))
        If isRunning Then
            Label10.Text = Label10.Text + 1
            If Label10.Text = 100 Then
                Timer3.Stop()
                Form3.Show()
            End If
        End If
    End Sub
End Class
