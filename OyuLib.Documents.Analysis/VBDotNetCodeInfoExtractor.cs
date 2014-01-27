using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class VBDotNetCodeInfoExtractor : CodeInfoExtractor<SourceVBDotNet>
    {
        #region constructor

        protected VBDotNetCodeInfoExtractor(SourceVBDotNet source)
            : base(source)
        {
            
        }

        #endregion

        #region Method

        #region Override

        public override CodeInfoEventMethod GetCodeInfoEventMethodSuggestVal(CodeInfoMemberVariable suggestVal)
        {
            throw new NotImplementedException();
        }

        public override CodeInfoMemberVariable GetCodeInfoMemberVariable(string suggestVal)
        {
            throw new NotImplementedException();
        }

        public override CodeInfoMethod GetCodeInfoMethodBlockSuggestVal(string suggestVal, string blockName)
        {
            throw new NotImplementedException();
        }

        public override CodeInfoMethod GetCodeInfoMethodSuggestVal(string suggestVal)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
