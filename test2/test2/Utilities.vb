Imports System.Runtime.CompilerServices

Public Module Utilities

    <Extension()>
    Public Sub SnapToGrid(tile As Control, Optional spacing As Integer = 50)
        tile.Left = CInt((tile.Left - PlayScreen.playgrid.Location.X) / spacing) * spacing + PlayScreen.playgrid.Location.X 'the tile's top left corner's X-coordinate is moved to the nearest spacing on the grid
        tile.Top = CInt((tile.Top - PlayScreen.playgrid.Location.Y) / spacing) * spacing + PlayScreen.playgrid.Location.Y 'the tile's top left corner's Y-coordinate is moved to the nearest spacing on the grid
    End Sub

    <Extension()>
    Public Sub MoveToOriginal(tile As Control, firstpoint As Point)
        Dim dx As Single = (tile.Location.X - firstpoint.X) / 100 'this is a hundredth of the distance between the tile's original x-position and its final x-position
        Dim dy As Single = (tile.Location.Y - firstpoint.Y) / 100 'this is a hundredth of the distance between the tile's original y-position and its final y-position

        For i = 100 To 0 Step -1
            tile.Location = New Point((i * dx + firstpoint.X), (i * dy + firstpoint.Y)) 'the tile's location is moved, 1/100th at a time, back to its original position
            Threading.Thread.Sleep(0.7) 'there is a pause between each movement so that it seems as though it is flowing
        Next

        tile.Location = firstpoint 'finally the tile's location is set to its original location
    End Sub

End Module
