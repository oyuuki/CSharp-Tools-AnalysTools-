using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public PresetProfile(EnumLungPreset presetEnum)
        {
            this._presetEnum = presetEnum;
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
        
        #endregion

        #endregion

        #endregion
    }
}
