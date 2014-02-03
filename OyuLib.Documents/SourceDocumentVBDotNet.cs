using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceDocumentVBDotNet : SourceDocument
    {
        #region constractor

        public SourceDocumentVBDotNet()
            : base()
        {

        }

        public SourceDocumentVBDotNet(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override SourceDocumentRule GetSourceRule()
        {
            return new SourceDocumentRuleVBDotNet();
        }

        #endregion

        #endregion        
    }
}
