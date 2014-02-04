using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    internal class ExtractorCodeInfoVBDotNet : ExtractorCodeInfo<SourceDocumentVBDotNet>
    {
        #region constructor

        protected ExtractorCodeInfoVBDotNet(SourceDocumentVBDotNet source)
            : base(source)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override CodeInfoBlockBeginEventMethod GetCodeInfoEventMethodSuggestVal(SourceCodeInfoMemberVariable suggestVal, SourceDocumentVBDotNet source)
        {
            throw new NotImplementedException();
        }

        public override SourceCodeInfoMemberVariable GetCodeInfoMemberVariable(string suggestVal, SourceDocumentVBDotNet source)
        {
            throw new NotImplementedException();
        }

        public override SourceCodeInfoBlockBeginMethod GetCodeInfoMethodSuggestVal(SourceCodeInfoMemberVariable suggestVal, SourceDocumentVBDotNet source)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
