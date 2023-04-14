
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
        public const string getR = "https://lvcinfo.com.br/simple/LvcInfoGetRegistro.php";
        JsonConnect jsonConnect = new JsonConnect();

        public OcorrenciaEncerrada()
        {
            BindingContext = this;
            BindingContext = new Registro();
            InitializeComponent();
         



        }
        protected async override void OnAppearing()
        {

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
                    ((Registro)BindingContext).Status_Caso="Investigação encerrada";
                    listar_Registro.ItemsSource = listRegisto;
                   
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", "Você não possui investigações finalizadas", "cancel");
                }
            }


             
           
        }

        

       
    }
    }

