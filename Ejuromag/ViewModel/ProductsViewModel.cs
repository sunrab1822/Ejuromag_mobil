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
        public List<Manufacturer> manufacturers;

        [ObservableProperty]
        Product selectedProduct;

        [ObservableProperty]
        Category productCategory;

        [ObservableProperty]
        Manufacturer productManufacturer;

        [ObservableProperty]
        int categoryID;

        [ObservableProperty]
        int manufactID;

        [RelayCommand]
        Task NavigateToDetails()
        {
            Dictionary<string, object> navigationParameter = new Dictionary<string, object>
                {
                    {"Product", SelectedProduct}
                };
            return Shell.Current.GoToAsync(nameof(ProductDetailsView), true, navigationParameter);

            } 

        [RelayCommand]
        async void Appearing()
        {
            if (ProductCategory == null || ProductManufacturer == null)
            {
                Categories = ApiFunctions.GetCategories().ToList();
                Manufacturers = ApiFunctions.GetManufacturers().ToList();
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

        partial void OnProductManufacturerChanged(Manufacturer value)
        {
            Manufacturers = ApiFunctions.GetManufacturers().ToList();
            Products = ApiFunctions.GetProducts().ToList();
            if (ProductManufacturer != null)
            {
                ManufactID = value.id;
                Products = Products.Where(x => x.manufacturer_id == ProductManufacturer.id).ToList();
            }
        }

        partial void OnCategoryIDChanged(int value)
        {
            Products = ApiFunctions.GetProducts().ToList();
            if (value != 0)
                Products = Products.Where(x => x.category_id == value).ToList();
        }

        partial void OnManufactIDChanged(int value)
        {
            Products = ApiFunctions.GetProducts().ToList();
            if(value != 0)
                Products = Products.Where(x => x.manufacturer_id == value).ToList();
        }

    }
}
