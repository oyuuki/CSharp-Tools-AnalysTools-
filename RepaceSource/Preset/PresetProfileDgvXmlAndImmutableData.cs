﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonCompornent;
using RepaceSource.ComboBoxEnum;

namespace RepaceSource.Preset
{
    class PresetProfileDgvXmlAndImmutableData : PresetProfileDgv
    {
        #region const

        /// <summary>
        /// Constructor
        /// </summary>
        public PresetProfileDgvXmlAndImmutableData(
            EnumLungPreset presetEnum,
            string uniqueFileNamepart,
            ExDataGridViewControl exDgv,
            string keyColName,
            params string[] colNameArray)
            : base(presetEnum, uniqueFileNamepart, exDgv, keyColName, colNameArray)
        {

        }

        #endregion

        #region Method

        #region Override

        public override void ReadDataToDgv()
        {
            
        }

        #endregion

        #endregion

    }
}
