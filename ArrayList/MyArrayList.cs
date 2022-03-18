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
        public T[] Items
        {
            get => Items;      
            set
            {
                Items = new T[10];
            }
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
            T[] Old = Items;
            Items = new T[Old.Length * 2];
            Array.Copy(Old, 0, Items, 0, Old.Length);
        }

        public void Add(T Item)
        {
            if(Lenght >= Items.Length)
            {
                IncreaseCapacity();
            }

            Items[Lenght] = Item;

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

        public void RemoveAt(int index)
        {
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}