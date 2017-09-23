Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer2.Start()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim isRunning As Boolean = Process.GetProcesses().Any(Function(p) p.ProcessName.Contains("LeagueOfLegends"))
        If isRunning Then
            Label1.Text = Label1.Text + 1
            If Label1.Text = 20 Then
                Timer1.Stop()
                Me.Hide()
                Form2.Show()
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim isRunning As Boolean = Process.GetProcesses().Any(Function(p) p.ProcessName.Contains("LeagueClient"))
        If isRunning Then
            Label2.Text = Label2.Text + 1
            If Label2.Text = 100 Then
                Me.Show()

            End If
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        BunifuImageButton1.Visible = True
    End Sub
End Class