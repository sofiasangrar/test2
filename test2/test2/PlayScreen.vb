Public Class PlayScreen
    Public colourList(3) As Color
    Public playgrid As PlayGrid
    Public tiles = New List(Of Tile) 'a list of every tile that is created
    Public cellSize As Integer
    Public dimensions As Integer
    Public userTurn As Boolean = True
    Public computer As Opponent

    Public loadGame As Boolean
    Public loadBoardSize As Integer
    Public loadCellSize As Integer
    Public loadComputerScore(3) As Integer
    Public loadUserScore(3) As Integer
    Public BoardData(,) As Integer

    Public Structure Scores 'the colour and its corresponding score is stored in a record structure
        Public colour As Color
        Public score As Integer
    End Structure

    Public playerScore(3) As Scores
    Public playerScoreBoard As ScoreTable
    Public opponentScore(3) As Scores
    Public computerScoreBoard As ScoreTable
    Public playerTiles(5) As Tile

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'a standardised list of colours is created for ease of changing them if necessary
        colourList(0) = Color.Red
        colourList(1) = Color.LimeGreen
        colourList(2) = Color.DeepSkyBlue
        colourList(3) = Color.Gold

        If loadGame = True Then
            dimensions = loadBoardSize
            cellSize = loadCellSize
            For counter = 0 To 3
                playerScore(counter).score = loadUserScore(counter)
                opponentScore(counter).score = loadComputerScore(counter)
            Next
        Else
            dimensions = BoardSize.boardDimensions
            cellSize = BoardSize.cellSize
            'initially all scores are set to 0
            For counter = 0 To 3
                playerScore(counter).score = 0
                opponentScore(counter).score = 0
            Next
        End If

        WindowState = FormWindowState.Maximized 'the window starts up full screen
        computer = New Opponent
        For counter = 0 To 5
            playerTiles(counter) = New Tile(Me, New Point(((counter) * cellSize) + ((counter + 1) * 80) + 200, Bottom - 200), cellSize) 'new tiles are created with even spacing
            Dim newButton As New RotateButton(Me, New Point(playerTiles(counter).Location.X + Int(cellSize / 4), playerTiles(0).Bottom + 20)) 'new rotate buttons are created under these tiles
        Next

        playgrid = New PlayGrid(dimensions, Me, cellSize) 'a new playgrid is initialised

        'the colours that the scores refer to are initialised
        For counter = 0 To 3
            playerScore(counter).colour = colourList(counter)
            opponentScore(counter).colour = colourList(counter)
        Next

        playerScoreBoard = New ScoreTable(Me, New Point(1000, 400), playerScore)
        computerScoreBoard = New ScoreTable(Me, New Point(1000, 150), opponentScore)

        Dim swapButton As New SwapButton 'the swap button is created
        Dim saveButton As New Save

    End Sub

    Public Sub FindWinner()
        Dim lowestPlayerScore As Integer = playerScore(0).score
        Dim lowestComputerScore As Integer = opponentScore(0).score
        For counter = 0 To 3
            If playerScore(counter).score < lowestPlayerScore Then
                lowestPlayerScore = playerScore(counter).score
            End If
            If opponentScore(counter).score < lowestComputerScore Then
                lowestPlayerScore = playerScore(counter).score
            End If
        Next

        If lowestPlayerScore > lowestComputerScore Then
            Dim name As String = InputBox("You win! Enter name")
            Dim readarray() As String
            Dim filename As String = "C:\Users\12h169\source\repos\test2\highScore.txt"
            Dim file As New IO.StreamReader(filename)
            Dim upperBound As Integer

            Dim scoresArray() As highScore

            readarray = file.ReadToEnd.Split(",")
            file.Close()
            upperBound = UBound(readarray)
            ReDim scoresArray(upperBound)
            scoresArray(0).score = lowestPlayerScore
            scoresArray(0).name = name


            If upperBound > 0 Then
                For i = 1 To upperBound
                    scoresArray(i).score = Val(Strings.Left(readarray(i - 1), 3))
                    scoresArray(i).name = Strings.Right(readarray(i - 1), readarray(i - 1).Length - 3)
                Next
                SortHighScores(scoresArray, upperBound)
                HighScoreTable.Show()
                HighScoreTable.populateGrid(scoresArray)
                Close()
            End If
        Else
            MsgBox("You lose")
            HighScoreTable.Show()
            Close()
        End If
    End Sub

    Public Structure highScore
        Public score As Integer
        Public name As String
    End Structure

    Public Sub SortHighScores(ByRef scoresArray, ByVal upperbound)
        Dim filename As String = "C:\Users\12h169\source\repos\test2\highScore.txt"
        Dim temp As highScore


        For counter = 0 To upperbound - 1
            If Val(scoresArray(counter).score) >= Val(scoresArray(counter + 1).score) Then
                Exit For
            End If
            If Val(scoresArray(counter).score) < Val(scoresArray(counter + 1).score) Then
                temp = scoresArray(counter)
                scoresArray(counter) = scoresArray(counter + 1)
                scoresArray(counter + 1) = temp
            End If
        Next

        Dim writefile As IO.StreamWriter
        writefile = My.Computer.FileSystem.OpenTextFileWriter(filename, False)

        For counter = 0 To UBound(scoresArray)
            writefile.Write(Format(scoresArray(counter).score, "000") & scoresArray(counter).name & ",")
        Next
        writefile.Close()
    End Sub
End Class
