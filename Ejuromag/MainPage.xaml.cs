
using Ejuromag.Models;
using Ejuromag.View;

namespace Ejuromag
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();

            var items = new List<CollectionItems>
            {
                new CollectionItems { Image = "needtoregisterslides2.webp" },
                new CollectionItems { Image = "socialmediaslides33.webp" },
                new CollectionItems { Image = "vueperslides1.webp" },
            };
            carouselView.ItemsSource = items;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"LoginView");
        }

        private void Cart(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"CartView");
        }

        private void logout_TLB_Clicked(object sender, EventArgs e)
        {
            if(logout_TLB.IsEnabled == true)
            {

            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"ProductsView");
            
        }
    }
}