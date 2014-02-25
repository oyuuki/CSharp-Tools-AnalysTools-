﻿using System.Text.RegularExpressions;

namespace OyuLib.Documents.Replace
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
        public ReplaceLogicText(
            string stringWillBeReplace, 
            string stringReplacing,
            bool isRegexincludePettern)
            : base(stringWillBeReplace, stringReplacing)
        {
            this._isRegexincludePettern = isRegexincludePettern;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicText(
            ReplaceInfo reInfo,
            bool isRegexincludePettern)
            : base(reInfo)
        {
            this._isRegexincludePettern = isRegexincludePettern;
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

        protected virtual string GetReplaceTextProcNormal(string replaceText)
        {
            if (string.IsNullOrEmpty(this.ReInfo.StringWillBeReplace))
            {
                return replaceText;
            }

            return replaceText.Replace(this.ReInfo.StringWillBeReplace, this.ReInfo.StringReplacing);
        }

        protected virtual string GetReplaceTextProcRegex(string replaceText)
        {
            return Regex.Replace(replaceText, this.ReInfo.StringWillBeReplace, this.ReInfo.StringReplacing);
        }

        #endregion

        #region Override

        public override string GetReplacedText(string replaceText)
        {
            return this.GetReplaceTextProc(replaceText);
        }

        public override bool IsMatch(string replaceText)
        {
            if (this.IsRegexincludePettern)
            {
                return Regex.IsMatch(replaceText, this.ReInfo.StringWillBeReplace);
            }
            else
            {
                return replaceText.IndexOf(this.ReInfo.StringWillBeReplace) >= 0;
            }
        }

        #endregion

        #endregion
    }
}
