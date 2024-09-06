using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBasico.ViewModels
{
    partial class AcercaViewModel : BaseViewModel
    {
        public AcercaViewModel()
        {
            Title = "Acerca del creador";
        }

        [RelayCommand]
        public async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
