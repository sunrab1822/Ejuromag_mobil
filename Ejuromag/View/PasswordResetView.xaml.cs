using Ejuromag.ViewModel;

namespace Ejuromag.View;

public partial class PasswordResetView : ContentPage
{
	public PasswordResetView(PasswordResetViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}