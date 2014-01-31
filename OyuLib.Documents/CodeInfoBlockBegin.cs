using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public abstract class CodeInfoBlockBegin : CodeInfo
        
    {
        #region instanceVal

        private int _statement = -1;
        private int _statementObject = -1;

        #endregion

        #region Constructor

        public CodeInfoBlockBegin(
            int statement,
            int statementObject)
            : base()
        {
            this._statement = statement;
            this._statementObject = statementObject;
        }

        public CodeInfoBlockBegin(
            Code code,
            CodePartsFactory coFac,
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
        }

        public string StatementObject
        {
            get { return this.GetCodePartsString(this._statementObject); }
        }

        #endregion

        #region Method

        #region override

        public override string GetCodeText()
        {
            return "ステートメント：　　ステートメント名" + this.Statement + "関連オブジェクト：" + this.StatementObject;
        }

        #endregion

        public abstract Type GetCodeInfoBlockEndType();

        #endregion
    }
}
