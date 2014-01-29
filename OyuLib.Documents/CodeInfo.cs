using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public abstract class CodeInfo : Code
    {
        #region Constructor

        protected CodeInfo()
            : base()
        {
               
        }

        protected CodeInfo(Code code)
            : base(code)
        {
            
        }

        protected CodeInfo(string codeString, string codeDelimiter)
            : base(codeString, codeDelimiter)
        {
            
        }

        #endregion

        #region Method

        #region Public

        protected string GetCodePartsString(int index)
        {
            if (index < 0)
            {
                return "(None)";
            }

            return this.CodeParts()[index];
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return this.GetCodeText();
        }

        #endregion

        #region Abstract

        public abstract string GetCodeText();

        #endregion

        #endregion

    }
}
