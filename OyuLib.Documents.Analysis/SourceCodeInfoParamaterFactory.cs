using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoParamaterFactory<TParamaterValue, TParamater>
        where TParamaterValue : SourceCodeInfoParamaterValue
        where TParamater : SourceCodeInfoParamater
    {
        #region InstanceVal
        
        private int _hierarchyCount = -1;

        private SourceCodePartsfactory _factory = null;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterFactory(
            SourceCodePartsfactory factory)
            : this(0, factory)
        {
            
        }

        public SourceCodeInfoParamaterFactory(
            int hierarchyCount,
            SourceCodePartsfactory factory)
        {
            this._hierarchyCount = hierarchyCount;
            this._factory = factory;
        }


        #endregion

        #region Property

        public int HierarchyCount
        {
            get { return this._hierarchyCount;  }
        }

        #endregion

        #region Method

        #region Public

        public TParamater GetSourceCodeInfoParamater()
        {
            var retList = new List<TParamaterValue>();

            foreach (var paramaterValueString in this.GetSourceCodePartsFactory().GetCodeParts())
            {
                retList.Add(this.GetSourceCodeInfoParamaterValue(paramaterValueString));
            }

            return this.GetSourceCodeInfoParamater(retList.ToArray());
        }

        #endregion

        #region Private

        protected SourceCodePartsfactory GetSourceCodePartsFactory()
        {
            return this._factory;
        }

        #endregion

        #region Protected

        protected TParamaterValue GetSourceCodeInfoParamaterValue(string paramaterValueString)
        {
            var sourceCode = new SourceCode(paramaterValueString);
            var fac = this.GetSourceCodePartsFactoryParamaterValue(sourceCode);
            string paramaterString = string.Empty; 

            var retValue = this.GetSourceCodeInfoParamaterValueLogic(sourceCode, fac, out paramaterString);
            return retValue;
        }

        

        #endregion

        #region Abstract

        protected abstract TParamaterValue GetSourceCodeInfoParamaterValueLogic(SourceCode sourceCode, SourceCodePartsfactory fac, out string paramaterString);
        protected abstract TParamater GetSourceCodeInfoParamater(TParamaterValue[] values);
        protected abstract SourceCodePartsfactory GetSourceCodePartsFactoryParamaterValue(SourceCode sourceCode);

        #endregion

        #endregion
    }
}
