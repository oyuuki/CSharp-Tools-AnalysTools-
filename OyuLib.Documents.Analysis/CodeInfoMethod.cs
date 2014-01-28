using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    public class CodeInfoMethod : CodeInfo
    {
        #region instanceVal

        private readonly int _accessModifier = -1;

        private readonly int _name = -1;

        private readonly int _returnTypeName = -1;

        private CodeInfoValiable[] _paramValiables = null;

        #endregion

        #region Constructor

        public CodeInfoMethod()
            : base()
        {
            
        }

        public CodeInfoMethod(
            Code code,
            int accessModifier,
            int name,
            int returnTypeName,
            CodeInfoValiable[] paramValiables)
            : base(code)
        {
            this._accessModifier = accessModifier;
            this._name = name;
            this._returnTypeName = returnTypeName;
            this._paramValiables = paramValiables;
        }

        public CodeInfoMethod(
            string codeLine,
            string codeDelimiter,
            int accessModifier,
            int name,
            int returnTypeName,
            CodeInfoValiable[] paramValiables)
            : base(codeLine, codeDelimiter)
        {
            this._accessModifier = accessModifier;
            this._name = name;
            this._returnTypeName = returnTypeName;
            this._paramValiables = paramValiables;
        }

        #endregion

        #region Property

        public string AccessModifier
        {
            get { return this.GetCodePartsString(this._accessModifier); }   
        }

        public string Name
        {

            get
            {
                var locName = this.GetCodePartsString(this._name); 

                return locName.Substring(0, locName.IndexOf("("));
            }
        }

        public string ReturnTypeName
        {
            get { return this.GetCodePartsString(this._returnTypeName); }   
        }


        public CodeInfoValiable[] ParamValiables
        {
            get { return this._paramValiables; }
            set { this._paramValiables = value; }
        }

        #endregion

        #region Method

        #region Override

        public override string GetCodeText()
        {
            return "メソッド名：" + this.Name + "アクセス修飾子" + this.AccessModifier + "戻り値型名：" + this.ReturnTypeName + this.Code.CodeString;
        }

        #endregion

        public override CodeInfo GetCodeInfo()
        {
            throw new NotImplementedException();
        }

        public override bool IsCodeInfo()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
