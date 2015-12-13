using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public class GenericList<X> : IGenericList<X>
    {
        /// <summary>
        /// The actual storage for GenericList.
        /// </summary>
        private X[] _internalStorage;
        /// <summary>
        /// Size with which the GenericList was inititated.
        /// </summary>
        private int _initialSize;
        /// <summary>
        /// Current number of elements in the list.
        /// </summary>
        private int _size;
        public int Count
        {
            get
            {
                return _size;
            }
        }
        /// <summary>
        /// Default constructor for GenericList which initiates list with capacity of 4.
        /// </summary>
        public GenericList()
            : this(4)
        {
        }
        /// <summary>
        /// Constructor for GenericList which initiates list with specified capacity.
        /// </summary>
        public GenericList(int initialSize)
        {
            _initialSize = initialSize;
            _size = 0;
            _internalStorage = new X[initialSize];
        }
        public void Add(X item)
        {
            if (_size == _internalStorage.Length)
            {
                rearrange();
            }
            _internalStorage[_size] = item;
            _size++;
        }
        private void rearrange()
        {
            X[] temp = new X[_internalStorage.Length * 2];
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                temp[i] = _internalStorage[i];
            }
            _internalStorage = temp;
        }
        public void Clear()
        {
            _internalStorage = new X[_initialSize];
            _size = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index > _size - 1)
            {
                throw new IndexOutOfRangeException("The specified index is not in range");
            }
            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    moveOneLeft(i);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Method which moves all the elements after index one place left.
        /// Index is the first position at which the new elements are placed.
        /// </summary>
        private void moveOneLeft(int index)
        {
            for (int i = index; i < _size; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _size--;
        }

        public bool RemoveAt(int index)
        {
            if (index > _size - 1)
            {
                return false;
            }
            moveOneLeft(index);
            return true;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class GenericListEnumerator<X> : IEnumerator<X>
        {
            private GenericList<X> genericList;
            private int _current;

            public GenericListEnumerator(GenericList<X> genericList)
            {
                this.genericList = genericList;
                _current = 0;
            }

            public X Current
            {
                get
                {
                    _current++;
                    return genericList.GetElement(_current - 1);
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                //igrnored
            }

            public bool MoveNext()
            {
                if (_current < genericList.Count)
                {
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                //ignored
            }
        }
    }
}
