Imports System.Xml

Public Class frmMain

    Private Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr
    Private Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpdwProcessID As Integer) As Integer
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hWnd As IntPtr, ByVal WinTitle As String, ByVal MaxLength As Integer) As Integer
    Private Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (ByVal hwnd As Integer) As Integer

    Private LastTophWnd As Integer = 0
    Private LastWindowTitle As String = ""

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim hWnd As IntPtr = GetForegroundWindow()
        If hWnd = IntPtr.Zero Then Exit Sub

        Dim TitleLength As Integer
        TitleLength = GetWindowTextLength(hWnd.ToInt32)

        Dim WindowTitle As String = StrDup(TitleLength + 1, " "c)
        GetWindowText(hWnd, WindowTitle, TitleLength + 1)
        WindowTitle = WindowTitle.Substring(0, TitleLength)

        If (LastTophWnd = hWnd.ToInt32) AndAlso (LastWindowTitle = WindowTitle) Then
            Exit Sub
        Else
            LastTophWnd = hWnd.ToInt32
            LastWindowTitle = WindowTitle
        End If

        Dim PID As Integer = 0
        GetWindowThreadProcessId(hWnd, PID)
        If PID = 0 Then Exit Sub

        Dim ProcessInfo As Process = Process.GetProcessById(PID)
        If ProcessInfo Is Nothing Then Exit Sub

        Dim LI As New ListViewItem
        LI.Text = PID.ToString
        LI.SubItems.Add(WindowTitle & " - " & ProcessInfo.MainWindowTitle)
        LI.SubItems.Add(ProcessInfo.ProcessName)
        LI.SubItems.Add(ProcessInfo.StartInfo.FileName & " " & ProcessInfo.StartInfo.Arguments)
        lsvWindows.EnsureVisible(lsvWindows.Items.Add(LI).Index)
    End Sub

    Private Sub tsbClearList_Click(sender As Object, e As EventArgs) Handles tsbClearList.Click
        Timer1.Enabled = False
        LastTophWnd = 0
        LastWindowTitle = ""
        lsvWindows.Items.Clear()
        Timer1.Enabled = tsbMonitoring.Checked
    End Sub

    Private Sub tsbExportList_Click(sender As Object, e As EventArgs) Handles tsbExportList.Click
        Using SFD As New SaveFileDialog
            With SFD
                .AddExtension = True
                .AutoUpgradeEnabled = True
                .CheckFileExists = False
                .CheckPathExists = True
                .CreatePrompt = False
                .DefaultExt = "txt"
                .DereferenceLinks = True
                .Filter = "Text Files|*.txt|CSV Files|*.csv|XML Files|*.xml|All Files|*.*"
                .OverwritePrompt = True
                .ShowHelp = False
                .SupportMultiDottedExtensions = True
                .Title = "Export List"
                .ValidateNames = True
            End With
            If SFD.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ExportItems(SFD.FileName, SFD.FilterIndex)
            End If
        End Using



    End Sub

    Private Sub ExportItems(ByVal Filename As String, ByVal FileType As Integer)
        Dim OutFile As System.IO.StreamWriter
        Dim OutLine As New System.Text.StringBuilder
        Try
            OutFile = My.Computer.FileSystem.OpenTextFileWriter(Filename, False)
        Catch ex As Exception
            MsgBox("Error opening '" & Filename & "'" & ControlChars.CrLf & ex.Message, MsgBoxStyle.Exclamation, "Error Opening File")
            Exit Sub
        End Try

        Timer1.Enabled = False
        Select Case FileType
            'Case 1 ' This is handled in "Case Else" because we default to text
            Case 2 'CSV File
                Try
                    OutFile.WriteLine("PID, ""Title"", ""Process Name"", ""Command Line""")
                    For Each LI As ListViewItem In lsvWindows.Items
                        OutFile.WriteLine("{0}, ""{1}"", ""{2}"", ""{3}""", LI.SubItems(0).Text, LI.SubItems(1).Text, LI.SubItems(2).Text, LI.SubItems(3).Text)
                    Next
                Catch ex As Exception
                    MsgBox("Error writing to file: " & ex.Message, MsgBoxStyle.Exclamation, "Error Writing to File")
                Finally
                    OutFile.Close()
                End Try
            Case 3 'XML File
                Try
                    Dim MyWriter As Xml.XmlWriter = Xml.XmlWriter.Create(OutFile)
                    MyWriter.WriteStartDocument(True)
                    MyWriter.WriteStartElement("processes")

                    For Each LI As ListViewItem In lsvWindows.Items
                        MyWriter.WriteStartElement("process")
                        MyWriter.WriteElementString("pid", LI.SubItems(0).Text)
                        MyWriter.WriteElementString("title", LI.SubItems(1).Text)
                        MyWriter.WriteElementString("name", LI.SubItems(2).Text)
                        MyWriter.WriteElementString("commandline", LI.SubItems(3).Text)
                        MyWriter.WriteEndElement()
                    Next

                    MyWriter.WriteEndElement()
                    MyWriter.WriteEndDocument()
                    MyWriter.Close()
                Catch ex As Exception
                    MsgBox("Error writing to file: " & ex.Message, MsgBoxStyle.Exclamation, "Error Writing to File")
                Finally
                    OutFile.Close()
                End Try

            Case Else 'Unknown type, default to text
                Try
                    OutFile.WriteLine("PID  Title   Process Name    Command Line")
                    For Each LI As ListViewItem In lsvWindows.Items
                        OutFile.WriteLine("{0}  {1} {2} {3}", LI.SubItems(0).Text, LI.SubItems(1).Text, LI.SubItems(2).Text, LI.SubItems(3).Text)
                    Next
                Catch ex As Exception
                    MsgBox("Error writing to file: " & ex.Message, MsgBoxStyle.Exclamation, "Error Writing to File")
                Finally
                    OutFile.Close()
                End Try
        End Select
        Timer1.Enabled = tsbMonitoring.Checked
    End Sub

    Private Sub tsbMonitoring_CheckedChanged(sender As Object, e As EventArgs) Handles tsbMonitoring.CheckedChanged
        Timer1.Enabled = tsbMonitoring.Checked
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Console.WriteLine(System.Runtime.InteropServices.Marshal.GetTypeLibGuidForAssembly(System.Reflection.Assembly.GetExecutingAssembly).ToString)
        Console.WriteLine(CType(Me.GetType.Assembly.GetCustomAttributes(GetType(System.Runtime.InteropServices.GuidAttribute), False)(0), System.Runtime.InteropServices.GuidAttribute).Value.ToString)

    End Sub
End Class
