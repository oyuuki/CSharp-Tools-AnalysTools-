using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class Document
    {
        #region instanceVal

        private string _text = string.Empty;

        private LineCharCode _lineCode = null;

        private DocumentItem[] Documentitems = null;

        #endregion

        #region constructor

        public Document()
        {
            
        }

        public Document(string text)
        {
            this._text = text;
        }

        #endregion

        #region Property

        public string Text
        {
            get { return this._text; }
            set { this._text = value; }
        }

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

        #region Method

        #region Public

        public string[] GetLineArray()
        {
            return this.GetLineArrayProcd();
        }

        public DocumentitemSentence[] GetSentence()
        {
            return (from i in this.GetLineArrayProcd()
                          select new DocumentitemSentence(i)).ToArray();
        }

        #endregion

        #region Private

        private string[] GetLineArrayProcd()
        {
            return new CharCodeManager(this.LineCode).GetSpilitString(this._text);
        }

        private bool IsSetLineCode()
        {
            return this._lineCode != null;
        }

        #endregion

        #endregion
    }
}
