using OyuLib.IO;

namespace OyuLib.Documents.Sources
{
    public class SourceDocumentCSharp : SourceDocument
    {
        #region constractor

        public SourceDocumentCSharp()
        {
            
        }

        public SourceDocumentCSharp(string filepath)
            : base(filepath)
        {
            
        }

        public SourceDocumentCSharp(string filepath, CharSet charactorSet)
            : base(filepath, charactorSet)
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
