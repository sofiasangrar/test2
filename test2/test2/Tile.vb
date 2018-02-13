Public Class Tile
    Inherits Panel
    Public IsDragging As Boolean = False 'the variable used to detect whether the tile is currently being dragged or not
    Public StartPoint As Point 'its location as used in dragging events
    Public FirstPoint As Point 'its location used in dragging events
    Public LastPoint As Point 'the end location in a dragging event
    Public pictureBox1 As PictureBox 'one half of the tile
    Public pictureBox2 As PictureBox 'the other half of the tile
    Public launchPosition As Point 'where the tile originally started
    Public orientation As Integer = 1 'the orientation of the tile, which always starts at 1 (odd numbers are vertical)
    Public leftBox As PictureBox 'if the tile is horizontal, then the left box is referenced with this
    Public rightBox As PictureBox 'if the tile is horizontal, then the right box is referenced with this
    Public topBox As PictureBox 'if the tile is vertical, then the top box is referenced with this
    Public bottomBox As PictureBox 'if the tile is vertical, then the bottom box is referenced with this


    Public Sub New(form As Control, loc As Point, cellSize As Integer)
        PlayScreen.tiles.Add(Me) 'when a new instance of a tile is created, it is automatically added to the list of tiles 
        pictureBox1 = New PictureBox
        pictureBox2 = New PictureBox
        pictureBox1.Size = New Size(cellSize, cellSize) 'the size of each half of the tile is 50 x 50
        pictureBox1.BackColor = RandomColour(PlayScreen.colourList) 'half of the tile is set to a random colour
        pictureBox1.BorderStyle = BorderStyle.FixedSingle
        Controls.Add(pictureBox1) 'this adds the picture box to the tile
        pictureBox2.Size = New Size(cellSize, cellSize)
        pictureBox2.BackColor = RandomColour(PlayScreen.colourList)
        pictureBox2.BorderStyle = BorderStyle.FixedSingle
        Controls.Add(pictureBox2)
        launchPosition = loc 'the original launch position is saved 

        orientate() 'the tiles are set to face the correct direction
        BringToFront() 'the tiles are brought to the front

        'eaxh half of the tile is linked to subroutines that occur when the mouse is down, the mouse moves, and the mouse is up on either of the pictureboxes
        AddHandler pictureBox1.MouseDown, AddressOf tile_MouseDown
        AddHandler pictureBox1.MouseMove, AddressOf tile_MouseMove
        AddHandler pictureBox1.MouseUp, AddressOf tile_MouseUp
        AddHandler pictureBox2.MouseDown, AddressOf tile_MouseDown
        AddHandler pictureBox2.MouseMove, AddressOf tile_MouseMove
        AddHandler pictureBox2.MouseUp, AddressOf tile_MouseUp

        Location = loc 'the tile's location is set to the one passed in
        form.Controls.Add(Me) 'it is added to the form
    End Sub

    Private Sub Tile_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If PlayScreen.userTurn = False Then
            Exit Sub
        End If
        StartPoint = PointToScreen(New Point(e.X, e.Y)) 'the start point of the drag is set to the absolute screen location of the mouse when it is down
            FirstPoint = StartPoint 'the first point is the start point
            IsDragging = True 'a drag is commencing
            BringToFront() 'a tile being dragged must always be at the front
    End Sub

    Private Sub tile_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If PlayScreen.userTurn = False Then
            Exit Sub
        End If
        If IsDragging Then 'checks if a drag is taking place
            Dim EndPoint As Point = PointToScreen(New Point(e.X, e.Y)) 'the end point is the location of the mouse as it moves
            Left += (EndPoint.X - StartPoint.X) 'the x-coordinate of the tile is increased by the difference between the startpoint and the current mouse position
            Top += (EndPoint.Y - StartPoint.Y) 'the y-coordinate of the tile is increased by the difference between the startpoint and the current mouse position
            StartPoint = EndPoint
            LastPoint = EndPoint
        End If
    End Sub

    Private Sub tile_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        If PlayScreen.userTurn = False Then
            Exit Sub
        End If
        Dim outer1 As Integer
        Dim inner1 As Integer
        Dim outer2 As Integer
        Dim inner2 As Integer

        IsDragging = False 'when the mouse is up the tile is no longer being dragged

        If Bounds.IntersectsWith(PlayScreen.playgrid.Bounds) Then 'checks if the tile is touching any point of the playgrid
            SnapToGrid(PlayScreen.cellSize)
            Dim firstloc As New Point(PointToScreen(Location)) 'the absolute location on the screen of the tile
            firstloc.X = firstloc.X - PlayScreen.playgrid.Location.X 'the location needs adjusted as the grid is in a different place
            firstloc.Y = firstloc.Y - PlayScreen.playgrid.Location.Y
            Dim secondLoc As Point
            If orientation Mod 2 = 0 Then 'if the tile is horizontal
                secondLoc = New Point(firstloc.X + PlayScreen.cellSize * 2, firstloc.Y)
                PlayScreen.playgrid.FindLocation(firstloc, secondLoc, outer1, inner1, outer2, inner2)
                If PlayScreen.playgrid.cells(outer1, inner1).cellProperty = Color.LightGray And PlayScreen.playgrid.cells(outer2, inner2).cellProperty = Color.LightGray Then
                    PlayScreen.playgrid.SetColour(leftBox.BackColor, rightBox.BackColor, outer1, inner1, outer2, inner2)
                Else
                    MoveToOriginal(launchPosition)
                End If
            Else
                secondLoc = New Point(firstloc.X, firstloc.Y + PlayScreen.cellSize * 2)
                PlayScreen.playgrid.FindLocation(firstloc, secondLoc, outer1, inner1, outer2, inner2)
                If PlayScreen.playgrid.cells(outer1, inner1).cellProperty = Color.LightGray And PlayScreen.playgrid.cells(outer2, inner2).cellProperty = Color.LightGray Then
                    PlayScreen.playgrid.SetColour(topBox.BackColor, bottomBox.BackColor, outer1, inner1, outer2, inner2)
                Else
                    MoveToOriginal(launchPosition)
                End If
            End If

            For Each tile In PlayScreen.tiles
                If Bounds.IntersectsWith(tile.bounds) AndAlso tile IsNot Me Then
                    MoveToOriginal(launchPosition)
                    Return
                End If
            Next

            If Left < PlayScreen.playgrid.Left Or Right > PlayScreen.playgrid.Right Or Top < PlayScreen.playgrid.Top Or Bottom > PlayScreen.playgrid.Bottom Then
                MoveToOriginal(launchPosition)
                Return
            End If

            Dim replaceIndex As Integer = Array.IndexOf(PlayScreen.playerTiles, sender.parent)
            PlayScreen.playerTiles(replaceIndex) = New Tile(PlayScreen, launchPosition, PlayScreen.cellSize)
        Else
            MoveToOriginal(launchPosition)
            Return
        End If
        RemoveHandler pictureBox1.MouseDown, AddressOf tile_MouseDown
        RemoveHandler pictureBox2.MouseDown, AddressOf tile_MouseDown
        RemoveHandler pictureBox1.MouseMove, AddressOf tile_MouseMove
        RemoveHandler pictureBox1.MouseUp, AddressOf tile_MouseUp
        RemoveHandler pictureBox2.MouseMove, AddressOf tile_MouseMove
        RemoveHandler pictureBox2.MouseUp, AddressOf tile_MouseUp
        PlayScreen.playgrid.CalculateScore(outer1, inner1, outer2, inner2)
        If PlayScreen.playgrid.CheckForMoves() = False Then
            MsgBox("GameOver")
            PlayScreen.FindWinner()
        Else
            PlayScreen.userTurn = False
            PlayScreen.computer.opponentTurn(0)
        End If
    End Sub

    Public Sub Rotate()
        If PlayScreen.userTurn = False Then
            Exit Sub
        End If
        orientation = orientation + 1
        If orientation = 4 Then
            orientation = 0
        End If
        orientate()
    End Sub

    Public Sub orientate()
        Select Case orientation
            Case 0
                Size = New Size(PlayScreen.cellSize * 2, PlayScreen.cellSize)
                pictureBox1.Location = New Point(0, 0)
                pictureBox2.Location = New Point(PlayScreen.cellSize, 0)
                leftBox = pictureBox1
                rightBox = pictureBox2
            Case 1
                Size = New Size(PlayScreen.cellSize, PlayScreen.cellSize * 2)
                pictureBox1.Location = New Point(0, 0)
                pictureBox2.Location = New Point(0, PlayScreen.cellSize)
                topBox = pictureBox1
                bottomBox = pictureBox2
            Case 2
                Size = New Size(PlayScreen.cellSize * 2, PlayScreen.cellSize)
                pictureBox1.Location = New Point(PlayScreen.cellSize, 0)
                pictureBox2.Location = New Point(0, 0)
                leftBox = pictureBox2
                rightBox = pictureBox1
            Case 3
                Size = New Size(PlayScreen.cellSize, PlayScreen.cellSize * 2)
                pictureBox1.Location = New Point(0, PlayScreen.cellSize)
                pictureBox2.Location = New Point(0, 0)
                topBox = pictureBox2
                bottomBox = pictureBox1
        End Select
    End Sub
End Class