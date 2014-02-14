using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    public class ReplaceItem
    {
        #region InstanceVal

        private string _targetString = string.Empty;

        private string _replaceString = string.Empty;

        #endregion

        #region Constructor

        public ReplaceItem(string targetString, string replaceString)
        {
            this._targetString = targetString;
            this._replaceString = replaceString;
        }

        #endregion

        #region Property

        public string TargetString
        {
            get { return this._targetString; }
            set { this._targetString = value; }
        }

        public string ReplaceString
        {
            get { return this._replaceString; }
            set { this._replaceString = value; }
        }

        #endregion
    }
}
