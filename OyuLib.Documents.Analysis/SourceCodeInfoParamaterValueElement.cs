﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterValueElement : SourceCodeInfo        
    {
        #region instanceVal

        private int _parammaterName = -1;

        private int _hierarchyCount = -1;

        private int _parentIndex = -1;

        private StringRange _range = null;

        #endregion

        #region Constructor

        public SourceCodeInfoParamaterValueElement(
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

        protected int ParammaterNameIndex
        {
            get { return this._parammaterName; }            
        }

        protected int HierarchyCountIndex
        {
            get { return this._hierarchyCount; }
        }
        protected int ParentIndexIndex
        {
            get { return this._parentIndex; }
        }

        public string ParamaterName
        {
            get { return this.GetCodePartsString(this._parammaterName); }
            set { this.SetOverwriteValue(this._parammaterName, value); }
        }

        public string HierarchyCount
        {
            get { return this.GetCodePartsString(this._hierarchyCount); }
        }
        public string ParentIndex
        {
            get { return this.GetCodePartsString(this._parentIndex); }
        }

        
        public string BefSymbol
        {
            get { return this.Range.SpilitSeparatorStart; }
        }

        public string AetSymbol
        {
            get { return this.Range.SpilitSeparatorEnd; }
        }

        internal StringRange Range
        {
            get { return this._range; }
        }

        

        #endregion

        #region Method

        #region Public

        public void DeleteBefSymbol()
        {
            this.Range.SpilitSeparatorStart = string.Empty;            
        }

        public void DeleteAftSymbol()
        {
            this.Range.SpilitSeparatorEnd = string.Empty;
        }

        #endregion

        #region Override

        public override NestIndex[] GetNestIndices()
        {
            return new NestIndex[] { new NestIndex(this.ParammaterNameIndex, this.HierarchyCountIndex, this.ParentIndexIndex)}; 
        }

        protected override string GetCodeText()
        {
            return "パラメータ名：" + this.ParammaterNameIndex;
        }

        #endregion

        #endregion
    }
}
