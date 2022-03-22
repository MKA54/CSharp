using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
    internal class InstanceNamesComparer : EqualityComparer<Person>
    {
        public override bool Equals(Person p1, Person p2)
        {
            if (Object.ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (Object.ReferenceEquals(p1, null) || Object.ReferenceEquals(p2, null))
            {
                return false;
            }

            return Equals(p1.Name, p2.Name);
        }

        public override int GetHashCode(Person p)
        {
            if (Object.ReferenceEquals(p, null))
            {
                return 0;
            }

            if(p.Name == null)
            {
                return 0;
            }

            var prime = 37;
            var hash = 1; 

            return prime * hash + p.Name.GetHashCode();
        }
    }
}