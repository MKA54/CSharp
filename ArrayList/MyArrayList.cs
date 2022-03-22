using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    internal class MyArrayList<T> : IList<T>
    {
        private static readonly int DEFAULT_CAPACITY = 10;

        public MyArrayList()
        {
            Items = new T[DEFAULT_CAPACITY];
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
                Items[Lenght] = item;

                Lenght++;
            }
        }

        public MyArrayList(int initialCapacity)
        {
            Items = new T[initialCapacity];
        }

        public T[] Items { get; set; }

        public int Lenght { get; set; }

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

        public int Count => Lenght;

        public bool IsReadOnly => false;

        private void IncreaseCapacity()
        {
            T[] oldItems = Items;
            Items = new T[oldItems.Length * 2];

            Array.Copy(oldItems, 0, Items, 0, oldItems.Length);
        }

        private void EnsureCapacity(int minCapacity)
        {
            if (minCapacity > Items.Length)
            {
                var newArray = Items;

                Array.Resize(ref newArray, minCapacity);

                Items = newArray;
            }
        }

        public void Add(T item)
        {
            if (Lenght + 1 > Items.Length)
            {
                IncreaseCapacity();
            }

            Items[Lenght] = item;

            Lenght++;
            ModCount++;
        }

        public void Clear()
        {
            for (var i = 0; i < Lenght; i++)
            {
                Items[i] = default;
            }

            Lenght = 0;
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

            if (array.Length + Lenght > Items.Length)
            {
                EnsureCapacity(array.Length + Lenght);
            }

            T[] temp = new T[Items.Length];

            Array.Copy(Items, 0, temp, 0, arrayIndex);
            Array.Copy(Items, arrayIndex, temp, arrayIndex + array.Length, Lenght - arrayIndex);

            var i = arrayIndex;

            foreach (T element in array)
            {
                temp[i] = element;

                i++;
            }

            Items = temp;

            Lenght += array.Length;
            ModCount++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentMod = ModCount;

            for (var i = 0; i < Lenght; i++)
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
            for (var i = 0; i < Lenght; i++)
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
            for (var i = 0; i < Lenght; i++)
            {
                if (Equals(Items[i], item))
                {
                    Items[i] = default;

                    Lenght--;
                    ModCount++;

                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int Index)
        {
            if (Index < Lenght - 1)
            {
                Array.Copy(Items, Index + 1, Items, Index, Lenght - Index - 1);
            }

            Lenght--;
            ModCount++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Lenght)
            {
                throw new ArgumentOutOfRangeException($"Index must be from 0 to {Lenght - 1}. Index = {index}");
            }
        }

        public override string ToString()
        {
            if (Lenght == 0)
            {
                return "{}";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{");

            var count = 0;

            for (var i = 0; i < Items.Length; i++)
            {
                if (count == Lenght)
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