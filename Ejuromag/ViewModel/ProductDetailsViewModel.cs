using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ejuromag.API;
using Ejuromag.Models;

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

        //partial void OnSelectedProductChanged(Product value)
        //{
        //    Categories = ApiFunctions.GetCategories();
        //    Manufacturers = ApiFunctions.GetManufacturers();
        //    if (SelectedProduct.category_id == Category.id && SelectedProduct.manufacturer_id == Manufacturer.id)
        //    {
        //        CategoryName = value.name;
        //        ManufacturerName = value.name;
        //    }
        //}

        [RelayCommand]
        Task AddToCart()
        {
            return Shell.Current.GoToAsync("CartView");
        }
    }
}
