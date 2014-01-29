using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoCallMethod: CodeInfo
    {
        #region instanceVal

        /// <summary>
        /// calling Method Name
        /// </summary>
        private int _callmethodName = -1;

        /// <summary>
        /// 
        /// </summary>
        private int _paramater = -1;

        #endregion

        #region Constructor

        public CodeInfoCallMethod()
            : base()
        {
            
        }

        public CodeInfoCallMethod(
            Code code,
            int callmethodName,
            int paramater)
            : base(code)
        {
            this._callmethodName = callmethodName;
            this._paramater = paramater;
        }

        public CodeInfoCallMethod(
            string codeLine,
            string codeDelimiter,
            int callmethodName,
            int paramater)
            : base(codeLine, codeDelimiter)
        {
            this._callmethodName = callmethodName;
            this._paramater = paramater;
        }

        #endregion

        #region property

        public string CallmethodName
        {
            get { return this.GetCodePartsString(this._callmethodName); }
        }

        public string Paramater
        {
            get { return this.GetCodePartsString(this._paramater); }
        }

        #endregion

        #region Method

        #region override

        public override string GetCodeText()
        {
            return "呼び出しメソッド名：" + this.Code.CodeString;
        }

        #endregion

        #endregion

    }
}
