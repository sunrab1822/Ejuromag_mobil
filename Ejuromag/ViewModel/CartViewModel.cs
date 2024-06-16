using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejuromag.ViewModel
{
    public partial class CartViewModel : ObservableObject
    {
        [ObservableProperty]
        string users;

        [ObservableProperty]
        string userEmail;

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string cartProducts;

        [ObservableProperty]
        string productPrice;

        [ObservableProperty]
        string productImage;

        [ObservableProperty]
        string productName;

        [ObservableProperty]
        string productNumber;

        [ObservableProperty]
        string productStaticPrice;

        [RelayCommand]
        async void Appearing()
        {
            string CartProducts = SecureStorage.Default.GetAsync("CartProducts").Result;
            string[] slices = CartProducts.Split(";");
            ProductImage = slices[0];
            ProductName = slices[1];
            ProductPrice = slices[2];
            ProductNumber = slices[3];
            ProductStaticPrice = slices[4];

            string Users = SecureStorage.Default.GetAsync("userData").Result;
            string[] parts = Users.Split(";");
            UserEmail = parts[1];
            UserName = parts[0];

        }

        [RelayCommand]
        void PlusPiece()
        {
            int szam = int.Parse(ProductNumber);
            szam++;

            int ar = int.Parse(ProductPrice);
            ar += int.Parse(ProductStaticPrice);

            ProductNumber = Convert.ToString(szam);
            ProductPrice = Convert.ToString(ar);
        }

        [RelayCommand]
        void MinusPiece()
        {
            if(int.Parse(ProductNumber)== 1)
            {
                SecureStorage.Remove("CartProducts");
                ProductNumber = "0";
                ProductStaticPrice = "0";
                ProductPrice = "0";
                ProductName = "";
                ProductImage = "";
            }
            else
            {
                int szam = int.Parse(ProductNumber);
                szam--;

                int ar = int.Parse(ProductPrice);
                ar -= int.Parse(ProductStaticPrice);

                ProductNumber = Convert.ToString(szam);
                ProductPrice = Convert.ToString(ar);
            }
        }

        [RelayCommand]
        Task SetOrder()
        {
            if (ProductImage != null && ProductName != null && ProductNumber != null && ProductPrice != null)
            {
                if (SecureStorage.GetAsync("isLoggedIn").Result == $"{true}")
                {
                    Shell.Current.DisplayAlert("Order", "We recieved your order!", "OK");
                    SecureStorage.Remove("CartProducts");
                    ProductNumber = "0";
                    ProductStaticPrice = "0";
                    ProductPrice = "0";
                    ProductName = "";
                    ProductImage = "";
                    UserName = "";
                    UserEmail = "";
                    return Shell.Current.GoToAsync("MainPage");
                }
                else
                {
                    Shell.Current.DisplayAlert("Error", "Please login before purchasing something!", "OK");
                    return Shell.Current.GoToAsync("LoginView");
                }
            }
            return Shell.Current.DisplayAlert("Error", "There are no products in the cart!", "OK");
        }

        [RelayCommand]
        Task GoToHome()
        {
            return Shell.Current.GoToAsync("../../..");
        }
    }
}
