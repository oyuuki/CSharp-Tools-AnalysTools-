
using System.Text.RegularExpressions;

namespace OyuLib.Documents.Replace
{
    public class ReplaceLogicSource : ReplaceLogicText
    {
        #region instanceVal

        private string _commentString = string.Empty;

        private string _commentSeparator = string.Empty;

        #endregion

        #region Constructor
        
        public ReplaceLogicSource()
            : base()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicSource(
            string stringWillBeReplace, 
            string stringReplacing,
            string commentString,
            string commentSeparator)
            : base(stringWillBeReplace, stringReplacing)
        {
            this._commentString = commentString;
            this._commentSeparator = commentSeparator;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicSource(
            ReplaceInfo reInfo, 
            string commentString,
            string commentSeparator)
            : base(reInfo)
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

        #region Overide

        protected override string GetReplaceTextProcNormal(string replaceText)
        {
            if (string.IsNullOrEmpty(this.ReInfo.StringWillBeReplace))
            {
                return replaceText;
            }

            var comment = string.Empty;

            if (replaceText.Trim().StartsWith(this.CommentSeparator))
            {
                return replaceText;
            }

            if (replaceText.IndexOf(this.ReInfo.StringWillBeReplace) >= 0)
            {
                comment = this.CommentSeparator + this.CommentString + "元コード：" + replaceText;
            }

            var retString = replaceText.Replace(this.ReInfo.StringWillBeReplace, this.ReInfo.StringReplacing);

            if (!string.IsNullOrEmpty(comment))
            {
                retString = retString.EndTrim() + comment;
            }

            return retString;
        }

        protected override string GetReplaceTextProcRegex(string replaceText)
        {
            return Regex.Replace(replaceText, this.ReInfo.StringWillBeReplace, this.ReInfo.StringReplacing);
        }

        #endregion

        #endregion
    }
}
