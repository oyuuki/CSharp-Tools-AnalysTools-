using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstAttribute
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class ConstValueAttribute : Attribute
    {
        #region instance

        private string _constStr = null;

        private string _tranceedStr = null;

        #endregion

        public ConstValueAttribute(string constStr, string tranceedStr) 
        { 
            this._constStr = constStr;
            this._tranceedStr = tranceedStr;
        }

        public string GetTranceValue()
        {
            return this._tranceedStr;
        }

        public string GetConstStrValue()
        {
            return this._constStr;
        }
    }
}
