using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;



namespace OyuLib.Data.DB
{

    public class DBControlManagerUtilSqlServer : DBControlManagerUtil
    {
        private string _serverName = string.Empty;

        private string _dbName = string.Empty;

        public override string GetConnectionString()
        {
            return "Provider=SQLOLEDB;Data Source=" + this._serverName + ";Initial Catalog=" + this._dbName +
                   "; User ID=" + this._loginUserName + ";Password=" + this._password + ";";
        }

        /// <summary>
        /// コンストラクタ
        /// Oracle接続情報を引数から受け取り
        /// インスタンスに保持する
        /// </summary>
        /// <param name="loginUserName">ユーザー名</param>
        /// <param name="password">パスワード</param>
        /// <remarks></remarks>

        public DBControlManagerUtilSqlServer(string loginUserName, string password, string serverName, string dbName)
        {
            this._loginUserName = loginUserName;
            this._password = password;
            this._serverName = serverName;
            this._dbName = dbName;
        }

    }
}