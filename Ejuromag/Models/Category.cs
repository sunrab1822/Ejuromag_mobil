using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejuromag.Models
{

    public class CategoryRoot
    {
        public bool error { get; set; }
        public Category[] data { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
    }

}
