using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoBlockBeginMethod : CodeInfoBlockBegin
    {
        #region instanceVal

        private readonly int _accessModifier = -1;

        private readonly int _name = -1;

        private readonly int _returnTypeName = -1;

        private readonly int _paramaters = -1;

        private readonly string _codeDelimiterParamater = null;

        #endregion

        #region Constructor

        public CodeInfoBlockBeginMethod(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public CodeInfoBlockBeginMethod(
            Code code,
            CodePartsFactory coFac,
            string codeDelimiterParamater,
            int statement,
            int statementObject,
            int accessModifier,
            int name,
            int returnTypeName,
            int paramaters)
            : base(code, coFac, statement, statementObject)
        {
            this._accessModifier = accessModifier;
            this._name = name;
            this._returnTypeName = returnTypeName;
            this._paramaters = paramaters;
            this._codeDelimiterParamater = codeDelimiterParamater;
        }

        #endregion

        #region Property

        public string AccessModifier
        {
            get { return this.GetCodePartsString(this._accessModifier); }   
        }

        public string Name
        {
            get{ return this.GetCodePartsString(this._name); }
        }

        public string ReturnTypeName
        {
            get { return this.GetCodePartsString(this._returnTypeName); }   
        }


        public string ParamatersString
        {
            get { return this.GetCodePartsString(this._paramaters); }   
        }

        private string CodeDelimiterParamater
        {
            get { return this._codeDelimiterParamater; }
        }

        public StringRange[] Paramaters
        {
            get
            {
                var s = new StringSpilitter(this.ParamatersString);
                return  s.GetStringRangeSpilit(new CharCode(this.CodeDelimiterParamater).GetCharCodeString(), new ManagerStringNested("(", ")"));
            }
        }

        #endregion


        #region Method

        #region Override

        public override string GetCodeText()
        {
            return "メソッド名：" + this.Name + "アクセス修飾子" + this.AccessModifier + "戻り値型名：" + this.ReturnTypeName + " パラメータ：" + this.Paramaters + ParamatersString;
        }

        #endregion


        public override Type GetCodeInfoBlockEndType()
        {
            return typeof(CodeInfoBlockEndMethod);
        }

        #endregion
    }
}
