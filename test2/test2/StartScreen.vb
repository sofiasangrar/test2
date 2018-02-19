Public Class StartScreen


    Private Sub StartScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized 'the window starts up full screen
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        Dim writeFile As IO.StreamWriter
        Dim filename As String = "C:\Users\12h169\source\repos\test2\savefile.txt"
        Dim readFile As New IO.StreamReader(filename)
        Dim readData As String
        readData = readFile.ReadToEnd
        readFile.Close()
        If readData <> "" Then
            Dim overwrite As MsgBoxResult = MsgBox("There is a game already saved. Do you want to overwrite it?", MsgBoxStyle.YesNo, "Alert")
            If overwrite = MsgBoxResult.Yes Then
                writeFile = My.Computer.FileSystem.OpenTextFileWriter(filename, False)
                writeFile.Write("")
                writeFile.Close()
                BoardSize.Show()
                BoardSize.BringToFront()
            End If
        Else
            writeFile = My.Computer.FileSystem.OpenTextFileWriter(filename, False)
            writeFile.Write("")
            writeFile.Close()
            BoardSize.Show()
            BoardSize.BringToFront()
        End If

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim filename As String = "C:\Users\12h169\source\repos\test2\savefile.txt"
        Dim readarray() As String
        Dim file As New IO.StreamReader(filename)
        Dim writeFile As IO.StreamWriter
        readarray = file.ReadToEnd.Split(vbCr)
        file.Close()
        If readarray(0) <> "" Then
            PlayScreen.loadBoardSize = Convert.ToInt32(readarray(0))
            PlayScreen.loadCellSize = Convert.ToInt32(readarray(1))
            For loopCounter = 0 To 3
                PlayScreen.loadUserScore(loopCounter) = Convert.ToInt32(readarray(loopCounter + 2))
                PlayScreen.loadComputerScore(loopCounter) = Convert.ToInt32(readarray(loopCounter + 6))

            Next
            ReDim PlayScreen.BoardData(PlayScreen.loadBoardSize, PlayScreen.loadBoardSize)
            Dim counter As Integer = 10
            Do Until counter = UBound(readarray)
                For outer = 0 To PlayScreen.loadBoardSize
                    For inner = 0 To PlayScreen.loadBoardSize
                        PlayScreen.BoardData(outer, inner) = Convert.ToInt32(readarray(counter))
                        counter = counter + 1
                    Next
                Next
            Loop
            writeFile = My.Computer.FileSystem.OpenTextFileWriter(filename, False)
            writeFile.Write("")
            writeFile.Close()
            PlayScreen.loadGame = True
            PlayScreen.Show()
            Close()
        Else
            MsgBox("There is no game saved.")
        End If
    End Sub

    Private Sub btnHighScore_Click(sender As Object, e As EventArgs) Handles btnHighScore.Click
        NewBackButton(HighScoreTable)
    End Sub

    Private Sub btnInstructions_Click(sender As Object, e As EventArgs) Handles btnInstructions.Click
        NewBackButton(Instructions)
    End Sub

    Private Sub NewBackButton(form As Form)
        Dim goBack As New Button
        goBack.Size = New Size(50, 50)
        goBack.Location = New Point(100, 12)
        goBack.BackgroundImage = My.Resources.back
        goBack.BackgroundImageLayout = ImageLayout.Stretch
        form.Controls.Add(goBack)
        AddHandler goBack.Click, AddressOf Back_Click
        form.Show()
    End Sub

    Public Sub Back_Click(sender As Object, e As EventArgs)
        ActiveForm.Close()
    End Sub
End Class