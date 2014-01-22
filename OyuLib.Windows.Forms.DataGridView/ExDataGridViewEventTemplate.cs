using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace OyuLib.Windows.Forms.DataGridView
{
    /// <summary>
    /// Store and Call the event of DataGridViewControl.
    /// Hashtable has been used for Store the event.
    /// </summary>
    public class ExDataGridViewEventTemplate
    {
        private List<ExDataGridViewEventValue> _eventList = null;

        /// <summary>
        /// constructor
        /// initialize instance valiable
        /// </summary>
        public ExDataGridViewEventTemplate()
        {
            _eventList = new List<ExDataGridViewEventValue>();
        }


        /// <summary>
        /// add event info to instance
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="eveType">kind of event</param>
        /// <param name="del">delegateMethod</param>
        public void AddEvents<T>(string name, EnumDGVEvent evekind, ExDelegateClass.DelegateCellConClick<EventArgs> del)
            where T: ExDataGridViewEventValue, new()
        {
            T value = new T();

            value.CompornentId = name;
            value.CompornentType = evekind;
            value.Del = del;

            this._eventList.Add(value);
        }

        public ExDataGridViewEventValue[] getEventList()
        {
            return this._eventList.ToArray();
        }
    }
}
