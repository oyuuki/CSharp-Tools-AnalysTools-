﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoValiable : SourceCodeInfo
    {
        #region instanceVal

        private readonly int _value = -1;

        private readonly int _name = -1;

        private readonly int _typeName = -1;

        private bool _isConst = false;

        #endregion

        #region Constructor

        public SourceCodeInfoValiable()
            : base()
        {
            
        }

        public SourceCodeInfoValiable(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int value,
            int name,
            int typeName,
            bool isConst)
            : base(code, coFac)
        {
            this._value = value;
            this._name = name;
            this._typeName = typeName;
            this._isConst = isConst;
        }

        #endregion

        #region Property

        public string Value
        {
            get { return this.GetCodePartsString(this._value); }
            set { this.SetOverwriteValue(this._value, value); }
        }

        public string Name
        {
            get { return this.GetCodePartsString(this._name); }
            set { this.SetOverwriteValue(this._name, value); }
        }

        public string TypeName
        {
            get { return this.GetCodePartsString(this._typeName); }
            set { this.SetOverwriteValue(this._typeName, value); }
        }

        public bool IsConst
        {
            get { return this._isConst; }   
        }

        #endregion

        #region Method

        #region Override

        protected override string GetCodeText()
        {
            return "ローカル変数名：" + this.Name + "値：" + this.Value + "型名：" + this.TypeName + "CONST?" + this.IsConst;
        }

        public override NestIndex[] GetNestIndices()
        {
            return new NestIndex[]
            {
                new NestIndex(this._value),
                new NestIndex(this._name),
                new NestIndex(this._typeName)
            };
        }

        #endregion

        #endregion
    }
}
