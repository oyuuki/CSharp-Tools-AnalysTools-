using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoMethod : CodeInfo
    {
        #region instanceVal

        private string _accessModifier = string.Empty;

        private string _name = string.Empty;

        private string _returnTypeName = string.Empty;

        private string _methodBody = string.Empty;

        private CodeInfoValiable[] _paramValiable = null;

        #endregion

        #region Constructor

        public CodeInfoMethod()
            : base()
        {
            
        }

        public CodeInfoMethod(
            string codeLine,
            string accessModifier,
            string name,
            string returnTypeName,
            string methodBody,
            CodeInfoValiable[] paramValiable)
            : base(codeLine)
        {
            this._accessModifier = accessModifier;
            this._name = name;
            this._returnTypeName = returnTypeName;
            this._methodBody = methodBody;
            this._paramValiable = paramValiable;
        }

        #endregion
    }
}
