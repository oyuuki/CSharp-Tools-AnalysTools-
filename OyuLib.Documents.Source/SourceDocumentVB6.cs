
using OyuLib.IO;

namespace OyuLib.Documents.Sources
{
    public class SourceDocumentVB6 : SourceDocument
    {
        #region constractor

        public SourceDocumentVB6()
        {
            
        }

        public SourceDocumentVB6(string filepath)
            : base(filepath)
        {
            
        }

        public SourceDocumentVB6(string filepath, CharSet charactorSet)
            : base(filepath, charactorSet)
        {
            
        }

        public SourceDocumentVB6(string textString, bool dummy, bool dummy2)
            : base(textString, dummy, dummy2)
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
