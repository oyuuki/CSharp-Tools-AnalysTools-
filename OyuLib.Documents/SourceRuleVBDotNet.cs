using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceRuleVBDotNet : SourceRule
    {
        #region Method

        #region override

        public string[] GetMethodHead()
        {
            return new string[] { SyntaxStringVBDotNet.CONST_METHODHEAD_SUB, SyntaxStringVBDotNet.CONST_METHODHEAD_FUNCTION };
        }

        public override string GetCodeEndSeparatorString()
        {
            return new LineCharCode().GetCharCodeString();
        }

        public override string GetCodesSeparatorString()
        {
            return new CharCode(" ").GetCharCodeString();
        }

        public override string GetControlCodeBeginIf()
        {
            return SyntaxStringVBDotNet.CONST_IF;
        }

        public override string GetControlCodeEndIf()
        {
            return SyntaxStringVBDotNet.CONST_END;
        }

        public override string GetControlCodeBeginFor()
        {
            return SyntaxStringVBDotNet.CONST_FOR;
        }

        public override string GetControlCodeEndFor()
        {
            return SyntaxStringVBDotNet.CONST_STATEMENT_NEXT;
        }

        public override string GetControlCodeBeginDoWhile()
        {
            return SyntaxStringVBDotNet.CONST_DO;
        }

        public override string GetControlCodeEndDoWhile()
        {
            return SyntaxStringVBDotNet.CONST_STATEMENT_LOOP;
        }

        public override string GetControlCodeBeginCaseFomula()
        {
            return SyntaxStringVBDotNet.CONST_STATEMENT_SELECT;
        }

        public override string GetControlCodeEndCaseFomula()
        {
            return SyntaxStringVBDotNet.CONST_END;
        }

        public override string GetControlCodeCaseValue()
        {
            return SyntaxStringVBDotNet.CONST_STATEMENT_CASE;
        }

        public override string[] GetAccessModifiersString()
        {
            return new string[] { 
                SyntaxStringVBDotNet.CONST_ACCESSMODIFIER_PRIVATE, 
                SyntaxStringVBDotNet.CONST_ACCESSMODIFIER_PUBLIC, 
                SyntaxStringVBDotNet.CONST_ACCESSMODIFIER_INTERNAL, 
                SyntaxStringVBDotNet.CONST_ACCESSMODIFIER_PROTECTEDFRIEND,
                SyntaxStringVBDotNet.CONST_ACCESSMODIFIER_PROTECTED, 
                SyntaxStringVBDotNet.CONST_ACCESSMODIFIER_FRIEND,};
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
            return new string[] { SyntaxStringVBDotNet.CONST_UNDERBAR, SyntaxStringVBDotNet.CONST_COMMA };
        }

        #endregion

        #endregion
    }
}
