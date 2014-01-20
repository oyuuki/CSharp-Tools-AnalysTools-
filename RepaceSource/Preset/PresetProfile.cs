using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonCompornent;
using ConstAttribute;
using RepaceSource.ComboBoxEnum;

namespace RepaceSource.Preset
{
    class PresetProfile
    {
        #region InstanceVal

        /// <summary>
        /// Number of Preset
        /// </summary>
        protected EnumLungPreset _presetEnum = EnumLungPreset.None;

        /// <summary>
        /// Number of Preset
        /// </summary>
        protected EnumLungExtensionpreset _presetExtensionEnum = EnumLungExtensionpreset.None;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public PresetProfile(string constValue)
        {
            this._presetEnum = ConstAttributeManager<EnumLungPreset>.GetEnumValue(constValue);
            this._presetExtensionEnum = ConstAttributeManager<EnumLungExtensionpreset>.GetEnumValue(constValue); 
        }

        /// <summary>
        /// Number of Preset
        /// </summary>
        public EnumLungPreset PresetEnum
        {
            get { return _presetEnum; }
            set { _presetEnum = value; }
        }

        #endregion

        #region Method

        #region Public

        #region instance

        /// <summary>
        /// Get The Name of Preset
        /// </summary>
        /// <returns></returns>
        public string GetPresetName()
        {
            return ConstAttributeManager<EnumLungPreset>.GetValueByEnumValue(this._presetEnum);
        }

        /// <summary>
        /// Get The Unique Number of Preset
        /// </summary>
        /// <returns></returns>
        public string GetPresetNumber()
        {
            return ConstAttributeManager<EnumLungPreset>.GetConstByEnumValue(this._presetEnum);
        }

        /// <summary>
        /// Get The Unique Number of Preset
        /// </summary>
        /// <returns></returns>
        public string GetFileExtension()
        {
            return ConstAttributeManager<EnumLungExtensionpreset>.GetValueByEnumValue(this._presetExtensionEnum);
        }
        
        #endregion

        #endregion

        #endregion
    }
}
