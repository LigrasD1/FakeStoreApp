using LoginBasico.Models;
using LoginBasico.ViewModels;
namespace LoginBasico.Views;

public partial class ProductoDetallePage : ContentPage
{
	public ProductoDetallePage(Producto param)
	{
		InitializeComponent();
        ProductoDetalleViewModel vm = new ProductoDetalleViewModel();
        this.BindingContext = vm;
        vm.Producto = param;
    }
}