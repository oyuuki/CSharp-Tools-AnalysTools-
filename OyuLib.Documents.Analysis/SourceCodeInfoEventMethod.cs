using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginEventMethod : SourceCodeInfoBlockBeginMethod
    {
        #region instanceVal

        private readonly int _eventObjectName = -1;

        private readonly int _eventName = -1;

        private bool _isDeleteHandles = false;

        #endregion

        #region Constructor

        public SourceCodeInfoBlockBeginEventMethod(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public SourceCodeInfoBlockBeginEventMethod(
            SourceCode code,
            SourceCodePartsfactory coFac,
            string CodeDelimiterParamater,
            int statement,
            int statementObject,
            int accessModifier,
            int name,
            int returnTypeName,
            int eventObjectName,
            int eventName,
            int paramater,
            SourceCodeInfoParamater sourceCodeInfoParamaterValueMethod)
            : base(code, coFac, CodeDelimiterParamater, statement, statementObject, accessModifier, name, returnTypeName, sourceCodeInfoParamaterValueMethod, paramater)
        {
            this._eventObjectName = eventObjectName;
            this._eventName = eventName;
        }


        #endregion

        #region Property

        public string EventObjectName
        {
            get { return this.GetCodePartsString(this._eventObjectName); }
            set { this.SetOverwriteValue(this._eventObjectName, value); }
        }

        public string EventName
        {
            get { return this.GetCodePartsString(this._eventName); }
            set { this.SetOverwriteValue(this._eventName, value); }
        }

        public bool IsDeleteHandles
        {
            get { return this._isDeleteHandles; }
            set { this._isDeleteHandles = value; }
        }


        #endregion

        #region Method

        #region override

        protected override string GetCodeText()
        {
            return "イベントメソッド名：" + this.Name + "アクセス修飾子" + this.AccessModifier + "イベント名：" + this.EventName +
                   "イベント発生オブジェクト名：" + this.EventObjectName + "パラメータ名：" + Paramater;
        }

        public override NestIndex[] GetNestIndices()
        {
            return ArrayUtil.GetMargeArray(base.GetNestIndices(),

                new NestIndex[]
                {
                    new NestIndex(this._eventObjectName),
                    new NestIndex(this._eventName)
                });
        }

        public override string GetCodePartsOverWriteValues()
        {
            string code =  base.GetCodePartsOverWriteValues();

            if(this.IsDeleteHandles)
            {
                code = code.Substring(0, code.IndexOf("Handles")); 
            }

            return code;
        }

        #endregion

        #endregion

    }
}
