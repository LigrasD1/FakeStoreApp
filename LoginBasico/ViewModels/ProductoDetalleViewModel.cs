using LoginBasico.Models;
using LoginBasico.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LoginBasico.ViewModels
{
    public partial class ProductoDetalleViewModel : BaseViewModel
    {
        [ObservableProperty]
        Producto producto;

        public ProductoDetalleViewModel()
        {
            Title = "Detalle de Producto";
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
