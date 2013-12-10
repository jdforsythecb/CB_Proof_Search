Public Class Settings

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        'MessageBox.Show("CB: " + rdioCB.Checked.ToString() + " MM: " + rdioMM.Checked.ToString() + " addtl: " + txtExtraPaths.Text)
        My.Settings.isCB = rdioCB.Checked
        My.Settings.isMM = rdioMM.Checked

        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Reload()

        '' restore saved settings
        rdioCB.Checked = My.Settings.isCB
        rdioMM.Checked = My.Settings.isMM

    End Sub

    Private Sub btnCancelSettings_Click(sender As Object, e As EventArgs) Handles btnCancelSettings.Click
        Me.Close()
    End Sub
End Class