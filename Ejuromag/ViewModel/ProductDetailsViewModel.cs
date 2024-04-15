using CommunityToolkit.Mvvm.ComponentModel;
using Ejuromag.Models;

namespace Ejuromag.ViewModel
{
    [QueryProperty(nameof(SelectedProduct), "Product")]
    public partial class ProductDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Product selectedProduct;


    }
}
