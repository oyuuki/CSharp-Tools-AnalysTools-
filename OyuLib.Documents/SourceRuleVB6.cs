using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    class SourceRuleVB6 : SourceRule
    {
        #region Method

        #region Override

        public override string GetCodeEndSeparatorString()
        {
            return new LineCharCode().GetCharCodeString();
        }

        public override string[] GetAccessModifiersString()
        {
            return new string[] { "Friend", "Public", "Private" };
        }

        public override string[] GetCodeNextSeparatorStrings()
        {
            return new string[] { "_", "," };
        }

        #endregion

        #endregion
    }
}
