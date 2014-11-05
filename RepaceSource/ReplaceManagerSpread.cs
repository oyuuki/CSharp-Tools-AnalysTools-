using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.Documents.Sources.Analysis;

namespace RepaceSource
{
    public abstract class ReplaceManagerSpread<T> : ReplaceManager<T>
        where T : SourceCodeInfo
    {
        #region InstanceVal

        private string _rowString = string.Empty;
        private string _colString = string.Empty;

        #endregion

        #region Constructor

        public ReplaceManagerSpread(
            string rowString, 
            string colString,
            string spreadValiableName,
            string comment, 
            string commentSeparator,
            T value,
            int lineIndex)
            : base(value, comment, commentSeparator, spreadValiableName, lineIndex)
        {
            this._rowString = rowString;
            this._colString = colString;
        }

        #endregion

        #region Property

        public string RowStringMinusOne
        {
            get { return this._rowString + " - 1"; }
        }

        public string ColStringMinusOne
        {
            get { return this._colString + " - 1"; }
        }

        public string RowString
        {
            get { return this._rowString; }
            set { this._rowString = value; }
        }

        public string ColString
        {
            get { return this._colString; }
            set { this._colString = value; }
        }

        public string GetAddMinusValue(string paramString)
        {
            int parseInt = 0;
            string retValue = paramString;

            // 数字または列数、行数取得プロパティの場合、マイナスをつける
            if ((!paramString.Equals("eventArgs.Row")
                && !paramString.Equals(this.ValiableName + ".eventArgs.Column")
                && !paramString.Equals(this.ValiableName + ".ActiveSheet.ActiveRowIndex")
                && !paramString.Equals(this.ValiableName + ".ActiveSheet.ActiveColumnIndex")
                || int.TryParse(paramString, out parseInt)) &&
                paramString.IndexOf("- 1") < 0)
            {
                paramString += " - 1";
            }

            return paramString;
        }

        protected string GetSpreadName()
        {
            string spreadName = this.ValiableName;

            if (!string.IsNullOrEmpty(spreadName))
            {
                spreadName += ".";
            }

            return spreadName;
        }

        #endregion
    }
}
