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
            int typeName)
            : base(code)
        {
            this._value = value;
            this._name = name;
            this._typeName = typeName;
        }

        public CodeInfoValiable(
            string codeLine,
            string codeDelimiter,
            int value,
            int name,
            int typeName)
            : base(codeLine, codeDelimiter)
        {
            this._value = value;
            this._name = name;
            this._typeName = typeName;
        }

        #endregion

        #region Property

        public string Value
        {
            get { return this.Code.CodeParts()[this._value]; }
        }

        public string Name
        {
            get { return this.Code.CodeParts()[this._name]; }
        }

        public string TypeName
        {
            get { return this.Code.CodeParts()[this._typeName]; }   
        }

        #endregion
    }
}
