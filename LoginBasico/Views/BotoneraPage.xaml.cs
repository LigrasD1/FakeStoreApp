using LoginBasico.ViewModels;

namespace LoginBasico.Views;

public partial class BotoneraPage : ContentPage
{
	public BotoneraPage()
	{
		InitializeComponent();
		BindingContext = new BotoneraViewModel();
	}
}