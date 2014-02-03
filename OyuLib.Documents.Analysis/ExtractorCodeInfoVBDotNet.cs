using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class ExtractorCodeInfoVBDotNet : ExtractorCodeInfo<SourceDocumentVBDotNet>
    {
        #region constructor

        protected ExtractorCodeInfoVBDotNet(SourceDocumentVBDotNet source)
            : base(source)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override CodeInfoBlockBeginEventMethod GetCodeInfoEventMethodSuggestVal(CodeInfoMemberVariable suggestVal, SourceDocumentVBDotNet source)
        {
            throw new NotImplementedException();
        }

        public override CodeInfoMemberVariable GetCodeInfoMemberVariable(string suggestVal, SourceDocumentVBDotNet source)
        {
            throw new NotImplementedException();
        }

        public override CodeInfoBlockBeginMethod GetCodeInfoMethodSuggestVal(CodeInfoMemberVariable suggestVal, SourceDocumentVBDotNet source)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
