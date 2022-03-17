using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.List
{
    internal class SinglyLinkedList<T>
    {
        public SinglyLinkedList() { }

        public SinglyLinkedList(T Data) {
            Head = new List.ListItem<T>(Data);
            ++Size;
        }

        public ListItem<T> Head
        {
            get;
            set;
        }

        public int Size
        {
            get;
            set;
        }

        public int GetSize() => Size;

        public void Add(T Data)
        {
            InsertByIndex(Size, Data);
        }

        public T GetFirstData()
        {
            CheckListSize();

            return Head.Data;
        }

        private void CheckIndex(int Index)
        {
            if (Index < 0 || Index >= Size)
            {
                throw new IndexOutOfRangeException("Index must be from 0 to " + (Size - 1) + ". Index = " + Index);
            }
        }

        private void CheckListSize()
        {
            if (Size == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }
        }

        private ListItem<T> GetByIndex(int Index)
        {
            CheckIndex(Index);

            ListItem<T> Item = null;
            int I = 0;

            for (var Current = Head; Current != null; Current = Current.Next)
            {
                if (Index == I)
                {
                    Item = Current;

                    break;
                }

                ++I;
            }

            return Item;
        }

        public T GetDataByIndex(int Index)
        {
            return GetByIndex(Index).Data;
        }

        public T SetDataByIndex(int Index, T Data)
        {
            var Item = GetByIndex(Index);

            T OldData = Item.Data;

            Item.Data = Data;

            return OldData;
        }

        public T DeleteByIndex(int Index)
        {
            CheckIndex(Index);

            if (Index == 0)
            {
                return DeleteFirst();
            }

            var Previous = GetByIndex(Index - 1);
            var Current = Previous.Next;

            T Data = Current.Data;

            Previous.Next = Current.Next;

            --Size;

            return Data;
        }

        public void AddFirst(T Data)
        {
            Head = new ListItem<T>(Data, Head);

            ++Size;
        }

        public void InsertByIndex(int Index, T Data)
        {
            if (Size != Index)
            {
                CheckIndex(Index);
            }

            if (Index == 0)
            {
                AddFirst(Data);

                return;
            }

            var NewItem = new ListItem<T>(Data);
            var Previous = GetByIndex(Index - 1);

            NewItem.Next = Previous.Next;
            Previous.Next = NewItem;

            ++Size;
        }

        public bool DeleteByData(T Data)
        {
            if (Size == 0)
            {
                return false;
            }

            if (Equals(Head.Data, Data))
            {
                DeleteFirst();

                return true;
            }

            for (ListItem<T> Current = Head.Next, Previous = Head; Current != null; Previous = Current, Current = Current.Next)
            {
                if (Equals(Data, Current.Data))
                {
                    Previous.Next = Current.Next;

                    --Size;

                    return true;
                }
            }

            return false;
        }

        public T DeleteFirst()
        {
            CheckListSize();

            T Data = Head.Data;

            Head = Head.Next;

            Size--;

            return Data;
        }

        public void Reverse()
        {
            ListItem<T> Previous = null;
            ListItem<T> Current = Head;

            while (Current != null)
            {
                ListItem<T> next = Current.Next;

                Current.Next = Previous;
                Previous = Current;
                Current = next;
            }

            Head = Previous;
        }

        public SinglyLinkedList<T> Copy()
        {
            if (Size == 0)
            {
                return new SinglyLinkedList<T>();
            }

            SinglyLinkedList<T> Copy = new SinglyLinkedList<T>(Head.Data);

            for (ListItem<T> Current = Head.Next, CurrentCopy = Copy.Head; Current != null; Current = Current.Next,
                    CurrentCopy = CurrentCopy.Next)
            {
                ListItem<T> ItemCopy = new ListItem<T>(Current.Data);

                CurrentCopy.Next = ItemCopy;
            }

            Copy.Size = Size;

            return Copy;
        }

      
        public override String ToString()
        {
            if (Size == 0)
            {
                return "{}";
            }

            StringBuilder StringBuilder = new StringBuilder();

            StringBuilder.Append("{");

            for (var Current = Head; Current != null; Current = Current.Next)
            {
                if(Current.Data == null)
                {
                    StringBuilder.Append("null").Append(", ");
                    continue;
                }

                StringBuilder.Append(Current.Data).Append(", ");
            }

            StringBuilder.Remove(StringBuilder.Length - 2, 2);

            StringBuilder.Append("}");

            return StringBuilder.ToString();
        }
    }
}