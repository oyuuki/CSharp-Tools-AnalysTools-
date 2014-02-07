using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Collection;

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


        #region Method

        #region Public

        public string GetCodeString()
        {
            return this._code.CodeString;
        }

        public int CodePartsLength
        {
            get { return this.GetCodeParts().Length; }
        }

        public int GetCodeLineNumber()
        {
            return this._code.CodeLineNumber;
        }

        protected string GetCodePartsString(int index)
        {
            if (index < 0)
            {
                return "(None)";
            }

            return this._coFac.GetCodeParts()[index];
        }

        public string GetTemplateString()
        {
            return new SourceCodeTemplateFactory(
                this.GetNestIndices(),
                this.GetCodeRanges(),
                GetCodeString()).GetTemplateString();
        }

        public string[] GetCodeParts()
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

        #region Virtual

        protected internal virtual StringRange[] GetCodeRanges()
        {
            return this._coFac.GetCodePartsRanges();
        }

        #endregion

        #region Abstract

        protected abstract string GetCodeText();

        public abstract NestIndex[] GetNestIndices();


        #endregion

        #endregion

    }
}
