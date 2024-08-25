using LoginBasico.ViewModels;
using LoginBasico.Services;

namespace LoginBasico.Views;

public partial class ProductoListaPage : ContentPage
{
    public ProductoListaPage()
    {
        ProductoServices service = new ProductoServices();
        ProductosListaViewModel vm = new ProductosListaViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as ProductosListaViewModel;

        if (vm != null)
        {
            await vm.GetProductosCommand.ExecuteAsync(null);
        }
    }
}