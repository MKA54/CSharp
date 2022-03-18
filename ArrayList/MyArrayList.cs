using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    internal class MyArrayList<T> : IList<T>
    {
        public MyArrayList()
        {
            Items = new T[10];
        }

        public MyArrayList(ICollection collection)
        {
            Items = new T[collection.Count];
            Items.CopyTo((Array)collection, 0);

            Lenght = collection.Count;
        }

        public MyArrayList(int initialCapacity)
        {
            Items = new T[initialCapacity];
        }

        public T[] Items
        {
            get;
            set;
        }

        public int Lenght
        {
            get;
            set;
        }

        public T this[int index]
        {
            get => Items[index];
            set => Items[index] = value;
        }

        public int Count => Lenght;

        public bool IsReadOnly => throw new NotImplementedException();

        public void IncreaseCapacity()
        {
            T[] old = Items;
            Items = new T[old.Length * 2];
            Array.Copy(old, 0, Items, 0, old.Length);
        }

        public void Add(T item)
        {
            if (Lenght >= Items.Length)
            {
                IncreaseCapacity();
            }

            Items[Lenght] = item;

            Lenght++;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int Index)
        {
            if (Index < Lenght - 1)
            {
                Array.Copy(Items, Index + 1, Items, Index, Lenght - Index - 1);
            }

            Lenght--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}