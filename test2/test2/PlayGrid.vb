Public Class PlayGrid
    Inherits Panel

    Public Structure Cell
        Public onScreen As PictureBox
        Public cellProperty As Color
    End Structure

    Public cells(,) As Cell
    Public dimensions As Integer

    Public Sub New(size As Integer, form As PlayScreen, cellSize As Integer)
        dimensions = size
        ReDim cells(dimensions, dimensions)
        Me.Size = New Size((dimensions + 1) * cellSize, (dimensions + 1) * cellSize)
        Location = New Point(625 - Width / 2, 300 - Height / 2)

        For outer = 0 To dimensions
            For inner = 0 To dimensions
                cells(outer, inner).onScreen = New PictureBox()
                cells(outer, inner).onScreen.Size = New Size(cellSize, cellSize)
                cells(outer, inner).onScreen.BackColor = Color.LightGray
                cells(outer, inner).cellProperty = Color.LightGray
                cells(outer, inner).onScreen.BorderStyle = BorderStyle.FixedSingle
                cells(outer, inner).onScreen.Location = New Point(outer * cellSize, inner * cellSize)
                cells(outer, inner).onScreen.AllowDrop = True
                Controls.Add(cells(outer, inner).onScreen)
            Next
        Next

        cells(1, 1).cellProperty = PlayScreen.colourList(0)
        cells(1, 1).onScreen.BackColor = PlayScreen.colourList(0)
        cells(dimensions - 1, 1).cellProperty = PlayScreen.colourList(1)
        cells(dimensions - 1, 1).onScreen.BackColor = PlayScreen.colourList(1)
        cells(1, dimensions - 1).cellProperty = PlayScreen.colourList(2)
        cells(1, dimensions - 1).onScreen.BackColor = PlayScreen.colourList(2)
        cells(dimensions - 1, dimensions - 1).cellProperty = PlayScreen.colourList(3)
        cells(dimensions - 1, dimensions - 1).onScreen.BackColor = PlayScreen.colourList(3)

        form.Controls.Add(Me)

        If PlayScreen.loadGame = True Then
            PopulateBoard()
        End If
    End Sub

    Private Sub PopulateBoard()
        For outer = 0 To PlayScreen.loadBoardSize
            For inner = 0 To PlayScreen.loadBoardSize
                If PlayScreen.BoardData(outer, inner) <> -1 Then
                    cells(outer, inner).cellProperty = PlayScreen.colourList(PlayScreen.BoardData(outer, inner))
                    cells(outer, inner).onScreen.BackColor = cells(outer, inner).cellProperty
                End If
            Next
        Next

    End Sub

    Public Sub FindLocation(ByVal loc1 As Point, ByVal loc2 As Point, ByRef outer1 As Integer, ByRef inner1 As Integer, ByRef outer2 As Integer, ByRef inner2 As Integer)
        Dim found1 As Boolean = False
        Dim found2 As Boolean = False

        For outer = 0 To dimensions
            For inner = 0 To dimensions
                Dim screenloc As New Point(cells(outer, inner).onScreen.PointToScreen(cells(outer, inner).onScreen.Location))

                screenloc.X = screenloc.X - 1
                screenloc.Y = screenloc.Y - 1

                If screenloc = loc1 Then
                    found1 = True
                    outer1 = outer
                    inner1 = inner
                End If
                If screenloc = loc2 Then
                    found2 = True
                    outer2 = outer
                    inner2 = inner
                End If
                If found1 = True AndAlso found2 = True Then
                    Exit For
                End If

            Next
        Next
    End Sub

    Public Sub SetColour(ByVal colour1 As Color, ByVal colour2 As Color, ByVal outer1 As Integer, ByVal inner1 As Integer, ByVal outer2 As Integer, ByVal inner2 As Integer)
        cells(outer1, inner1).cellProperty = colour1
        cells(outer2, inner2).cellProperty = colour2
    End Sub

    Public Sub CalculateScore(ByVal outer1, ByVal inner1, ByVal outer2, ByVal inner2)

        Dim cell1Colour As Color = cells(outer1, inner1).cellProperty
        Dim cell2colour As Color = cells(outer2, inner2).cellProperty
        Dim incrementScore As Integer
        Dim outerCounter As Integer
        Dim innerCounter As Integer

        For i = 0 To 3
            If PlayScreen.playerScore(i).colour = cell1Colour Then
                incrementScore = i
            End If
        Next

        If inner1 > 0 Then
            For counter = inner1 - 1 To 0 Step -1
                If cells(outer1, counter).cellProperty = cell1Colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                Else
                    Exit For
                End If
            Next
        End If

        If outer1 < dimensions Then
            For counter = outer1 + 1 To dimensions
                If counter = outer2 And inner1 = inner2 Then
                    Exit For
                ElseIf cells(counter, inner1).cellProperty = cell1Colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                Else
                    Exit For
                End If
            Next
        End If

        If inner1 < dimensions Then
            For counter = inner1 + 1 To dimensions
                If counter = inner2 And outer1 = outer2 Then
                    Exit For
                ElseIf cells(outer1, counter).cellProperty = cell1Colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                Else
                    Exit For
                End If
            Next
        End If


        If outer1 > 0 Then
            For counter = outer1 - 1 To 0 Step -1
                If cells(counter, inner1).cellProperty = cell1Colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                Else
                    Exit For
                End If
            Next
        End If

        If inner1 > 0 And outer1 > 0 Then
            outerCounter = outer1 - 1
            innerCounter = inner1 - 1
            Do While outerCounter >= 0 And innerCounter >= 0
                If cells(outerCounter, innerCounter).cellProperty = cell1Colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                    outerCounter = outerCounter - 1
                    innerCounter = innerCounter - 1
                Else
                    Exit Do
                End If
            Loop
        End If

        If outer1 < dimensions And inner1 > 0 Then
            outerCounter = outer1 - 1
            innerCounter = inner1 + 1
            Do While outerCounter >= 0 And innerCounter <= dimensions
                If cells(outerCounter, innerCounter).cellProperty = cell1Colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                    outerCounter = outerCounter - 1
                    innerCounter = innerCounter + 1
                Else
                    Exit Do
                End If
            Loop
        End If

        If outer1 < dimensions And inner1 < dimensions Then
            outerCounter = outer1 + 1
            innerCounter = inner1 + 1
            Do While outerCounter <= dimensions And innerCounter <= dimensions
                If cells(outerCounter, innerCounter).cellProperty = cell1Colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                    outerCounter = outerCounter + 1
                    innerCounter = innerCounter + 1
                Else
                    Exit Do
                End If
            Loop
        End If

        If outer1 < dimensions And inner1 > 0 Then
            outerCounter = outer1 + 1
            innerCounter = inner1 - 1
            Do While outerCounter <= dimensions And innerCounter >= 0
                If cells(outerCounter, innerCounter).cellProperty = cell1Colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                    outerCounter = outerCounter + 1
                    innerCounter = innerCounter - 1
                Else
                    Exit Do
                End If
            Loop
        End If

        For i = 0 To 3
            If PlayScreen.playerScore(i).colour = cell2colour Then
                incrementScore = i
            End If
        Next

        If inner2 > 0 Then
            For counter = inner2 - 1 To 0 Step -1
                If counter = inner1 And outer1 = outer2 Then
                    Exit For
                ElseIf cells(outer2, counter).cellProperty = cell2colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                Else
                    Exit For
                End If
            Next
        End If

        If outer2 < dimensions Then
            For counter = outer2 + 1 To dimensions
                If cells(counter, inner2).cellProperty = cell2colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                Else
                    Exit For
                End If
            Next
        End If

        If inner2 < dimensions Then
            For counter = inner2 + 1 To dimensions
                If cells(outer2, counter).cellProperty = cell2colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                Else
                    Exit For
                End If
            Next
        End If

        If outer2 > 0 Then
            For counter = outer2 - 1 To 0 Step -1
                If counter = outer1 And inner1 = inner2 Then
                    Exit For
                ElseIf cells(counter, inner2).cellProperty = cell2colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                Else
                    Exit For
                End If
            Next
        End If

        If inner2 > 0 And outer2 > 0 Then
            outerCounter = outer2 - 1
            innerCounter = inner2 - 1
            Do While outerCounter >= 0 And innerCounter >= 0
                If cells(outerCounter, innerCounter).cellProperty = cell2colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                    outerCounter = outerCounter - 1
                    innerCounter = innerCounter - 1
                Else
                    Exit Do
                End If
            Loop
        End If

        If outer2 < dimensions And inner2 > 0 Then
            outerCounter = outer2 - 1
            innerCounter = inner2 + 1
            Do While outerCounter >= 0 And innerCounter <= dimensions
                If cells(outerCounter, innerCounter).cellProperty = cell2colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                    outerCounter = outerCounter - 1
                    innerCounter = innerCounter + 1
                Else
                    Exit Do
                End If
            Loop
        End If

        If outer2 < dimensions And inner2 < dimensions Then
            outerCounter = outer2 + 1
            innerCounter = inner2 + 1
            Do While outerCounter <= dimensions And innerCounter <= dimensions
                If cells(outerCounter, innerCounter).cellProperty = cell2colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                    outerCounter = outerCounter + 1
                    innerCounter = innerCounter + 1
                Else
                    Exit Do
                End If
            Loop
        End If

        If outer2 < dimensions And inner2 > 0 Then
            outerCounter = outer2 + 1
            innerCounter = inner2 - 1
            Do While outerCounter <= dimensions And innerCounter >= 0
                If cells(outerCounter, innerCounter).cellProperty = cell2colour Then
                    PlayScreen.playerScore(incrementScore).score = PlayScreen.playerScore(incrementScore).score + 1
                    outerCounter = outerCounter + 1
                    innerCounter = innerCounter - 1
                Else
                    Exit Do
                End If
            Loop
        End If

        For counter = 0 To 3
            PlayScreen.playerScoreBoard.scoreDisplay(counter).scoreBox.Text = PlayScreen.playerScore(counter).score
        Next
    End Sub

    Public Function CheckForMoves()
        Dim moreMoves As Boolean
        Dim tally As Integer = 0
        For outer = 0 To dimensions
            For inner = 0 To dimensions
                If cells(outer, inner).cellProperty = Color.LightGray Then
                    tally = tally + 1
                Else
                    tally = 0
                End If
                If tally = 2 Then
                    moreMoves = True
                    Return moreMoves
                    Exit Function
                End If
            Next
            tally = 0
        Next
        For inner = 0 To dimensions
            For outer = 0 To dimensions
                If cells(outer, inner).cellProperty = Color.LightGray Then
                    tally = tally + 1
                Else
                    tally = 0
                End If
                If tally = 2 Then
                    moreMoves = True
                    Return moreMoves
                    Exit Function
                End If
            Next
            tally = 0
        Next
        Return moreMoves
    End Function
End Class
