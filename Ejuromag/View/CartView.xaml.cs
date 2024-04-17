using Ejuromag.ViewModel;

namespace Ejuromag.View;

public partial class CartView : ContentPage
{
	public CartView(CartViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}