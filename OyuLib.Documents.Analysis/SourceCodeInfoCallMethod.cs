using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoCallMethod : SourceCodeInfo
    {
        #region instanceVal

        /// <summary>
        /// calling Method Name
        /// </summary>
        private int _callmethodName = -1;

        private readonly string _codeDelimiterParamater = null;

        private readonly int _paramater = -1;

        private readonly int _objName = -1;

        private SourceCodeInfoParamaterMethod _sourceCodeInfoParamaterValueMethod = null;

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
            int objName,
            SourceCodeInfoParamaterMethod sourceCodeInfoParamaterValueMethod,
            int paramater)
            : base(code, coFac)
        {

            this._codeDelimiterParamater = codeDelimiterParamater;
            this._callmethodName = callmethodName;
            this._paramater = paramater;
            this._sourceCodeInfoParamaterValueMethod = sourceCodeInfoParamaterValueMethod;
            this._objName = objName;
        }

        #endregion

        #region property

        public string CallmethodName
        {
            get { return this.GetCodePartsString(this._callmethodName); }
            set { this.SetOverwriteValue(this._callmethodName, value); }
        }

        public string ObjName
        {
            get { return this.GetCodePartsString(this._objName); }
            set { this.SetOverwriteValue(this._objName, value); }
        }

        public string Paramater
        {
            get { return this.GetCodePartsString(this._paramater); }
            set { this.SetOverwriteValue(this._paramater, value); }
        }

        private string CodeDelimiterParamater
        {
            get { return this._codeDelimiterParamater; }
        }

        protected SourceCodeInfoParamaterMethod Paramaters
        {
            get { return this._sourceCodeInfoParamaterValueMethod; }
        }

        #endregion

        #region Method

        #region override

        protected override string GetCodeText()
        {
            return "呼び出しメソッド名：" + this.CallmethodName + " パラメータ：" + this.Paramater;
        }

        public override NestIndex[] GetNestIndices()
        {
            return new NestIndex[]
            {
                new NestIndex(this._callmethodName),
                new NestIndex(this._objName),
                new NestIndex(this._paramater)
            };
        }

        #endregion

        #endregion

    }
}
