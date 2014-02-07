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

        public TParamater GetSourceCodeInfoParamater(SourceCodePartsfactory factory, int hierarchyCount, StringRange range)
        {
            var retList = new List<TParamaterValue>();
            
            var codeparts = factory.GetCodeParts();
            var codeRanges = factory.GetCodePartsRanges();

            for (int index = 0; index < codeparts.Length; index++)
            {
                retList.Add(this.GetSourceCodeInfoParamaterValue(codeparts[index], hierarchyCount, index, codeRanges[index]));
            }

            return this.GetSourceCodeInfoParamater(retList.ToArray(), range);
        }

        public TParamater GetSourceCodeInfoParamater()
        {
            return GetSourceCodeInfoParamater(this.Factory, 1, this.Range);
        }

        #endregion

        #region Private

        #endregion

        #region Protected

        protected TParamaterValue GetSourceCodeInfoParamaterValue(
            string paramaterValueString, 
            int hierarchyCount,
            int groupCount, 
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
                groupCount,  
                hierarchyCount);

            if (!string.IsNullOrEmpty(paramaterString))
            {
                retValue.ChildParamater = this.GetSourceCodeInfoParamater(this.GetFactory(paramaterString), hierarchyCount + 1, paramaterRange);    
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
            int groupCount,
            int hierarchyCount);
        protected abstract TParamater GetSourceCodeInfoParamater(TParamaterValue[] values, StringRange range);
        protected abstract TFactory GetFactory(string paramaterString);
        // protected abstract TParamater GetChildParamater(int codepartIndex, TParamaterValue[] values);
        protected abstract SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(SourceCode sourceCode);

        #endregion

        #endregion
    }
}
