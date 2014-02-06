﻿using System;
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
            SourceCodeInfoParamaterMethod sourceCodeInfoParamaterValueMethod)
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
                   "イベント発生オブジェクト名：" + this.EventObjectName + "パラメータ名：" + Paramaters;
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

        #endregion

        #endregion

    }
}
