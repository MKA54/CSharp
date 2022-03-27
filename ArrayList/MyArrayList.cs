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

        public int ModCount { get; set; }

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
            var oldItems = Items;
            Items = new T[oldItems.Length * 2];

            Array.Copy(oldItems, 0, Items, 0, oldItems.Length);
        }

        private void EnsureCapacity(int minCapacity)
        {
            if (minCapacity <= Items.Length)
            {
                return;
            }

            var newArray = Items;

            Array.Resize(ref newArray, minCapacity);

            Items = newArray;
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
                throw new ArgumentNullException("Добавляемая коллекция пустая");
            }

            CheckIndex(arrayIndex);

            if (array.Length + Length > Items.Length)
            {
                EnsureCapacity(array.Length + Length);
            }

            T[] temp = new T[Items.Length];

            Array.Copy(Items, 0, temp, 0, arrayIndex);
            Array.Copy(Items, arrayIndex, temp, arrayIndex + array.Length, Length - arrayIndex);

            var i = arrayIndex;

            foreach (T element in array)
            {
                temp[i] = element;

                i++;
            }

            Items = temp;

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

            Items[index] = item;

            ModCount++;
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < Length; i++)
            {
                if (Equals(Items[i], item))
                {
                    Items[i] = default;

                    Length--;
                    ModCount++;

                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int Index)
        {
            if (Index < Length - 1)
            {
                Array.Copy(Items, Index + 1, Items, Index, Length - Index - 1);
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

                if (Items[i] != null)
                {
                    stringBuilder.Append(Items[i]).Append(", ");
                    count++;
                }
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }
    }
}