using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    }
}
