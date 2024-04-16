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
            List<Product> productList = new List<Product>();
            Parallel.Invoke(() =>
            {
                string url = "https://bgs.jedlik.eu/ejuromag/Ejuromag/api/products";
                productList = HTTPConnection<ProductRoot>.Get(url).Result.data.ToList();
            });
            return productList;
        }

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            Parallel.Invoke(() =>
            {
                string url = "https://bgs.jedlik.eu/ejuromag/Ejuromag/api/categories";
                categories = HTTPConnection<CategoryRoot>.Get(url).Result.data.ToList();
            });
            categories.Insert(0, new Category() { id = 0, categoryName = "Mind" });
            return categories;
        }

        public static List<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            Parallel.Invoke(() =>
            {
                string url = "https://bgs.jedlik.eu/ejuromag/Ejuromag/api/manufacturers";
                manufacturers = HTTPConnection<ManufacturerRoot>.Get(url).Result.data.ToList();
            });
            return manufacturers;
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
