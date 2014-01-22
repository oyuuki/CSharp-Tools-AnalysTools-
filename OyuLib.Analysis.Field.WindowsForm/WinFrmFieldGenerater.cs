using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Analysis.Source.Field.WindowsForm
{
    abstract class WinFrmFieldGenerater : InputFieldItem
    {
        #region constractor

        public WinFrmFieldGenerater(string sourceText, int hierarchyIndex, string itemSignature)
                : base(sourceText, hierarchyIndex, itemSignature)
        {
            
        }

        public WinFrmFieldGenerater()
        {
        }

        #endregion

        #region method

        #region GetInputItem

        public WindowsFormFieldItem GetInputItem()
        {
            string id = this.GetId();
            string name = this.GetName();
            string format = this.GetFormat();
            string type = this.GetExType();
            string beam = this.GetBeam();
            string source = this._sourceText;
            string tabIndex = this.GetTabIndex();
            string readonlyFlg = this.GetReadOnly();
            string imeMode = this.GetImeMode();
            int hierarchyIndex = this._hierarchyIndex;
            string itemSignature = this._itemSignature;

            return new WindowsFormFieldItem(id, name, format, type, beam, source, tabIndex, readonlyFlg, imeMode, hierarchyIndex, itemSignature);
        }

        #endregion

        #region GetFieldValue

        /// <summary>
        /// Get to value that find in source by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GetFieldValue(string key)
        {
            string[] spilitedSourcebyKai = this._sourceText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            foreach (string text in spilitedSourcebyKai)
            {
                if (text.IndexOf(key) >= 0)
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
            return this._itemSignature;
        }

        #endregion

        #endregion

        #endregion

    }
}
