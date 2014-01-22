

namespace OyuLib.OyuText.Replace
{
    public abstract class ReplacerAbs<T>
        where T : ReplaceLogicAbs, new()
    {
        #region instanceVal

        protected Sentence _text = null;

        /// <summary>
        /// Prove that String Either include regex or not
        /// </summary>
        protected bool _isRegexincludePettern = false;

        /// <summary>
        /// Prove that String Either include regex or not
        /// </summary>
        protected object[] _objArray = null;

        #endregion

        #region constructor

        public ReplacerAbs(string textString, object[] objArray)
        {
            this._text = new Sentence(textString);
            this._objArray = objArray;
        }

        public ReplacerAbs(Sentence text, object[] objArray)
        {
            this._text = text;
            this._objArray = objArray;
        }

        #endregion

        #region property

        public bool IsRegexincludePettern
        {
            get { return this._isRegexincludePettern; }
            set { this._isRegexincludePettern = value; }
        }

        #endregion

        #region method

        #region Public

        public T GetReplaceClass()
        {
            T rep = Util.GetInstance<T>(this._objArray);
            return rep;
        }

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

        #endregion

        #region Abstruct

        protected abstract string[] ReplaceProc(T rep);

        protected abstract int[] GetReplaceNumberProc(T rep);

        #endregion

        #endregion
    }
}
