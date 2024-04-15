using Ejuromag.ViewModel;

namespace Ejuromag.View;

public partial class ProductDetailsView : ContentPage
{
	public ProductDetailsView(ProductDetailsViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}