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
                new Person("Николай", 12),
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
                uniqueList.Select(p => p.Name)).Insert(0, "Имен: ");

            Console.WriteLine($"Список уникальных {allNamesString}");
        }
    }
}