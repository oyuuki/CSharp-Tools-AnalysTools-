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

        private string _codeStringNonModify = string.Empty;

        private string _codeString = string.Empty;

        private int _codeLineNumber = -1;

        #endregion

        #region Constructor

        public SourceCode()
        {
            
        }

        public SourceCode(SourceCode code)
            : this(code.CodeString, code.CodeLineNumber, code._codeStringNonModify)
        {
            
        }

        public SourceCode(string codeLine, int codeIndex, string codeStringNonModify)
        {
            this._codeString = codeLine;
            this._codeLineNumber = codeIndex;
            this._codeStringNonModify = codeStringNonModify;
        }

        public SourceCode(string codeLine)
            : this(codeLine, -1, codeLine)
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

        public string CodeStringNonModify
        {
            get { return this._codeStringNonModify; }
            set { this._codeStringNonModify = value; }
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
