using LoginBasico.ViewModels;

namespace LoginBasico.Views;

public partial class BuscarUsuarioPage : ContentPage
{
	public BuscarUsuarioPage()
	{
		InitializeComponent();
		BindingContext = new UsuarioDetalleViewModel();
	}
}