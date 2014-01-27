using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class CodeInfoValiable : CodeInfo
    {
        #region instanceVal

        private string _value = string.Empty;

        private string _name = string.Empty;

        private string _typeName = string.Empty;

        #endregion

        #region Constructor

        public CodeInfoValiable()
            : base()
        {
            
        }

        public CodeInfoValiable(
            string codeLine,
            string value,
            string name,
            string typeName)
            : base(codeLine)
        {
            this._value = value;
            this._name = name;
            this._typeName = typeName;
        }

        #endregion

        #region Property

        public string Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }

        #endregion
    }
}
