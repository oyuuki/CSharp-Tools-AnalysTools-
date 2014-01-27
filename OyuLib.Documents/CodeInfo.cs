using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public abstract class CodeInfo
    {
        #region instanceVal

        private Code _code = null;

        #endregion

        #region Constructor

        protected CodeInfo()
        {
               
        }

        protected CodeInfo(Code code)
        {
            this._code = code;
        }

        protected CodeInfo(string codeString, string codeDelimiter)
        {
            this._code = new Code(codeString, codeDelimiter);
        }

        #endregion

        #region Method

        #region New

        protected string[] CodeParts
        {
            get { return this._code.GetSpilitByDelimiter(); }
        }
        
        #endregion

        #endregion
    }
}
