using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoBlockEnd : SourceCodeInfo
    {
        #region instanceVal

        private int _statement = -1;

        #endregion

        #region Constructor

        public SourceCodeInfoBlockEnd(int statement)
            : base()
        {
            this._statement = statement;
        }

        public SourceCodeInfoBlockEnd(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement)
            : base(code, coFac)
        {
            this._statement = statement;
        }

        #endregion

        #region property

        public string Statement
        {
            get { return this.GetCodePartsString(this._statement); }
        }

        #endregion

        #region Method

        protected override string GetCodeText()
        {
            return "ブロック終了：" + this.Statement;
        }

        #endregion
    }
}
