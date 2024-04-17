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
    public partial class PasswordResetViewModel : ObservableObject
    {
        [ObservableProperty]
        string email;

        [RelayCommand]
        void ResetPasswordSend()
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

            MessageRoot message = ApiFunctions.ResetPassword(Email);
            if (message != null)
            {
                Shell.Current.DisplayAlert("Success!", "Email sent with further informations!", "OK");
                Shell.Current.GoToAsync(nameof(LoginView));
            }
            else
            {
                Shell.Current.DisplayAlert("Hiba!", "Failed to send email!", "OK");
            }

        }
    }
}
