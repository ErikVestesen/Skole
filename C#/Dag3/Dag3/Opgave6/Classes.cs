using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave6
{
    class GrowableArray<T>
    {
        private T[] array = new T[10];
        public T this[int i]
        {
            get
            {
                this.array = growIfNeeded(i);
                return array[i];
            }

            set
            {
                this.array = growIfNeeded(i);
                array[i] = value;
            }
        }

        private T[] growIfNeeded(int i)
        {
            if (i >= array.Length)
            {
                Array.Resize(ref array, i + 1);
            }
            return array;
        }
    }
}

