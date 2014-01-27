using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class CodeInfoExtractorVBDotNet : CodeInfoExtractor<SourceVBDotNet>
    {
        #region constructor

        protected CodeInfoExtractorVBDotNet(SourceVBDotNet source)
            : base(source)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override CodeInfoEventMethod GetCodeInfoEventMethodSuggestVal(CodeInfoMemberVariable suggestVal, SourceVBDotNet source)
        {
            throw new NotImplementedException();
        }

        public override CodeInfoMemberVariable GetCodeInfoMemberVariable(string suggestVal, SourceVBDotNet source)
        {
            throw new NotImplementedException();
        }

        public override CodeInfoMethod GetCodeInfoMethodSuggestVal(CodeInfoMemberVariable suggestVal, SourceVBDotNet source)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
