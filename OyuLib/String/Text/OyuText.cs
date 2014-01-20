using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.OyuChar;

namespace OyuLib.String.Text
{
    public class OyuText
    {
        #region instanceVal

        private string _text = string.Empty;

        private LineCode _lineCode = null;

        #endregion

        #region constructor

        public OyuText(string text)
        {
            this._text = text;
        }

        #endregion

        #region Property

        public LineCode LineCode
        {
            get { return this._lineCode; }
            set { this._lineCode = value; }
        }

        #endregion

        #region method

        public string[] GetLineArray()
        {
            return CharManager<LineCode>.GetSpilitString(this._text);
        }

        private LineCode GetLineCode()
        {
            LineCode retLineCode = null;

            if (this.IsSetLineCode())
            {
                retLineCode = this._lineCode;
            }
            else
            {
                retLineCode = new LineCode();
            }

            return retLineCode;
        }

        private bool IsSetLineCode()
        {
            return this._lineCode != null;
        }

        #endregion
    }
}
