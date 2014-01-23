using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class DocumentItemWritting : DocumentItem
    {
        #region InstanceVal

        private DocumentitemSentence[] sentences = null;

        #endregion

        #region Constructor

        public DocumentItemWritting(string text)
        {

        }

        public DocumentItemWritting(DocumentitemSentence[] sentences)
        {

        }

        public DocumentItemWritting(string[] textLines)
        {

        }

        #endregion
    }
}
