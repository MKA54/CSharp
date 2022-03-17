using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    internal class Program
    {
        static void Main()
        {
            List.SinglyLinkedList<string> NamesList = new List.SinglyLinkedList<string>("Петр");

            NamesList.Add("Андрей");
            NamesList.Add("Степан");
            NamesList.Add("Владимир");
            NamesList.Add("Константин");
            NamesList.Add(null);
            NamesList.Add("Василий");
            NamesList.Add("Григорий");

            Console.WriteLine("Список: " + NamesList.ToString());

            Console.WriteLine("Размер списка: " + NamesList.GetSize());

            Console.WriteLine("Первое значение списка: " + NamesList.GetFirstData());

            string Name = NamesList.GetDataByIndex(6);

            Console.WriteLine("Полученное значение по индексу: " + Name);

            string OldData = NamesList.SetDataByIndex(6, "Роман");
            Console.WriteLine("Старое значение по индексу: " + OldData);

            Console.WriteLine("Список: " + NamesList);

            OldData = NamesList.DeleteByIndex(2);
            Console.WriteLine("Удаленное значение по индексу: " + OldData);

            NamesList.AddFirst("Виктор");
            Console.WriteLine("Список: " + NamesList);

            NamesList.InsertByIndex(7, "Глеб");
            Console.WriteLine("Список: " + NamesList);

            bool IsDeleted = NamesList.DeleteByData("Владимир");
            Console.WriteLine("Узел удален: " + IsDeleted);

            OldData = NamesList.DeleteFirst();
            Console.WriteLine("Удаленное значение: " + OldData);

            NamesList.Reverse();
            Console.WriteLine("Список: " + NamesList);

            List.SinglyLinkedList<string> Copy = NamesList.Copy();
            Console.WriteLine("Копия списка: " + Copy);
        }
    }
}