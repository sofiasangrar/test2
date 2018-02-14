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
        Dim found As Boolean = False
        Dim useTilePos As Integer
        Dim useTile As ComputerTile
        Dim counter As Integer = 0
        Dim horizontalGaps(0) As TileVacancy
        Dim verticalGaps(0) As TileVacancy
        Dim potentialScores(0) As PlayGrid.computerScores
        Dim move As PlayGrid.computerScores
        Do Until found = True Or counter = 6
            If computerTiles(counter).pictureBox1.BackColor = useColour Or computerTiles(counter).pictureBox2.BackColor = useColour Then
                found = True
                useTilePos = counter
                useTile = computerTiles(useTilePos)
            Else
                counter = counter + 1
            End If
        Loop
        If found = False Then
            loc = loc + 1
            opponentTurn(loc)
        Else
            FindGap(horizontalGaps, verticalGaps)
            getScores(horizontalGaps, verticalGaps, useTile, potentialScores)
            If UBound(potentialScores) > 0 Then
                sortScores(potentialScores, useColour)
            End If
            move = potentialScores.Last
            PlayScreen.playgrid.SetColour(move.colour1, move.colour2, move.outer1, move.inner1, move.outer2, move.inner2)
            PlayScreen.opponentScore(Array.IndexOf(PlayScreen.colourList, move.colour1)).score = PlayScreen.opponentScore(Array.IndexOf(PlayScreen.colourList, move.colour1)).score + move.score1
            PlayScreen.opponentScore(Array.IndexOf(PlayScreen.colourList, move.colour2)).score = PlayScreen.opponentScore(Array.IndexOf(PlayScreen.colourList, move.colour2)).score + move.score2
            For counter = 0 To 3
                PlayScreen.computerScoreBoard.scoreDisplay(counter).scoreBox.Text = PlayScreen.opponentScore(counter).score
            Next
            If PlayScreen.playgrid.CheckForMoves = True Then
                PlayScreen.userTurn = True
            Else
                MsgBox("Game over")
                PlayScreen.FindWinner()
            End If
        End If
    End Sub

    Public Structure TileVacancy
        Public outer1 As Integer
        Public inner1 As Integer
        Public outer2 As Integer
        Public inner2 As Integer
    End Structure

    Private Sub FindGap(ByRef horizontalGaps() As TileVacancy, ByRef verticalGaps() As TileVacancy)
        Dim gaplength As Integer = 0
        Dim tally As Integer = 0
        For outer = 0 To PlayScreen.playgrid.dimensions
            For inner = 0 To PlayScreen.playgrid.dimensions
                If PlayScreen.playgrid.cells(outer, inner).cellProperty = Color.LightGray Then
                    tally = tally + 1
                Else
                    tally = 0
                End If
                If tally >= 2 Then
                    ReDim Preserve verticalGaps(gaplength)
                    verticalGaps(gaplength).outer1 = outer
                    verticalGaps(gaplength).inner1 = inner - 1
                    verticalGaps(gaplength).outer2 = outer
                    verticalGaps(gaplength).inner2 = inner
                    gaplength = gaplength + 1
                End If
            Next
            tally = 0
        Next
        tally = 0
        gaplength = 0
        For inner = 0 To PlayScreen.playgrid.dimensions
            For outer = 0 To PlayScreen.playgrid.dimensions
                If PlayScreen.playgrid.cells(outer, inner).cellProperty = Color.LightGray Then
                    tally = tally + 1
                Else
                    tally = 0
                End If
                If tally >= 2 Then
                    ReDim Preserve horizontalGaps(gaplength)
                    horizontalGaps(gaplength).outer1 = outer - 1
                    horizontalGaps(gaplength).inner1 = inner
                    horizontalGaps(gaplength).outer2 = outer
                    horizontalGaps(gaplength).inner2 = inner
                    gaplength = gaplength + 1
                End If
            Next
            tally = 0
        Next
    End Sub

    Private Sub getScores(ByVal hgaps() As TileVacancy, ByVal vgaps() As TileVacancy, ByVal tile As ComputerTile, ByRef opponentScores() As PlayGrid.computerScores)
        Dim i As Integer = 0
        For counter = 0 To 2 Step 2
            tile.orientation = counter
            tile.orientate()
            For loopCounter = 0 To UBound(hgaps)
                ReDim Preserve opponentScores(i)
                opponentScores(i) = PlayScreen.playgrid.CalculateOpponentScore(hgaps(loopCounter).outer1, hgaps(loopCounter).inner1, hgaps(loopCounter).outer2, hgaps(loopCounter).inner2, tile, counter)
                i = i + 1
            Next
        Next
        For counter = 1 To 3 Step 2
            tile.orientation = counter
            tile.orientate()
            For loopCounter = 0 To UBound(vgaps)
                ReDim Preserve opponentScores(i)
                opponentScores(i) = PlayScreen.playgrid.CalculateOpponentScore(vgaps(loopCounter).outer1, vgaps(loopCounter).inner1, vgaps(loopCounter).outer2, vgaps(loopCounter).inner2, tile, counter)
                i = i + 1
            Next
        Next
    End Sub

    Private Sub sortScores(ByRef scoresArray() As PlayGrid.computerScores, ByVal colour As Color)
        Dim score1 As Integer
        Dim score2 As Integer
        Dim temp As PlayGrid.computerScores
        Dim max As Integer
        Dim firstMax As Integer
        For outerloop = UBound(scoresArray) - 1 To 0 Step -1
            For counter = 0 To outerloop
                If scoresArray(counter).colour1 = colour Then
                    score1 = scoresArray(counter).score1
                Else
                    score1 = scoresArray(counter).score2
                End If
                If scoresArray(counter + 1).colour1 = colour Then
                    score2 = scoresArray(counter + 1).score1
                Else
                    score2 = scoresArray(counter + 1).score2
                End If
                If score1 > score2 Then
                    temp = scoresArray(counter)
                    scoresArray(counter) = scoresArray(counter + 1)
                    scoresArray(counter + 1) = temp
                End If
            Next
        Next
        If scoresArray(0).colour1 = colour Then
            max = scoresArray(0).score1
        Else
            max = scoresArray(0).score2
        End If

        For counter = 1 To UBound(scoresArray)
            If scoresArray(counter).colour1 = colour And scoresArray(counter).score1 > max Then
                max = scoresArray(counter).score1
            ElseIf scoresArray(counter).colour2 = colour And scoresArray(counter).score2 > max Then
                max = scoresArray(counter).score2
            End If
        Next

        For counter = 0 To UBound(scoresArray)
            If (scoresArray(counter).colour1 = colour And scoresArray(counter).score1 = max) Or (scoresArray(counter).colour2 = colour And scoresArray(counter).score2 = max) Then
                firstMax = counter
                Exit For
            End If
        Next

        For outerloop = UBound(scoresArray) - 1 To firstMax Step -1
            For counter = 0 To outerloop
                If scoresArray(counter).colour1 = colour Then
                    score1 = scoresArray(counter).score2
                Else
                    score1 = scoresArray(counter).score1
                End If
                If scoresArray(counter + 1).colour1 = colour Then
                    score2 = scoresArray(counter + 1).score2
                Else
                    score2 = scoresArray(counter + 1).score1
                End If
                If score1 > score2 Then
                    temp = scoresArray(counter)
                    scoresArray(counter) = scoresArray(counter + 1)
                    scoresArray(counter + 1) = temp
                End If
            Next
        Next
    End Sub
End Class