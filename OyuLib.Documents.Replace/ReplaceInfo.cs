
namespace OyuLib.Documents.Replace
{
    public class ReplaceInfo
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

        #endregion

        #region Property

        public string StringReplacing
        {
            get { return this._stringReplacing; }
        }

        public string StringWillBeReplace
        {
            get { return this._stringWillBeReplace; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ReplaceInfo(string stringWillBeReplace, string stringReplacing)
        {
            this._stringWillBeReplace = stringWillBeReplace;
            this._stringReplacing = stringReplacing;
        }

        #endregion
    }
}
