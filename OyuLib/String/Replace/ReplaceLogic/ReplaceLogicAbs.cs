using System;
using System.Text.RegularExpressions;

namespace OyuLib.String.Replace.ReplaceLogic
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ReplaceLogicAbs
    {
        #region instanceVal

        /// <summary>
        /// The String replacing 
        /// </summary>
        private string _stringReplacing = string.Empty;

        /// <summary>
        /// The String that will be replace
        /// </summary>
        private string _stringWillBeReplace = string.Empty;

        /// <summary>
        /// Prove that String Either include regex or not
        /// </summary>
        private bool _isRegexincludePettern = false;

        #endregion

        #region property

        protected string StringReplacing
        {
            get { return this._stringReplacing; }
        }

        protected string StringWillBeReplace
        {
            get { return this._stringWillBeReplace; }
        }

        public bool IsRegexincludePettern
        {
            get { return this._isRegexincludePettern; }
            set { this._isRegexincludePettern = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicAbs()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicAbs(string stringReplacing, string stringWillBeReplace)
        {
            this._stringReplacing = stringReplacing;
            this._stringWillBeReplace = stringWillBeReplace;
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
            return replaceText.Replace(this.StringWillBeReplace, this.StringReplacing);    
        }

        private string GetReplaceTextProcRegex(string replaceText)
        {
            return Regex.Replace(replaceText,StringWillBeReplace,StringReplacing);
        }

        #endregion

        #region abstruct

        public abstract string GetReplacedText(string replaceText);

        #endregion

        #endregion
    }
}
