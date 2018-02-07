Public Class ScoreTable
    Inherits Panel

    Public Structure Score
        Public colourBox As PictureBox
        Public scoreBox As TextBox
    End Structure

    Public scoreDisplay(3) As Score

    Public Sub New(form As Control, loc As Point, player() As PlayScreen.Scores)
        Location = loc
        Size = New Size(100, 50)

        For counter = 0 To 3
            scoreDisplay(counter).colourBox = New PictureBox
            scoreDisplay(counter).colourBox.Left = counter * 25
            scoreDisplay(counter).colourBox.Size = New Size(25, 25)
            scoreDisplay(counter).colourBox.BackColor = PlayScreen.colourList(counter)
            scoreDisplay(counter).colourBox.BorderStyle = BorderStyle.FixedSingle
            Controls.Add(scoreDisplay(counter).colourBox)

            scoreDisplay(counter).scoreBox = New TextBox
            scoreDisplay(counter).scoreBox.Location = New Point(counter * 25, 25)
            scoreDisplay(counter).scoreBox.Size = New Size(25, 25)
            scoreDisplay(counter).scoreBox.BackColor = Color.White
            scoreDisplay(counter).scoreBox.BorderStyle = BorderStyle.FixedSingle
            scoreDisplay(counter).scoreBox.Text = player(counter).score
            scoreDisplay(counter).scoreBox.ReadOnly = True
            Controls.Add(scoreDisplay(counter).scoreBox)
        Next

        form.Controls.Add(Me)

    End Sub


End Class
