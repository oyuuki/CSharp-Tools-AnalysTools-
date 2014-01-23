using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace OyuLib.Documents
{
    public class DocumentItemBody
    {
        #region InstanceVal

        private Sentence[] _sentenses = null;

        private DocumentItem[] _childDocuments = null;

        #endregion

        #region Constructor

        public DocumentItemBody()
        {
            
        }

        #endregion
    }
}
