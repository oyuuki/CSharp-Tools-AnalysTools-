using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoParamater
    {
        #region instanceVal

        private SourceCodeInfoParamaterValue[] _sourceCodeInfoParamaterValues = null;
        private StringRange _range = null;
        

        #endregion

        #region Constructor

        public SourceCodeInfoParamater(
            SourceCodeInfoParamaterValue[] sourceCodeInfoParamaterValues,
            StringRange range)
        {
            this._sourceCodeInfoParamaterValues = sourceCodeInfoParamaterValues;
            this._range = range;
        }

        #endregion

        #region Property

        public SourceCodeInfoParamaterValue[] GetParamaterValue
        {
            get { return this._sourceCodeInfoParamaterValues; }
        }

        public StringRange ParamaterRange
        {
            get { return this._range; }
        }

        #endregion


        #region Method

        public StringRange GetStringRange()
        {
            var retList = new List<StringRange>();

            foreach (var val in this.GetParamaterValue)
            {
                var range = val.Range;
                range.Childs = val.GetCodeRanges();

                retList.Add(range);                
            }

            ParamaterRange.Childs = retList.ToArray();

            return ParamaterRange;
        }

        public NestIndex[] GetNestIndices()
        {
            var retList = new List<NestIndex>();

            foreach (var val in GetParamaterValue)
            {
                var nestIndex = val.NestIndex;
                nestIndex.Childs = val.GetNestIndices();

                retList.Add(nestIndex);  
            }

            return retList.ToArray();
        }

        #endregion
    }
}
