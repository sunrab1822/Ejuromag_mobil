namespace Ejuromag.View;

public partial class ProductDetailsView : ContentPage
{
	public ProductDetailsView(ProductDetailsView vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}