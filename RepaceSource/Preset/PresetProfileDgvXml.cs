using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OyuLib.Windows.Forms.DataGridView;

namespace RepaceSource.Preset
{
    class PresetProfileDgvXml : PresetProfileDgv
    {
        #region const

        /// <summary>
        /// Constructor
        /// </summary>
        public PresetProfileDgvXml(
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
            this._exDgv.ReadDatatoXml(this.GetXmlFileNameWithOutExtension(), this._colNameArray);
        }

        #endregion

        #endregion
    }
}
