using System;
using System.Collections;

namespace OyuLib.Collection
{
    public class EnumeratorByIndex<T> : IEnumerator
    {
        #region InstanceVal

        private T[] _tArray;

        private int _index;

        #endregion

        #region constructor

        public EnumeratorByIndex(T[] tArray)
        {
            this._tArray = tArray;
        }

        #endregion

        #region Method

        void IEnumerator.Reset()
        {
            this._index = -1;
        }
        bool IEnumerator.MoveNext()
        {
            if (this._index < _tArray.Length)
                this._index++;

            return (!(this._index == _tArray.Length));
        }

        object IEnumerator.Current
        {
            get
            {
                if ((this._index < 0) || (this._index == _tArray.Length))
                    throw new InvalidOperationException();
                return _tArray[this._index];
            }
        }

        #endregion
    }
}
