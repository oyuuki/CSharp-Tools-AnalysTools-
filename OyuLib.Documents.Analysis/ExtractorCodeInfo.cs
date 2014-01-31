using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public abstract class ExtractorCodeInfo<T>
        where T : Source, new()
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

        public CodeInfo GetCodeInfo()
        {
            throw new Exception("未実装：ソースのすべてをCodeInfoに変換したものを返す");
        }

        public CodeInfo[] GetCodeInfoByValName(string valName)
        {
            var retList = new List<CodeInfo>();

            CodeInfoMemberVariable val = this.GetCodeInfoMemberVariable(valName, this.Source);

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

        public abstract CodeInfoMemberVariable GetCodeInfoMemberVariable(string suggestVal, T source);
        public abstract CodeInfoBlockBeginMethod  GetCodeInfoMethodSuggestVal(CodeInfoMemberVariable suggestVal, T source);
        public abstract CodeInfoEventMethod GetCodeInfoEventMethodSuggestVal(CodeInfoMemberVariable suggestVal, T source);

        #endregion

        #endregion
    }
}
