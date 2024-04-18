using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejuromag.API;
using Ejuromag.Models;
using Ejuromag.View;

namespace Ejuromag.ViewModel
{
    [QueryProperty(nameof(SelectedProduct), "Product")]
    public partial class ProductDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Product selectedProduct;

        [ObservableProperty]
        Category category;

        [ObservableProperty]
        string categoryName;

        [ObservableProperty]
        string manufacturerName;

        [ObservableProperty]
        public List<Category> categories;

        [ObservableProperty]
        public List<Manufacturer> manufacturers;

        [ObservableProperty]
        Manufacturer manufacturer;

        [RelayCommand]
        async void Appearing()
        {
            Categories = ApiFunctions.GetCategories().ToList();
            Manufacturers = ApiFunctions.GetManufacturers().ToList();
            ManufacturerName = Manufacturers[SelectedProduct.manufacturer_id - 1].name;
            CategoryName = Categories[SelectedProduct.category_id].categoryName;

        }

       [RelayCommand]
        Task AddToCart()
        {
            SecureStorage.SetAsync("CartProducts", $"{SelectedProduct.picture};{SelectedProduct.name};{SelectedProduct.price};{1};{SelectedProduct.price}");
            return Shell.Current.GoToAsync("CartView");
            }
        }
    }

