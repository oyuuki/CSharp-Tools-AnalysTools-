using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using OyuLib.OyuWindows.Compornent.ExDataGridView.Util.Admission;

namespace OyuLib.OyuWindows.Compornent.ExDataGridView.Manager
{
    /// <summary>
    /// Provide Utility methods for DataGridView KeyDown, keyPress, Keyup
    /// </summary>
    class DataGridViewAdmissionControlGeneral
    {
        #region Instance

        /// <summary>
        /// ExDataGridView Instance
        /// </summary>
        private ExDataGridViewControl _dgv = null;

        /// <summary>
        /// Current cell move util
        /// </summary>
        private DataGridViewAdmissionMoveCurrentControl _moveCurCellCon = null;

        /// <summary>
        /// Copy And paste util
        /// </summary>
        private DataGridViewAdmissionCopyPasteControl _copypasteCon = null;

        #endregion

        #region Constractor

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        public DataGridViewAdmissionControlGeneral(ExDataGridViewControl dgv)
        {
            this._dgv = dgv;
            this._moveCurCellCon = new DataGridViewAdmissionMoveCurrentControl(this._dgv);
            this._copypasteCon = new DataGridViewAdmissionCopyPasteControl(this._dgv);
        }

        #endregion

        #region Method

        #region MoveCurrentCell

        /// <summary>
        /// Move to Current Cell Focus
        /// </summary>
        /// <param name="isNext"></param>
        public void MoveCurrentCell(bool isNext)
        {
            if(isNext)
            {
                this._moveCurCellCon.MoveNextCell();
            }
            else
            {
                this._moveCurCellCon.MovePrevCell();
            }
        }

        #endregion
        
        #region Copy & Paste

        /// <summary>
        /// copy to Data that is Selected Cell to ClipBored
        /// </summary>
        public void CopySelectCellsDataClip()
        {
             // copy to textData to clipbored
                Clipboard.SetText(this._copypasteCon.GetTextData());             
        }

        #endregion

        #endregion
    }
}
