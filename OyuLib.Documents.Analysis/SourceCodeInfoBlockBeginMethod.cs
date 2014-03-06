﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginMethod : SourceCodeInfoBlockBegin, IParamater
    {
        #region instanceVal

        private readonly int _accessModifier = -1;

        private readonly int _name = -1;

        private readonly int _returnTypeName = -1;

        private readonly string _codeDelimiterParamater = null;

        private SourceCodeInfoParamater _sourceCodeInfoParamaterValueMethod = null;

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
            SourceCodeInfoParamater sourceCodeInfoParamaterValueMethod,
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
            set { this.SetOverwriteValue(this._accessModifier, value); }
        }

        public string Name
        {
            get{ return this.GetCodePartsString(this._name); }
            set { this.SetOverwriteValue(this._name, value); }
        }

        public string ReturnTypeName
        {
            get { return this.GetCodePartsString(this._returnTypeName); }
            set { this.SetOverwriteValue(this._returnTypeName, value); }
        }

        public StringRange Range
        {
            get { return null; }
            set { return; }
        }

        public SourceCodeInfoParamater[] GetSourceCodeInfoParamaters()
        {
            return new SourceCodeInfoParamater[] { this.Paramater };
        }

        protected SourceCodeInfoParamater Paramater
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

        public bool GetIsOverWriteParamater()
        {
            foreach (var param in this.GetSourceCodeInfoParamaters())
            {
                foreach (var codeinfo in param.GetAllSourceCodeInfos())
                {
                    if (codeinfo.IsOverWrite())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected override string GetCodeText()
        {
            return "メソッド名：" + this.Name + 
                "アクセス修飾子" + this.AccessModifier + 
                "戻り値型名：" + this.ReturnTypeName + 
                " パラメータ：" + Paramater;
        }

        public override Type GetCodeInfoBlockEndType()
        {
            return typeof(SourceCodeInfoBlockEndMethod);
        }

        protected internal override StringRange[] GetCodeRanges()
        {
            var stringRange = base.GetCodeRanges();

            stringRange[this._paramater].Childs = this.Paramater.GetStringRange();

            return stringRange;
        }

        public override NestIndex[] GetNestIndices()
        {
            var retList = new List<NestIndex>();

            retList.Add(new NestIndex(this._accessModifier));
            retList.Add(new NestIndex(this._name));
            retList.Add(new NestIndex(this._returnTypeName));

            var paramNestIndex = new NestIndex(this._paramater);

            paramNestIndex.Childs = this.Paramater.GetNestIndex();

            retList.Add(paramNestIndex);

            return retList.ToArray();
        }

        public override bool GetParamaterOverWriteValues(int index, ref StringBuilder strBu)
        {
            if (index == this._paramater)
            {
                strBu.Append(this.GetSourceCodeInfoParamaters()[0].GetParamaterOverWriteValues());
                return true;
            }

            return false;
        }

        #endregion

        #endregion
    }
}
