using Ejuromag.Models;
using Ejuromag.ViewModel;

namespace Ejuromag.View;


public partial class ProductsView : ContentPage
{
    ProductsViewModel VM;
	public ProductsView(ProductsViewModel vm)
	{
		InitializeComponent();
		this.VM = vm;
		this.BindingContext = vm;

	}

    private void price_PCK_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}