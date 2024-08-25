using Microsoft.Maui.Controls;
using LoginBasico.ViewModels;
using LoginBasico.Services;
namespace LoginBasico.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }


}