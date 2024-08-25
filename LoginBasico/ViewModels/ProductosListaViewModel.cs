using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginBasico.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using LoginBasico.Services;
using LoginBasico.Views;

namespace LoginBasico.ViewModels
{
    public partial class ProductosListaViewModel : BaseViewModel
    {
        public ObservableCollection<Producto> Productos { get; } = new();

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        Producto productoseleccionado;

        IProductoServices _productoServices;


        public ProductosListaViewModel(IProductoServices productoServices) 
        {
            Title = "Lista de productos";
            _productoServices = productoServices;

        }
        [RelayCommand]
        private async Task GetProductosAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    // consultamos lista de productos
                    var productos = await _productoServices.GetProductsAsync();

                    if (productos != null)
                    {
                        if (Productos.Count != 0)
                            Productos.Clear();

                        foreach (var producto in productos)
                            Productos.Add(producto);
                    }

                    IsBusy = false;
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
                }
                finally
                {
                    IsBusy = false;
                }

            }
        }

        [RelayCommand]
        private async Task GoToDetail()
        {
            if (productoseleccionado == null)
            {
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new ProductoDetallePage(productoseleccionado), true);
        }


        //Con [RelayCommand] indico que un metodo es un comando.
    }
}
