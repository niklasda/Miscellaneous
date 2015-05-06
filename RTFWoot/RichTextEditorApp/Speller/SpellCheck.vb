Imports System.Reflection
Imports Microsoft.Office.Interop.Word

Namespace Speller
    Public Class SpellCheck
        Public Function CheckSpelling(ByVal textToCheck As String) As String

            Dim result As String

            Dim iErrorCount As Integer = 0
            Dim app As New Application()

            If textToCheck.Length > 0 Then

                app.Visible = True
                Dim visible As Object = True

                Dim doc As _Document = app.Documents.Add(Visible:=True)
                doc.Words.First.InsertBefore(textToCheck)
                Dim we As ProofreadingErrors = doc.SpellingErrors
                iErrorCount = we.Count

                doc.CheckSpelling()

                If iErrorCount = 0 Then
                    result = "Spelling OK. No errors corrected "
                ElseIf iErrorCount = 1 Then
                    result = "Spelling OK. 1 error corrected "
                Else
                    result = "Spelling OK. " + iErrorCount.ToString + " errors corrected "
                    Dim first As Object = 0
                    Dim last As Object = doc.Characters.Count - 1
                End If
                '//                tBox.Text = doc.Range(ref first, ref last).Text;

            Else
                result = "Textbox is empty"
            End If

            Dim saveChanges As Object = False
            app.Quit(saveChanges)

            Return result
        End Function
    End Class
End Namespace
