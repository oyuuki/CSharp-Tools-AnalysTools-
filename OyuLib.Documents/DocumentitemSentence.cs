using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents
{
    public class DocumentitemSentence : DocumentItem
    {
        #region instanceVal

        /// <summary>
        /// subject string
        /// </summary>
        private string _subject = string.Empty;

        /// <summary>
        /// predicate string
        /// </summary>
        private string _predicate = string.Empty;

        /// <summary>
        /// text 
        /// </summary>
        private string _text = string.Empty;

        #endregion

        #region Constructor

        public DocumentitemSentence(string subject, string predicate)
        {
            this._subject = subject;
            this._predicate = predicate;
        }
        public DocumentitemSentence(string text)
        {
            this._text = text;// >>  TODO: this code will be change to call the Method that called "GetCreateSentence"
        }

        #endregion

        #region Method

        public virtual DocumentitemSentence GetCreateSentence()
        {
            throw new Exception("未実装箇所あり");
            // >>  TODO: this place will be added Some code that Create Sentence from text property
        }

        public string GetText()
        {
            return this._text;
        }

        #endregion
    }
}
