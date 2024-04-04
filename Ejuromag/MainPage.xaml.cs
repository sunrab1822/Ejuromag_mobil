using Ejuromag.View;

namespace Ejuromag
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"LoginView");
        }

        private void Cart(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"CartView");
        }
    }
}