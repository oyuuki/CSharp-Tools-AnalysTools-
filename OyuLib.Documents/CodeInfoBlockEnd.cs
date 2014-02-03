using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public abstract class CodeInfoBlockEnd : CodeInfo
    {
        #region instanceVal

        private int _statement = -1;

        #endregion

        #region Constructor

        public CodeInfoBlockEnd(int statement)
            : base()
        {
            this._statement = statement;
        }

        public CodeInfoBlockEnd(
            Code code,
            CodePartsFactory coFac,
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
