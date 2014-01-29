using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoValiable : CodeInfo
    {
        #region instanceVal

        private readonly int _value = -1;

        private readonly int _name = -1;

        private readonly int _typeName = -1;

        private bool _isConst = false;

        #endregion

        #region Constructor

        public CodeInfoValiable()
            : base()
        {
            
        }

        public CodeInfoValiable(
            Code code,
            int value,
            int name,
            int typeName,
            bool isConst)
            : base(code)
        {
            this._value = value;
            this._name = name;
            this._typeName = typeName;
            this._isConst = isConst;
        }

        public CodeInfoValiable(
            string codeLine,
            string codeDelimiter,
            int value,
            int name,
            int typeName,
            bool isConst)
            : base(codeLine, codeDelimiter)
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
            get
            {
                if (this._value < 0)
                {
                    return "(None)";
                }
                
                return this.CodeParts()[this._value];
            }
        }

        public string Name
        {
            get { return this.CodeParts()[this._name]; }
        }

        public string TypeName
        {
            get { return this.CodeParts()[this._typeName]; }   
        }

        public bool IsConst
        {
            get { return this._isConst; }   
        }

        #endregion

        #region Method

        #region Override

        public override string GetCodeText()
        {
            return "ローカル変数名：" + this.Name + "値：" + this.Value + "型名：" + this.TypeName + "CONST?" + this.IsConst;
        }

        #endregion

        #endregion
    }
}
