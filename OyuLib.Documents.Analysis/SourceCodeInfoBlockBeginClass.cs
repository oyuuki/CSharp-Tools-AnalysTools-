using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public class SourceCodeInfoBlockBeginClass : SourceCodeInfoBlockBegin
    {
         #region instanceVal

        private readonly int _accessModifier = -1;

        private readonly int _name = -1;

        #endregion

        #region Constructor

        public SourceCodeInfoBlockBeginClass(
            int statement,
            int statementObject)
            : base(statement, statementObject)
        {
            
        }

        public SourceCodeInfoBlockBeginClass(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement,
            int statementObject,
            int accessModifier,
            int name)
            : base(code, coFac, statement, statementObject)
        {
            this._accessModifier = accessModifier;
            this._name = name;
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

        #endregion

        #region Method

        #region Override

        protected override string GetCodeText()
        {
            return "クラス名：" + this.Name + 
                "アクセス修飾子" + this.AccessModifier;
        }

        public override Type GetCodeInfoBlockEndType()
        {
            return typeof(SourceCodeInfoBlockEndClass);
        }

        public override NestIndex[] GetNestIndices()
        {
            var retList = new List<NestIndex>();

            retList.Add(new NestIndex(this._accessModifier));
            retList.Add(new NestIndex(this._name));

            return retList.ToArray();
        }

        #endregion

        #endregion
    }
}
