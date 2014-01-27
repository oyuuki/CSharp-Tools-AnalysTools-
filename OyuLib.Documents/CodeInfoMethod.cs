using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
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
            get { return this.CodeParts[this._accessModifier]; }
        }

        public string Name
        {
            get { return this.CodeParts[this._name]; }
        }

        public string ReturnTypeName
        {
            get { return this.CodeParts[this._returnTypeName]; }
        }


        public CodeInfoValiable[] ParamValiables
        {
            get { return this._paramValiables; }
            set { this._paramValiables = value; }
        }

        #endregion
    }
}
