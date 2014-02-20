using OyuLib;
using System.Collections.Generic;

namespace OyuLib.Documents.Replace
{
    public abstract class ReplacerAbs<T>
        where T : ReplaceLogicAbs, new()
    {
        #region instanceVal

        protected Document _text = null;

        /// <summary>
        /// Prove that String Either include regex or not
        /// </summary>
        protected bool _isRegexincludePettern = false;

        /// <summary>
        /// The String replacing 
        /// </summary>
        private string _stringReplacing = string.Empty;

        /// <summary>
        /// The String that will be replace
        /// </summary>
        private string _stringWillBeReplace = string.Empty;

        #endregion

        #region constructor

        protected ReplacerAbs(
            string textString,
            string stringWillBeReplace,
            string stringReplacing)
            : this(new Document(textString), stringWillBeReplace, stringReplacing)
        {

        }

        protected ReplacerAbs(
            Document text,
            string stringWillBeReplace,
            string stringReplacing)
        {
            this._text = text;
            this._stringWillBeReplace = stringWillBeReplace;
            this._stringReplacing = stringReplacing;
        }

        protected ReplacerAbs(
            Document text,
            ReplaceInfo info)
            : this(text, info.StringWillBeReplace, info.StringReplacing)
        {

        }

        #endregion

        #region property

        public string StringReplacing
        {
            get { return this._stringReplacing; }
            set { this._stringReplacing = value; }
        }

        public string StringWillBeReplace
        {
            get { return this._stringWillBeReplace; }
            set { this._stringWillBeReplace = value; }
        }

        public bool IsRegexincludePettern
        {
            get { return this._isRegexincludePettern; }
            set { this._isRegexincludePettern = value; }
        }

        #endregion

        #region method

        #region Public

        public ReplaceInfo GetReplaceInfo()
        {
            return this.GetReplaceClass().ReInfo;
        }

        /// <summary>
        /// Replace text that exchanged to the Array
        /// </summary>
        /// <returns></returns>
        public string GetReplacedText()
        {
            T rep = this.GetReplaceClass();
            var retArray = this.ReplaceProc(rep);
            return string.Join(this._text.LineCode.GetCharCodeString(), retArray);
        }

        /// <summary>
        /// Replace text that exchanged to the Array
        /// </summary>
        /// <returns></returns>
        public int[] GetReplacedNumberArray()
        {
            T rep = this.GetReplaceClass();
            return this.GetReplaceNumberProc(rep);
            
        }

        protected virtual string[] ReplaceProc(T rep)
        {
            List<string> retList = new List<string>();

            foreach (var line in this._text.GetLineArray())
            {
                retList.Add(rep.GetReplacedText(line));
            }

            return retList.ToArray();
        }

        protected virtual int[] GetReplaceNumberProc(T rep)
        {
            string[] befReplaceTextArray = this._text.GetLineArray();
            string[] replacedlineArray = this.ReplaceProc(rep);

            var retList = new List<int>();

            for (int rowIndex = 0; rowIndex < befReplaceTextArray.Length; rowIndex++)
            {
                if (!befReplaceTextArray[rowIndex].Equals(replacedlineArray[rowIndex]))
                {
                    retList.Add(rowIndex + 1);
                }
            }

            return retList.ToArray();
        }

        #endregion

        protected abstract T GetReplaceClass();

        #endregion
    }
}
