namespace List.List
{
    internal class ListItem<T>
    {
        public ListItem(T data)
        {
            Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
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