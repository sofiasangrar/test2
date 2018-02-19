Public Class SwapButton
    Inherits Button

    Public Sub New()
        Location = New Point(PlayScreen.playerTiles(5).Right + PlayScreen.cellSize * 1.5, PlayScreen.Bottom - 185)
        Size = New Size(40, 40) 'its size is set
        BackgroundImageLayout = ImageLayout.Stretch
        BackgroundImage = My.Resources.swap
        BringToFront()
        PlayScreen.Controls.Add(Me)
        AddHandler Click, AddressOf BtnSwap_Click
    End Sub

    Private Sub BtnSwap_Click(sender As Object, e As MouseEventArgs)
        If PlayScreen.userTurn = False Then
            Exit Sub
        End If
        For Each tile In PlayScreen.playerTiles 'for each tile in the player's possession
            tile.orientation = 1 'its orientation is set to 1 - i.e. vertical
            tile.orientate()
            tile.pictureBox1.BackColor = RandomColour(PlayScreen.colourList) 'the background colour of each half of the tile is set to a new random colour
            tile.pictureBox2.BackColor = RandomColour(PlayScreen.colourList)
        Next
        PlayScreen.userTurn = False
        PlayScreen.computer.opponentTurn(0)
    End Sub

End Class
