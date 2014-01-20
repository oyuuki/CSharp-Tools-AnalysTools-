using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.OyuChar
{
    public abstract class CharCode
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

        #endregion

        #region Method

        #region abstract

        public string GetCharCodeString()
        {
            return Convert.ToString(this._charCode);
        }

        #endregion

        #endregion
    }
}
