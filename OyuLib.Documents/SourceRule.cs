using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public abstract class SourceRule
    {
        #region public

        public string[] GetControlCodes()
        {
            return new string[]
            {
                this.GetControlCodeIf(),
                this.GetControlCodeFor(),
                this.GetControlCodeWhile(),
                this.GetControlCodeDo(),
                this.GetControlCodeEndIf(),
                this.GetControlCodeEndFor(),
                this.GetControlCodeEndDo(),
                this.GetControlCodeEndWhile(),
            };
        }

        #region Abstract

        public abstract string GetCodeEndSeparatorString();
        public abstract string GetControlCodeIf();
        public abstract string GetControlCodeFor();
        public abstract string GetControlCodeDo();
        public abstract string GetControlCodeWhile();
        public abstract string GetControlCodeEndIf();
        public abstract string GetControlCodeEndFor();
        public abstract string GetControlCodeEndDo();
        public abstract string GetControlCodeEndWhile();
        public abstract string GetCodesSeparatorString();
        public abstract string[] GetAccessModifiersString();
        public abstract string[] GetControlStatementsString();
        public abstract string[] GetCodeNextSeparatorStrings();

        #endregion

        #endregion
    }
}
