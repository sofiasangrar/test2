Public Class StartScreen
    Public loadBoardSize As Integer
    Public loadCellSize As Integer
    Public loadComputerScore(3) As Integer
    Public loadUserScore(3) As Integer
    Public BoardData(,) As Integer
    Public loadGame As Boolean = False

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
                Hide()
            End If
        Else
            writeFile = My.Computer.FileSystem.OpenTextFileWriter(filename, False)
            writeFile.Write("")
            writeFile.Close()
            BoardSize.Show()
            BoardSize.BringToFront()
            Hide()
        End If

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim filename As String = "C:\Users\12h169\source\repos\test2\savefile.txt"
        Dim readarray() As String
        Dim file As New IO.StreamReader(filename)
        Dim writeFile As IO.StreamWriter
        readarray = file.ReadToEnd.Split(vbCr)
        file.Close()
        loadBoardSize = Convert.ToInt32(readarray(0))
        loadCellSize = Convert.ToInt32(readarray(1))

        For loopCounter = 0 To 3
            loadUserScore(loopCounter) = Convert.ToInt32(readarray(loopCounter + 2))
            loadComputerScore(loopCounter) = Convert.ToInt32(readarray(loopCounter + 6))
        Next

        ReDim BoardData(loadBoardSize, loadBoardSize)
        Dim counter As Integer = 10
        Do Until counter = UBound(readarray)
            For outer = 0 To loadBoardSize
                For inner = 0 To loadBoardSize
                    BoardData(outer, inner) = Convert.ToInt32(readarray(counter))
                    counter = counter + 1
                Next
            Next
        Loop
        writeFile = My.Computer.FileSystem.OpenTextFileWriter(filename, False)
        writeFile.Write("")
        writeFile.Close()
        loadGame = True
        Hide()
        PlayScreen.Show()
    End Sub

End Class