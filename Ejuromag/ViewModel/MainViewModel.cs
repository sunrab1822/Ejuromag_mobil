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

        [RelayCommand]
        void NavigateTo(string destination)
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
    }
}
