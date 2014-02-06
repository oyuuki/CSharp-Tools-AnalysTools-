using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

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

        public override NestIndex[] GetNestIndices()
        {
            throw new Exception("TODO：未実装");
        }

        #endregion

        #endregion
    }
}
