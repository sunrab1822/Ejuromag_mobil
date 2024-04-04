using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejuromag.Models
{


    public class UserRoot
    {
        public bool error { get; set; }
        public User user { get; set; }
    }

    public class User
    {
        public UserData user { get; set; }
        public string token { get; set; }
    }

    public class UserData
    {
        public string name { get; set; }
        public string email { get; set; }
        public int role { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public int id { get; set; }
    }

}
