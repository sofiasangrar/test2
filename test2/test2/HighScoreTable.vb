Public Class HighScoreTable

    Public Sub populateGrid(ByVal scoresArray)
        Dim endLoop As Integer
        If UBound(scoresArray) < 9 Then
            endLoop = UBound(scoresArray)
        Else
            endLoop = 9
        End If

        For counter = 0 To endLoop
            DataGridView1.Rows.Add(scoresArray(counter).name, scoresArray(counter).score)
        Next
    End Sub

    Private Sub HighScoreTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
    End Sub
End Class