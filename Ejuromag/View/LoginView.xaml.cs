using Ejuromag;
using Ejuromag.ViewModel;

namespace Ejuromag.View;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"RegisterView");
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(PasswordResetView));

    }
}