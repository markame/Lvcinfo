using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Lvcinfo.Views;
using Xamarin.Forms;

namespace Lvcinfo.ViewModels
{
    public class PaginaInicialModel:BaseViewModel
    {
        public Command novaNotificacaoCommand { get; set; }
        public Command listarRegistroCommand { get; set; }
        public Command sobreLvcCommmand { get; set; }
        public Command listarRegistroEncerradoCommand { get; set; }
        public PaginaInicialModel()
        {
            novaNotificacaoCommand = new Command(async () => await novaNotificacaoClick());
            listarRegistroCommand = new Command(async () => await listarRegistroClick());
            listarRegistroEncerradoCommand = new Command(async () => await listarRegistroEncerradoClick());
            sobreLvcCommmand = new Command(async() => await sobreLvcClick());

        }

        private async Task sobreLvcClick()
        {
            Application.Current.MainPage.Navigation.PushAsync(new SobreLvc());
        }
        private async Task listarRegistroEncerradoClick()
        {
          Application.Current.MainPage.Navigation.PushAsync(new OcorrenciaEncerrada());
        }

        private  async Task listarRegistroClick()
        {
           Application.Current.MainPage.Navigation.PushAsync(new ListarRegistro());
        }

        private async Task novaNotificacaoClick()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new NovaNotificacao());
        }

       



    }
}
