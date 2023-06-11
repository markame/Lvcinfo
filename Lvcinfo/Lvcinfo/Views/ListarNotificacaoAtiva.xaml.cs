
using Lvcinfo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lvcinfo.Views
{
   
    

    public partial class ListarRegistro : ContentPage
    {
        public const string getR = "https://lvcinfo.com.br/simple/LvcInfoGetRegistroByStatus.php";
        public ListarRegistro()
        {
            BindingContext = this;
            InitializeComponent();
          
        }

        protected async override void OnAppearing()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoadingPage());
            var usuario = Preferences.Get("_Id", "");

            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;
            using (var httpClient = new HttpClient(httpClientHandler))
            {

                var requestData = new { usuario = usuario, status = "Ativo" };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(getR, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                try
                {
                 
                    var list = JsonConvert.DeserializeObject<List<Registro>>(responseContent);
                    ObservableCollection<Registro> listRegisto = new ObservableCollection<Registro>(list);
                    if (listRegisto.Count != 0)
                    {
                        registro_Inves.ItemsSource = listRegisto;
                        await Application.Current.MainPage.Navigation.PopModalAsync();

                    }
                    else
                    {
                        DisplayAlert("Erro", "Você não possui investigações ativas", "cancelar");
                        await Application.Current.MainPage.Navigation.PopModalAsync();
                    }

                    
                   


                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", "Erro ao entrar em contato com servidor", "cancelar");
                }
            }


        }

        private void registro_Inves_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }
            Registro registro = e.Item as Registro;
            if (registro == null)
            {
                return;
            }
           

            _=Navigation.PushAsync(new EmAndamentoDetalhe(registro));
            


        }



    }
}