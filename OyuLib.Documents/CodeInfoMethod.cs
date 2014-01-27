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

        private CodeInfoValiable[] _paramValiables = null;

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
            CodeInfoValiable[] paramValiables)
            : base(codeLine)
        {
            this._accessModifier = accessModifier;
            this._name = name;
            this._returnTypeName = returnTypeName;
            this._methodBody = methodBody;
            this._paramValiables = paramValiables;
        }

        #endregion

        #region Property

        public string AccessModifier
        {
            get { return this._accessModifier; }
            set { this._accessModifier = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string ReturnTypeName
        {
            get { return this._returnTypeName; }
            set { this._returnTypeName = value; }
        }

        public string MethodBody
        {
            get { return this._methodBody; }
            set { this._methodBody = value; }
        }

        public CodeInfoValiable[] ParamValiables
        {
            get { return this._paramValiables; }
            set { this._paramValiables = value; }
        }

        #endregion
    }
}
