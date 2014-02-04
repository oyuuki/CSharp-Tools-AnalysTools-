using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoOther : SourceCodeInfo
    {
        #region Constructor

        public SourceCodeInfoOther()
        {
               
        }

        public SourceCodeInfoOther(
            SourceCode code,
            SourceCodePartsfactory _coFac)
            : base(code, _coFac)
        {
        }

        #endregion

        #region Method

        #region Override

        protected override string GetCodeText()
        {
            return "その他コード：" + this.CodeString;
        }

        protected override int[] GetCodePartsIndex()
        {
            throw new Exception("TODO：未実装");
        }

        #endregion

        #endregion
    }
}
