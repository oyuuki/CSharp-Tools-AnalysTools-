using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.OyuAttribute;

namespace OyuLib.OyuCharCode
{
    public class CharCode
    {
        #region instanceVal

        private char _charCode = char.MinValue;

        #endregion

        #region constructor

        public CharCode(char charCode)
        {
            this._charCode = charCode;
        }

        public CharCode(string stringCode)
        {
            this._charCode = Convert.ToChar(stringCode);
        }

        public CharCode(CharCodeKind charCodeKind)
            : this(ConstAttributeManager<CharCodeKind>.GetValueByEnumValue(charCodeKind))
        {

        }

        #endregion

        #region Method

        #region virtual

        public virtual string GetCharCodeString()
        {
            return Convert.ToString(this._charCode);
        }

        #endregion

        #endregion
    }
}
