
using System.Text.RegularExpressions;
using OyuLib.Documents.Sources.Analysis;

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
            string commentSeparator,
            bool isRegexincludePettern)
            : base(stringWillBeReplace, stringReplacing, isRegexincludePettern)
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
            string commentSeparator,
            bool isRegexincludePettern)
            : base(reInfo, isRegexincludePettern)
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
            var befReplaceText = replaceText;

            SourceCodePartsfactoryNocomment fac = new SourceCodePartsfactoryNocomment(new Sources.SourceCode(replaceText), " ");
            replaceText = fac.GetStringWithOutComment();

            if (string.IsNullOrEmpty(replaceText))
            {
                return befReplaceText;
            }

            if (string.IsNullOrEmpty(this.ReInfo.StringWillBeReplace))
            {
                return befReplaceText;
            }

            var comment = string.Empty;

            if (replaceText.Trim().StartsWith(this.CommentSeparator))
            {
                return befReplaceText;
            }

            var retString = befReplaceText;

            if (replaceText.IndexOf(this.ReInfo.StringWillBeReplace) >= 0)
            {
                comment = this.CommentSeparator + this.CommentString + "  元コード：" + befReplaceText;
                retString = replaceText.Replace(this.ReInfo.StringWillBeReplace, this.ReInfo.StringReplacing).Trim() + comment;
            }

            return retString;
        }

        protected override string GetReplaceTextProcRegex(string replaceText)
        {
            SourceCodePartsfactoryNocomment fac = new SourceCodePartsfactoryNocomment(new Sources.SourceCode(replaceText), " ");
            string target = fac.GetStringWithOutComment();

            if (string.IsNullOrEmpty(target))
            {
                return replaceText;
            }

            return Regex.Replace(target, this.ReInfo.StringWillBeReplace, this.ReInfo.StringReplacing);
        }

        #endregion

        #endregion
    }
}
