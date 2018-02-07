<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BoardSize
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
        Me.lblChoose = New System.Windows.Forms.Label()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btn10 = New System.Windows.Forms.Button()
        Me.btn15 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblChoose
        '
        Me.lblChoose.AutoSize = True
        Me.lblChoose.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChoose.ForeColor = System.Drawing.Color.Orange
        Me.lblChoose.Location = New System.Drawing.Point(48, 59)
        Me.lblChoose.Name = "lblChoose"
        Me.lblChoose.Size = New System.Drawing.Size(263, 22)
        Me.lblChoose.TabIndex = 0
        Me.lblChoose.Text = "CHOOSE YOUR BOARD SIZE:"
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.Orange
        Me.btn7.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn7.Location = New System.Drawing.Point(35, 101)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(82, 39)
        Me.btn7.TabIndex = 1
        Me.btn7.Text = "7 X 7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'btn10
        '
        Me.btn10.BackColor = System.Drawing.Color.Orange
        Me.btn10.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn10.Location = New System.Drawing.Point(146, 101)
        Me.btn10.Name = "btn10"
        Me.btn10.Size = New System.Drawing.Size(82, 39)
        Me.btn10.TabIndex = 2
        Me.btn10.Text = "10 X 10"
        Me.btn10.UseVisualStyleBackColor = False
        '
        'btn15
        '
        Me.btn15.BackColor = System.Drawing.Color.Orange
        Me.btn15.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn15.Location = New System.Drawing.Point(255, 101)
        Me.btn15.Name = "btn15"
        Me.btn15.Size = New System.Drawing.Size(82, 39)
        Me.btn15.TabIndex = 3
        Me.btn15.Text = "15 X 15"
        Me.btn15.UseVisualStyleBackColor = False
        '
        'BoardSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(360, 170)
        Me.Controls.Add(Me.btn15)
        Me.Controls.Add(Me.btn10)
        Me.Controls.Add(Me.btn7)
        Me.Controls.Add(Me.lblChoose)
        Me.Name = "BoardSize"
        Me.Text = "BoardSize"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblChoose As Label
    Friend WithEvents btn7 As Button
    Friend WithEvents btn10 As Button
    Friend WithEvents btn15 As Button
End Class
