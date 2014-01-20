using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalysVBFormApl
{
    class Memo
    {
        #region const

        /// <summary>
        /// Spilit At MEMO
        /// </summary>
        private const string MEMOSPILITCHAR = "||MEMO||";

        #endregion
        
        /// <summary>
        /// MEMO
        /// </summary>
        private string _memo = null;

        /// <summary>
        /// DBNAME CRUD
        /// </summary>
        private string _DBName = null;

        #region constractor

        public Memo(string memoStr)
        {
            string[] strMemoArray = memoStr.Trim().Split(new string[] { MEMOSPILITCHAR }, StringSplitOptions.None);

            if (strMemoArray.Length > 0)
            {
                this._memo = strMemoArray[0];
            }

            if (strMemoArray.Length > 1)
            {
                this._DBName = strMemoArray[1];
            }
        }

        #endregion

        #region method

        public Memo(string memo, string dbName)
        {
            this._memo = memo;
            this._DBName = dbName;
        }

        public string GetMemo()
        {
            return this._memo;
        }

        public string GetDBName()
        {
            return this._DBName;
        }

        public string GetMemoStr()
        {
            return this._memo + MEMOSPILITCHAR + this._DBName;
        }

        #endregion
    }
}
