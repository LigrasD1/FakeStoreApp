using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginBasico.Services;
using LoginBasico.Views;
using LoginBasico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using LoginBasico.Utils;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LoginBasico.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {

        [ObservableProperty]
        string username;
        [ObservableProperty]
        string password;

        ILoginServices _services;
       
        public LoginViewModel()
        {
            Title = "Login";
            _services = new LoginServices();
        }
       

        [RelayCommand]
        public async Task LoginAsync()
        {
            if (!IsBusy)
            {
                try
                {       
                    IsBusy = true;
                    var response = await _services.RealizarLoginAsync(username, password);
                    if (response.IsSuccessStatusCode)
                    {
                        IsBusy = false;
                        //await Application.Current.MainPage.Navigation.PushAsync(new UsuarioListaPage());
                        await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
                        
                    }
                    else 
                    {
                        await Application.Current.MainPage.DisplayAlert("Alerta","Inicio denegado","Ok");
                       
                        IsBusy = false;
                    }

                }
                catch (Exception)
                {
                    
                    throw;
                }
            }   

        }
    }
}
