
using Ejuromag.Models;
using Ejuromag.View;
using Ejuromag.ViewModel;

namespace Ejuromag.View
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage( MainViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;

            var items = new List<CollectionItems>
            {
                new CollectionItems { Image = "needtoregisterslides2.webp" },
                new CollectionItems { Image = "socialmediaslides33.webp" },
                new CollectionItems { Image = "vueperslides1.webp" },
            };
            carouselView.ItemsSource = items;
        }
    }
}