using System.Collections.Generic;

namespace Lambdas
{
    internal class InstanceNamesComparer : EqualityComparer<Person>
    {
        public override bool Equals(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (p1 is null|| p2 is null)
            {
                return false;
            }

            return Equals(p1.Name, p2.Name);
        }

        public override int GetHashCode(Person p)
        {
            if (p.Name == null)
            {
                return 0;
            }

            const int prime = 37;
            const int hash = 1; 

            return prime * hash + p.Name.GetHashCode();
        }
    }
}