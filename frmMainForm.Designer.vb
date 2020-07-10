<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainForm
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
    Me.txtOutputString = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.cmdConvert = New System.Windows.Forms.Button()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.chkErrorOnEmpty = New System.Windows.Forms.CheckBox()
    Me.cboDecimalSeparator = New System.Windows.Forms.ComboBox()
    Me.txtInputString = New System.Windows.Forms.TextBox()
    Me.cmdConvert2 = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'txtOutputString
    '
    Me.txtOutputString.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtOutputString.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtOutputString.Location = New System.Drawing.Point(12, 366)
    Me.txtOutputString.Multiline = True
    Me.txtOutputString.Name = "txtOutputString"
    Me.txtOutputString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtOutputString.Size = New System.Drawing.Size(794, 343)
    Me.txtOutputString.TabIndex = 1
    Me.txtOutputString.WordWrap = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(15, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 15)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Input String:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(16, 349)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(46, 15)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Output:"
    '
    'cmdConvert
    '
    Me.cmdConvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdConvert.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmdConvert.Location = New System.Drawing.Point(642, 8)
    Me.cmdConvert.Name = "cmdConvert"
    Me.cmdConvert.Size = New System.Drawing.Size(75, 24)
    Me.cmdConvert.TabIndex = 4
    Me.cmdConvert.Text = "Convert"
    Me.cmdConvert.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(99, 12)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(113, 15)
    Me.Label3.TabIndex = 6
    Me.Label3.Text = "Decimal Separator:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(302, 12)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(164, 15)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "A=Auto; R=Regional Settings"
    '
    'chkErrorOnEmpty
    '
    Me.chkErrorOnEmpty.AutoSize = True
    Me.chkErrorOnEmpty.Checked = Global.WindowsApp1.My.MySettings.Default.ErrorOnEmpty
    Me.chkErrorOnEmpty.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.WindowsApp1.My.MySettings.Default, "ErrorOnEmpty", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.chkErrorOnEmpty.Location = New System.Drawing.Point(479, 14)
    Me.chkErrorOnEmpty.Name = "chkErrorOnEmpty"
    Me.chkErrorOnEmpty.Size = New System.Drawing.Size(149, 17)
    Me.chkErrorOnEmpty.TabIndex = 8
    Me.chkErrorOnEmpty.Text = "Error on empty input value"
    Me.chkErrorOnEmpty.UseVisualStyleBackColor = True
    '
    'cboDecimalSeparator
    '
    Me.cboDecimalSeparator.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WindowsApp1.My.MySettings.Default, "DecimalSeparator", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.cboDecimalSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboDecimalSeparator.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboDecimalSeparator.FormattingEnabled = True
    Me.cboDecimalSeparator.Items.AddRange(New Object() {"A", "R", ",", "."})
    Me.cboDecimalSeparator.Location = New System.Drawing.Point(216, 8)
    Me.cboDecimalSeparator.Name = "cboDecimalSeparator"
    Me.cboDecimalSeparator.Size = New System.Drawing.Size(78, 23)
    Me.cboDecimalSeparator.TabIndex = 5
    Me.cboDecimalSeparator.Text = Global.WindowsApp1.My.MySettings.Default.DecimalSeparator
    '
    'txtInputString
    '
    Me.txtInputString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtInputString.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.WindowsApp1.My.MySettings.Default, "InputString", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.txtInputString.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtInputString.Location = New System.Drawing.Point(12, 36)
    Me.txtInputString.Multiline = True
    Me.txtInputString.Name = "txtInputString"
    Me.txtInputString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtInputString.Size = New System.Drawing.Size(794, 301)
    Me.txtInputString.TabIndex = 0
    Me.txtInputString.Text = Global.WindowsApp1.My.MySettings.Default.InputString
    Me.txtInputString.WordWrap = False
    '
    'cmdConvert2
    '
    Me.cmdConvert2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdConvert2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmdConvert2.Location = New System.Drawing.Point(729, 8)
    Me.cmdConvert2.Name = "cmdConvert2"
    Me.cmdConvert2.Size = New System.Drawing.Size(75, 24)
    Me.cmdConvert2.TabIndex = 9
    Me.cmdConvert2.Text = "Convert 2"
    Me.cmdConvert2.UseVisualStyleBackColor = True
    '
    'frmMainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(820, 720)
    Me.Controls.Add(Me.cmdConvert2)
    Me.Controls.Add(Me.chkErrorOnEmpty)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.cboDecimalSeparator)
    Me.Controls.Add(Me.cmdConvert)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtOutputString)
    Me.Controls.Add(Me.txtInputString)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmMainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "String to Double Convertierung"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents txtInputString As TextBox
  Friend WithEvents txtOutputString As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents cmdConvert As Button
  Friend WithEvents cboDecimalSeparator As ComboBox
  Friend WithEvents Label3 As Label
  Friend WithEvents Label4 As Label
  Friend WithEvents chkErrorOnEmpty As CheckBox
  Friend WithEvents cmdConvert2 As Button
End Class
