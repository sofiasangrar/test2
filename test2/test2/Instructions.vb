Public Class Instructions
    Private Sub Instructions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

    End Sub

    Public Sub Back_Click(sender As Object, e As EventArgs)
        Close()
    End Sub
End Class