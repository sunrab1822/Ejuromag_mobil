using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejuromag.API;
using Ejuromag.Models;
using Ejuromag.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejuromag.ViewModel
{
    [QueryProperty(nameof(ProductCategory), "Category")]
    public partial class ProductsViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<Product> products;

        [ObservableProperty]
        public List<Product> productsToShow;

        [ObservableProperty]
        public List<Category> categories;

        [ObservableProperty]
        Product selectedProduct;

        [ObservableProperty]
        Category productCategory;

        [ObservableProperty]
        int categoryID;

        [RelayCommand]
        Task NavigateToDetails()
        {
            if (SelectedProduct != null)
            {
                Dictionary<string, object> navigationParameter = new Dictionary<string, object>
                {
                    {"Product", SelectedProduct}
                };
                return Shell.Current.GoToAsync("ProductDetailsView", true, navigationParameter);
            }
            return Shell.Current.DisplayAlert("Hiba!", "A kiválasztott termék adatai nem jeleníthetőek meg!", "Ok");
        }

        [RelayCommand]
        async void Appearing()
        {
            if (ProductCategory == null)
            {
                Categories = ApiFunctions.GetCategories().ToList();
                Products = ApiFunctions.GetProducts().ToList();
            }
        }

        partial void OnProductCategoryChanged(Category value)
        {
            Categories = ApiFunctions.GetCategories().ToList();
            Products = ApiFunctions.GetProducts().ToList();
            if (ProductCategory != null)
            {
                CategoryID = value.id;
                Products = Products.Where(x => x.category_id == ProductCategory.id).ToList();
            }
        }

        partial void OnCategoryIDChanged(int value)
        {
            Products = ApiFunctions.GetProducts().ToList();
            if (value != 0)
                Products = Products.Where(x => x.category_id == value).ToList();
        }

    }
}
