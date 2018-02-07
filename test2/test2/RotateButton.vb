Public Class RotateButton
    Inherits Button

    Public Sub New(form As Form, loc As Point)
        Location = loc 'each button's location is set to the location passed in
        Size = New Size(22, 22) 'its size is always 22 by 22 pixels
        BackgroundImage = My.Resources.rotate 'the background image of the button is set to an clockwise arrow, which is a picture in the program's resources
        BackColor = PlayScreen.BackColor
        FlatAppearance.BorderSize = 0
        BackgroundImageLayout = ImageLayout.Stretch 'the image must fit to the button
        form.Controls.Add(Me) 'the new button is added to the form
        AddHandler Click, AddressOf btnRotate_Click 'the button now does something when it is clicked
    End Sub


    Private Sub btnRotate_Click(sender As Object, e As EventArgs)
        Dim MyTileLoc As Point = New Point(Location.X - Int(PlayScreen.cellSize / 4), Location.Y - (PlayScreen.cellSize * 2 + 20)) 'the location of the tile that the rotate button controls is specified
        For Each tile In PlayScreen.playerTiles 'checks each tile in the user's posession
            If tile.Location = MyTileLoc Then
                tile.Rotate() 'If it finds a tile whose location matches that Of the tile it should control Then this tile Is rotated clockwise by 90 degrees
                Return 'the sub is exited once the appropriate tile is found 
            End If
        Next
    End Sub

End Class
