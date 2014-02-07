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

        #endregion


        #region Method

        public StringRange[] GetStringRange()
        {
            var retList = new List<StringRange>();

            foreach (var val in this.GetParamaterValue)
            {
                var range = val.Range;
                range.Childs = val.GetCodeRanges();

                retList.Add(range);                
            }

            return retList.ToArray();
        }

        public NestIndex[] GetNestIndex()
        {
            var retList = new List<NestIndex>();

            foreach (var val in GetParamaterValue)
            {
                NestIndex paramValuesHead = new NestIndex(-1);
                paramValuesHead.Childs = val.GetNestIndices();

                retList.Add(paramValuesHead);  
            }

            return retList.ToArray();
        }

        #endregion
    }
}
