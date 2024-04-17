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
        [RelayCommand]
        Task SetOrder()
        {
           Shell.Current.DisplayAlert("Rendelés", "A rendelését rögzítettük", "OK");
           return Shell.Current.GoToAsync("MainPage");
        }
    }
}
