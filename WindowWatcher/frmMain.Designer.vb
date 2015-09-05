<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lsvWindows = New System.Windows.Forms.ListView()
        Me.chPID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chProcessName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCommandLine = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbMonitoring = New System.Windows.Forms.ToolStripButton()
        Me.tsbExportList = New System.Windows.Forms.ToolStripButton()
        Me.tsbClearList = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'lsvWindows
        '
        Me.lsvWindows.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chPID, Me.chTitle, Me.chProcessName, Me.chCommandLine})
        Me.lsvWindows.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvWindows.Location = New System.Drawing.Point(0, 25)
        Me.lsvWindows.MultiSelect = False
        Me.lsvWindows.Name = "lsvWindows"
        Me.lsvWindows.Size = New System.Drawing.Size(508, 237)
        Me.lsvWindows.TabIndex = 0
        Me.lsvWindows.UseCompatibleStateImageBehavior = False
        Me.lsvWindows.View = System.Windows.Forms.View.Details
        '
        'chPID
        '
        Me.chPID.Text = "PID"
        '
        'chTitle
        '
        Me.chTitle.Text = "Title"
        '
        'chProcessName
        '
        Me.chProcessName.Text = "ProcessName"
        '
        'chCommandLine
        '
        Me.chCommandLine.Text = "Command Line"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbMonitoring, Me.tsbExportList, Me.tsbClearList})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(508, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbMonitoring
        '
        Me.tsbMonitoring.Checked = True
        Me.tsbMonitoring.CheckOnClick = True
        Me.tsbMonitoring.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsbMonitoring.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbMonitoring.Image = CType(resources.GetObject("tsbMonitoring.Image"), System.Drawing.Image)
        Me.tsbMonitoring.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMonitoring.Name = "tsbMonitoring"
        Me.tsbMonitoring.Size = New System.Drawing.Size(71, 22)
        Me.tsbMonitoring.Text = "&Monitoring"
        '
        'tsbExportList
        '
        Me.tsbExportList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExportList.Image = CType(resources.GetObject("tsbExportList.Image"), System.Drawing.Image)
        Me.tsbExportList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportList.Name = "tsbExportList"
        Me.tsbExportList.Size = New System.Drawing.Size(65, 22)
        Me.tsbExportList.Text = "&Export List"
        Me.tsbExportList.ToolTipText = "Export the list to a text, CSV, or XML file"
        '
        'tsbClearList
        '
        Me.tsbClearList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbClearList.Image = CType(resources.GetObject("tsbClearList.Image"), System.Drawing.Image)
        Me.tsbClearList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClearList.Name = "tsbClearList"
        Me.tsbClearList.Size = New System.Drawing.Size(59, 22)
        Me.tsbClearList.Text = "&Clear List"
        Me.tsbClearList.ToolTipText = "Clears everything in the list"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 262)
        Me.Controls.Add(Me.lsvWindows)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmMain"
        Me.Text = "WindowWatcher"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lsvWindows As System.Windows.Forms.ListView
    Friend WithEvents chPID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chProcessName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCommandLine As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbExportList As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClearList As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbMonitoring As System.Windows.Forms.ToolStripButton

End Class
