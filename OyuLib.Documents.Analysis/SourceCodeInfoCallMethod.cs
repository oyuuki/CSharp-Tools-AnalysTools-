using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoCallMethod : SourceCodeInfo, IParamater
    {
        #region instanceVal

        /// <summary>
        /// calling Method Name
        /// </summary>
        private int _callmethodName = -1;

        private readonly string _codeDelimiterParamater = null;

        private readonly int _paramater = -1;

        private readonly int _objName = -1;

        private SourceCodeInfoParamater _sourceCodeInfoParamaterValueMethod = null;

        private StringRange _range = null;

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
            SourceCodeInfoParamater sourceCodeInfoParamaterValueMethod,
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

        public string ParamaterString
        {
            get { return this.GetCodePartsString(this._paramater); }
            set { this.SetOverwriteValue(this._paramater, value); }
        }

        private string CodeDelimiterParamater
        {
            get { return this._codeDelimiterParamater; }
        }

        public StringRange Range 
        {
            get { return this._range; }
            set { this._range = value; }
        }

        #endregion

        #region Method

        #region override

        public SourceCodeInfoParamater GetSourceCodeInfoParamater()
        {
            return this._sourceCodeInfoParamaterValueMethod;
        }

        protected override string GetCodeText()
        {
            return "呼び出しメソッド名：" + this.CallmethodName + " パラメータ：" + this.GetSourceCodeInfoParamater();
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

        public override bool GetParamaterOverWriteValues(int index, ref StringBuilder strBu)
        {
            if (index == this._paramater)
            {
                strBu.Append(this.GetSourceCodeInfoParamater().GetParamaterOverWriteValues());
                return true;
            }

            return false;
        }

        #endregion

        #endregion

    }
}
