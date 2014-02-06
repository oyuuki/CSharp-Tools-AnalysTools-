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

        public int GetCodeLineNumber()
        {
            return this._code.CodeLineNumber;
        }

        public SourceCodePartsfactory GetSourceCodePartsfactory()
        {
            return this._coFac;
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
            return this._coFac.GetTemplateString(this.GetCodePartsIndex());
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

        #region Abstract

        protected abstract string GetCodeText();

        protected internal abstract HierarchyUniqueIndex[] GetCodePartsIndex();


        #endregion

        #endregion

    }
}
