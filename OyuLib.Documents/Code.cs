using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public sealed class Code
    {
        #region InstanceVal

        private string _codeString = string.Empty;

        #endregion

        #region Constructor

        public Code()
        {
            
        }

        public Code(Code code)
            : this(code.CodeString)
        {
            
        }

        public Code(string codeLine)
        {
            this._codeString = codeLine;
        }

        #endregion

        #region Property

        public string CodeString
        {
            get { return this._codeString; }
            set { this._codeString = value; }
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
