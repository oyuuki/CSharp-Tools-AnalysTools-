using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class ExtractorCodeInfoVBDotNet : ExtractorCodeInfo<SourceVBDotNet>
    {
        #region constructor

        protected ExtractorCodeInfoVBDotNet(SourceVBDotNet source)
            : base(source)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override CodeInfoBlockBeginEventMethod GetCodeInfoEventMethodSuggestVal(CodeInfoMemberVariable suggestVal, SourceVBDotNet source)
        {
            throw new NotImplementedException();
        }

        public override CodeInfoMemberVariable GetCodeInfoMemberVariable(string suggestVal, SourceVBDotNet source)
        {
            throw new NotImplementedException();
        }

        public override CodeInfoBlockBeginMethod GetCodeInfoMethodSuggestVal(CodeInfoMemberVariable suggestVal, SourceVBDotNet source)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
