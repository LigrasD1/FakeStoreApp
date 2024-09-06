using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginBasico.Models;
using LoginBasico.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBasico.ViewModels
{
    public partial class CarritoViewModel : BaseViewModel
    {
        public ObservableCollection<ProductoCarrito> Products { get; }= new();
        
        [ObservableProperty]
        bool isRefreshing;
        IProductoServices _services;
        public CarritoViewModel(ProductoServices servicio)
        {
            Title = "Carrito";
            _services = servicio;    
        }
        [RelayCommand]
        public async Task PedirCarritoAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    var Carro = await _services.GetCarritoAsync();
                    if (Carro != null)
                    {
                        if (Products.Count != 0)
                            Products.Clear();

                        foreach (var producto in Carro)
                            Products.Add(producto);
                    }
                    //Products.Clear();

                    //for (int i = 0; i < 10; i++)
                    //{
                    //    Products.Add(new ProductoCarrito
                    //    {
                    //        CarritoId = 1,
                    //        idUsuarioCarrito = 1,
                    //        image = "yo.png",
                    //        title = $"producto de prueba {i}"
                    //    });
                    //}

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
        public async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
