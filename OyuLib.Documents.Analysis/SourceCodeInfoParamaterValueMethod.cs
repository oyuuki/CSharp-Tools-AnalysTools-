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

        public int TypeName
        {
            get { return this._typeName; }
        }

        #endregion

        #region Method

        #region Public




        #endregion

        #region Override

        protected override NestIndex GetNestIndex()
        {
            return new NestIndex(this.TypeName, this.HierarchyCount, this.ParentIndex);
        }

        protected override string GetCodeText()
        {
            return "パラメータ名：" + this.ParammaterName;
        }

        #endregion

        #endregion
    }
}
