using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public abstract class CodeInfo : IAnalysisLogic
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

        #region Property

        public Code Code
        {
            get { return this._code; }
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

            return this.Code.CodeParts()[index];
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

        public abstract CodeInfo GetCodeInfo();
        public abstract bool IsCodeInfo();

        #endregion

        #endregion

    }
}
