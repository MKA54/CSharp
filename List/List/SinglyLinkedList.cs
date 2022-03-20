using System;
using System.Text;

namespace List.List
{
    internal class SinglyLinkedList<T>
    {
        public SinglyLinkedList() { }

        public SinglyLinkedList(T data)
        {
            Head = new ListItem<T>(data);
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

        public void Add(T data)
        {
            InsertByIndex(Size, data);
        }

        public T GetFirstData()
        {
            CheckListSize();

            return Head.Data;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException($"Index must be from 0 to {Size - 1}" +
                    $". Index = {index}");
            }
        }

        private void CheckListSize()
        {
            if (Size == 0)
            {
                throw new ArgumentNullException("The list is empty");
            }
        }

        private ListItem<T> GetByIndex(int index)
        {
            CheckIndex(index);

            ListItem<T> item = null;
            int i = 0;

            for (var current = Head; current != null; current = current.Next)
            {
                if (index == i)
                {
                    item = current;

                    break;
                }

                ++i;
            }

            return item;
        }

        public T GetDataByIndex(int index) => GetByIndex(index).Data;

        public T SetDataByIndex(int index, T data)
        {
            var item = GetByIndex(index);

            T oldData = item.Data;

            item.Data = data;

            return oldData;
        }

        public T DeleteByIndex(int index)
        {
            CheckIndex(index);

            if (index == 0)
            {
                return DeleteFirst();
            }

            var previous = GetByIndex(index - 1);
            var current = previous.Next;

            T data = current.Data;

            previous.Next = current.Next;

            --Size;

            return data;
        }

        public void AddFirst(T data)
        {
            Head = new ListItem<T>(data, Head);

            ++Size;
        }

        public void InsertByIndex(int index, T data)
        {
            if (Size != index)
            {
                CheckIndex(index);
            }

            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            var newItem = new ListItem<T>(data);
            var previous = GetByIndex(index - 1);

            newItem.Next = previous.Next;
            previous.Next = newItem;

            ++Size;
        }

        public bool DeleteByData(T data)
        {
            if (Size == 0)
            {
                return false;
            }

            if (Equals(Head.Data, data))
            {
                DeleteFirst();

                return true;
            }

            for (ListItem<T> current = Head.Next, previous = Head; current != null;
                previous = current, current = current.Next)
            {
                if (Equals(data, current.Data))
                {
                    previous.Next = current.Next;

                    --Size;

                    return true;
                }
            }

            return false;
        }

        public T DeleteFirst()
        {
            CheckListSize();

            T data = Head.Data;

            Head = Head.Next;

            Size--;

            return data;
        }

        public void Reverse()
        {
            ListItem<T> previous = null;
            ListItem<T> current = Head;

            while (current != null)
            {
                ListItem<T> next = current.Next;

                current.Next = previous;
                previous = current;
                current = next;
            }

            Head = previous;
        }

        public SinglyLinkedList<T> Copy()
        {
            if (Size == 0)
            {
                return new SinglyLinkedList<T>();
            }

            SinglyLinkedList<T> copy = new SinglyLinkedList<T>(Head.Data);

            for (ListItem<T> current = Head.Next, currentCopy = copy.Head; current != null;
                current = current.Next, currentCopy = currentCopy.Next)
            {
                ListItem<T> itemCopy = new ListItem<T>(current.Data);

                currentCopy.Next = itemCopy;
            }

            copy.Size = Size;

            return copy;
        }


        public override String ToString()
        {
            if (Size == 0)
            {
                return "{}";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{");

            for (var current = Head; current != null; current = current.Next)
            {
                if (current.Data == null)
                {
                    stringBuilder.Append("null").Append(", ");
                    continue;
                }

                stringBuilder.Append(current.Data).Append(", ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);

            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }
    }
}