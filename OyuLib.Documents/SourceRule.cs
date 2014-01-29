using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public abstract class SourceRule
    {
        #region Abstract

        public abstract string GetCodeEndSeparatorString();
        public abstract string GetCodesSeparatorString();
        public abstract string[] GetAccessModifiersString();
        public abstract string[] GetControlStatementsString();
        public abstract string[] GetCodeNextSeparatorStrings();


        #endregion
    }
}
