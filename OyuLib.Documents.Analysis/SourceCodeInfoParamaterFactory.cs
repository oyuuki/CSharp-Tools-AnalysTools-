using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoParamaterFactory<TParamaterValue, TParamater, TFactory>
        where TParamaterValue : SourceCodeInfoParamaterValue
        where TParamater : SourceCodeInfoParamater
        where TFactory : SourceCodePartsfactory
    {
        #region InstanceVal

        private int _parentIndex = -1;

        private TFactory _factory = null;

        private StringRange _range = null;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterFactory(
            int parentIndex,
            TFactory factory,
            StringRange range)
        {
            this._parentIndex = parentIndex;
            this._factory = factory;
            this._range = range;
        }


        #endregion

        #region Property

        public int ParentIndex
        {
            get { return this._parentIndex; }
        }

        public TFactory Factory
        {
            get { return this._factory; }
        }

        public StringRange Range
        {
            get { return this._range; }
        }

        #endregion

        #region Method

        #region Public

        public TParamater GetSourceCodeInfoParamater(SourceCodePartsfactory factory, int hierarchyCount, int parentIndex, StringRange range)
        {
            var retList = new List<TParamaterValue>();
            int startPartsindex = 0;

            var codeparts = factory.GetCodeParts();
            var codeRanges = factory.GetCodePartsRanges();

            for (int index = 0; index < codeparts.Length; index++)
            {
                retList.Add(this.GetSourceCodeInfoParamaterValue(codeparts[index], hierarchyCount, startPartsindex, parentIndex, codeRanges[index]));
                startPartsindex = retList[retList.Count - 1].CodePartsLength;
            }

            return this.GetSourceCodeInfoParamater(retList.ToArray(), range);
        }

        public TParamater GetSourceCodeInfoParamater()
        {
            return GetSourceCodeInfoParamater(this.Factory, 1, this.ParentIndex, this.Range);
        }

        #endregion

        #region Private

        #endregion

        #region Protected

        protected TParamaterValue GetSourceCodeInfoParamaterValue(
            string paramaterValueString, 
            int hierarchyCount, 
            int partsStartIndex, 
            int parentIndex,
            StringRange range)
        {
            var sourceCode = new SourceCode(paramaterValueString);
            var fac = this.GetSourceCodePartsFactoryParamaterValue(sourceCode);
            string paramaterString = string.Empty;
            int paramaterStringIndex = 0;
            StringRange paramaterRange = null;

            var retValue = this.GetSourceCodeInfoParamaterValueLogic(
                sourceCode, 
                fac, 
                range, 
                out paramaterString, 
                out paramaterStringIndex, 
                out paramaterRange, 
                partsStartIndex, 
                parentIndex, 
                hierarchyCount);

            if (!string.IsNullOrEmpty(paramaterString))
            {
                retValue.ChildParamater = this.GetSourceCodeInfoParamater(this.GetFactory(paramaterString), hierarchyCount + 1, paramaterStringIndex, paramaterRange);    
            }

            return retValue;
        }

        

        #endregion

        #region Abstract

        protected abstract TParamaterValue GetSourceCodeInfoParamaterValueLogic
            (SourceCode sourceCode,
            SourceCodePartsfactory fac,
            StringRange rangeParam,
            out string paramaterString, 
            out int paramaterStringIndex,
            out StringRange range,
            int partsStartIndex, 
            int parentIndex,
            int hierarchyCount);
        protected abstract TParamater GetSourceCodeInfoParamater(TParamaterValue[] values, StringRange range);
        protected abstract TFactory GetFactory(string paramaterString);
        protected abstract SourceCodeInfoParamaterFactory<TParamaterValue, TParamater, TFactory> GetFactory(TParamaterValue[] values);
        // protected abstract TParamater GetChildParamater(int codepartIndex, TParamaterValue[] values);
        protected abstract SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(SourceCode sourceCode);

        #endregion

        #endregion
    }
}
