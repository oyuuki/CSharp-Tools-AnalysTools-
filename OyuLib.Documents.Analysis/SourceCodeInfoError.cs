using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoError : SourceCodeInfo
    {
        #region Constructor

        public SourceCodeInfoError()
        {
               
        }

        public SourceCodeInfoError(
            SourceCode code,
            SourceCodePartsfactory _coFac)
            : base(code, _coFac)
        {
        }

        public SourceCodeInfoError(
            SourceCode code)
            : base(code, new SourceCodePartsfactoryNocomment(code, " "))
        {
        }

        #endregion

        #region Method

        #region Override

        protected override string GetCodeText()
        {
            return "その他コード：" + this.GetCodeString();
        }

        public override NestIndex[] GetNestIndices()
        {
            throw new Exception("TODO：未実装");
        }
        

        #endregion

        #endregion
    }
}
