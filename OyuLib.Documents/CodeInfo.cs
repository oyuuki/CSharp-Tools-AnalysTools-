using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public abstract class CodeInfo<T>
        where T : Code, new()
    {
        #region instanceVal

        private T _code = null;

        #endregion

        #region Constructor

        protected CodeInfo()
        {
               
        }

        protected CodeInfo(T code)
        {
            this._code = code;
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

            return this._code.CodeParts()[index];
        }

        public string[] CodeParts()
        {
            return this._code.CodeParts();
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
