using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Sources.Analysis.InputFields
{
    public abstract class WinFrmInputFieldExtractor : InputField
    {
        #region constractor

        protected WinFrmInputFieldExtractor(string sourceText, int hierarchyIndex, string itemSignature)
                : base(sourceText, hierarchyIndex, itemSignature)
        {
            
        }

        protected WinFrmInputFieldExtractor()
        {

        }

        #endregion

        #region method

        #region GetInputItem

        public WinFrmInputField GetWinFrmField()
        {
            string id = this.GetId();
            string name = this.GetName();
            string format = this.GetFormat();
            string type = this.GetExType();
            string beam = this.GetBeam();
            string source = this.SourceText;
            string tabIndex = this.GetTabIndex();
            string readonlyFlg = this.GetReadOnly();
            string imeMode = this.GetImeMode();
            int hierarchyIndex = this.HierarchyIndex;
            string itemSignature = this.ItemSignature;

            return new WinFrmInputField(id, name, format, type, beam, source, tabIndex, readonlyFlg, imeMode, hierarchyIndex, itemSignature);
        }

        #endregion

        #region GetFieldValue

        /// <summary>
        /// Get The Value of property that point by a propertyName parameter
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected string GetWinFrmFieldPropertyValue(string propertyName)
        {
            string[] spilitedSourcebyKai = this.SourceText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            foreach (string text in spilitedSourcebyKai)
            {
                if (text.IndexOf(propertyName) >= 0)
                {
                    string retValue = text.Substring(text.IndexOf("=") + 1).Trim();
                    return retValue.Replace("\"", "");
                }
            }

            return string.Empty;
        }

        #endregion

        #region abstract

        #region GetId

        protected abstract string GetId();

        #endregion

        #region GetName

        protected abstract string GetName();

        #endregion

        #region GetFormat

        protected abstract string GetFormat();

        #endregion

        #region GetType

        protected abstract string GetExType();

        #endregion

        #region GetBeam

        protected abstract string GetBeam();

        #endregion

        #region GetTabIndex

        protected abstract string GetTabIndex();

        #endregion

        #region GetReadOnly

        protected abstract string GetReadOnly();

        #endregion

        #region GetImeMode

        protected abstract string GetImeMode();

        #endregion

        #region GetItemSignature

        /// <summary>
        /// Get instance valiable that called _itemSignature
        /// </summary>
        /// <returns></returns>
        public string GetItemSignature()
        {
            return this.ItemSignature;
        }

        #endregion

        #endregion

        #endregion

    }
}
