using System;
using System.Collections.Generic;

namespace ArrayList
{
    internal class Program
    {
        static void Main()
        {
            var emptyList = new MyArrayList<string>();
            Console.WriteLine($"Пустой список: {emptyList}");

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

            var womensNames = new MyArrayList<string>(namesList);
            Console.WriteLine($"Список женских имён: {womensNames}");

            var index = 5;
            Console.WriteLine($"Элемент по индексу {index}: {mansNames[index]}");

            var name1 = "Григорий";
            mansNames[index] = name1;

            Console.WriteLine($"Список мужских имён: {mansNames}");

            Console.WriteLine($"Нахождения имени {name1} в списке: " +
                $"{mansNames.Contains(name1)}");
            Console.WriteLine($"Нахождения имени {name1} в списке: " +
                $"{womensNames.Contains(name1)}");

            Console.WriteLine($"Индекс первого вхождения имени {name1} в списке: " +
                $"{mansNames.IndexOf(name1)}");
            Console.WriteLine($"Индекс первого вхождения имени {name1} в списке: " +
                $"{womensNames.IndexOf(name1)}");

            var name2 = "Павел";

            var isDeleted = mansNames.Remove("Евгений");

            Console.WriteLine($"Результат удаления: {isDeleted}");

            mansNames.Insert(index, name2);
            Console.WriteLine($"Список мужских имён: {mansNames}");

            mansNames.RemoveAt(5);
            Console.WriteLine($"Список мужских имён: {mansNames}");

            var newNames = new[] { "Юрий", "Владимир", "Станислав" };

            mansNames.CopyTo(newNames, 3);
            Console.WriteLine($"Список мужских имён: {mansNames}");

            IEnumerator<string> enumerator = mansNames.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string text = enumerator.Current;
                Console.WriteLine(text);
            }

            mansNames.Clear();

            Console.WriteLine($"Список после очистки: {mansNames}");
            Console.WriteLine($"Количество элементов в списке: {mansNames.Count}");
        }
    }
}