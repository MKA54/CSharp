using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
    internal class Program
    {
        static void Main()
        {
            var list = new List<Person>
            {
                new Person("Роман", 12),
                new Person("Игнат", 25),
                new Person("Ольга", 38),
                new Person("Мария", 25),
                new Person("Валентина", 41),
                new Person("Лазарь", 34),
                new Person("Николай", 17),
                new Person("Мария", 35),
                new Person("Роман", 41),
                new Person("Галина", 56),
            };

            var uniqueList = list.Distinct(new InstanceNamesComparer());

            foreach (var item in uniqueList)
            {
                Console.WriteLine(item);
            }

            string allNamesString = string.Join(", ",
                uniqueList.Select(person => person.Name)).Insert(0, "Имена: ");

            Console.WriteLine("Список уникальных имен");
            Console.WriteLine(allNamesString);

            var minors = list.
                Where(person => person.Age < 18)
                .ToList();
            Console.WriteLine();

            Console.WriteLine("Список несовершеннолетних:");
            minors.ForEach(value => Console.WriteLine(value.ToString()));
            Console.WriteLine();

            var averageAgeMinors = minors.Average(person => person.Age);
            Console.WriteLine($"Средний возраст несовершеннолетних: {averageAgeMinors}");

            var middleAgedPeople = list
                .Where(person => person.Age >= 20 && person.Age <= 45)
                .ToList();
            Console.WriteLine();

            Console.WriteLine("Список людей среднего возраста:");
            middleAgedPeople.ForEach(value => Console.WriteLine(value.ToString()));
            Console.WriteLine();

            var newList = list
                .GroupBy(person => person.Name)
                .ToDictionary(person => person.Key, p => list.Average(person => person.Age));

            Console.WriteLine("Список имен со средним возрастом списка:");
            foreach(var item in newList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}