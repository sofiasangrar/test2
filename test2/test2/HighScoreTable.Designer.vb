<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HighScoreTable
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.UserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Score = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnQuit = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Orange
        Me.DataGridView1.CausesValidation = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.ColumnHeadersHeight = 70
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserName, Me.Score})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Consolas", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(462, 57)
        Me.DataGridView1.MaximumSize = New System.Drawing.Size(400, 570)
        Me.DataGridView1.MinimumSize = New System.Drawing.Size(400, 570)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 30
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.RowTemplate.Height = 50
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridView1.Size = New System.Drawing.Size(400, 570)
        Me.DataGridView1.TabIndex = 0
        '
        'UserName
        '
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        Me.UserName.DefaultCellStyle = DataGridViewCellStyle8
        Me.UserName.HeaderText = "Name"
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        Me.UserName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UserName.Width = 200
        '
        'Score
        '
        Me.Score.HeaderText = "Score"
        Me.Score.Name = "Score"
        Me.Score.ReadOnly = True
        Me.Score.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Score.Width = 200
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
        'HighScoreTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.background
        Me.ClientSize = New System.Drawing.Size(1059, 639)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "HighScoreTable"
        Me.Text = "HighScoreTable"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents UserName As DataGridViewTextBoxColumn
    Friend WithEvents Score As DataGridViewTextBoxColumn
    Friend WithEvents btnQuit As Button
End Class
