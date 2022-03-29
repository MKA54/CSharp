using System;

namespace List
{
    internal class Program
    {
        private static void Main()
        {
            var namesList = new List.SinglyLinkedList<string>("Петр");

            namesList.Add("Андрей");
            namesList.Add("Степан");
            namesList.Add("Владимир");
            namesList.Add("Константин");
            namesList.Add(null);
            namesList.Add("Василий");
            namesList.Add("Григорий");

            Console.WriteLine($"Список: {namesList}");

            Console.WriteLine($"Размер списка: {namesList.Size}");

            Console.WriteLine($"Первое значение списка: {namesList.GetFirstData()}");

            var name = namesList.GetDataByIndex(6);

            Console.WriteLine($"Полученное значение по индексу: {name}");

            var oldData = namesList.SetDataByIndex(6, "Роман");
            Console.WriteLine($"Старое значение по индексу: {oldData}");

            Console.WriteLine($"Список: {namesList}");

            oldData = namesList.DeleteByIndex(2);
            Console.WriteLine($"Удаленное значение по индексу: {oldData}");

            namesList.AddFirst("Виктор");
            Console.WriteLine($"Список: {namesList}");

            namesList.InsertByIndex(7, "Глеб");
            Console.WriteLine($"Список: {namesList}");

            var isDeleted = namesList.DeleteByData("Владимир");
            Console.WriteLine($"Узел удален: {isDeleted}");

            oldData = namesList.DeleteFirst();
            Console.WriteLine($"Удаленное значение: {oldData}");

            namesList.Reverse();
            Console.WriteLine($"Список: {namesList}");

            var copy = namesList.Copy();
            Console.WriteLine($"Копия списка: {copy}");
        }
    }
}