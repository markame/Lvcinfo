using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lvcinfo.Services;
using Lvcinfo.Views;
using Xamarin.Forms;

namespace Lvcinfo.ViewModels
{
    public class PaginaInicialModel:BaseViewModel
    {
        public Command novaNotificacaoCommand { get; set; }
        public PaginaInicialModel()
        {
            novaNotificacaoCommand = new Command(async () => await novaNotificacaoClick());
        }

        private async Task novaNotificacaoClick()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NovaOcorrencia());
        }

       



    }
}
