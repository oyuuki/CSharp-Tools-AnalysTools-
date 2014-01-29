﻿using System;
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

        public override string GetCodesSeparatorString()
        {
            return new CharCode(" ").GetCharCodeString();
        }

        public override string[] GetAccessModifiersString()
        {
            return new string[] { "Friend", "Public", "Private" };
        }
        public override string[] GetControlStatementsString()
        {
            return new string[] { 
                SyntaxStringVBDotNet.CONST_IF, 
                SyntaxStringVBDotNet.CONST_FOR, 
                SyntaxStringVBDotNet.CONST_WHILE, 
                SyntaxStringVBDotNet.CONST_DO};
        }

        public override string[] GetCodeNextSeparatorStrings()
        {
            return new string[] { "_", "," };
        }

        #endregion

        #endregion
    }
}
