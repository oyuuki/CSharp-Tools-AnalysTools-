using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepaceSource
{
    public class ReplaceItem
    {
        #region InstanceVal

        private string _targetString = string.Empty;

        private string[] _replaceStrings = null;

        #endregion

        #region Constructor

        public ReplaceItem(string targetString, string replaceString)
        {
            this._targetString = targetString;
            this._replaceStrings = new string[] { replaceString };
        }

        public ReplaceItem(string targetString, string[] replaceStrings)
        {
            this._targetString = targetString;
            this._replaceStrings = replaceStrings;
        }

        #endregion

        #region Property

        public string TargetString
        {
            get { return this._targetString; }
            set { this._targetString = value; }
        }

        public string[] ReplaceStrings
        {
            get { return this._replaceStrings; }
            set { this._replaceStrings = value; }
        }

        public string ReplaceString
        {
            get { return this._replaceStrings[0]; }
            set { this._replaceStrings[0] = value; }
        }

        #endregion
    }
}
