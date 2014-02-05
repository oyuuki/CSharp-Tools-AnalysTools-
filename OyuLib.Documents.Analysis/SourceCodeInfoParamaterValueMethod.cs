using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            int parammaterName, 
            int hierarchyCount,
            int typeName)
            : base(code, coFac, parammaterName, hierarchyCount)
        {
            this._typeName = typeName;
        }

        #endregion

        #region Property

        public string TypeName
        {
            get { return this.GetCodePartsString(this._typeName); }
        }

        #endregion

        #region Method

        #region Public




        #endregion

        #region Override

        protected override int[] GetCodePartsIndex()
        {
            return ArrayUtil.GetMargeArray<int>(new[] {this._typeName}, base.GetCodePartsIndex());
        }

        protected override string GetCodeText()
        {
            return "パラメータ名：" + this.ParammaterName;
        }

        #endregion

        #endregion
    }
}
