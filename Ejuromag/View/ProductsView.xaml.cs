using Ejuromag.ViewModel;

namespace Ejuromag.View;

public partial class ProductsView : ContentPage
{
    ProductsView viewmodel;
    public ProductsView(ProductsViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;

	}
}