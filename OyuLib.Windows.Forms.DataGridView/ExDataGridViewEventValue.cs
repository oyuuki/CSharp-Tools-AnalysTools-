using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace OyuLib.Windows.Forms.DataGridView
{
    public abstract class ExDataGridViewEventValue
    {
        #region instance valiable

        /// <summary>
        /// store id that adding event compornent
        /// </summary>
        private string _compornentId = null;

        /// <summary>
        /// store name that adding event compornent
        /// </summary>
        private EnumDGVEvent _compornentType = EnumDGVEvent.eveCellClick;

        /// <summary>
        /// store delegateproc
        /// </summary>
        private ExDelegateClass.DelegateCellConClick<EventArgs> _del = null;

        #endregion  


        #region propaty

        /// <summary>
        /// propaty of _compornentId
        /// </summary>
        public string CompornentId
        {
            get
            {
                return this._compornentId;
            }

            set
            {
                this._compornentId = value;
            }

        }

        /// <summary>
        /// propaty of _compornentType
        /// </summary>
        public EnumDGVEvent CompornentType
        {
            get
            {
                return this._compornentType;
            }

            set
            {
                this._compornentType = value;
            }

        }

        /// <summary>
        /// propaty of _compornentType
        /// </summary>
        public ExDelegateClass.DelegateCellConClick<EventArgs> Del
        {
            get
            {
                return this._del;
            }

            set
            {
                this._del = value;
            }

        }

        #endregion

        #region constructer

        public ExDataGridViewEventValue()
        {

        }

        /// <summary>
        /// constructer proc.
        /// store all valiable value to instance valiables.
        /// </summary>
        /// <param name="compornentId"></param>
        /// <param name="compornentType"></param>
        /// <param name="del"></param>
        public ExDataGridViewEventValue(
            string compornentId,
            EnumDGVEvent compornentType,
            ExDelegateClass.DelegateCellConClick<EventArgs> del)
        {
            this._compornentId = compornentId;
            this._compornentType = compornentType;
            this._del = del;
        }

        #endregion
    }
}
