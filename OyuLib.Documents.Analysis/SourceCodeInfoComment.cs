using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoComment : SourceCodeInfo
    {
        #region Constructor

        public SourceCodeInfoComment()
            : base()
        {
            
        }

        public SourceCodeInfoComment(
            SourceCode code,
            SourceCodePartsfactory _coFac)
            : base(code, _coFac)
        {
            
        }

        #endregion

        #region Method

        #region override

        protected override string GetCodeText()
        {
            return "コメント：" + this.GetCodeString();
        }

        protected override int[] GetCodePartsIndex()
        {
            throw new Exception("TODO：未実装");
        }

        #endregion

        #endregion
    }
}
