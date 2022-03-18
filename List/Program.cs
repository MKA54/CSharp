using System;

namespace List
{
    internal class Program
    {
        static void Main()
        {
            List.SinglyLinkedList<string> namesList = new List.SinglyLinkedList<string>("Петр");

            namesList.Add("Андрей");
            namesList.Add("Степан");
            namesList.Add("Владимир");
            namesList.Add("Константин");
            namesList.Add(null);
            namesList.Add("Василий");
            namesList.Add("Григорий");

            Console.WriteLine("Список: {0}", namesList.ToString());

            Console.WriteLine("Размер списка: {0}", namesList.GetSize());

            Console.WriteLine("Первое значение списка: {0}", namesList.GetFirstData());

            string name = namesList.GetDataByIndex(6);

            Console.WriteLine("Полученное значение по индексу: {0}", name);

            string oldData = namesList.SetDataByIndex(6, "Роман");
            Console.WriteLine("Старое значение по индексу: {0}", oldData);

            Console.WriteLine("Список: {0}", namesList);

            oldData = namesList.DeleteByIndex(2);
            Console.WriteLine("Удаленное значение по индексу: {0}", oldData);

            namesList.AddFirst("Виктор");
            Console.WriteLine("Список: {0}", namesList);

            namesList.InsertByIndex(7, "Глеб");
            Console.WriteLine("Список: {0}", namesList);

            bool isDeleted = namesList.DeleteByData("Владимир");
            Console.WriteLine("Узел удален: {0}", isDeleted);

            oldData = namesList.DeleteFirst();
            Console.WriteLine("Удаленное значение: {0}", oldData);

            namesList.Reverse();
            Console.WriteLine("Список: {0}", namesList);

            List.SinglyLinkedList<string> Copy = namesList.Copy();
            Console.WriteLine("Копия списка: {0}", Copy);
        }
    }
}