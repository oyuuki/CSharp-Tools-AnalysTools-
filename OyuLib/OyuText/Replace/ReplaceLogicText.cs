using System.Text.RegularExpressions;

namespace OyuLib.OyuText.Replace
{
    public class ReplaceLogicText : ReplaceLogicAbs
    {
        #region instanceVal

        /// <summary>
        /// Prove that String Either include regex or not
        /// </summary>
        private bool _isRegexincludePettern = false;

        #endregion

        #region Constructor


        public ReplaceLogicText()
            : base()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicText(string stringWillBeReplace, string stringReplacing)
            : base(stringWillBeReplace, stringReplacing)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicText(ReplaceInfo reInfo)
            : base(reInfo)
        {
        }

        #endregion

        #region Property

        public bool IsRegexincludePettern
        {
            get { return this._isRegexincludePettern; }
            set { this._isRegexincludePettern = value; }
        }

        #endregion

        #region Method

        #region protected

        public string GetReplaceTextProc(string replaceText)
        {
            if (this.IsRegexincludePettern)
            {
                return this.GetReplaceTextProcRegex(replaceText);
            }
            else
            {
                return this.GetReplaceTextProcNormal(replaceText);
            }
        }

        private string GetReplaceTextProcNormal(string replaceText)
        {
            return replaceText.Replace(this.ReInfo.StringWillBeReplace, this.ReInfo.StringReplacing);
        }

        private string GetReplaceTextProcRegex(string replaceText)
        {
            return Regex.Replace(replaceText, this.ReInfo.StringWillBeReplace, this.ReInfo.StringReplacing);
        }

        #endregion

        #region Override

        public override string GetReplacedText(string replaceText)
        {
            return this.GetReplaceTextProc(replaceText);
        }

        #endregion

        #endregion
    }
}
