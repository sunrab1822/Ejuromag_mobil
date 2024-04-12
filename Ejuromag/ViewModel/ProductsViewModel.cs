using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejuromag.API;
using Ejuromag.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejuromag.ViewModel
{
    public partial class ProductsViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Product> products;

        [ObservableProperty]
        public ObservableCollection<Category> categories;

        [ObservableProperty]
        Product selectedProduct;

        [RelayCommand]
        Task NavigateToDetails()
        {
            if (SelectedProduct != null)
            {
                Dictionary<string, object> navigationParameter = new Dictionary<string, object>
                {
                    {"Game", SelectedProduct},
                };
                return Shell.Current.GoToAsync("ProductDetailsPage", true, navigationParameter);
            }
            return Shell.Current.DisplayAlert("Hiba!", "A kiválasztott termék adatai nem jeleníthetőek meg!", "Ok");
        }

        [RelayCommand]
        async void Appearing()
        {
            Products = ApiFunctions.GetProducts().ToObservableCollection();
            Categories = ApiFunctions.GetCategories().ToObservableCollection();
        }
    }
}
