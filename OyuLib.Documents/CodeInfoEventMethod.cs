﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockBeginEventMethod : CodeInfoBlockBeginMethod
    {
        #region instanceVal

        private readonly int _eve = -1;

        #endregion

        #region Constructor

        public CodeInfoBlockBeginEventMethod(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public CodeInfoBlockBeginEventMethod(
            Code code,
            CodePartsFactory coFac,
            string CodeDelimiterParamater,
            int statement,
            int statementObject,
            int accessModifier,
            int name,
            int returnTypeName,
            int paramaters,
            int eve)
            : base(code, coFac,CodeDelimiterParamater, statement, statementObject, accessModifier, name, returnTypeName, paramaters)
        {
            this._eve = eve;
        }

        #endregion

        #region Property

        public string ObjNamesuggestEventName
        {
            get { return this.GetEventString()[0]; }
        }

        public string EventName
        {
            get { return this.GetEventString()[1]; }
        }

        #endregion

        #region Method


        private string[] GetEventString()
        {
            return
                new CharCodeManager(new CharCode(".")).GetSpilitString(
                    this.GetCodePartsString(this._eve));
        }

        #region override

        public override string GetCodeText()
        {

            if (this.Paramaters[0].Childs != null)
            {
                int a = 1;
            }

            return "イベントメソッド名：" + this.Name + "アクセス修飾子" + this.AccessModifier + "イベント名：" + this.EventName +
                   "イベント発生オブジェクト名：" + this.ObjNamesuggestEventName  + "パラメータ名：" + this.Paramaters + ParamatersString;
        }

        #endregion

        #endregion

    }
}
