using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OyuLib.OyuWindows.Compornent.ExDataGridView;
using RepaceSource.ComboBoxEnum;

namespace RepaceSource.Preset
{
    abstract class PresetProfileDgv
    {
        #region Const

        /// <summary>
        /// 
        /// </summary>
        private const string CONST_PRESET_FILENAME_PART1 = "Preset_";

        /// <summary>
        /// 
        /// </summary>
        private const string CONST_SERIALIZE_EXTENSION = ".xml";

        #endregion

        #region InstanceVal

        protected PresetProfile _prof = null;

        /// <summary>
        /// 
        /// </summary>
        protected ExDataGridViewControl _exDgv = null;

        /// <summary>
        /// 
        /// </summary>
        protected string _keyColName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        protected string[] _colNameArray = null;

        /// <summary>
        /// 
        /// </summary>
        protected string _uniqueFileName = string.Empty;

        #endregion

        #region constructor


        /// <summary>
        /// Constructor
        /// </summary>
        public PresetProfileDgv(
            PresetProfile prof,
            string uniqueFileNamepart,
            ExDataGridViewControl exDgv,
            string keyColName,
            params string[] colNameArray)
        {
            this._prof = prof;
            this._uniqueFileName = uniqueFileNamepart;
            this._exDgv = exDgv;
            this._keyColName = keyColName;
            this._colNameArray = colNameArray;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PresetProfileDgv(
            string constValue,
            string uniqueFileNamepart,
            ExDataGridViewControl exDgv,
            string keyColName,
            params string[] colNameArray)
            : this(new PresetProfile(constValue), uniqueFileNamepart, exDgv, keyColName, colNameArray)
        {
            
        }

        #endregion

        #region Property

        public string KeyColName
        {
            get { return this._keyColName; }
            set { this._keyColName = value; }
        }

        public string[] ColNameArray
        {
            get { return this._colNameArray; }
            set { this._colNameArray = value; }
        }

        public PresetProfile Prof
        {
            get { return this._prof; }
            set { this._prof = value; }
        }


        #endregion

        #region Method

        #region Public

        /// <summary>
        /// Get The Path of File That was SERIALIZED
        /// </summary>
        /// <returns></returns>
        public string GetXmlFileNameWithOutExtension()
        {
            return CONST_PRESET_FILENAME_PART1 + _uniqueFileName + this._prof.GetPresetName();
        }

        public void WriteDataToXmlFromDgv()
        {
            this._exDgv.StoreDatatoXml(this.GetXmlFileNameWithOutExtension(), this._keyColName, this._colNameArray);
        }

        #endregion

        #region abstruct

        public abstract void ReadDataToDgv();

        #endregion

        #endregion
    }
}
