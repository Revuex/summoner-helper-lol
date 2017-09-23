Public Class Form2

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim u As String = Form1.BunifuMetroTextbox1.Text
        Dim r As String = Form1.BunifuDropdown1.selectedValue.ToString
        Dim url As String = "http://lolskill.net/game/"
        u.Replace(" ", "+")
        WebBrowser1.Navigate(url + r + "/" + u)
    End Sub
End Class