using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public abstract class CodeInfoExtractor<T>
        where T : Source, new()
    {
        #region instanceVal

        private T _source = null;

        #endregion

        #region constructor

        protected CodeInfoExtractor(T source)
        {
            this._source = source;
        }

        #endregion

        #region property

        public T Source
        {
            get { return this._source; }
        }

        #endregion


        #region Method

        #region abstract

        public abstract CodeInfoEventMethod GetCodeInfoEventMethodSuggestVal(CodeInfoMemberVariable suggestVal);
        public abstract CodeInfoMemberVariable GetCodeInfoMemberVariable(string suggestVal);
        public abstract CodeInfoMethod GetCodeInfoMethodSuggestVal(string suggestVal);
        public abstract CodeInfoMethod GetCodeInfoMethodBlockSuggestVal(string suggestVal, string blockName);

        #endregion

        #endregion
    }
}
