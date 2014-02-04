using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public abstract class SourceDocumentRule
    {
        #region public

        public string[] GetControlCodes()
        {
            return new string[]
            {
                this.GetControlCodeBeginIf(),
                this.GetControlCodeEndIf(),
                this.GetControlCodeBeginFor(),
                this.GetControlCodeEndFor(),
                this.GetControlCodeBeginDoWhile(),
                this.GetControlCodeEndDoWhile(),
            };
        }

        #region Abstract

        public abstract string GetCodeEndSeparatorString();
        public abstract string GetControlCodeBeginIf();
        public abstract string GetControlCodeEndIf();
        public abstract string GetControlCodeBeginDoWhile();
        public abstract string GetControlCodeEndDoWhile();
        public abstract string GetControlCodeBeginFor();
        public abstract string GetControlCodeEndFor();
        public abstract string GetControlCodeBeginCaseFomula();
        public abstract string GetControlCodeEndCaseFomula();
        public abstract string GetControlCodeCaseValue();
        public abstract string GetCodesSeparatorString();
        public abstract string[] GetAccessModifiersString();
        public abstract string[] GetControlStatementsString();
        public abstract string[] GetCodeNextSeparatorStrings();

        #endregion

        #endregion
    }
}
