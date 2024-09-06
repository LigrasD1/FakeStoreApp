using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginBasico.Models;
using LoginBasico.Views;
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

                    var LUsuarios = await _usuarioservices.GetUsuarioAsync();

                    if (LUsuarios != null)
                    {
                        if (Usuarios.Count != 0)
                            Usuarios.Clear();

                        foreach (var producto in LUsuarios)
                            Usuarios.Add(producto);
                    }
                    //Usuarios.Clear();
                    //Usuarios.Add(new Usuario
                    //{
                    //    id = 1,
                    //    username="David",
                    //    email="UsuarioPrueba"
                    //});

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
        public async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        public async Task GoToDetail()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BuscarUsuarioPage());
        }
    }
}
