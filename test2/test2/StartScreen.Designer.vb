<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StartScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblGenius = New System.Windows.Forms.Label()
        Me.btnInstructions = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnHighScore = New System.Windows.Forms.Button()
        Me.btnNewGame = New System.Windows.Forms.Button()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblGenius
        '
        Me.lblGenius.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGenius.AutoSize = True
        Me.lblGenius.Font = New System.Drawing.Font("Courier New", 100.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGenius.ForeColor = System.Drawing.Color.Orange
        Me.lblGenius.Location = New System.Drawing.Point(336, 236)
        Me.lblGenius.Name = "lblGenius"
        Me.lblGenius.Size = New System.Drawing.Size(544, 151)
        Me.lblGenius.TabIndex = 0
        Me.lblGenius.Text = "GENIUS"
        '
        'btnInstructions
        '
        Me.btnInstructions.BackColor = System.Drawing.Color.LightCoral
        Me.btnInstructions.Font = New System.Drawing.Font("Consolas", 27.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInstructions.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnInstructions.Location = New System.Drawing.Point(72, 464)
        Me.btnInstructions.Name = "btnInstructions"
        Me.btnInstructions.Size = New System.Drawing.Size(273, 74)
        Me.btnInstructions.TabIndex = 1
        Me.btnInstructions.Text = "INSTRUCTIONS"
        Me.btnInstructions.UseVisualStyleBackColor = False
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnLoad.Font = New System.Drawing.Font("Consolas", 27.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnLoad.Location = New System.Drawing.Point(867, 464)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(243, 74)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Text = "LOAD GAME"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'btnHighScore
        '
        Me.btnHighScore.BackColor = System.Drawing.Color.LimeGreen
        Me.btnHighScore.Font = New System.Drawing.Font("Consolas", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHighScore.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnHighScore.Location = New System.Drawing.Point(513, 638)
        Me.btnHighScore.Name = "btnHighScore"
        Me.btnHighScore.Size = New System.Drawing.Size(213, 39)
        Me.btnHighScore.TabIndex = 3
        Me.btnHighScore.Text = "HIGH SCORE TABLE"
        Me.btnHighScore.UseVisualStyleBackColor = False
        '
        'btnNewGame
        '
        Me.btnNewGame.BackColor = System.Drawing.Color.Gold
        Me.btnNewGame.Font = New System.Drawing.Font("Consolas", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewGame.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnNewGame.Location = New System.Drawing.Point(513, 450)
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.Size = New System.Drawing.Size(213, 99)
        Me.btnNewGame.TabIndex = 4
        Me.btnNewGame.Text = "NEW GAME"
        Me.btnNewGame.UseVisualStyleBackColor = False
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.Wheat
        Me.btnQuit.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.cross
        Me.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnQuit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnQuit.Location = New System.Drawing.Point(12, 12)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(79, 77)
        Me.btnQuit.TabIndex = 5
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'StartScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(1122, 718)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnNewGame)
        Me.Controls.Add(Me.btnHighScore)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnInstructions)
        Me.Controls.Add(Me.lblGenius)
        Me.Name = "StartScreen"
        Me.Text = "StartScreen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblGenius As Label
    Friend WithEvents btnInstructions As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnHighScore As Button
    Friend WithEvents btnNewGame As Button
    Friend WithEvents btnQuit As Button
End Class
