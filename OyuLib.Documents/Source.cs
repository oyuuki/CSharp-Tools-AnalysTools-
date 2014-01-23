
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using OyuLib.Documents;

namespace OyuLib.Documents
{
    public abstract class Source : Document
    {
        #region constractor

        public Source()
            : base()
        {


        }

        public Source(string sourceText)
            : base(sourceText)
        {
            
        }

        #endregion

        #region Property

        public string SourceText
        {
            get { return this.DocumnetText; }
            set { this.DocumnetText = value; }
        }

        private new string DocumentText
        {
            get { return base.DocumnetText; }
            set { base.DocumnetText = value; }
        }

        #endregion

        #region Method

        #region abstruct



        #endregion

        #endregion
    }
}
