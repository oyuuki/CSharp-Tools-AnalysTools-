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

        private int _parentIndex = -1;

        private StringRange _range = null;

        private SourceCodeInfoParamater _childparamater = null;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterValue(
            SourceCode code,
            SourceCodePartsfactory coFac,
            StringRange range,
            int parammaterName, 
            int parentIndex,
            int hierarchyCount)
            : base(code, coFac)
        {
            this._parammaterName = parammaterName;
            this._hierarchyCount = hierarchyCount;
            this._parentIndex = parentIndex;
            this._range = range;

            this.Range.Childs = GetCodeRanges();
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
        public int ParentIndex
        {
            get { return this._parentIndex; }
        }

        public bool hasChild
        {
            get { return this._childparamater != null; }
        }

        internal StringRange Range
        {
            get { return this._range; }
        }

        public SourceCodeInfoParamater ChildParamater
        {
            get { return this._childparamater; }
            internal set { this._childparamater = value; }
        }

        #endregion

        #region Method

        #region Public

        public NestIndex GetNestIndix()
        {
            NestIndex nestIndxIndex = this.GetNestIndex();

            NestIndex[] childs = null;

            if (this.hasChild)
            {
                childs = this.ChildParamater.GetNestIndices();
            }

            nestIndxIndex.Childs = childs;

            return nestIndxIndex;
        }


        #endregion

        #region Abstract

        protected abstract NestIndex GetNestIndex();
        
        #endregion

        #region Override

        public override NestIndex[] GetNestIndices()
        {
            throw new Exception("使用できません");
        }

        protected override string GetCodeText()
        {
            return "パラメータ名：" + this.ParammaterName;
        }

        protected internal override StringRange[] GetCodeRanges()
        {
            StringRange[] childs = null;

            if (this.hasChild)
            {
                childs = ArrayUtil.GetMargeArray(base.GetCodeRanges(), new StringRange[] { this.ChildParamater.GetStringRange() });
            }
            else
            {
                childs = base.GetCodeRanges();
            }

            return childs;
        }

        #endregion

        #endregion
    }
}
