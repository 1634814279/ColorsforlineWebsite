Imports System.Data.SqlClient
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    Public Shared CflL As New ColorsforlineLibrary.Main
    Public Shared highscore As Integer
    Public Const connectString = "Server=192.168.2.107;Database=colorforlines;User ID=sa;Password=inter@WZL@7;Trusted_Connection=False"
    Public Shared ID As Integer

    'Public Shared Function ReturnArray(ByVal sum As String, ByVal words As String) As 
    <System.Web.Services.WebMethod()>
    Public Shared Function CanMove(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal UID As String) As String
        'Return "Hello " & words & Environment.NewLine & "The Current Time is: " & DateTime.Now.ToString()
        If CflL.array(x2, y2) = 0 Then
            If CflL.canMove(x1, y1, x2, y2) = True Then
                CflL.Move(x1, y1, x2, y2)
                If CflL.checkline(x2, y2) = 0 Then
                    If CflL.canNextStep = False Then
                        CflL.initialize()
                        Return "GameOver"
                    Else
                        CflL.nextStep()
                    End If
                Else
                    'windowsapplication里还有额外判断 目前认为不需要
                End If
                Return "true"
            Else
                Return "false"
            End If
        Else
            Return "false"
        End If
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function Refresh(ByVal restart As String, ByVal UID As String) As String
        'Dim highscoreUI As Integer = 0

        Dim color As String = CflL.color(0) & CflL.color(1) & CflL.color(2)
        Dim sqlConnection1 As New SqlConnection(connectString)
        Dim cmd As New SqlCommand
        sqlConnection1.Open()
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1
        If restart = "true" Then
            CflL.initialize()
            cmd.CommandText = "select highscore FROM dbo.colorforlines where ID='" & ID & "'"
            highscore = cmd.ExecuteScalar()
        End If
        If CflL.score > highscore Then
            cmd.CommandText = "UPDATE dbo.colorforlines set highscore=" & CflL.score & " where ID='" & ID & "'"
            cmd.ExecuteScalar()
            'highscore = CflL.score
            'highscoreUI = CflL.score
        Else
            'highscoreUI = highscore
        End If
        cmd.CommandText = "update dbo.colorforlines set line0 = '" & CflL.save(0) & "' , line1 = '" & CflL.save(1) & "' , line2='" & CflL.save(2) & "' , line3='" & CflL.save(3) & "' , line4='" & CflL.save(4) & "' , line5='" & CflL.save(5) & "' , line6='" & CflL.save(6) & "' , line7='" & CflL.save(7) & "' , color='" & color & "' , score=" & CflL.score & " where ID='" & ID & "'"
        cmd.ExecuteScalar()
        sqlConnection1.Close()

        Dim json As String = "{"
        For i = 0 To CflL.theSizeOfArray
            json &= Chr(34) & "line" & i & Chr(34) & ":" & Chr(34)
            For j = 0 To CflL.theSizeOfArray
                json &= CflL.array(i, j)
            Next
            json &= Chr(34) & ","
        Next
        'json &= Chr(34) & "score" & Chr(34) & ":" & Chr(34) & CflL.score & Chr(34) & "," & Chr(34) & "color" & Chr(34) & ":" & Chr(34) & color & Chr(34) & "," & Chr(34) & "highscore" & Chr(34) & ":" & Chr(34) & highscoreUI & Chr(34) & "}"
        json &= Chr(34) & "score" & Chr(34) & ":" & Chr(34) & CflL.score & Chr(34) & "," & Chr(34) & "color" & Chr(34) & ":" & Chr(34) & color & Chr(34) & "," & Chr(34) & "highscore" & Chr(34) & ":" & Chr(34) & highscore & Chr(34) & "}"
        Return json
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function firstLoad(ByVal UID As String) As String
        Dim sqlConnection1 As New SqlConnection(connectString)
        Dim cmd As New SqlCommand
        sqlConnection1.Open()
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1
        cmd.CommandText = "select ID from dbo.login where UID='" & UID & "'"
        ID = cmd.ExecuteScalar()
        Dim returnValue(8) As String
        For i = 0 To CflL.theSizeOfArray
            cmd.CommandText = "select line" & i & " FROM dbo.colorforlines where ID='" & ID & "'"
            returnValue(i) = cmd.ExecuteScalar()
            For j = 0 To 1
            Next
            CflL.load(returnValue(i), i)
        Next
        cmd.CommandText = "select highscore FROM dbo.colorforlines where ID='" & ID & "'"
        highscore = cmd.ExecuteScalar()
        cmd.CommandText = "select color FROM dbo.colorforlines where ID='" & ID & "'"
        Dim color As String = cmd.ExecuteScalar()
        For i = 0 To 2
            CflL.color(i) = Mid(color, i + 1, 1)
        Next
        sqlConnection1.Close()
        Return ""
    End Function
End Class
