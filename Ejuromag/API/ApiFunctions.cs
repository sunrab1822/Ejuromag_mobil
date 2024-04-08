using Ejuromag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejuromag.API
{
    public static class ApiFunctions
    {
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            Parallel.Invoke(() =>
            {
                string url = "https://bgs.jedlik.eu/ejuromag/Ejuromag/api/products";
                products = HTTPConnection<List<Product>>.Get(url).Result;
            });
            return products;
        }

        public static User Register(string name ,string email, string password, string password2)
        {
            UserRoot user = null;
            Parallel.Invoke(() =>
            {
                string url = "https://bgs.jedlik.eu/ejuromag/Ejuromag/api/register";
                string content ='{' + $"\r\\n    \\\"name\\\": \\\"{name}\\\",\\r\\n    \\\"email\\\": \\\"{email}\\\",\\r\\n    \\\"password\\\": \\\"{password}\\\",\\r\\n    \\\"password_confirmation\\\": \\\"{password2}\\\"\\r\\n" + "}";
                user = HTTPConnection<UserRoot>.Post(url, content).Result;
            });
            if (user != null)
                return user.user;
            return null;
        }
    }
}
