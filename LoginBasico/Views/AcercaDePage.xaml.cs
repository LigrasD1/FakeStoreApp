using LoginBasico.ViewModels;

namespace LoginBasico.Views;

public partial class AcercaDePage : ContentPage
{
	public AcercaDePage()
	{
		InitializeComponent();
		BindingContext = new AcercaViewModel();
	}
}