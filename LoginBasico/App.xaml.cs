using LoginBasico.Views;
namespace LoginBasico
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new UsuarioListaPage());
        }
    }
}
