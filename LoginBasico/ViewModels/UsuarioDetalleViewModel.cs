using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginBasico.Models;
using LoginBasico.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBasico.ViewModels
{
    public partial class UsuarioDetalleViewModel : BaseViewModel
    {
        [ObservableProperty]
        Usuario user= new Usuario();
        [ObservableProperty]
        int id;
        IUsuarioServices services;
        public UsuarioDetalleViewModel()
        {
            Title = "Detalle del usuario";
            services= new UsuarioServices();
        }

        [RelayCommand]
        public async Task BuscarUsuarioIdAsync()
        {
            if (!IsBusy) 
            {
                IsBusy = true;

                try
                {
                    user = await services.PedirUsuario(id);
                    OnPropertyChanged(nameof(User));

                    if (user == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Alerta", "No existe usuario con la id indicada", "Ok");
                    }
                    
                    
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Alerta", "No se pudo solicitar la informacion", "Ok");

                    throw;
                }finally { IsBusy = false; }
            }

        }
        [RelayCommand]
        public async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
