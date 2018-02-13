Public Class ComputerTile
    Inherits Panel
    Public pictureBox1 As PictureBox 'one half of the tile
    Public pictureBox2 As PictureBox 'the other half of the tile
    Public orientation As Integer = 1 'the orientation of the tile, which always starts at 1 (odd numbers are vertical)
    Public leftBox As PictureBox 'if the tile is horizontal, then the left box is referenced with this
    Public rightBox As PictureBox 'if the tile is horizontal, then the right box is referenced with this
    Public topBox As PictureBox 'if the tile is vertical, then the top box is referenced with this
    Public bottomBox As PictureBox 'if the tile is vertical, then the bottom box is referenced with this


    Public Sub New()
        pictureBox1 = New PictureBox
        pictureBox2 = New PictureBox
        pictureBox1.BackColor = RandomColour(PlayScreen.colourList) 'half of the tile is set to a random colour
        Controls.Add(pictureBox1) 'this adds the picture box to the tile
        pictureBox2.BackColor = RandomColour(PlayScreen.colourList)
        Controls.Add(pictureBox2)
        orientate() 'the tiles are set to face the correct direction
    End Sub

    Public Sub Rotate()
        orientation = orientation + 1
        If orientation = 4 Then
            orientation = 0
        End If
        orientate()
    End Sub

    Public Sub orientate()
        Select Case orientation
            Case 0
                leftBox = pictureBox1
                rightBox = pictureBox2
            Case 1
                topBox = pictureBox1
                bottomBox = pictureBox2
            Case 2
                leftBox = pictureBox2
                rightBox = pictureBox1
            Case 3
                topBox = pictureBox2
                bottomBox = pictureBox1
        End Select
    End Sub
End Class
