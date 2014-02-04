using OyuLib.IO;

namespace OyuLib.Documents.Sources
{
    public class SourceDocumentVBDotNet : SourceDocument
    {
        #region constractor

        public SourceDocumentVBDotNet()
        {
            
        }

        public SourceDocumentVBDotNet(string filepath)
            : base(filepath)
        {
            
        }

        public SourceDocumentVBDotNet(string filepath, CharSet charactorSet)
            : base(filepath, charactorSet)
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
