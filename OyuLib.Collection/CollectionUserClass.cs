using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OyuLib.Collection
{
    public abstract class CollectionUserClass<T> : System.Collections.CollectionBase
    {
        #region InstanceVal

        #endregion

        #region Method

        public void Add(T tValue)
        {
            List.Add(tValue);
        }

        public void Remove(int index)
        {
            // Check to see if there is a widget at the supplied index.
            if (index > Count - 1 || index < 0)
            // If no widget exists, a messagebox is shown and the operation 
            // is cancelled.
            {
                throw new Exception("");
            }
            else
            {
                List.RemoveAt(index);
            }
        }

        // C#
        public T Item(int Index)
        {
            // The appropriate item is retrieved from the List object and
            // explicitly cast to the Widget type, then returned to the 
            // caller.
            return (T)List[Index];
        }
        
        #endregion
    }
}
