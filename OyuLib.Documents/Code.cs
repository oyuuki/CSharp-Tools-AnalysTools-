using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public sealed class Code
    {
        #region InstanceVal

        private string _codeString = string.Empty;

        private int _codeLineNumber = -1;

        #endregion

        #region Constructor

        public Code()
        {
            
        }

        public Code(Code code)
            : this(code.CodeString, code.CodeLineNumber)
        {
            
        }

        public Code(string codeLine, int codeIndex)
        {
            this._codeString = codeLine;
            this._codeLineNumber = codeIndex;
        }

        #endregion

        #region Property

        public string CodeString
        {
            get { return this._codeString; }
            set { this._codeString = value; }
        }

        public int CodeLineNumber
        {
            get { return this._codeLineNumber; }
            set { this._codeLineNumber = value; }
        }

        #endregion

        #region Method

        #region internal

        internal string GetTrimCodeString()
        {
            return this.CodeString.Trim();
        }

        #endregion

        #endregion
    }
}
