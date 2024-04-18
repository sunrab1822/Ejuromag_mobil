using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejuromag.API;
using Ejuromag.Models;
using Ejuromag.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ejuromag.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [RelayCommand]
        void Appearing()
        {
            string userData = SecureStorage.Default.GetAsync("userData").Result;
            if (userData != "" && userData != null)
            {
                string[] slices = userData.Split(";");
                Email = slices[1];
                Password = slices[2];
            }
        }

        [RelayCommand]
        void isLoggedIn()
        {
            
        }

        [RelayCommand]
        void Login()
        {
            if (String.IsNullOrWhiteSpace(Email))
            {
                Shell.Current.DisplayAlert("Hiba!", "Please fill the email field!", "OK");
                return;
            }
            if (Email == null || !Email.Contains("@"))
            {
                Shell.Current.DisplayAlert("Hiba!", "Email is incorrect!", "OK");
                return;
            }
            if (Password == null && Password.Length < 8)
            {
                Shell.Current.DisplayAlert("Hiba!", "Password is incorrect!", "OK");
                return;
            }
            User user = ApiFunctions.Login(Email, Password);
            if (user != null)
            {
                SecureStorage.Default.SetAsync("userData", $"{user.user.name};{user.user.email};{Password};{user.token}");
                SecureStorage.SetAsync("isLoggedIn", $"{true}");
                Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                Shell.Current.DisplayAlert("Hiba!", "Login failed!", "OK");
            }
        }
    }
}
