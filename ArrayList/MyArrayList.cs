using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    internal class MyArrayList<T> : IList<T>
    {
        private const int DefaultCapacity = 10;

        public MyArrayList()
        {
            _items = new T[DefaultCapacity];
        }

        public MyArrayList(ICollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"Collection does not exist, collection: {null}");
            }

            _items = new T[collection.Count];

            foreach (T item in collection)
            {
                _items[Length] = item;

                Length++;
            }
        }

        public MyArrayList(int initialCapacity)
        {
            _items = new T[initialCapacity];
        }

        private T[] _items;

        private int Length { get; set; }

        private long ModCount { get; set; }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return _items[index];
            }

            set
            {
                CheckIndex(index);

                _items[index] = value;
            }
        }

        public int Count => Length;

        public bool IsReadOnly => false;

        private void IncreaseCapacity()
        {
            var newItems = new T[_items.Length * 2];

            for (var i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        private void EnsureCapacity(int minCapacity)
        {
            if (minCapacity <= _items.Length)
            {
                return;
            }

            var newItems = new T[minCapacity];

            for (var i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        public void Add(T item)
        {
            if (Count + 1 > _items.Length)
            {
                IncreaseCapacity();
            }

            _items[Count] = item;

            if (long.MaxValue == ModCount)
            {
                ModCount = 0;
            }

            Length++;
            ModCount++;
        }

        public void Clear()
        {
            for (var i = 0; i < Length; i++)
            {
                _items[i] = default;
            }

            Length = 0;

            if (long.MaxValue == ModCount)
            {
                ModCount = 0;
            }

            ModCount++;
        }

        public bool Contains(T item) => IndexOf(item) >= 0;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Collection does not exist, collection: {null}");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length - 1)
            {
                throw new ArgumentOutOfRangeException($"Index must be from 0 to { array.Length - 1}." +
                                                      $"Index = {arrayIndex}");
            }

            for (var i = 0; i < Count; i++)
            {
                if (i + arrayIndex == array.Length)
                {
                    break;
                }

                array[i + arrayIndex] = _items[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentMod = ModCount;

            for (var i = 0; i < Count; i++)
            {
                if (currentMod != ModCount)
                {
                    throw new InvalidOperationException("The collection has changed");
                }

                yield return _items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (Equals(_items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            CheckIndex(index);

            EnsureCapacity(_items.Length + 1);

            var newItem = new T[_items.Length];

            var j = 0;

            for (var i = 0; i <= Count + 1; i++)
            {
                if (i == index)
                {
                    newItem[i] = item;

                    continue;
                }

                newItem[i] = _items[j];

                j++;
            }

            _items = newItem;

            if (long.MaxValue == ModCount)
            {
                ModCount = 0;
            }

            Length++;
            ModCount++;
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (!_items[i].Equals(item))
                {
                    continue;
                }

                RemoveAt(i);

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            var temp = _items;

            for (var i = index; i < Count; i++)
            {
                _items[i] = temp[i + 1];
            }

            Length--;

            if (Count < Math.Ceiling(_items.Length * 0.1))
            {
                TrimToSize();
            }

            if (long.MaxValue == ModCount)
            {
                ModCount = 0;
            }

            ModCount++;
        }

        public void TrimToSize()
        {
            var newItems = new T[Count];

            for (var i = 0; i < Count; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;

            if (long.MaxValue == ModCount)
            {
                ModCount = 0;
            }

            ModCount++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Index must be from 0 to {Count - 1}. Index = {index}");
            }
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "{}";
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.Append("{");

            var count = 0;

            foreach (var item in _items)
            {
                if (count == Count)
                {
                    break;
                }

                stringBuilder.Append(item).Append(", ");
                count++;
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }
    }
}