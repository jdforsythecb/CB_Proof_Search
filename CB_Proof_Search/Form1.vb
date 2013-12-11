Imports System.IO

Public Class Form1

    '' global constants for base paths
    Private Const CBPROOFPATH As String = "g:\_CBProofs\"
    Private Const MMPROOFPATH As String = "g:\Jalan\PROOFS\"
    Private Const MMPROOFPATHWILL As String = "g:\WSCAN\MM"

    '' global variable to hold the current fileinfo list - IO.FileInfo to preserve the name and path of files
    Dim fileList As New List(Of IO.FileInfo)
    Dim masterFileList As New List(Of IO.FileInfo)

    '' global variable to hold the full list of paths to search
    Dim pathList As New List(Of String)


    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown

        '' if this was the enter key
        If e.KeyCode = Keys.Return Then

            '' always clear the lists when the input changes
            lstbxResults.Items.Clear()
            lstboxPathList.Items.Clear()
            fileList.Clear()
            pathList.Clear()

            '' trim whitespace from the search box
            txtSearch.Text = txtSearch.Text.Trim

            '' if the box isn't empty or less than two characters, search
            If (txtSearch.Text <> "" And txtSearch.Text.Length > 1) Then

                Dim pathToSearch As String
                Dim search As String = txtSearch.Text

                '' get the search path and search string
                If (My.Settings.isCB = True) Then
                    pathToSearch = CBPROOFPATH
                Else
                    pathToSearch = MMPROOFPATH
                End If

                '' add the topLevelPath to the search
                pathList.Add(pathToSearch)

                '' recursively add all subfolders at the top level path
                getAllSubfolders(pathToSearch)

                '' get the list of files that match the search string
                getFileList(search)

                Dim fileCount As Integer = 0

                '' add the new results to the list
                For Each file In fileList
                    lstbxResults.Items.Add(file.Name)
                    masterFileList.Add(file)
                    '' for every file, increment the file count
                    fileCount += 1
                Next

                '' if this is MM, search for Will's proofs in the appropriate g:\WSCAN\MM#\#-#\####\ folder
                If (My.Settings.isMM = True) Then
                    Dim firstNum As String = search.Substring(0, 1)
                    Dim secondNum As String = search.Substring(1, 1)
                    pathToSearch = MMPROOFPATHWILL & firstNum & "\" & firstNum & "-" & secondNum & "\" & search & "\"
                    pathList.Clear()
                    fileList.Clear()
                    pathList.Add(pathToSearch)
                    getAllSubfolders(pathToSearch)
                    '' get all files in the wscan folders that have proof in the name (the method already does a *.pdf)
                    getFileList("proof")

                    '' add the new results to the list
                    For Each File In fileList
                        lstbxResults.Items.Add(File.Name)
                        masterFileList.Add(File)
                        fileCount += 1
                    Next

                End If

                '' update the status with the counts
                lblStatus.Text = fileCount & " files found"
            End If
        End If

        '' else wasn't enter, so don't do anything
    End Sub

    Private Sub lstbxResults_DoubleClick(sender As Object, e As EventArgs) Handles lstbxResults.DoubleClick

        '' debug - to show the proper path/file is being selected
        'MessageBox.Show(fileList(lstbxResults.SelectedIndex).FullName)

        '' open the selected file in its default program
        Dim openFile As New ProcessStartInfo()
        With openFile
            .FileName = masterFileList(lstbxResults.SelectedIndex).FullName
            .UseShellExecute = True
        End With
        Process.Start(openFile)

    End Sub

    Private Sub lstbxResults_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstbxResults.MouseDown
        '' determine if this is a right mouse click
        If e.Button = Windows.Forms.MouseButtons.Right Then
            '' did we actually right-click on an item in the box
            Dim selInd As Integer = lstbxResults.IndexFromPoint(e.X, e.Y)

            '' if the returned selected index from cursor coordinates is not -1, then we clicked on something
            If selInd <> -1 Then

                '' get the full path of the item selected
                Dim selectedPath As String = masterFileList(selInd).FullName

                '' open explorer and select the file clicked
                Call Shell("explorer.exe /select," & selectedPath, AppWinStyle.NormalFocus)

            End If
        End If
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '' Helper functions
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    Private Sub getAllSubfolders(ByVal topLevelPath As String)
        Dim subfolder As String

        Try
            '' iterate through folders recursively, adding all subfolders to the list
            '' this will recursively call itself, adding items to the global
            '' pathList List(Of String) each time
            For Each subfolder In Directory.GetDirectories(topLevelPath)
                pathList.Add(subfolder)

                '' now for each subfolder, run this again recursively
                getAllSubfolders(subfolder)

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub getFileList(ByVal search As String)

        '' loop through list of paths
        For Each path In pathList

            '' if path exists, get a list of files from search and add it to the global fileList List(Of IO.FileInfo)
            If (Directory.Exists(path)) Then
                Dim folderInfo As New IO.DirectoryInfo(path)

                '' because of weird results searching for, e.g. *89*.* (files came back without "89" in the name,
                '' maybe due to something with long filenames and 8.3 equivalents?), we now get *.* and filter
                '' the results here

                '' 11-29-13 added OrderBy to sort files alphabetically (per folder)
                For Each fileName As IO.FileInfo In folderInfo.GetFiles("*.pdf").OrderBy(Function(x) x.Name)
                    If fileName.Name.ToUpper.Contains(search.ToUpper) Then
                        fileList.Add(fileName)
                    End If
                Next

                '' debug
                lstboxPathList.Items.Add(path)

            Else
                '' debug
                lstboxPathList.Items.Add("e00 " + path)
                'MessageBox.Show("error path: " & path & " exists? " & Directory.Exists(path).ToString())

            End If

        Next

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        'MessageBox.Show("clicked")
        'SettingsForm.Show()
        Dim stngFrm As New Settings()
        stngFrm.Show()

    End Sub


    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        '' get which proof is selected
        Dim file As String = fileList(lstbxResults.SelectedIndex).FullName
        Try
            Dim myprocess As New Process
            myprocess.StartInfo.CreateNoWindow = False
            myprocess.StartInfo.Verb = "print"
            myprocess.StartInfo.FileName = file
            myprocess.Start()
            myprocess.WaitForExit(10000)
            Try
                myprocess.CloseMainWindow()
                myprocess.Close()
            Catch ex As Exception

            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
