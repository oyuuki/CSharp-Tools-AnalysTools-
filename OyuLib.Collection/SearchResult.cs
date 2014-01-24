using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Collection
{
    public abstract class EnumeratorByIndex<T> : IEnumerator<T>
    {
        #region InstanceVal

        private int _index = -1;

        private T[] _sResultItem = null;

        #endregion

        #region constructor

        public EnumeratorByIndex()
        {
            this._sResultItem = new T[] { };
        }

        public EnumeratorByIndex(T[] sResultItem)
        {
            this._sResultItem = sResultItem;
        }

        public EnumeratorByIndex(T resultItem)
        {
            this._sResultItem = new T[] { resultItem };
        }

        #endregion

        #region Method

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            this._index++;
            return (this._index < this._sResultItem.Length);
        }

        public void Reset()
        {
            this._index = -1; // -1にするのがポイント
        }

        public T Current
        {
            get
            {
                return this._sResultItem[this._index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this._sResultItem[this._index];
            }
        }
        
        #endregion
    }
}
