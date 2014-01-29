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

        public override string GetCodesSeparatorString()
        {
            return new CharCode(" ").GetCharCodeString();
        }

        public override string[] GetAccessModifiersString()
        {
            return new string[]
            {
                SyntaxStringCSharp.CONST_ACCESSMODIFIER_PUBLIC,
                SyntaxStringCSharp.CONST_ACCESSMODIFIER_INTERNAL,
                SyntaxStringCSharp.CONST_ACCESSMODIFIER_PROTECTED, 
                SyntaxStringCSharp.CONST_ACCESSMODIFIER_PRIVATE
            };
        }

        public override string[] GetControlStatementsString()
        {
            return new string[] { 
                SyntaxStringCSharp.CONST_IF, 
                SyntaxStringCSharp.CONST_FOR, 
                SyntaxStringCSharp.CONST_WHILE, 
                SyntaxStringCSharp.CONST_DO};
        }

        public override string[] GetCodeNextSeparatorStrings()
        {
            return null;
        }
    }
}
