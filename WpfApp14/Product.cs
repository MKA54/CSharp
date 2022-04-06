using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp14
{
    public enum Category
    {
        Food,
        Appliances

    }

    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
    }
}
