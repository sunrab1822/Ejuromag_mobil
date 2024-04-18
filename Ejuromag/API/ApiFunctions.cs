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
                string content ='{' + $"\r\n  \"name\": \"{name}\",\r\n  \"email\": \"{email}\",\r\n  \"password\": \"{password}\",\r\n  \"password_confirmation\": \"{password2}\"\r\n" + '}';
                user = HTTPConnection<UserRoot>.Post(url, content, null).Result;
            });
            if (user != null)
                return user.user;
            return null;
        }

        public static User Login(string email, string password)
        {
            UserRoot user = null;
            Parallel.Invoke(() =>
            {
                string url = "https://bgs.jedlik.eu/ejuromag/Ejuromag/api/login";
                string content = '{' + $"\r\n  \"email\": \"{email}\",\r\n  \"password\": \"{password}\"\r\n" + '}';
                user = HTTPConnection<UserRoot>.Post(url, content, null).Result;
            });
            if (user != null)
                return user.user;
            return null;
        }

        public static MessageRoot Logout(string header)
        {
            MessageRoot message = null;
            Parallel.Invoke(() =>
            {
                string url = "https://bgs.jedlik.eu/ejuromag/Ejuromag/api/logout";
                string content = "{ }";
                message = HTTPConnection<MessageRoot>.Post(url, content, header).Result;
            });
            if (message != null)
                return message;
            return null;
        }

        public static MessageRoot ResetPassword(string email)
        {
            MessageRoot message = null;
            Parallel.Invoke(() =>
            {
                string url = "https://bgs.jedlik.eu/ejuromag/Ejuromag/api/reset-password-token";
                string content = '{' + $"\r\n  \"email\": \"{email}\"" + '}';
                message = HTTPConnection<MessageRoot>.Post(url, content, null).Result;
            });
            if (message != null)
                return message;
            return null;
        }

        public static User SendOrder(string email, string address, int[] productsID, string header)
        {
            UserRoot user = null;
            Parallel.Invoke(() =>
            {
                string url = "https://bgs.jedlik.eu/ejuromag/Ejuromag/api/create-order";
                string content = '{' + $"\r\n  \"email\": \"{email}\",\r\n  \"address\": \"{address}\",\r\n  \"products\": {productsID}\r\n" + '}';
                user = HTTPConnection<UserRoot>.Post(url, content, header).Result;
            });
            if (user != null)
                return user.user;
            return null;
        }
    }
}
