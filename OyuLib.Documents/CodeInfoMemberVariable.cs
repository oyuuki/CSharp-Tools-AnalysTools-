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
            int accessModifiers)
            : base(code, value, name, typeName)
        {
            this._accessModifier = accessModifiers;
        }

        public CodeInfoMemberVariable(
            string codeString,
            string codeDelimiter,
            int value,
            int name,
            int typeName,
            int accessModifiers)
            : base(codeString, codeDelimiter,value, name, typeName)
        {
            this._accessModifier = accessModifiers;
        }

        #endregion

        #region Property

        public string AccessModifier
        {
            get { return this.Code.CodeParts()[this._accessModifier]; }
        }

        #endregion
    }
}
