using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OyuLib.Collection;

namespace OyuLib.Documents.Sources.Analysis
{
    public abstract class SourceCodeInfoBlockBegin : SourceCodeInfo
        
    {
        #region instanceVal

        private int _statement = -1;
        private int _statementObject = -1;

        #endregion

        #region Constructor

        public SourceCodeInfoBlockBegin(
            int statement,
            int statementObject)
            : base()
        {
            this._statement = statement;
            this._statementObject = statementObject;
        }

        public SourceCodeInfoBlockBegin(
            SourceCode code,
            SourceCodePartsfactory coFac,
            int statement,
            int statementObject)
            : base(code, coFac)
        {
            this._statement = statement;
            this._statementObject = statementObject;   
        }

        #endregion

        #region property        

        public string Statement
        {
            get { return this.GetCodePartsString(this._statement); }
            set { this.SetOverwriteValue(this._statement, value); }
        }

        public string StatementObject
        {
            get { return this.GetCodePartsString(this._statementObject); }
            set { this.SetOverwriteValue(this._statementObject, value); }
        }

        #endregion

        #region Method

        #region override

        protected override string GetCodeText()
        {           
            return "ステートメント：　　ステートメント名" + this.Statement + "関連オブジェクト：" + this.StatementObject;
        }

        #endregion

        public abstract Type GetCodeInfoBlockEndType();

        public override NestIndex[] GetNestIndices()
        {
            return new NestIndex[]
            {
                new NestIndex(this._statement),
                new NestIndex(this._statementObject)
            };
        }

        #endregion
    }
}
