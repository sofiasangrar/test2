Public Class Opponent

    Private computerTiles(5) As ComputerTile

    Public Sub New()
        For counter = 0 To 5
            computerTiles(counter) = New ComputerTile
        Next
    End Sub

    Private Function GetLowestScore(location)
        Dim sortScores(3) As PlayScreen.Scores
        Dim temp As PlayScreen.Scores
        For counter = 0 To 3
            sortScores(counter).score = PlayScreen.opponentScore(counter).score
            sortScores(counter).colour = PlayScreen.opponentScore(counter).colour
        Next

        For outerloop = 2 To 0 Step -1
            For counter = 0 To outerloop
                If sortScores(counter).score > sortScores(counter + 1).score Then
                    temp = sortScores(counter)
                    sortScores(counter) = sortScores(counter + 1)
                    sortScores(counter + 1) = temp
                End If
            Next
        Next
        Return sortScores(location).colour
    End Function

    Public Sub opponentTurn(ByVal location As Integer)
        Dim loc As Integer = location
        Dim useColour As Color = GetLowestScore(loc)
        MsgBox(useColour.ToString & " is the colour I should use")
        Dim found As Boolean = False
        Dim useTilePos As Integer
        Dim useTile As ComputerTile
        Dim counter As Integer = 0
        Do Until found = True Or counter = 6
            If computerTiles(counter).pictureBox1.BackColor = useColour Or computerTiles(counter).pictureBox2.BackColor = useColour Then
                found = True
                useTilePos = counter
                useTile = computerTiles(useTilePos)
                MsgBox("Tile found. Tile is " & useTile.pictureBox1.BackColor.ToString & " and " & useTile.pictureBox2.BackColor.ToString)
            Else
                counter = counter + 1
            End If
        Loop
        If found = False Then
            MsgBox("Tile not found")
            loc = loc + 1
            opponentTurn(loc)
        Else
            FindBestPosition()
        End If
    End Sub

    Private Sub FindBestPosition()

        PlayScreen.userTurn = True
    End Sub

End Class
