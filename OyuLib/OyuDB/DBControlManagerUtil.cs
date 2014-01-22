using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace OyuLib.DB
{
    /// <summary>
    /// DBへの操作を行うクラス
    /// </summary>
    /// <remarks></remarks>
    public abstract class DBControlManagerUtil : IDisposable
    {

        #region "クラス変数"

        #region "DB接続"

        /// <summary>
        /// DB接続
        /// </summary>
        /// <remarks></remarks>

        protected OleDbConnection _connection;

        #endregion

        #region "トランザクション"

        /// <summary>
        /// トランザクション
        /// </summary>
        /// <remarks></remarks>

        protected OleDbTransaction _transaction;

        #endregion

        #region "オラクルインスタンスID"

        /// <summary>
        /// オラクルインスタンスID
        /// </summary>
        /// <remarks></remarks>

        protected string _oracleSid;

        #endregion

        #region "ログインユーザ名"

        /// <summary>
        /// ログインユーザ名
        /// </summary>
        /// <remarks></remarks>

        protected string _loginUserName;

        #endregion

        #region "パスワード"

        /// <summary>
        /// パスワード
        /// </summary>
        /// <remarks></remarks>

        protected string _password;

        #endregion

        #endregion

        #region "プロパティ"

        #region "DB接続"

        /// <summary>
        /// DB接続インスタンスを取得、設定する
        /// </summary>
        /// <value>DB接続インスタンス</value>
        /// <returns></returns>
        /// <remarks></remarks>
        public OleDbConnection Connection
        {

            get { return this._connection; }

            private set { this._connection = value; }
        }


        #endregion

        #region "トランザクション"

        /// <summary>
        /// DB接続インスタンスを取得、設定する
        /// </summary>
        /// <value>DB接続インスタンス</value>
        /// <returns></returns>
        /// <remarks></remarks>
        public OleDbTransaction Transaction
        {

            get { return this._transaction; }

            private set { this._transaction = value; }
        }


        #endregion

        #endregion

        #region "コンストラクタ"

        /// <summary>
        /// </summary>
        /// <remarks></remarks>

        public DBControlManagerUtil()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// Oracle接続情報を引数から受け取り
        /// インスタンスに保持する
        /// </summary>
        /// <param name="loginUserName">ユーザー名</param>
        /// <param name="password">パスワード</param>
        /// <remarks></remarks>

        public DBControlManagerUtil(string loginUserName, string password)
        {
            this._loginUserName = loginUserName;
            this._password = password;

        }

        #endregion

        #region "IDisposable実装メソッド"

        /// <summary>
        /// Disposeメソッド
        /// オブジェクトが破棄された時、処理を行う
        /// </summary>
        /// <remarks></remarks>
        public void Dispose()
        {
            // Oracleの接続を切断する
            this.Close();
        }


        #endregion

        #region "メソッド"

        #region "接続情報取得"



        /// <summary>
        /// コンストラクタに設定した情報を使ってOracleに接続し、
        /// その接続を返します。
        /// </summary>
        /// <remarks></remarks>
        public abstract string GetConnectionString();

        #endregion

        #region "接続OPEN"

        /// <summary>
        /// コンストラクタに設定した情報を使ってOracleに接続する
        /// </summary>
        /// <remarks></remarks>

        public void Open()
        {
            this.Connection = this.GetOpenCon();

        }

        /// <summary>
        /// コンストラクタに設定した情報を使ってOracleに接続し、
        /// その接続を返します。
        /// </summary>
        /// <remarks></remarks>
        private OleDbConnection GetOpenCon()
        {

            OleDbConnection con = new OleDbConnection();

            con.ConnectionString = this.GetConnectionString();
            con.Open();

            return con;

        }

        #endregion

        #region "接続CLOSE"

        /// <summary>
        /// Oracleの接続を切断する
        /// </summary>
        /// <remarks></remarks>

        public void Close()
        {
            // 接続が開かれていれば閉じる

            if ((this.Connection != null) & this.Connection.State == System.Data.ConnectionState.Open)
            {
                this.Connection.Close();
                this.Connection.Dispose();

            }

        }


        #endregion

        #region "トランザクション開始オブジェクト取得"


        /// <summary>
        /// トランザクションを開始する
        /// </summary>
        /// <remarks></remarks>

        public void BeginTran()
        {
            this.Transaction = this.Connection.BeginTransaction();

        }


        #endregion

        #region "トランザクションコミット"


        /// <summary>
        /// トランザクションをコミットする
        /// </summary>
        /// <remarks></remarks>

        public void Commit()
        {
            this.Transaction.Commit();

        }

        #endregion

        #region "トランザクションロールバック"


        /// <summary>
        /// トランザクションをロールバックする
        /// </summary>
        /// <remarks></remarks>

        public void RollBack()
        {
            this.Transaction.Rollback();

        }

        #endregion

        #endregion

    }
}