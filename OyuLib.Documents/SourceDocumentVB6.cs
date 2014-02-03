using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace OyuLib.Documents
{
    public class SourceDocumentVB6 : SourceDocument
    {
        #region constractor

        public SourceDocumentVB6()
            : base()
        {

        }

        public SourceDocumentVB6(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override SourceDocumentRule GetSourceRule()
        {
            return new SourceDocumentRuleVB6();
        }


        #endregion

        #endregion
    }
}
