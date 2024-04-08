using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejuromag.Models
{


    public class Product
    {
        public bool error { get; set; }
        public Data[] data { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public Category category_id { get; set; }
        public Manufacturer manufacturer_id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string picture { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }


}
