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

namespace Ejuromag.ViewModel
{
    public partial class RegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string password2;

        [RelayCommand]
        void Register()
        {
            if (String.IsNullOrWhiteSpace(UserName))
            {
                Shell.Current.DisplayAlert("Hiba!", "Nem adott meg felhasználónevet!", "OK");
                return;
            }
            if ( Email == null ||!Email.Contains("@"))
            {
                Shell.Current.DisplayAlert("Hiba!", "Nem megfelelő az email cím formátuma!", "OK");
                return;
            }
            if(Password.Length < 8 && Password != Password2)
            {
                Shell.Current.DisplayAlert("Hiba!", "A jelszó nem megfelelő!", "OK");
                return;
            }
            User user = ApiFunctions.Register(UserName, Email, Password, Password2);
            if(user != null)
            {
                SecureStorage.Default.SetAsync("userData", $"{UserName};{Email};{Password}");
                Shell.Current.GoToAsync(nameof(LoginView));
            }
            else
            {
                Shell.Current.DisplayAlert("Hiba!", "Sikertelen regisztráció!", "OK");
            }
        }
    }
}
