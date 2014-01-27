using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceRuleCSharp : SourceRule
    {
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
    }
}
