using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.OyuFile.OyuXml
{
    public class XmlValueTypeKeyAndValue
    {
        #region instance

        private string _key = null;

        private string _value = null;

        #endregion

        public string Key { get { return this._key; } set { this._key = value; } }
        public string Value { get { return this._value; } set { this._value = value; } } 

        #region constractor

        public XmlValueTypeKeyAndValue()
        {

        }

        public XmlValueTypeKeyAndValue(string key, string value)
        {
            this._key = key;
            this._value = value;
        }

        #endregion
    }
}
