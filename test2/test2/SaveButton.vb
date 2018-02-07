Public Class SaveButton
    Inherits Button

    Public Sub New(ByVal form As Form)
        Location = New Point(150, 50)
        Size = New Size(100, 30)
        BackColor = Color.Orange
        Text = "SAVE GAME"
        Font = New Font("Consolas", 12, FontStyle.Bold)
        form.Controls.Add(Me)
        AddHandler Click, AddressOf SaveButton_Click
    End Sub

    Private Sub SaveButton_Click()
        Dim file As IO.StreamWriter
        Dim filename As String = "C:\Users\12h169\source\repos\test2\savefile.txt"
        file = My.Computer.FileSystem.OpenTextFileWriter(filename, False)
        file.WriteLine(BoardSize.boardDimensions.ToString)
        For outer = 0 To BoardSize.boardDimensions
            For inner = 0 To BoardSize.boardDimensions
                file.WriteLine(Array.IndexOf(PlayScreen.colourList, PlayScreen.playgrid.cells(outer, inner).cellProperty).ToString)
            Next
        Next
        file.Close()
    End Sub

End Class
