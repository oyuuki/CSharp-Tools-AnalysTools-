using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public class SourceDocumentRuleCSharp : SourceDocumentRule
    {
        public override string GetCodeEndSeparatorString()
        {
            return new CharCode(";").GetCharCodeString();
        }

        public override string GetCodesSeparatorString()
        {
            return new CharCode(" ").GetCharCodeString();
        }

        public override string GetControlCodeBeginIf()
        {
            return SourceDocumentSyntaxCSharp.CONST_IF;
        }
        public override string GetControlCodeBeginFor()
        {
            return SourceDocumentSyntaxCSharp.CONST_FOR;
        }
        public override string GetControlCodeEndDoWhile()
        {
            throw new NotImplementedException();
        }

        public override string GetControlCodeEndIf()
        {
            return SourceDocumentSyntaxCSharp.CONST_BLOCKEND;
        }

        public override string GetControlCodeEndFor()
        {
            return SourceDocumentSyntaxCSharp.CONST_BLOCKEND;
        }

        public override string GetControlCodeBeginDoWhile()
        {
            throw new NotImplementedException();
        }

        public override string GetControlCodeBeginCaseFomula()
        {
            throw new NotImplementedException();
        }

        public override string GetControlCodeEndCaseFomula()
        {
            throw new NotImplementedException();
        }

        public override string GetControlCodeCaseValue()
        {
            throw new NotImplementedException();
        }

        public override string[] GetAccessModifiersString()
        {
            return new string[]
            {
                SourceDocumentSyntaxCSharp.CONST_ACCESSMODIFIER_PUBLIC,
                SourceDocumentSyntaxCSharp.CONST_ACCESSMODIFIER_INTERNAL,
                SourceDocumentSyntaxCSharp.CONST_ACCESSMODIFIER_PROTECTED, 
                SourceDocumentSyntaxCSharp.CONST_ACCESSMODIFIER_PRIVATE
            };
        }

        public override string[] GetControlStatementsString()
        {
            return new string[] { 
                SourceDocumentSyntaxCSharp.CONST_IF, 
                SourceDocumentSyntaxCSharp.CONST_FOR, 
                SourceDocumentSyntaxCSharp.CONST_WHILE, 
                SourceDocumentSyntaxCSharp.CONST_DO};
        }

        public override string[] GetCodeNextSeparatorStrings()
        {
            return null;
        }
    }
}
