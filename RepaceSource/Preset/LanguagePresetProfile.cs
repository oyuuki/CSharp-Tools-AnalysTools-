
using OyuLib;
using RepaceSource.ComboBoxEnum;

namespace RepaceSource.Preset
{
    public class LanguagePresetProfile
    {
        #region InstanceVal

        /// <summary>
        /// Number of Preset
        /// </summary>
        protected LanguagePreset _presetEnum = LanguagePreset.None;

        /// <summary>
        /// Number of Preset
        /// </summary>
        protected LanguagePresetExtension _presetExtensionEnum = LanguagePresetExtension.None;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public LanguagePresetProfile(string constValue)
        {
            this._presetEnum = ConstAttributeManager<LanguagePreset>.GetEnumValue(constValue);
            this._presetExtensionEnum = ConstAttributeManager<LanguagePresetExtension>.GetEnumValue(constValue); 
        }

        /// <summary>
        /// Number of Preset
        /// </summary>
        public LanguagePreset PresetEnum
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
            return ConstAttributeManager<LanguagePreset>.GetValueByEnumValue(this._presetEnum);
        }

        /// <summary>
        /// Get The Unique Number of Preset
        /// </summary>
        /// <returns></returns>
        public string GetPresetNumber()
        {
            return ConstAttributeManager<LanguagePreset>.GetConstByEnumValue(this._presetEnum);
        }

        /// <summary>
        /// Get The Unique Number of Preset
        /// </summary>
        /// <returns></returns>
        public string GetFileExtension()
        {
            return ConstAttributeManager<LanguagePresetExtension>.GetValueByEnumValue(this._presetExtensionEnum);
        }
        
        #endregion

        #endregion

        #endregion
    }
}
