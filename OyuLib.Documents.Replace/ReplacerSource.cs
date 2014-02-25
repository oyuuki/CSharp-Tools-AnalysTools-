using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Replace
{
    public class ReplacerSource : ReplacerAbs<ReplaceLogicSource>
    {
        #region insanceVal

        private string _commentString = string.Empty;

        private string _commentSeparator = string.Empty;

        #endregion

        #region Constructor

        public ReplacerSource(
            Document text,
            string stringWillBeReplace,
            string stringReplacing,
            string commentString,
            string commentSeparator)
            : base(text, stringWillBeReplace, stringReplacing)
        {
            this._commentString = commentString;
            this._commentSeparator = commentSeparator;
        }

        public ReplacerSource(
            string textString,
            string stringWillBeReplace,
            string stringReplacing,
            string commentString,
            string commentSeparator)
            : base(textString, stringWillBeReplace, stringReplacing)
        {
            this._commentString = commentString;
            this._commentSeparator = commentSeparator;
        }

        #endregion

        #region Property

        public string CommentString
        {
            get { return this._commentString; }
            set { this._commentString = value; }
        }

        public string CommentSeparator
        {
            get { return this._commentSeparator; }
            set { this._commentSeparator = value; }
        }


        #endregion

        #region Method

        #region Override

        protected override ReplaceLogicSource GetReplaceClass()
        {
            return new ReplaceLogicSource(this.StringWillBeReplace, this.StringReplacing, this.CommentString, this.CommentSeparator, this.IsRegexincludePettern);
        }

        #endregion

        #endregion

    }
}
