using OyuLib.Documents;

namespace OyuLib.Documents.Sources.Analysis.InputFields
{
    public abstract class InputField        
    {
        #region Instance

        private string _sourceText = string.Empty;

        private int _hierarchyIndex = 0;

        private string _itemSignature = string.Empty;

        #endregion

        #region Property

        public string SourceText
        {
            get { return this._sourceText; }
            set { this._sourceText = value; }
        }

        public int HierarchyIndex
        {
            get { return this._hierarchyIndex; }
            set { this._hierarchyIndex = value; }
        }

        public string ItemSignature
        {
            get { return this._itemSignature; }
            set { this._itemSignature = value; }
        }

        #endregion

        #region constractor

        protected InputField()
        {

        }

        protected InputField(string sourceText, int hierarchyIndex, string itemSignature)
        {
            this._sourceText = sourceText;
            this._hierarchyIndex = hierarchyIndex;
            this._itemSignature = itemSignature;
        }

        #endregion
    }
}
