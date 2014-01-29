using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoMemberVariable : CodeInfoValiable
    {
        #region instanceVal

        private readonly int _accessModifier = -1;

        #endregion

        #region Constructor

        public CodeInfoMemberVariable()
            : base()
        {
            
        }

        public CodeInfoMemberVariable(
            Code code,
            int value,
            int name,
            int typeName,
            int accessModifiers,
            bool isConst)
            : base(code, value, name, typeName, isConst)
        {
            this._accessModifier = accessModifiers;
        }

        public CodeInfoMemberVariable(
            string codeString,
            string codeDelimiter,
            int value,
            int name,
            int typeName,
            int accessModifiers,
            bool isConst)
            : base(codeString, codeDelimiter, value, name, typeName, isConst)
        {
            this._accessModifier = accessModifiers;
        }

        #endregion

        #region Property

        public string AccessModifier
        {
            get { return this.GetCodePartsString(this._accessModifier); }   
        }

        #endregion

        #region Method

        #region Override

        public override string GetCodeText()
        {
            return "メンバ変数名：" +  this.Name + " アクセス修飾子" + this.AccessModifier + " 値：" + this.Value + "型名：" + this.TypeName + "CONST?" + this.IsConst;
        }

        #endregion

        #endregion
    }
}
