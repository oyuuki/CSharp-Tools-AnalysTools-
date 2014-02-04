using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources
{
    public class SourceDocumentRuleVB6 : SourceDocumentRule
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

        public override string GetControlCodeBeginIf()
        {
            return SourceDocumentSyntaxVBDotNet.CONST_IF;
        }
        public override string GetControlCodeBeginFor()
        {
            return SourceDocumentSyntaxVBDotNet.CONST_FOR;
        }
        public override string GetControlCodeEndDoWhile()
        {
            return SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_LOOP;
        }
        
        public override string GetControlCodeEndIf()
        {
            return SourceDocumentSyntaxVBDotNet.CONST_END;
        }
        public override string GetControlCodeEndFor()
        {
            return SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_NEXT;
        }

        public override string GetControlCodeBeginDoWhile()
        {
            return SourceDocumentSyntaxVBDotNet.CONST_DO;
        }

        public override string GetControlCodeBeginCaseFomula()
        {
            return SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_SELECT;
        }

        public override string GetControlCodeEndCaseFomula()
        {
            return SourceDocumentSyntaxVBDotNet.CONST_END;
        }

        public override string GetControlCodeCaseValue()
        {
            return SourceDocumentSyntaxVBDotNet.CONST_STATEMENT_CASE;
        }

        public override string[] GetAccessModifiersString()
        {
            return new string[] { "Friend", "Public", "Private" };
        }
        public override string[] GetControlStatementsString()
        {
            return new string[] { 
                SourceDocumentSyntaxVBDotNet.CONST_IF, 
                SourceDocumentSyntaxVBDotNet.CONST_FOR, 
                SourceDocumentSyntaxVBDotNet.CONST_WHILE, 
                SourceDocumentSyntaxVBDotNet.CONST_DO};
        }

        public override string[] GetCodeNextSeparatorStrings()
        {
            return new string[] { "_", "," };
        }

        #endregion

        #endregion
    }
}
