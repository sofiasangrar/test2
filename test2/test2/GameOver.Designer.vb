<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameOver
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblGameOver = New System.Windows.Forms.Label()
        Me.lblWinOrLose = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblGameOver
        '
        Me.lblGameOver.AutoSize = True
        Me.lblGameOver.BackColor = System.Drawing.Color.Transparent
        Me.lblGameOver.Font = New System.Drawing.Font("Consolas", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameOver.ForeColor = System.Drawing.Color.Red
        Me.lblGameOver.Location = New System.Drawing.Point(66, 66)
        Me.lblGameOver.Name = "lblGameOver"
        Me.lblGameOver.Size = New System.Drawing.Size(284, 56)
        Me.lblGameOver.TabIndex = 0
        Me.lblGameOver.Text = "GAME OVER!"
        '
        'lblWinOrLose
        '
        Me.lblWinOrLose.AutoSize = True
        Me.lblWinOrLose.BackColor = System.Drawing.Color.Transparent
        Me.lblWinOrLose.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWinOrLose.Location = New System.Drawing.Point(138, 156)
        Me.lblWinOrLose.Name = "lblWinOrLose"
        Me.lblWinOrLose.Size = New System.Drawing.Size(0, 34)
        Me.lblWinOrLose.TabIndex = 1
        Me.lblWinOrLose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GameOver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.background
        Me.ClientSize = New System.Drawing.Size(410, 237)
        Me.Controls.Add(Me.lblWinOrLose)
        Me.Controls.Add(Me.lblGameOver)
        Me.Name = "GameOver"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GameOver"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblGameOver As Label
    Friend WithEvents lblWinOrLose As Label
End Class
