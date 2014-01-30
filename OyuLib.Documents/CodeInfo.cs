using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public abstract class CodeInfo
    {
        #region instanceVal

        private Code _code = null;
        private CodePartsFactory _coFac = null;

        #endregion

        #region Constructor

        protected CodeInfo()
        {
               
        }

        protected CodeInfo(
            Code code,
            CodePartsFactory coFac)
        {
            this._code = code;
            this._coFac = coFac;
        }

        #endregion

        #region Property

        public string CodeString
        {
            get { return this._code.CodeString; }
        }

        #endregion

        #region Method

        #region Public

        protected string GetCodePartsString(int index)
        {
            if (index < 0)
            {
                return "(None)";
            }

            return this._coFac.GetCodeParts()[index];
        }

        public string[] CodeParts()
        {
            return this._coFac.GetCodeParts();
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return this.GetCodeText();
        }

        #endregion

        #region Abstract

        public abstract string GetCodeText();

        #endregion

        #endregion

    }
}
