using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceDocumentCSharp : SourceDocument
    {
        #region constractor

        public SourceDocumentCSharp()
            : base()
        {

        }

        public SourceDocumentCSharp(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        #region override

        public override SourceDocumentRule GetSourceRule()
        {
            return new SourceDocumentRuleCSharp();
        }

        #endregion

        #endregion
    }
}
