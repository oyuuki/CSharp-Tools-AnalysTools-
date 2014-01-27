using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoMemberVariable : CodeInfoValiable
    {
        #region instanceVal

        private string _accessModifier = string.Empty;

        #endregion

        #region Constructor

        public CodeInfoMemberVariable()
            : base()
        {
            
        }

        public CodeInfoMemberVariable(
            string codeString,
            string value,
            string name,
            string typeName,
            string accessModifiers)
            : base(codeString, value, name, typeName)
        {
            this._accessModifier = accessModifiers;
        }

        #endregion

        #region Property

        public string AccessModifier
        {
            get { return this._accessModifier; }
            set { this._accessModifier = value; }
        }

        #endregion
    }
}
