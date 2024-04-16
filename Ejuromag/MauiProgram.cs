using CommunityToolkit.Maui;
using Ejuromag.View;
using Ejuromag.ViewModel;
using Microsoft.Extensions.Logging;

namespace Ejuromag
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa_brands.ttf", "Brands");
                    fonts.AddFont("fa_solid_900.ttf", "FontAwesome");
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<RegisterView>();
            builder.Services.AddSingleton<RegisterViewModel>();
            builder.Services.AddSingleton<LoginView>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<ProductsView>();
            builder.Services.AddSingleton<ProductsViewModel>();
            builder.Services.AddSingleton<ProductDetailsView>();
            builder.Services.AddSingleton<ProductDetailsViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}