using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Documents.Analysis
{
    /// <summary>
    /// InputItem info of DisplaySource
    /// </summary>
    public class WinFrmField : InputFieldItem
    {
        #region instance

        /// <summary>
        /// item Name
        /// </summary>
        private string _id = null;

        /// <summary>
        /// item Name
        /// </summary>
        private string _name = null;

        /// <summary>
        /// item inputfield format
        /// </summary>
        private string _format = null;

        /// <summary>
        /// type of item
        /// </summary>
        private string _type = null;

        /// <summary>
        /// </summary>
        private string _beam = null;

        /// <summary>
        /// </summary>
        private string _tabindex = null;

        /// <summary>
        /// readOnly
        /// </summary>
        private string _readOnly = null;

        /// <summary>
        /// readOnly
        /// </summary>
        private string _imeMode = null;

        #endregion

        #region constractor

        /// <summary>
        /// constractor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="beam"></param>
        /// <param name="source"></param>
        /// <param name="tabIndex"></param>
        /// <param name="hierarchyIndex"></param>
        /// <param name="itemSignature"></param>
        public WinFrmField(
            string id,
            string name, 
            string format, 
            string type,
            string beam, 
            string source,
            string tabIndex,
            string readOnly,
            string imeMode,
            int hierarchyIndex,
            string itemSignature)
            : base(source, hierarchyIndex, itemSignature)
        {
            this._id = id;
            this._name = name;
            this._format = format;
            this._type = type;
            this._beam = beam;
            this._tabindex = tabIndex;
            this._readOnly = readOnly;
            this._imeMode = imeMode;
        }

        #endregion

        #region Method

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

        #region GetId

        /// <summary>
        /// Get instance valiable that called _id
        /// </summary>
        /// <returns></returns>
        public string GetId()
        {
            return this._id;
        }

        #endregion

        #region GetName

        /// <summary>
        /// Get instance valiable that called _name
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return this._name;
        }

        #endregion

        #region GetFormat

        /// <summary>
        /// Get instance valiable that called _format
        /// </summary>
        /// <returns></returns>
        public string GetFormat()
        {
            return this._format;
        }

        #endregion

        #region GetType

        /// <summary>
        /// Get instance valiable that called _type
        /// </summary>
        /// <returns></returns>
        public string GetExType()
        {
            return this._type;
        }

        #endregion

        #region GetBeam

        /// <summary>
        /// Get instance valiable that called _beam
        /// </summary>
        /// <returns></returns>
        public string GetBeam()
        {
            return this._beam;
        }

        #endregion

        #region GetTabIndex

        /// <summary>
        /// Get instance valiable that called _tabindex
        /// </summary>
        /// <returns></returns>
        public string GetTabIndex()
        {
            return this._tabindex;
        }

        #endregion

        #region GetSource

        /// <summary>
        /// Get instance valiable that called _source
        /// </summary>
        /// <returns></returns>
        public string GetSource()
        {
            return this.SourceText;
        }

        #endregion

        #region GetReadOnly

        /// <summary>
        /// Get instance valiable that ReadOnly
        /// </summary>
        /// <returns></returns>
        public string GetReadOnly()
        {
            return this._readOnly;
        }

        #endregion

        #region GetImeMode

        /// <summary>
        /// Get instance valiable that imeMode
        /// </summary>
        /// <returns></returns>
        public string GetImeMode()
        {
            return this._imeMode;
        }

        #endregion

        #region GetHierarchyIndex

        /// <summary>
        /// get hierarchyIndex
        /// </summary>
        /// <returns></returns>
        public int GetHierarchyIndex()
        {
            return this.HierarchyIndex;
        }

        #endregion

        #endregion

    }
}
