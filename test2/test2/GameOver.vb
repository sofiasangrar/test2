Public Class GameOver
    Private Sub GameOver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BringToFront()
        HighScoreTable.Show()
        PlayScreen.Close()
    End Sub
End Class