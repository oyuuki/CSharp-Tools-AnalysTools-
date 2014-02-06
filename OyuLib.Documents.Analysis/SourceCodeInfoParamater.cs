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

        public HierarchyUniqueIndex[] GetCodePartsIndex()
        {
            var retList = new List<HierarchyUniqueIndex>();

            foreach (var val in GetSourceCodeInfoParamaterValue())
            {
                retList.AddRange(val.GetCodePartsIndex());
            }

            return retList.ToArray();
        }

        #endregion
    }
}
