using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    internal class Program
    {
        static void Main()
        {
            MyArrayList<string> emptyList = new MyArrayList<string>();
            Console.WriteLine($"Пустой список: {emptyList}");

            MyArrayList<string> mansNames = new MyArrayList<string>();

            mansNames.Add("Петр");
            mansNames.Add("Сергей");
            mansNames.Add("Иван");
            mansNames.Add("Глеб");
            mansNames.Add("Евгений");
            mansNames.Add("Роман");
            mansNames.Add("Евгений");

            Console.WriteLine($"Список мужских имён: {mansNames}");
            Console.WriteLine($"Количество элементов в списке: {mansNames.Count}");

            List<string> namesList = new List<string> { "Ольга", "Жанна", "Мария", "Алла" };

            MyArrayList<string> womensNames = new MyArrayList<string>(namesList);
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

            mansNames.Insert(index, name2);
            Console.WriteLine($"Список мужских имён: {mansNames}");

            mansNames.RemoveAt(5);
            Console.WriteLine($"Список мужских имён: {mansNames}");

            string[] newNames = new[] { "Юрий", "Владимир", "Станислав"};
            mansNames.CopyTo(newNames, 2);

            Console.WriteLine($"Список мужских имён: {mansNames}");
        }
    }
}
