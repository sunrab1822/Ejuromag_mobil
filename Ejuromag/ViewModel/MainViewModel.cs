using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejuromag.API;
using Ejuromag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejuromag.ViewModel
{
    public partial class MainViewModel : ObservableObject 
    {

        [ObservableProperty]
        string loginOrName;

        [ObservableProperty]
        string usertoken;

        [ObservableProperty]
        bool logoutIsEnabled;

        [RelayCommand]
         async void NavigateToCart(string destination)
        {
            if (SecureStorage.GetAsync("isLoggedIn").Result == $"{true}")
            {
                if(SecureStorage.GetAsync("CartProducts").Result != null)
                {
                    await Shell.Current.GoToAsync($"{destination}");
                }
                else
                {
                   await Shell.Current.DisplayAlert("Error", "There are no items in the cart!", "OK");
                }
                
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "You can't see cart without logging in!", "OK");
            }
        }

        [RelayCommand]
        void NavigateToLogin(string destination)
        {
            Shell.Current.GoToAsync($"{destination}");
        }

        [RelayCommand]
        void NavigateToProducts(string categoryParam)
        {
            Category category = ApiFunctions.GetCategories().Where(x => x.categoryName == categoryParam).FirstOrDefault();
            if (category != null)
            {
                Dictionary<string, object> navigationParameters = new Dictionary<string, object>()
                {
                    {"Category", category }
                };
                Shell.Current.GoToAsync($"ProductsView",true,navigationParameters);
            }
        }

        [RelayCommand]
        async void Appearing()
        {
            string UserData = SecureStorage.Default.GetAsync("userData").Result;
            if (UserData != null)
            {
                
                LogoutIsEnabled = true;
                string[] slices = UserData.Split(";");
                LoginOrName = slices[0];
                Usertoken = slices[3];
            }
            else
            {
                LoginOrName = "Login";
                LogoutIsEnabled = false;
            }

        }

        [RelayCommand]
        async void Logout()
        {
            if(SecureStorage.GetAsync("isLoggedIn").Result == $"{true}")
            {
                MessageRoot message = ApiFunctions.Logout(Usertoken);
                await SecureStorage.SetAsync("isLoggedIn", $"{false}");
                SecureStorage.Default.Remove("userData");
                Appearing();
            }
            else 
            { 
                await Shell.Current.DisplayAlert("Error", "Logging out doesn't work if you're not logged in!", "OK");
            }
            
        }
    }
}
