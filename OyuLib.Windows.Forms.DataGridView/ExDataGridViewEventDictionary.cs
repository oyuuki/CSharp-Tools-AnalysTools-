using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Windows.Forms.DataGridView
{
    class ExDataGridViewEventDictionary
    {
        private Dictionary<EnumDGVEvent, Dictionary<string, ExDelegateClass.DelegateCellConClick<EventArgs>>> _eventDic = null;

        public ExDataGridViewEventDictionary()
        {
            _eventDic = new Dictionary<EnumDGVEvent, Dictionary<string, ExDelegateClass.DelegateCellConClick<EventArgs>>>();
        }

        public void AddEvent(ExDataGridViewEventValue value)
        {
            this.AddEvent(value.CompornentId, value.CompornentType, value.Del);
        }

        public void AddEvent(string compornentId,
            EnumDGVEvent compornentType,
            ExDelegateClass.DelegateCellConClick<EventArgs> del)
        {
            if (!_eventDic.ContainsKey(compornentType))
            {
                _eventDic.Add(compornentType, new Dictionary<string, ExDelegateClass.DelegateCellConClick<EventArgs>>());
            }

            _eventDic[compornentType].Add(compornentId, del);
        }


        public ExDelegateClass.DelegateCellConClick<EventArgs> GetEvent(string compornentId,
            EnumDGVEvent compornentType)
        {
            if (this._eventDic.ContainsKey(compornentType))
            {
                if (this._eventDic[compornentType].ContainsKey(compornentId))
                {

                    return this._eventDic[compornentType][compornentId];
                }

            }

            return null;
        }
    }
}
