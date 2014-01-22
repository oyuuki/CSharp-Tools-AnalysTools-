using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OyuLib.OyuWindows.Compornent.ExDataGridView;
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
            string constValue,
            string uniqueFileNamepart,
            ExDataGridViewControl exDgv,
            string keyColName,
            params string[] colNameArray)
            : base(constValue, uniqueFileNamepart, exDgv, keyColName, colNameArray)
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
