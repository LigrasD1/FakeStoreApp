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
    public   partial class UsuarioListaViewModel: BaseViewModel
    {
        public ObservableCollection<Usuario> Usuarios { get; } = new();
        [ObservableProperty]
        bool isRefreshing;

        IUsuarioServices _usuarioservices;
        public UsuarioListaViewModel(IUsuarioServices userservices) 
        {
            Title = "Lista de Usuarios";
            _usuarioservices = userservices;
        }

        [RelayCommand]
        private async Task GetUserAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    // consultamos lista de productos
                    var LUsuarios = await _usuarioservices.GetUsuarioAsync();

                    if (LUsuarios != null)
                    {
                        if (Usuarios.Count != 0)
                            Usuarios.Clear();

                        foreach (var producto in LUsuarios)
                            Usuarios.Add(producto);
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
    }
}
