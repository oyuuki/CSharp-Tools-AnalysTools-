using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoMemberVariable : CodeInfoValiable
    {
        #region instanceVal

        private string _typeName = string.Empty;

        private string _accessModifier = string.Empty;

        #endregion

        #region Constructor

        public CodeInfoMemberVariable()
            : base()
        {
            
        }

        public CodeInfoMemberVariable(
            string codeString,
            string accessModifiers,
            string value,
            string name,
            string typeName)
            : base(codeString, accessModifiers, value, name)
        {
            this._typeName = typeName;
        }

        #endregion

    }
}
