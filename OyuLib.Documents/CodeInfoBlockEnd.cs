using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockEnd : CodeInfo
    {
        #region instanceVal

        private int _statement = -1;

        #endregion

        #region Constructor

        public CodeInfoBlockEnd()
            : base()
        {
            
        }

        public CodeInfoBlockEnd(
            Code code)
            : base(code)
        {

        }

        #endregion

        #region property

        public string Statement
        {
            get { return this.GetCodePartsString(this._statement); }
        }

        #endregion

        #region Method

        #region override

        public override string GetCodeText()
        {
            return "Endステートメント：";
        }

        #endregion

        #endregion
    }
}
