using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoParamaterFactory<TParamaterValue, TParamater, TFactory>
        where TParamaterValue : SourceCodeInfoParamaterValue
        where TParamater : SourceCodeInfoParamater
        where TFactory : SourceCodePartsfactory
    {
        #region InstanceVal

        private int _codepartIndex = -1;

        private int _hierarchyCount = -1;

        private TFactory _factory = null;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterFactory(
            int codepartIndex,
            TFactory factory)
            : this(codepartIndex, 0, factory)
        {
            
        }

        public SourceCodeInfoParamaterFactory(
            int codepartIndex,
            int hierarchyCount,
            TFactory factory)
        {
            this._codepartIndex = codepartIndex;
            this._hierarchyCount = hierarchyCount;
            this._factory = factory;
        }


        #endregion

        #region Property

        public int CodepartIndex
        {
            get { return this._codepartIndex; }
        }

        public int HierarchyCount
        {
            get { return this._hierarchyCount; }
        }

        public TFactory Factory
        {
            get { return this._factory; }
        }

        #endregion

        #region Method

        #region Public

        public TParamater GetSourceCodeInfoParamater(int codepartIndex, SourceCodePartsfactory factory, int hierarchyCount)
        {
            var retList = new List<TParamaterValue>();

            foreach (var paramaterValueString in factory.GetCodeParts())
            {
                retList.Add(this.GetSourceCodeInfoParamaterValue(codepartIndex, paramaterValueString, hierarchyCount));
                codepartIndex++;
            }

            return this.GetSourceCodeInfoParamater(retList.ToArray());
        }

        public TParamater GetSourceCodeInfoParamater()
        {
            return GetSourceCodeInfoParamater(this.CodepartIndex, this.Factory, this.HierarchyCount);
        }

        #endregion

        #region Private

        #endregion

        #region Protected

        protected TParamaterValue GetSourceCodeInfoParamaterValue(int codepartIndex, string paramaterValueString, int hierarchyCount)
        {
            var sourceCode = new SourceCode(paramaterValueString);
            var fac = this.GetSourceCodePartsFactoryParamaterValue(sourceCode);
            string paramaterString = string.Empty; 

            var retValue = this.GetSourceCodeInfoParamaterValueLogic(sourceCode, fac, out paramaterString);

            if (!string.IsNullOrEmpty(paramaterString))
            {
                retValue.ChildParamater = this.GetSourceCodeInfoParamater(codepartIndex, this.GetFactory(paramaterString), hierarchyCount + 1);    
            }

            return retValue;
        }

        

        #endregion

        #region Abstract

        protected abstract TParamaterValue GetSourceCodeInfoParamaterValueLogic(SourceCode sourceCode, SourceCodePartsfactory fac, out string paramaterString);
        protected abstract TParamater GetSourceCodeInfoParamater(TParamaterValue[] values);
        protected abstract TFactory GetFactory(string paramaterString);
        protected abstract SourceCodeInfoParamaterFactory<TParamaterValue, TParamater, TFactory> GetFactory(TParamaterValue[] values);
        // protected abstract TParamater GetChildParamater(int codepartIndex, TParamaterValue[] values);
        protected abstract SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(SourceCode sourceCode);

        #endregion

        #endregion
    }
}
