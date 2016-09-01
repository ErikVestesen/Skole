using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave5
{
    class GrowableArray
    {
        private int[] array = new int[10];
        public int this[int i]
        {
            get {
                this.array = growIfNeeded(i);
                return array[i];
            }

            set {
                this.array = growIfNeeded(i);
                array[i] = value;
                }
            }

            private int[] growIfNeeded(int i) {
                if (i >= array.Length) {
                    Array.Resize(ref array, i+1);
                }
                return array;
            }
        }
    }
