
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;
using Lvcinfo.Models;

using Lvcinfo.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace Lvcinfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OcorrenciaEncerrada : ContentPage
    {
        public const string getR = "https://lvcinfo.com.br/simple/LvcInfoGetRegistroByStatus.php";
        JsonConnect jsonConnect = new JsonConnect();

        public OcorrenciaEncerrada()
        {
            BindingContext = this;
            BindingContext = new Registro();
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

                var requestData = new { usuario = usuario, status = "Finalizado" };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(getR, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                try
                {
                   
                
                    var list = JsonConvert.DeserializeObject<List<Registro>>(responseContent);
                  
                    ObservableCollection<Registro> listRegisto = new ObservableCollection<Registro>(list);
                   
                    registro_Inves.ItemsSource = listRegisto;

                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", "Você não possui investigações finalizadas"+ex, "cancel");
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
            
            _=Navigation.PushAsync(new OcorrenciaEncerradasDatalhe(registro));

          
           
        }

    }
    }
    

