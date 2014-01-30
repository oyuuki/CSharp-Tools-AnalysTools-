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

        public override string GetControlCodeIf()
        {
            return SyntaxStringCSharp.CONST_IF;
        }
        public override string GetControlCodeFor()
        {
            return SyntaxStringCSharp.CONST_FOR;
        }
        public override string GetControlCodeDo()
        {
            return SyntaxStringCSharp.CONST_DO;
        }
        public override string GetControlCodeWhile()
        {
            return SyntaxStringCSharp.CONST_WHILE;
        }

        public override string GetControlCodeEndIf()
        {
            return SyntaxStringCSharp.CONST_BLOCKEND;
        }
        public override string GetControlCodeEndFor()
        {
            return SyntaxStringCSharp.CONST_BLOCKEND;
        }
        public override string GetControlCodeEndDo()
        {
            return SyntaxStringCSharp.CONST_BLOCKEND;
        }
        public override string GetControlCodeEndWhile()
        {
            return SyntaxStringCSharp.CONST_BLOCKEND;
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
