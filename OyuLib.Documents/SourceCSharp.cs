using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceCSharp : Source
    {
        #region constractor

        public SourceCSharp()
            : base()
        {

        }

        public SourceCSharp(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        #region override

        public override string GetCodeEndSeparatorString()
        {
            return new CharCode(";").GetCharCodeString();
        }

        public override string[] GetAccessModifiersString()
        {
            return new string[] { "protected", "Internal", "public", "Private" };
        }

        public override string[] GetCodeNextSeparatorStrings()
        {
            return null;
        }

        #endregion

        #endregion
    }
}
