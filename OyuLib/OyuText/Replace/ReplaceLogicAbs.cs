namespace OyuLib.OyuText.Replace
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ReplaceLogicAbs
    {
        #region instanceVal

        /// <summary>
        /// 
        /// </summary>
        private ReplaceInfo _reInfo = null;

        #endregion

        #region property

        public ReplaceInfo ReInfo
        {
            get { return this._reInfo; }
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
        public ReplaceLogicAbs(string stringWillBeReplace, string stringReplacing)
            : this(new ReplaceInfo(stringWillBeReplace, stringReplacing))
        {
            
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceLogicAbs(ReplaceInfo reInfo)
        {
            this._reInfo = reInfo;
        }

        #endregion

        #region Method

        
        #region abstruct

        public abstract string GetReplacedText(string replaceText);

        #endregion

        #endregion
    }
}
