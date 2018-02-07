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
        Dim readarray() As String
        Dim filename As String = "C:\Users\12h169\source\repos\test2\highScore.txt"
        Dim file As New IO.StreamReader(filename)

        Dim scoresArray() As PlayScreen.highScore

        readarray = file.ReadToEnd.Split(",")
        file.Close()
        Dim upperBound As Integer = UBound(readarray) - 1
        ReDim scoresArray(upperBound)

        For i = 0 To upperBound
            scoresArray(i).score = Val(Strings.Left(readarray(i), 3))
            scoresArray(i).name = Strings.Right(readarray(i), readarray(i).Length - 3)
        Next
        populateGrid(scoresArray)
    End Sub
End Class