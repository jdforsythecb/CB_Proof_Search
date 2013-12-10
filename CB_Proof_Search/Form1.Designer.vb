<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lstbxResults = New System.Windows.Forms.ListBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lstboxPathList = New System.Windows.Forms.ListBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(216, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(15, 410)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(46, 13)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "0 results"
        '
        'lstbxResults
        '
        Me.lstbxResults.FormattingEnabled = True
        Me.lstbxResults.Location = New System.Drawing.Point(15, 48)
        Me.lstbxResults.Name = "lstbxResults"
        Me.lstbxResults.Size = New System.Drawing.Size(186, 342)
        Me.lstbxResults.TabIndex = 6
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(15, 21)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(100, 20)
        Me.txtSearch.TabIndex = 5
        '
        'lstboxPathList
        '
        Me.lstboxPathList.FormattingEnabled = True
        Me.lstboxPathList.Location = New System.Drawing.Point(297, 37)
        Me.lstboxPathList.Name = "lstboxPathList"
        Me.lstboxPathList.Size = New System.Drawing.Size(274, 368)
        Me.lstboxPathList.TabIndex = 8
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(126, 400)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 9
        Me.btnPrint.Text = "Print Proof"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(216, 443)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lstboxPathList)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lstbxResults)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Form1"
        Me.Text = "CB Proof Search"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lstbxResults As System.Windows.Forms.ListBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lstboxPathList As System.Windows.Forms.ListBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button

End Class
