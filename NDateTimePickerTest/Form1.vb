Public Class Form1



    Private Sub NDateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles NDateTimePicker1.ValueChanged
        If NDateTimePicker1.IsNull Then
            Log("NDateTimePicker1_ValueChanged: is null")
        Else
            Log("NDateTimePicker1_ValueChanged: {0}", NDateTimePicker1.ValueAsNullable.Value)
        End If
    End Sub

    Public Sub Log(ByVal message As String, ParamArray args() As Object)

        If args.Length > 0 Then
            message = String.Format(message, args)
        End If

        TextBox1.AppendText(message & vbCrLf)

    End Sub



    Private Sub Button_Click(sender As Object, e As EventArgs) _
        Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click

        Try
            If sender Is Button1 Then
                NDateTimePicker1.Value = Nothing
            ElseIf sender Is Button2 Then
                NDateTimePicker1.Value = DBNull.Value
            ElseIf sender Is Button3 Then
                NDateTimePicker1.Value = System.DateTime.Now.ToString()
            ElseIf sender Is Button4 Then
                NDateTimePicker1.Value = System.DateTime.Now
            ElseIf sender Is Button5 Then
                NDateTimePicker1.Value = New Object()
            End If
        Catch ex As Exception
            Log("Button_Click exception: {1} ({0})", ex.GetType(), ex.Message)
        End Try

    End Sub

End Class
