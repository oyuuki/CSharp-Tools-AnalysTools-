using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OyuLib.OyuIO.OyuFile
{
    public class FileAbs
    {
        #region instanceVal

        /// <summary>
        /// File Path String
        /// </summary>
        private string _filePath = string.Empty;

        /// <summary>
        /// Set The WriteMode of Text(true:Append, false:Overwrite)
        /// </summary>
        private bool _isAppendMode = false;

        #endregion

        #region constructor

        public FileAbs(string filePath)
        {
            this._filePath = filePath;
        }

        public FileAbs(string filePath, bool isAppendMode)
        {
            this._filePath = filePath;
            this._isAppendMode = isAppendMode;
        }

        #endregion

        #region Property

        protected string FilePath
        {
            get { return this._filePath; }
            set { this._filePath = value; }
        }

        public bool IsAppendMode
        {
            get { return this._isAppendMode; }
            set { this._isAppendMode = value; }
        }

        #endregion


        #region Method

        #region Public

        /// <summary>
        /// Check the File Exists
        /// </summary>
        /// <returns></returns>
        public bool IsExist()
        {
            return File.Exists(this._filePath);
        }


        #endregion

        #region protected

        protected void CreateNewFile()
        {
            File.Create(this.FilePath).Close();
        }

        #region Exception

        protected void ThrowExNotExistFile()
        {
            throw new Exception("ファイルが存在しません。ファイルパス" + this.FilePath);
        }

        protected void ThrowExAlreadyExistFile()
        {
            throw new Exception("ファイルがすでに存在します。ファイルパス" + this.FilePath);
        }

        #endregion

        #endregion

        #endregion
    }
}
