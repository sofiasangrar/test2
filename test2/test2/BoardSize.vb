Public Class BoardSize
    Public boardDimensions As Integer
    Public cellSize As Integer

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        boardDimensions = 6
        cellSize = 50
        PlayScreen.Show()
        Close()
        StartScreen.Close()
    End Sub

    Private Sub btn10_Click(sender As Object, e As EventArgs) Handles btn10.Click
        boardDimensions = 9
        cellSize = 45
        PlayScreen.Show()
        Close()
        StartScreen.Close()
    End Sub

    Private Sub btn15_Click(sender As Object, e As EventArgs) Handles btn15.Click
        boardDimensions = 14
        cellSize = 30
        PlayScreen.Show()
        Close()
        StartScreen.Close()
    End Sub

    Private Sub BoardSize_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class