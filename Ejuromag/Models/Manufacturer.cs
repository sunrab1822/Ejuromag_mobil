using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejuromag.Models
{

    public class ManufacturerRoot
    {
        public bool error { get; set; }
        public Manufacturer[] data { get; set; }
    }

    public class Manufacturer
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
