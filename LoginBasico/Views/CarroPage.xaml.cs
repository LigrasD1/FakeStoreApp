using LoginBasico.ViewModels;
using LoginBasico.Services;
namespace LoginBasico.Views;

public partial class CarroPage : ContentPage
{
	public CarroPage()
	{
        ProductoServices service = new ProductoServices();
        CarritoViewModel vm = new CarritoViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
	}
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as CarritoViewModel;

        if (vm != null)
        {
            await vm.PedirCarritoAsync();
        }
    }
}