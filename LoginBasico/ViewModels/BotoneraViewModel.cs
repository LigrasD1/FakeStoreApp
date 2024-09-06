using CommunityToolkit.Mvvm.Input;
using LoginBasico.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBasico.ViewModels
{
    partial class BotoneraViewModel : BaseViewModel
    {
        public BotoneraViewModel()
        {
            Title = "TP 5 MVVM";
        }

        [RelayCommand]
        public async Task GoToProductoLista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
        }

        [RelayCommand]
        public async Task GoToUsuarioLista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioListaPage());
        }

        [RelayCommand]
        public async Task GoToCarrito()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CarroPage());
        }

        [RelayCommand]
        public async Task GoToAcercaDe()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AcercaDePage());
        }

        [RelayCommand]
        public async Task GoToLogin()
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        [RelayCommand]
        public async Task Cerrar()
        {
            bool Confirmacion = await Application.Current.MainPage.DisplayAlert(
            "Confirmar",
            "¿Estás seguro de que deseas cerrar la aplicación?",
            "Sí",
            "No");

            if (Confirmacion)
            {
                // Lógica para cerrar la aplicación
                Application.Current.Quit();
            }

        }
    }
}
