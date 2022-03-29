using System;
using System.Collections.Generic;

namespace ArrayList
{
    internal class Program
    {
        private static void Main()
        {
            var emptyList = new MyArrayList<string>();
            Console.WriteLine($"Пустой список: {emptyList}");
            Console.WriteLine($"Количество элементов в списке: {emptyList.Length}");

            var mansNames = new MyArrayList<string>();

            mansNames.Add("Петр");
            mansNames.Add("Сергей");
            mansNames.Add("Иван");
            mansNames.Add("Глеб");
            mansNames.Add("Евгений");
            mansNames.Add("Роман");
            mansNames.Add("Евгений");

            Console.WriteLine($"Список мужских имён: {mansNames}");
            Console.WriteLine($"Количество элементов в списке: {mansNames.Count}");

            var namesList = new List<string> { "Ольга", "Жанна", "Мария", "Алла" };

            var womens = new MyArrayList<string>(namesList);
            Console.WriteLine($"Список женских имён: {womens}");

            const int index = 5;
            Console.WriteLine($"Элемент по индексу {index}: {mansNames[index]}");

            const string name1 = "Григорий";
            mansNames[index] = name1;

            Console.WriteLine($"Список мужских имён: {mansNames}");

            Console.WriteLine($"Нахождения имени {name1} в списке: " +
                $"{mansNames.Contains(name1)}");
            Console.WriteLine($"Нахождения имени {name1} в списке: " +
                $"{womens.Contains(name1)}");

            Console.WriteLine($"Индекс первого вхождения имени {name1} в списке: " +
                $"{mansNames.IndexOf(name1)}");
            Console.WriteLine($"Индекс первого вхождения имени {name1} в списке: " +
                $"{womens.IndexOf(name1)}");

            var isDeleted = mansNames.Remove("Евгений");

            Console.WriteLine($"Результат удаления: {isDeleted}");
            Console.WriteLine($"Список мужских имён после удаления: {mansNames}");

            const string name2 = "Павел";

            mansNames.Insert(1, name2);
            Console.WriteLine($"Список мужских имён после вставки: {mansNames}");

            mansNames.RemoveAt(5);
            Console.WriteLine($"Список мужских имён: {mansNames}");

            var newNames = new[] {"Ольга", "Светлана", "Эльвира","", ""};

            mansNames.CopyTo(newNames, 2);

            Console.WriteLine("Массив женских имён после копирования мужских:");
            foreach (var name in newNames)
            {
                Console.WriteLine(name);
            }

            mansNames.Clear();

            Console.WriteLine($"Список после очистки: {mansNames}");
            Console.WriteLine($"Количество элементов в списке: {mansNames.Count}");
        }
    }
}