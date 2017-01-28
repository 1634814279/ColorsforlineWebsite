Imports System.Data.SqlClient
Imports System.Data

Partial Class login
    Inherits System.Web.UI.Page
    Public Const connectString = "Server=192.168.2.107;Database=colorforlines;User ID=sa;Password=inter@WZL@7;Trusted_Connection=False"

    <System.Web.Services.WebMethod()>
    Public Shared Function login(ByVal username As String, ByVal userpw As String) As String
        Dim UID As String

        Dim sqlConnection1 As New SqlConnection(connectString)
        Dim cmd As New SqlCommand
        sqlConnection1.Open()
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1
        cmd.CommandText = "select UID FROM dbo.login where username='" & username & "' and password='" & userpw & "'"
        UID = cmd.ExecuteScalar()
        sqlConnection1.Close()
        If UID = "" Then
            Return "{" & Chr(34) & "login" & Chr(34) & ":" & Chr(34) & "false" & Chr(34) & "}"
        Else
            Return "{" & Chr(34) & "login" & Chr(34) & ":" & Chr(34) & "true" & Chr(34) & "," & Chr(34) & "UID" & Chr(34) & ":" & Chr(34) &
                UID & Chr(34) & "}"
        End If
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function regsiter(ByVal username As String, ByVal userpw As String) As String
        Dim id As String, UID As String
        Dim sqlConnection1 As New SqlConnection(connectString)
        Dim cmd As New SqlCommand
        sqlConnection1.Open()
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1
        cmd.CommandText = "select ID from dbo.login where username='" & username & "'"
        id = cmd.ExecuteScalar()
        If id <> Nothing Then
            Return "{" & Chr(34) & "register" & Chr(34) & ":" & Chr(34) & "false" & Chr(34) & "}"
        Else
            'cmd.CommandText = "select top 1 ID from dbo.login order by ID desc" '获取最后一行的SQL代码 但现在用自增长列完成这步操作
            'id = cmd.ExecuteScalar() + 1
            Dim sourceStr As String = username & userpw
            'Dim SHA As New System.Security.Cryptography.SHA1CryptoServiceProvider 'sha1加密
            Dim sha As New System.Security.Cryptography.SHA256Managed 'sha256加密
            'Dim sha As New System.Security.Cryptography.SHA512Managed 'sha512加密
            Dim bytValue() As Byte '输入
            Dim bytHash() As Byte '输出
            bytValue = System.Text.Encoding.UTF8.GetBytes(sourceStr) '输入字符转为byte
            bytHash = sha.ComputeHash(bytValue) '加密
            sha.Clear()
            UID = Convert.ToBase64String(bytHash)

            cmd.CommandText = "insert into dbo.login values ('" & username & "' , '" & userpw & "' , '" & UID & "')"
            cmd.ExecuteScalar()
            cmd.CommandText = "select ID from dbo.login where username='" & username & "'"
            id = cmd.ExecuteScalar()
            cmd.CommandText = "insert into dbo.colorforlines values (" & id & ",0,0,'00000000','00100000','00000000','00000100','00000050','00000000','40200000','00000000','152')"
            cmd.ExecuteScalar()
            sqlConnection1.Close()

            Return "{" & Chr(34) & "regsiter" & Chr(34) & ":" & Chr(34) & "true" & Chr(34) & "," & Chr(34) & "UID" & Chr(34) & ":" & Chr(34) &
        UID & Chr(34) & "}"
        End If
    End Function
End Class
