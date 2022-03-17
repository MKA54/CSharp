using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.List
{
    internal class ListItem<T>
    {
        public ListItem(T Data)
        {
            this.Data = Data;
        }

        public ListItem(T Data, ListItem<T> Next)
        {
            this.Data = Data;
            this.Next = Next;
        }

        public T Data
        {
            get;
            set;
        }

        public ListItem<T> Next
        {
            get;
            set;
        }
    }
}