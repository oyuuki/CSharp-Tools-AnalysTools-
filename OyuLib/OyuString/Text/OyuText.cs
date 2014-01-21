﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OyuLib.OyuChar;

namespace OyuLib.OyuString.Text
{
    public class OyuText
    {
        #region instanceVal

        private string _text = string.Empty;

        private LineCharCode _lineCode = null;

        #endregion

        #region constructor

        public OyuText(string text)
        {
            this._text = text;
        }

        #endregion

        #region Property

        public LineCharCode LineCode
        {
            get
            {
                LineCharCode retLineCode = null;

                if (this.IsSetLineCode())
                {
                    retLineCode = this._lineCode;
                }
                else
                {
                    retLineCode = new LineCharCode();
                }

                return retLineCode;
            }
            set { this._lineCode = value; }
        }

        #endregion

        #region method

        public string[] GetLineArray()
        {
            return new CharCodeManager(this.LineCode).GetSpilitString(this._text);
        }

        private bool IsSetLineCode()
        {
            return this._lineCode != null;
        }

        #endregion
    }
}
