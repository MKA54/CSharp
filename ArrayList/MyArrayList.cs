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
            Items = new T[DefaultCapacity];
        }

        public MyArrayList(ICollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"Collection does not exist, collection: {null}");
            }

            Items = new T[collection.Count];

            foreach (T item in collection)
            {
                Items[Length] = item;

                Length++;
            }
        }

        public MyArrayList(int initialCapacity)
        {
            Items = new T[initialCapacity];
        }

        public T[] Items { get; set; }

        public int Length { get; set; }

        private long ModCount { get; set; }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return Items[index];
            }

            set
            {
                CheckIndex(index);

                Items[index] = value;
            }
        }

        public int Count => Length;

        public bool IsReadOnly => false;

        private void IncreaseCapacity()
        {
            var newItems = new T[Items.Length * 2];

            for (var i = 0; i < Items.Length; i++)
            {
                newItems[i] = Items[i];
            }

            Items = newItems;
        }

        private void EnsureCapacity(int minCapacity)
        {
            if (minCapacity <= Items.Length)
            {
                return;
            }

            var newItems = new T[minCapacity];

            for (var i = 0; i < Items.Length; i++)
            {
                newItems[i] = Items[i];
            }

            Items = newItems;
        }

        public void Add(T item)
        {
            if (Length + 1 > Items.Length)
            {
                IncreaseCapacity();
            }

            Items[Length] = item;

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
                Items[i] = default;
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

            for (var i = arrayIndex; i < array.Length; i++)
            {
                array[i] = Items[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentMod = ModCount;

            for (var i = 0; i < Length; i++)
            {
                if (currentMod != ModCount)
                {
                    throw new InvalidOperationException("The collection has changed");
                }

                yield return Items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < Length; i++)
            {
                if (Equals(Items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            CheckIndex(index);

            EnsureCapacity(Items.Length + 1);

            var newItem = new T[Items.Length];

            var j = 0;

            for (var i = 0; i <= Length + 1; i++)
            {
                if (i == index)
                {
                    newItem[i] = item;

                    continue;
                }

                newItem[i] = Items[j];

                j++;
            }

            Items = newItem;

            if (long.MaxValue == ModCount)
            {
                ModCount = 0;
            }

            Length++;
            ModCount++;
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < Length; i++)
            {
                if (!Items[i].Equals(item))
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
            var temp = Items;

            for (var i = index; i < Length; i++)
            {
                Items[i] = temp[i + 1];
            }

            if (long.MaxValue == ModCount)
            {
                ModCount = 0;
            }

            Length--;
            ModCount++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException($"Index must be from 0 to {Length - 1}. Index = {index}");
            }
        }

        public override string ToString()
        {
            if (Length == 0)
            {
                return "{}";
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.Append("{");

            var count = 0;

            foreach (var item in Items)
            {
                if (count == Length)
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