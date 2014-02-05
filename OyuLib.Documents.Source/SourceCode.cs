using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public sealed class SourceCode
    {
        #region InstanceVal

        private string _codeString = string.Empty;

        private int _codeLineNumber = -1;

        #endregion

        #region Constructor

        public SourceCode()
        {
            
        }

        public SourceCode(SourceCode code)
            : this(code.CodeString, code.CodeLineNumber)
        {
            
        }

        public SourceCode(string codeLine, int codeIndex)
        {
            this._codeString = codeLine;
            this._codeLineNumber = codeIndex;
        }

        public SourceCode(string codeLine)
           : this(codeLine, -1)
        {
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
