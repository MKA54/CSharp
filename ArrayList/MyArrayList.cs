using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    internal class MyArrayList<T> : IList<T>
    {
        private static readonly int DefaultCapacity = 10;

        public MyArrayList()
        {
            Items = new T[DefaultCapacity];
        }

        public MyArrayList(ICollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Пустая коллекция");
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

        public long ModCount { get; set; }

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
            ModCount++;
        }

        public bool Contains(T item) => IndexOf(item) >= 0;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("The collection being added is empty");
            }

            if (arrayIndex < 0 || arrayIndex > Count || arrayIndex > 0 && arrayIndex < Count)
            {
                throw new ArgumentOutOfRangeException($"Invalid index value, index {arrayIndex}");
            }

            if (array.Length + Length > Items.Length)
            {
                EnsureCapacity(array.Length + Length);
            }

            if (arrayIndex == 0)
            {
                var temp = new T[array.Length + Length];

                for (var i = 0; i < array.Length; i++)
                {
                    temp[i] = array[i];
                }

                var k = 0;

                for (var j = array.Length; j < Count + array.Length; j++)
                {
                    temp[j] = Items[k];

                    k++;
                }

                Items = temp;
            }
            else
            {
                var init = Count;

                for (var i = 0; i < array.Length; i++)
                {
                    Items[init] = array[i];

                    init++;
                }
            }

            Length += array.Length;
            ModCount++;
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

            Length++;
            ModCount++;
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < Length; i++)
            {
                if (Items[i].Equals(item))
                {
                    RemoveAt(i);

                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int Index)
        {
            var temp = Items;

            for (var i = Index; i < Length; i++)
            {
                Items[i] = temp[i + 1];
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

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{");

            var count = 0;

            for (var i = 0; i < Items.Length; i++)
            {
                if (count == Length)
                {
                    break;
                }

                stringBuilder.Append(Items[i]).Append(", ");
                count++;
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }
    }
}