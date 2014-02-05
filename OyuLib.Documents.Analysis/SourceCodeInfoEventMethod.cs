using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginEventMethod : SourceCodeInfoBlockBeginMethod
    {
        #region instanceVal

        private readonly int _eventObjectName = -1;

        private readonly int _eventName = -1;

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
            SourceCodeInfoParamaterMethod sourceCodeInfoParamaterValueMethod)
            : base(code, coFac, CodeDelimiterParamater, statement, statementObject, accessModifier, name, returnTypeName, sourceCodeInfoParamaterValueMethod)
        {
            this._eventObjectName = eventObjectName;
            this._eventName = eventName;
        }


        #endregion

        #region Property

        public string EventObjectName
        {
            get { return this.GetCodePartsString(this._eventObjectName); }
        }

        public string EventName
        {
            get { return this.GetCodePartsString(this._eventName); }
        }

        #endregion

        #region Method

        #region override

        protected override string GetCodeText()
        {
            return "イベントメソッド名：" + this.Name + "アクセス修飾子" + this.AccessModifier + "イベント名：" + this.EventName +
                   "イベント発生オブジェクト名：" + this.EventObjectName + "パラメータ名：" + ParamatersString;
        }

        protected override int[] GetCodePartsIndex()
        {
            return ArrayUtil.GetMargeArray<int>(new[] { this._eventObjectName, this._eventName }, base.GetCodePartsIndex());
        }

        #endregion

        #endregion

    }
}
