using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    internal abstract class ExtractorCodeInfo<T>
        where T : SourceDocument, new()
    {
        #region instanceVal

        private T _source = null;

        #endregion

        #region constructor

        protected ExtractorCodeInfo(T source)
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

        #region public 

        public SourceCodeInfo GetCodeInfo()
        {
            throw new Exception("未実装：ソースのすべてをCodeInfoに変換したものを返す");
        }

        public SourceCodeInfo[] GetCodeInfoByValName(string valName)
        {
            var retList = new List<SourceCodeInfo>();

            SourceCodeInfoMemberVariable val = this.GetCodeInfoMemberVariable(valName, this.Source);

            if (val == null)
            {
                return null;
            }

            retList.Add(this.GetCodeInfoMethodSuggestVal(val, this.Source));
            retList.Add(this.GetCodeInfoEventMethodSuggestVal(val, this.Source));

            return retList.ToArray();
        }

        #endregion

        #region abstract

        public abstract SourceCodeInfoMemberVariable GetCodeInfoMemberVariable(string suggestVal, T source);
        public abstract SourceCodeInfoBlockBeginMethod  GetCodeInfoMethodSuggestVal(SourceCodeInfoMemberVariable suggestVal, T source);
        public abstract CodeInfoBlockBeginEventMethod GetCodeInfoEventMethodSuggestVal(SourceCodeInfoMemberVariable suggestVal, T source);

        #endregion

        #endregion
    }
}
