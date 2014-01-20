using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OyuLib.OyuFile
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
        private bool _isAppendText = false;

        #endregion

        #region constructor

        public FileAbs(string filePath)
        {
            this._filePath = filePath;
        }

        #endregion

        #region Property

        public bool IsAppendText
        {
            get { return this._isAppendText; }
            set { this._isAppendText = value; }
        }

        #endregion


        #region Method

        /// <summary>
        /// Check the File Exists
        /// </summary>
        /// <returns></returns>
        public bool IsExist()
        {
            return File.Exists(this._filePath);
        }

        #endregion
    }
}
