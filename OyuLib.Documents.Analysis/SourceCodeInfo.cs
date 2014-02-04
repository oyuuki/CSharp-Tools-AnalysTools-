using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfo
    {
        #region instanceVal

        private SourceCode _code = null;

        private SourceCodePartsfactory _coFac = null;

        #endregion

        #region Constructor

        protected SourceCodeInfo()
        {
               
        }

        protected SourceCodeInfo(
            SourceCode code,
            SourceCodePartsfactory coFac)
        {
            this._code = code;
            this._coFac = coFac;
        }

        #endregion

        #region Property

        public string CodeString
        {
            get { return this._code.CodeString; }
        }

        public int CodeLineNumber
        {
            get { return this._code.CodeLineNumber; }
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

            return this._coFac.GetCodeParts()[index];
        }

        public string[] CodeParts()
        {
            return this._coFac.GetCodeParts();
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return this.GetCodeText();
        }

        #endregion

        #region Abstract

        protected abstract string GetCodeText();

        #endregion

        #endregion

    }
}
