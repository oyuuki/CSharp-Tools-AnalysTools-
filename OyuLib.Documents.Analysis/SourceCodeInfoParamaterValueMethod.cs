using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoParamaterValueMethod : SourceCodeInfoParamaterValue
    {
        #region instanceVal

        private int _typeName = -1;

        #endregion

        #region Constructor
        public SourceCodeInfoParamaterValueMethod(
            SourceCode code,
            SourceCodePartsfactory coFac,
            StringRange range,
            int parammaterName,
            int parentIndex,
            int hierarchyCount,
            int typeName)
            : base(code, coFac, range, parammaterName, parentIndex, hierarchyCount)
        {
            this._typeName = typeName;
        }

        #endregion

        #region Property

        protected   int TypeNameIndex
        {
            get { return this._typeName; }
        }

        public string TypeName
        {
            get { return this.GetCodePartsString(this._typeName); }
            set { this.SetOverwriteValue(this._typeName, value); }
        }

        #endregion

        #region Method

        #region Public




        #endregion

        #region Override

        public override NestIndex[] GetNestIndices()
        {
            return ArrayUtil.GetMargeArray<NestIndex>(
                base.GetNestIndices(),
                new NestIndex[] { new NestIndex(this.TypeNameIndex, this.HierarchyCountIndex, this.ParentIndexIndex) });
        }

        protected override string GetCodeText()
        {
            return "パラメータ名：" + this.ParammaterNameIndex;
        }

        #endregion

        #endregion
    }
}
