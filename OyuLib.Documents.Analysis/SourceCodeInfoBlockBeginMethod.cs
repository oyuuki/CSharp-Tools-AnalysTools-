using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using OyuLib.Collection;

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

        private int _paramater = -1;

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
            SourceCodeInfoParamaterMethod sourceCodeInfoParamaterValueMethod,
            int paramater)
            : base(code, coFac, statement, statementObject)
        {
            this._accessModifier = accessModifier;
            this._name = name;
            this._returnTypeName = returnTypeName;
            this._codeDelimiterParamater = codeDelimiterParamater;
            this._sourceCodeInfoParamaterValueMethod = sourceCodeInfoParamaterValueMethod;
            this._paramater = paramater;
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


        public SourceCodeInfoParamaterMethod Paramaters
        {

            get { return this._sourceCodeInfoParamaterValueMethod; }   
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
                " パラメータ：" + Paramaters;
        }

        public override Type GetCodeInfoBlockEndType()
        {
            return typeof(SourceCodeInfoBlockEndMethod);
        }

        protected internal override StringRange[] GetCodeRanges()
        {
            var stringRange = base.GetCodeRanges();

            stringRange[this._paramater].Childs = new StringRange[] {this.Paramaters.GetStringRange()};

            return stringRange;
        }

        public override NestIndex[] GetNestIndices()
        {
            var retList = new List<NestIndex>();

            retList.Add(new NestIndex(this._accessModifier));
            retList.Add(new NestIndex(this._name));
            retList.Add(new NestIndex(this._returnTypeName));

            var paramNestIndex = new NestIndex(this._paramater, this._paramater, this._paramater);

            paramNestIndex.Childs = this.Paramaters.GetNestIndices();

            retList.Add(paramNestIndex);

            return retList.ToArray();
        }

        #endregion

        #endregion
    }
}
