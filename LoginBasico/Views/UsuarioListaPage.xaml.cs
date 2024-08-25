using LoginBasico.Models;
using LoginBasico.Services;
using LoginBasico.ViewModels;
namespace LoginBasico.Views;

public partial class UsuarioListaPage : ContentPage
{
    public UsuarioListaPage()
    {
        UsuarioServices service = new UsuarioServices();
        UsuarioListaViewModel vm = new UsuarioListaViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as UsuarioListaViewModel;

        if (vm != null)
        {
            await vm.GetUserCommand.ExecuteAsync(null);
        }
    }

}