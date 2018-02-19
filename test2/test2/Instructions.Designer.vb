<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Instructions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Instructions))
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.lblText = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.Transparent
        Me.btnQuit.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.cross
        Me.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnQuit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnQuit.Location = New System.Drawing.Point(12, 12)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(79, 77)
        Me.btnQuit.TabIndex = 7
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'lblText
        '
        Me.lblText.AutoSize = True
        Me.lblText.BackColor = System.Drawing.Color.Transparent
        Me.lblText.Font = New System.Drawing.Font("Consolas", 16.0!)
        Me.lblText.Location = New System.Drawing.Point(157, 130)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(864, 468)
        Me.lblText.TabIndex = 8
        Me.lblText.Text = resources.GetString("lblText.Text")
        '
        'Instructions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.background
        Me.ClientSize = New System.Drawing.Size(907, 581)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.btnQuit)
        Me.Name = "Instructions"
        Me.Text = "Instructions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnQuit As Button
    Friend WithEvents lblText As Label
End Class
