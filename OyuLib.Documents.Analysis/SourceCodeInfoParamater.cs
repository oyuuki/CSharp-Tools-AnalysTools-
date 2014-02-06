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

        #endregion

        #region Constructor

        public SourceCodeInfoParamater(
            SourceCodeInfoParamaterValue[] sourceCodeInfoParamaterValues)
        {
            this._sourceCodeInfoParamaterValues = sourceCodeInfoParamaterValues;
        }

        #endregion

        #region Method

        public SourceCodeInfoParamaterValue[] GetSourceCodeInfoParamaterValue()
        {
            return this._sourceCodeInfoParamaterValues;
        }

        public StringRange[] GetStringRange()
        {
            var retList = new List<StringRange>();

            foreach (var val in this.GetSourceCodeInfoParamaterValue())
            {
                retList.AddRange(val.GetCodeRanges());                
            }

            return retList.ToArray();
        }

        public NestIndex[] GetNestIndices()
        {
            var retList = new List<NestIndex>();

            foreach (var val in GetSourceCodeInfoParamaterValue())
            {
                retList.AddRange(val.GetNestIndices());
            }

            return retList.ToArray();
        }

        #endregion
    }
}
