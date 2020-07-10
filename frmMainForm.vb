Imports System.Globalization

Public Class frmMainForm
  Private Sub frmMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


  End Sub

  Private Sub frmMainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    txtInputString.SelectionStart = 0
    txtInputString.SelectionLength = 0
  End Sub

  Private Sub cmdConvert_Click(sender As Object, e As EventArgs) Handles cmdConvert.Click
    Dim dblResult As Decimal
    Dim sResult As String
    Dim sDecimalSep As String = String.Empty, sLine As String

    If cboDecimalSeparator.SelectedIndex = 0 Then
      sDecimalSep = "A"
    ElseIf cboDecimalSeparator.SelectedIndex = 1 Then
      sDecimalSep = "R"
    ElseIf cboDecimalSeparator.SelectedIndex > 1 Then
      sDecimalSep = cboDecimalSeparator.Text
    End If

    txtOutputString.Text = String.Empty

    '*** Check Nothing working
    sLine = Nothing

    Try
      dblResult = ParseDouble(sLine, sDecimalSep, chkErrorOnEmpty.Checked)
      sResult = String.Format("{0:0.00000}", dblResult)
    Catch ex As Exception
      sResult = ex.Message
    End Try
    txtOutputString.Text += String.Format("{0,14} ==> {1,17}", "Nothing", sResult) + vbCrLf


    '*** Loop input values
    For Each sLine In txtInputString.Lines
      Try
        dblResult = ParseDouble(sLine, sDecimalSep, chkErrorOnEmpty.Checked)
        sResult = String.Format("{0:0.00000}", dblResult)
      Catch ex As Exception
        sResult = ex.Message
      End Try

      txtOutputString.Text += String.Format("{0,14} ==> {1,17}", sLine, sResult) + vbCrLf
    Next
  End Sub

  Private Sub cmdConvert2_Click(sender As Object, e As EventArgs) Handles cmdConvert2.Click
    Dim dblResult As Decimal
    Dim sResult As String = String.Empty
    Dim sDecimalSep As String = String.Empty, sLine As String

    If cboDecimalSeparator.SelectedIndex = 0 Then
      sDecimalSep = ""
    ElseIf cboDecimalSeparator.SelectedIndex = 1 Then
      sDecimalSep = ""
    ElseIf cboDecimalSeparator.SelectedIndex > 1 Then
      sDecimalSep = cboDecimalSeparator.Text
    End If

    txtOutputString.Text = String.Empty

    '*** Check Nothing working
    If IsNumeric(Nothing, sDecimalSep, dblResult, sResult, chkErrorOnEmpty.Checked) Then
      sResult = String.Format("{0:0.00000}", dblResult)
    End If
    txtOutputString.Text += String.Format("{0,14} ==> {1,17}", "Nothing", sResult) + vbCrLf


    '*** Loop input values
    For Each sLine In txtInputString.Lines

      If IsNumeric(sLine, sDecimalSep, dblResult, sResult, chkErrorOnEmpty.Checked) Then
        sResult = String.Format("{0:0.00000}", dblResult)
      End If

      txtOutputString.Text += String.Format("{0,14} ==> {1,17}", sLine, sResult) + vbCrLf
    Next
  End Sub



  ''' <summary>
  ''' Parse double value string into double variable
  ''' </summary>
  ''' <param name="oValue">Input Value</param>
  ''' <param name="sDecimalSeparator">Use given Decimal Separator
  '''                                 'A' or Empty ==> Automatic determination
  '''                                 'R'          ==> Use Regional Settings
  '''                                 ','          ==> Use komma as decimal separator
  '''                                 '.'          ==> Use dot as decimal separator</param>
  ''' <param name="bRaiseErrorOnEmpty">Raise error on empty value</param>
  ''' <returns>Double value</returns>
  ''' <remarks>Created KT 2020-07-09</remarks>
  Public Shared Function ParseDouble(ByVal oValue As Object, Optional sDecimalSeparator As String = "A", Optional bRaiseErrorOnEmpty As Boolean = False) As Double
    Dim dblResult As Double = Nothing
    Dim sDoubleAsString As String = oValue
    Dim oDoubleAsCharList As IEnumerable(Of Char)
    Dim oNfi As System.IFormatProvider
    Const ERROR_TEXT As String = "Error parsing '{0}'."

    '*** Check Nothing given
    If (oValue Is Nothing) Then
      If bRaiseErrorOnEmpty Then
        Throw New Exception(String.Format(ERROR_TEXT + " No value given!", oValue))
      Else
        Return 0.0
      End If
    End If

    '*** String correction
    oDoubleAsCharList = sDoubleAsString.ToList()
    sDoubleAsString = sDoubleAsString.Trim
    sDoubleAsString = sDoubleAsString.Replace(" ", "")

    '*** Check Value given
    If (sDoubleAsString.Length = 0) Then
      If bRaiseErrorOnEmpty Then
        Throw New Exception(String.Format(ERROR_TEXT + " No value given!", oValue))
      Else
        Return 0.0
      End If
    End If

    '*** Check input value has numbers
    If Not HasNumbers(sDoubleAsString) Then
      Throw New Exception(String.Format(ERROR_TEXT + " No numeric value found!", oValue))
    End If

    '*** String correction
    sDoubleAsString = RemoveNonNumberDigitsAndCharacters(sDoubleAsString)

    '*** Use given decimal separator
    If (sDecimalSeparator = "A") OrElse (sDecimalSeparator = "") Then
      oNfi = System.Globalization.CultureInfo.InvariantCulture
    ElseIf sDecimalSeparator = "R" Then
      oNfi = System.Globalization.CultureInfo.CurrentCulture
    ElseIf (sDecimalSeparator = ",") OrElse (sDecimalSeparator = ".") Then
      oNfi = New Globalization.NumberFormatInfo With {.CurrencyDecimalSeparator = sDecimalSeparator}
    Else
      sDecimalSeparator = String.Empty
      oNfi = System.Globalization.CultureInfo.InvariantCulture
    End If

    '*** Remove thousend separators
    If sDecimalSeparator = "," Then
      sDoubleAsString = sDoubleAsString.Replace(".", "")
      If oDoubleAsCharList.Where(Function(ch) ch = ",").Count() > 1 Then
        Throw New Exception(String.Format(ERROR_TEXT + " Try removing doublicate separators", oValue))
      End If

    ElseIf sDecimalSeparator = "." Then
      sDoubleAsString = sDoubleAsString.Replace(",", "")
      If oDoubleAsCharList.Where(Function(ch) ch = ".").Count() > 1 Then
        Throw New Exception(String.Format(ERROR_TEXT + " Try removing doublicate separators", oValue))
      End If
    End If

    '*** Parse using regional settings
    If sDecimalSeparator = "R" Then
      Try
        dblResult = Double.Parse(sDoubleAsString, System.Globalization.NumberStyles.Any, oNfi)
      Catch ex As Exception
        Throw New Exception(String.Format(ERROR_TEXT + " " + ex.Message, oValue))
      End Try

      '*** Auto parse
    ElseIf oDoubleAsCharList.Where(Function(ch) ch = "." OrElse ch = ",").Count() <= 1 Then
      Try
        dblResult = Double.Parse(sDoubleAsString.Replace(",", "."), System.Globalization.NumberStyles.Any, oNfi)
      Catch ex As Exception
        Throw New Exception(String.Format(ERROR_TEXT + " " + ex.Message, oValue))
      End Try

    Else
      '*** Auto parse
      If oDoubleAsCharList.Where(Function(ch) ch = ".").Count() >= 1 AndAlso oDoubleAsCharList.Where(Function(ch) ch = ",").Count() >= 1 Then
        If sDoubleAsString.IndexOf(".") < sDoubleAsString.IndexOf(",") Then
          sDoubleAsString = sDoubleAsString.Replace(".", String.Empty)
        Else
          sDoubleAsString = sDoubleAsString.Replace(",", String.Empty)
        End If
        Double.TryParse(sDoubleAsString.Replace(","c, "."), System.Globalization.NumberStyles.Any, oNfi, dblResult)

      ElseIf oDoubleAsCharList.Where(Function(ch) ch = ".").Count() <= 1 AndAlso oDoubleAsCharList.Where(Function(ch) ch = ",").Count() > 1 Then
        Double.TryParse(sDoubleAsString.Replace(",", String.Empty), System.Globalization.NumberStyles.Any, oNfi, dblResult)

      ElseIf oDoubleAsCharList.Where(Function(ch) ch = ",").Count() <= 1 AndAlso oDoubleAsCharList.Where(Function(ch) ch = ".").Count() > 1 Then
        Double.TryParse(sDoubleAsString.Replace(".", String.Empty).Replace(",", "."), System.Globalization.NumberStyles.Any, oNfi, dblResult)

      Else
        Throw New Exception(String.Format(ERROR_TEXT + " Try removing thousand separators.", oValue))
      End If

    End If

    Return dblResult
  End Function

  ''' <summary>
  ''' Check if the given value is numeric using ParseDouble()
  ''' </summary>
  ''' <param name="sValue">Input text</param>
  ''' <param name="sDecimalSeparator">Use given Decimal Separator
  '''                                 'A' or Empty ==> Automatic determination
  '''                                 'R'          ==> Use Regional Settings
  '''                                 ','          ==> Use komma as decimal separator
  '''                                 '.'          ==> Use dot as decimal separator</param>
  ''' <param name="dReturnValue">Converted double value</param>
  ''' <param name="sReturnError">Convertion error</param>
  ''' <param name="bRaiseErrorOnEmpty">Raise error on empty value</param>
  ''' <returns>True, if input text is double vlaue</returns>
  ''' <remarks>Created KT 2020-07-09</remarks>
  Public Function IsNumeric(sValue As String, sDecimalSeparator As String, ByRef dReturnValue As Double, ByRef sReturnError As String, bRaiseErrorOnEmpty As Boolean) As Boolean

    Try
      sReturnError = String.Empty
      dReturnValue = 0.0
      dReturnValue = ParseDouble(sValue, sDecimalSeparator, bRaiseErrorOnEmpty)
      Return True
    Catch ex As Exception
      sReturnError = ex.Message
      Return False
    End Try
  End Function

  ''' <summary>
  ''' Remove none numeric characters for parsing input string
  ''' </summary>
  ''' <param name="sInputText">Input string</param>
  ''' <returns>Corrected string</returns>
  ''' <remarks>Created KT 2020-07-09</remarks>
  Public Shared Function RemoveNonNumberDigitsAndCharacters(ByVal sInputText As String) As String
    Dim oNumericChars As Char() = "0123456789,.-+eE".ToCharArray()
    Return New String(sInputText.Where(Function(c) oNumericChars.Any(Function(n) n = c)).ToArray())
  End Function

  ''' <summary>
  ''' Check input value contains numbers
  ''' </summary>
  ''' <param name="sInputText">Input string</param>
  ''' <returns>True, input value contains at least one number</returns>
  ''' <remarks>Created KT 2020-07-09</remarks>
  Public Shared Function HasNumbers(ByVal sInputText As String) As Boolean
    Dim oNumericChars As Char() = "0123456789".ToCharArray()
    Return New String(sInputText.Where(Function(c) oNumericChars.Any(Function(n) n = c)).ToArray()).Length > 0
  End Function


End Class
