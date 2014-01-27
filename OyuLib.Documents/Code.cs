using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class Code
    {
        #region InstanceVal

        private string _codeString = string.Empty;

        private string _codeDelimiter = string.Empty;

        #endregion

        #region Constructor

        public Code()
        {
            
        }

        public Code(string codeLine, string codeDelimiter)
        {
            this._codeString = codeLine;
            this._codeDelimiter = codeDelimiter;
        }

        #endregion

        #region Property

        public string CodeString
        {
            get { return this._codeString; }
            set { this._codeString = value; }
        }

        public string CodeDelimiter
        {
            get { return this._codeDelimiter; }
            set { this._codeDelimiter = value; }
        }

        #endregion

        #region Method

        public string[] CodeParts()
        {
            return new CharCodeManager(new CharCode(this.CodeDelimiter)).GetSpilitString(CodeString);
        }



        #endregion
    }
}
