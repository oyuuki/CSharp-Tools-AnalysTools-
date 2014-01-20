Public Class SqlServerDBCOntrolManager
    Inherits DBControlManagerUtil

    Private _serverName As String = String.Empty

    Private _dbName As String = String.Empty


    Public Overrides Function GetConnectionString() As String

        Return "Provider=SQLOLEDB;Data Source=" + Me._serverName + ";Initial Catalog=" + Me._dbName + "; User ID=" + Me._loginUserName + ";Password=" + Me._password + ";"

    End Function

    ''' <summary>
    ''' コンストラクタ
    ''' Oracle接続情報を引数から受け取り
    ''' インスタンスに保持する
    ''' </summary>
    ''' <param name="loginUserName">ユーザー名</param>
    ''' <param name="password">パスワード</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal loginUserName As String, _
                   ByVal password As String,
                   ByVal serverName As String, _
                   ByVal dbName As String)

        Me._loginUserName = loginUserName
        Me._password = password
        Me._serverName = serverName
        Me._dbName = dbName

    End Sub

End Class
