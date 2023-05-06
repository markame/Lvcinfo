using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace Lvcinfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FaleConosco : ContentPage
	{
		public FaleConosco ()
		{
			InitializeComponent ();
		}

        private async void Envia_Email(object sender, EventArgs e)
        {
			var emailMessenger = CrossMessaging.Current.EmailMessenger;
			if (emailMessenger.CanSendEmail)
			{
				var emailS = new EmailMessageBuilder()
					.To("suporte@lvcinfo.com.br")
					.Subject("Este email foi enviado por "+nome.Text)
					.Body(mensagem.Text)
					.Build();
				emailMessenger.SendEmail(emailS);
                await DisplayAlert("Obrigado!", "Agradecemos seu contato, acompanhe seu email para respostas ", "OK");

            }
			else
			{
			await DisplayAlert("Algo deu errado!","Algo deu enrrado com o envio de sua mensagem, por favor cheque a diponibilidade de internet","OK");
			}
        }
    }
}