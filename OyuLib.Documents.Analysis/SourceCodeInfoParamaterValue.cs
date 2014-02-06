using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoParamaterValue : SourceCodeInfo        
    {
        #region instanceVal

        private int _parammaterName = -1;

        private int _hierarchyCount = -1;

        private SourceCodeInfoParamater _childparamater = null;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterValue(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int parammaterName, 
            int hierarchyCount)
            : base(code, coFac)
        {
            this._parammaterName = parammaterName;
            this._hierarchyCount = hierarchyCount;
        }

        #endregion

        #region Property

        public string ParammaterName
        {
            get { return this.GetCodePartsString(this._parammaterName); }
        }

        public int HierarchyCount
        {
            get { return this._hierarchyCount; }
        }

        public bool hasChild
        {
            get { return this._childparamater != null; }
        }

        public SourceCodeInfoParamater ChildParamater
        {
            get { return this._childparamater; }
            internal set { this._childparamater = value; }
        }

        protected  internal override StringRange[] GetCodeRanges()
        {
            if (this.hasChild)
            {
                return ArrayUtil.GetMargeArray(base.GetCodeRanges(), this.ChildParamater.GetStringRange());
            }
            else
            {
                return base.GetCodeRanges();
            }
        }


        #endregion

        #region Method

        #region Override

        public override NestIndex[] GetNestIndices()
        {
            var nestIndex = new NestIndex(this._parammaterName);

            if (this.hasChild)
            {
                nestIndex.Childs = this.ChildParamater.GetNestIndices();
            }

            return new NestIndex[]{ nestIndex };
        }

        protected override string GetCodeText()
        {
            return "パラメータ名：" + this.ParammaterName;
        }

        #endregion

        #endregion
    }
}
