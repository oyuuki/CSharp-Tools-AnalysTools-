using OyuLib.Documents;

namespace OyuLib.Documents.Analysis.Sources.ScreenField
{
    public abstract class InputFieldItem : VB6SourceCode
    {
        #region Instance

        protected int _hierarchyIndex = 0;

        protected string _itemSignature = string.Empty;

        #endregion

        #region constractor

        public InputFieldItem()
        {

        }

        public InputFieldItem(string sourceText, int hierarchyIndex, string itemSignature)
            : base(sourceText)
        {
            this._hierarchyIndex = hierarchyIndex;
            this._itemSignature = itemSignature;
        }

        #endregion
    }
}
