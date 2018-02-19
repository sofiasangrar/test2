Public Class Save
    Inherits Button

    Public Sub New()
        Location = New Point(100, 12)
        Size = New Size(200, 70)
        BackColor = Color.Orange
        Text = "SAVE AND QUIT"
        Font = New Font("Consolas", 17, FontStyle.Bold)
        PlayScreen.Controls.Add(Me)
        AddHandler Click, AddressOf SaveButton_Click
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As MouseEventArgs)
        Dim response As MsgBoxResult = MsgBox("Are you sure you want to save and quit?", MsgBoxStyle.YesNo, "Alert")
        If response = MsgBoxResult.Yes Then
            Dim file As IO.StreamWriter
            Dim filename As String = "C:\Users\12h169\source\repos\test2\savefile.txt"
            file = My.Computer.FileSystem.OpenTextFileWriter(filename, False)
            file.WriteLine(PlayScreen.dimensions.ToString)
            file.WriteLine(PlayScreen.cellSize.ToString)
            For counter = 0 To 3
                file.WriteLine(PlayScreen.playerScore(counter).score.ToString)
            Next
            For counter = 0 To 3
                file.WriteLine(PlayScreen.opponentScore(counter).score.ToString)
            Next
            For outer = 0 To PlayScreen.dimensions
                For inner = 0 To PlayScreen.dimensions
                    file.WriteLine(Array.IndexOf(PlayScreen.colourList, PlayScreen.playgrid.cells(outer, inner).cellProperty).ToString)
                Next
            Next
            file.Close()
            PlayScreen.Close()
        End If
    End Sub

End Class
