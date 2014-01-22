using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using OyuLib.Windows.Forms.DataGridView;

namespace OyuLib.Windows.Forms.DataGridView
{
    public class ExDataGridViewEventManager
    {
        #region instance variable

        /// <summary>
        /// 行に登録するイベントの情報を保持する
        /// </summary>
        private ExDataGridViewEventTemplate _evtTemp = null;

        /// <summary>
        /// マネージ対象のDGV
        /// </summary>
        private ExDataGridViewControl _dgv = null;

        /// <summary>
        /// EventDictionaly
        /// </summary>
        private ExDataGridViewEventDictionary _eventDic = null;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evtTemp"></param>
        /// <param name="dgv"></param>
        public ExDataGridViewEventManager(ExDataGridViewControl dgv)
        {
            this._dgv = dgv;
            this._evtTemp = new ExDataGridViewEventTemplate();
            this._eventDic = new ExDataGridViewEventDictionary();
        }

        #endregion

        /// <summary>
        /// イベント登録
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="evekind"></param>
        /// <param name="del"></param>
        public void AddTempEvent<T>(string name, EnumDGVEvent evekind, ExDelegateClass.DelegateCellConClick<EventArgs> del)
            where T: ExDataGridViewEventValue, new()
        {
            this._evtTemp.AddEvents<T>(name, evekind, del);
        }

        public void AddAllEventToDgv()
        {
            this.AddAllEventToDgvProc(this._evtTemp, this._dgv);
        }

        private void AddAllEventToDgvProc(ExDataGridViewEventTemplate evtTemp,
                                        ExDataGridViewControl dgv)
        {
            foreach (ExDataGridViewEventValue value in evtTemp.getEventList())
            {
                this.AddEventToDgvProc(value, dgv);
            }
        }

        private void AddEventToDgvProc(ExDataGridViewEventValue value, ExDataGridViewControl dgv)
        {
            this._eventDic.AddEvent(value);
        }

        private ExDelegateClass.DelegateCellConClick<EventArgs> GetEventProc(int columnIndex, EnumDGVEvent evekind)
        {
            return this._eventDic.GetEvent(this._dgv.Columns[columnIndex].Name, evekind);
        }

        public void ExecProc(int columnIndex, EnumDGVEvent evekind, object sender, EventArgs e)
        {
            if (columnIndex < 0)
            {
                return;
            }

            ExDelegateClass.DelegateCellConClick<EventArgs> eventProc = this.GetEventProc(columnIndex, evekind);

            if (eventProc != null)
            {
                eventProc(sender, e);
            }
        }
    }
}
