using Microsoft.Extensions.Logging;
using LoginBasico.Services;
using LoginBasico.Models;
using LoginBasico.Views;
using LoginBasico.ViewModels;

namespace LoginBasico
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fontello.ttf", "MaterialDesignIcons");
                });
            builder.Services.AddSingleton<IProductoServices, ProductoServices>();
            builder.Services.AddSingleton<IUsuarioServices, UsuarioServices>();
            builder.Services.AddSingleton<ILoginServices, LoginServices>();


            builder.Services.AddTransient<UsuarioListaViewModel>();
            builder.Services.AddTransient<UsuarioListaPage>();
            builder.Services.AddTransient<ProductosListaViewModel>();
            builder.Services.AddTransient<ProductoDetallePage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<UsuarioDetalleViewModel>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
