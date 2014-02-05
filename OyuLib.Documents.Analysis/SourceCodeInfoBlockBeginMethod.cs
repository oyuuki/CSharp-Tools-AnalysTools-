using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginMethod : SourceCodeInfoBlockBegin
    {
        #region instanceVal

        private readonly int _accessModifier = -1;

        private readonly int _name = -1;

        private readonly int _returnTypeName = -1;

        private readonly string _codeDelimiterParamater = null;

        private SourceCodeInfoParamaterMethod _sourceCodeInfoParamaterValueMethod = null;

        #endregion

        #region Constructor

        public SourceCodeInfoBlockBeginMethod(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public SourceCodeInfoBlockBeginMethod(
            SourceCode code,
            SourceCodePartsfactory coFac,
            string codeDelimiterParamater,
            int statement,
            int statementObject,
            int accessModifier,
            int name,
            int returnTypeName,
            SourceCodeInfoParamaterMethod sourceCodeInfoParamaterValueMethod)
            : base(code, coFac, statement, statementObject)
        {
            this._accessModifier = accessModifier;
            this._name = name;
            this._returnTypeName = returnTypeName;
            this._codeDelimiterParamater = codeDelimiterParamater;
            this._sourceCodeInfoParamaterValueMethod = sourceCodeInfoParamaterValueMethod;
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
            get
            {
                StringBuilder strBr = new StringBuilder();

                foreach (var value in this._sourceCodeInfoParamaterValueMethod.GetSourceCodeInfoParamaterValue())
                {
                    strBr.Append("[" + value.ParammaterName + "]");
                }

                return strBr.ToString();
            }   
        }

        private string CodeDelimiterParamater
        {
            get { return this._codeDelimiterParamater; }
        }

        #endregion


        #region Method

        #region Override

        protected override string GetCodeText()
        {
            return "メソッド名：" + this.Name + 
                "アクセス修飾子" + this.AccessModifier + 
                "戻り値型名：" + this.ReturnTypeName + 
                " パラメータ：" + ParamatersString;
        }

        public override Type GetCodeInfoBlockEndType()
        {
            return typeof(SourceCodeInfoBlockEndMethod);
        }

        protected override int[] GetCodePartsIndex()
        {
            return new int[] { this._accessModifier, this._name, this._returnTypeName };
        }

        #endregion

        #endregion
    }
}
