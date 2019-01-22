Imports System.IO
Public Class Form1
    Dim sr As New StreamReader("in.txt")
    Dim sw As New StreamWriter("out.txt")
    Dim rm() As String = {"I", "V", "X", "L", "C", "D", "M"}
    Dim rn() As Integer = {1, 5, 10, 50, 100, 500, 1000}

    Sub x()
        Dim r(6) As String
        Dim str As String = sr.ReadLine
        Dim ans As String

        If str <> "#" Then
            Dim num As Integer = str
            If num = 0 Then sw.WriteLine("ZERO") : Exit Sub
            For i = 6 To 0 Step -1
                Dim t As Integer = num \ rn(i)
                For j = 1 To t
                    r(i) &= rm(i)
                Next
                num = num Mod rn(i)
            Next
            For i = 0 To 5
                Dim max As Integer = rn(i + 1) / rn(i) - 1
                If max = 4 And Len(r(i)) = max Then
                    r(i) = rm(i) & rm(i + 1)
                ElseIf max = 1 And Len(r(i)) = max Then
                    If r(i - 1) <> Nothing Then
                        If r(i - 1).Contains(rm(i)) Then
                            r(i) = rm(i - 1) & rm(i + 1)
                            r(i - 1) = ""
                        End If
                    End If
                End If
            Next
            Array.Reverse(r)
            ans = Join(r, "")
            sw.WriteLine(ans)
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Do While sr.Peek > -1
            x()
        Loop
        sw.Flush() : End
    End Sub

End Class
