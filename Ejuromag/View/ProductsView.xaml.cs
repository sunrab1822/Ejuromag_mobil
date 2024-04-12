using Ejuromag.ViewModel;

namespace Ejuromag.View;

public partial class ProductsView : ContentPage
{
	public ProductsView(ProductsViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;

	}
}