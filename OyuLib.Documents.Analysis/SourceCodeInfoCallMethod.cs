using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoCallMethod : SourceCodeInfo, IParamater
    {
        #region instanceVal

        /// <summary>
        /// calling Method Name
        /// </summary>
        private int _callmethodName = -1;

        /// <summary>
        /// 
        /// </summary>
        private readonly string _codeDelimiterParamater = null;


        private readonly int _paramater = -1;

        #endregion

        #region Constructor

        public SourceCodeInfoCallMethod()
            : base()
        {
            
        }

        public SourceCodeInfoCallMethod(
            SourceCode code,
            SourceCodePartsfactory coFac,
            string codeDelimiterParamater,
            int callmethodName,
            int paramater)
            : base(code, coFac)
        {

            this._codeDelimiterParamater = codeDelimiterParamater;
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

        private string CodeDelimiterParamater
        {
            get { return this._codeDelimiterParamater; }
        }

        public string ParamatersString
        {
            get { return this.GetCodePartsString(this._paramater); }
        }

        #endregion

        #region Method

        #region Public

        public StringRange[] GetStringRangesParamaters()
        {
            var s = new StringSpilitter(this.ParamatersString);
            return s.GetStringRangeSpilit(new CharCode(this.CodeDelimiterParamater).GetCharCodeString(), new ManagerStringNested("(", ")"));
        }

        #endregion

        #region override

        protected override string GetCodeText()
        {
            return "呼び出しメソッド名：" + this.CallmethodName + " パラメータ：" + this.GetStringRangesParamaters() + this.Paramater;
        }

        protected override int[] GetCodePartsIndex()
        {
            return new int[] { this._callmethodName, this._paramater };
        }

        #endregion

        #endregion

    }
}
