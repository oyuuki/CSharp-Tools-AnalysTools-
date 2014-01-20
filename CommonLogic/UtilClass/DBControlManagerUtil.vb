Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.OleDb

''' <summary>
''' DBへの操作を行うクラス
''' </summary>
''' <remarks></remarks>
Public MustInherit Class DBControlManagerUtil
    Implements IDisposable

#Region "クラス変数"

#Region "DB接続"

    ''' <summary>
    ''' DB接続
    ''' </summary>
    ''' <remarks></remarks>
    Protected _connection As OleDbConnection

#End Region

#Region "トランザクション"

    ''' <summary>
    ''' トランザクション
    ''' </summary>
    ''' <remarks></remarks>
    Protected _transaction As OleDbTransaction

#End Region

#Region "オラクルインスタンスID"

    ''' <summary>
    ''' オラクルインスタンスID
    ''' </summary>
    ''' <remarks></remarks>
    Protected _oracleSid As String

#End Region

#Region "ログインユーザ名"

    ''' <summary>
    ''' ログインユーザ名
    ''' </summary>
    ''' <remarks></remarks>
    Protected _loginUserName As String

#End Region

#Region "パスワード"

    ''' <summary>
    ''' パスワード
    ''' </summary>
    ''' <remarks></remarks>
    Protected _password As String

#End Region

#End Region

#Region "プロパティ"

#Region "DB接続"

    ''' <summary>
    ''' DB接続インスタンスを取得、設定する
    ''' </summary>
    ''' <value>DB接続インスタンス</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Connection() As OleDbConnection

        Get
            Return Me._connection
        End Get

        Private Set(ByVal value As OleDbConnection)
            Me._connection = value
        End Set

    End Property

#End Region

#Region "トランザクション"

    ''' <summary>
    ''' DB接続インスタンスを取得、設定する
    ''' </summary>
    ''' <value>DB接続インスタンス</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Transaction() As OleDbTransaction

        Get
            Return Me._transaction
        End Get

        Private Set(ByVal value As OleDbTransaction)
            Me._transaction = value
        End Set

    End Property

#End Region

#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()


    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' Oracle接続情報を引数から受け取り
    ''' インスタンスに保持する
    ''' </summary>
    ''' <param name="loginUserName">ユーザー名</param>
    ''' <param name="password">パスワード</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal loginUserName As String, _
                   ByVal password As String)

        Me._loginUserName = loginUserName
        Me._password = password

    End Sub

#End Region

#Region "IDisposable実装メソッド"

    ''' <summary>
    ''' Disposeメソッド
    ''' オブジェクトが破棄された時、処理を行う
    ''' </summary>
    ''' <remarks></remarks>
    Sub Dispose() Implements IDisposable.Dispose
        ' Oracleの接続を切断する
        Me.Close()
    End Sub


#End Region

#Region "メソッド"

#Region "接続情報取得"



    ''' <summary>
    ''' コンストラクタに設定した情報を使ってOracleに接続し、
    ''' その接続を返します。
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Function GetConnectionString() As String

#End Region

#Region "接続OPEN"

    ''' <summary>
    ''' コンストラクタに設定した情報を使ってOracleに接続する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Open()

        Me.Connection = Me.GetOpenCon()

    End Sub

    ''' <summary>
    ''' コンストラクタに設定した情報を使ってOracleに接続し、
    ''' その接続を返します。
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetOpenCon() As OleDbConnection

        Dim con As New OleDbConnection()

        con.ConnectionString = Me.GetConnectionString()
        con.Open()

        GetOpenCon = con

    End Function

#End Region

#Region "接続CLOSE"

    ''' <summary>
    ''' Oracleの接続を切断する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()

        ' 接続が開かれていれば閉じる
        If Not Me.Connection Is Nothing And Me.Connection.State = System.Data.ConnectionState.Open Then

            Me.Connection.Close()
            Me.Connection.Dispose()

        End If

    End Sub


#End Region

#Region "トランザクション開始オブジェクト取得"


    ''' <summary>
    ''' トランザクションを開始する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BeginTran()

        Me.Transaction = Me.Connection.BeginTransaction()

    End Sub


#End Region

#Region "トランザクションコミット"


    ''' <summary>
    ''' トランザクションをコミットする
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Commit()

        Me.Transaction.Commit()

    End Sub

#End Region

#Region "トランザクションロールバック"


    ''' <summary>
    ''' トランザクションをロールバックする
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RollBack()

        Me.Transaction.Rollback()

    End Sub

#End Region

#End Region

End Class
