using Lvcinfo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lvcinfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OcorrenciaEncerradasDatalhe : ContentPage
    {
        private string getByid = "https://lvcinfo.com.br/simple/LvcInfoGetImagebyId";
        double Latitude;
        double Longitude;
        public OcorrenciaEncerradasDatalhe(Registro registro)
        {
            Title = "Investição do Animal "+registro.Nome_Animal;
            InitializeComponent();
            IsEnabledd();
            coordenada.Text = Latitude+", "+ Longitude;
            data_Notificacao.Date = DateTime.ParseExact(registro.Data_Notificacao, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            uf.SelectedItem = registro.UF;
            muni_Notificacao.Text = registro.Muni_Notificacao;
            fonte_Notificacao.Text = registro.Fonte_Notificacao;
            nome_Proprietario.Text = registro.Nome_Proprietario;
            cpf_Proprietario.Text = registro.Cpf_Proprietario;
            logradouro_Proprietario.Text = registro.Logradouro_Proprietario;
            numero_Proprietario.Text = registro.Numero_Proprietario.ToString();
            bairro_Proprietario.Text = registro.Bairro_Proprietario;
            complemento_Proprietario.Text = registro.Complemento_Proprietario;
            zona_Proprietario.Text = registro.Zona_Proprietario;
            nome_Animal.Text = registro.Nome_Animal;
            if (registro.Sexo_Animal == 1)
            {
                SexoM.IsChecked = true;
            }
            else
            {
                SexoF.IsChecked = true;
            }
            idade_Animal.Text = registro.Idade_Animal;
            raca_Animal.Text = registro.Raca_Animal;
            porte_Animal.SelectedItem = registro.Porte_Animal;
            getString(registro.Foto_Animal, registro.Nome_Animal);


            if (registro.Procedencia_Animal == 1 )
            {
                urbana.IsChecked =true;
            }
            if (registro.Procedencia_Animal == 2)
            {
                periurbana.IsChecked= true;
            }
            if (registro.Procedencia_Animal == 3 )
            {
                rural.IsChecked = true;
            }

            if (registro.Abrigo_Animal == 1)
            {
                domiciliado.IsChecked = true;  
            }
            else
            {
                semi.IsChecked = true;
            }
            if (registro.Procedencia_Animal == 1)
            {
                Presencasim.IsChecked = true;
            }
            else
            {
                PresencaNao.IsChecked = true;
            }
            data_Sintomas.Date = DateTime.ParseExact(registro.Data_Sintoma, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (registro.Emagrecimento_Sintoma== 1)
            {
                emagrecimento_Animal.IsChecked = true;
            }
            else
            {
                emagrecimento_Animal.IsChecked = false;
            }
            if (registro.Alopecia_Sintoma == 1)
            {
                alopecia_Animal.IsChecked= true;
            }
            else
            {
                alopecia_Animal.IsChecked = false;
            }
            if(registro.Hepatomegalia_Sintoma == 1){
                hepatomegalia_Animal.IsChecked = true;
            }
            else
            {
                hepatomegalia_Animal.IsChecked = false;
            }
            if (registro.Apatia_Sintoma == 1)
            {
                apatia_Animal.IsChecked = true;
            }
            else
            {
                apatia_Animal.IsChecked = false;
            }
            if(registro.Lesoes_Sintoma == 1){
                lesoes_Animal.IsChecked = true;

            }
            else
            {
                lesoes_Animal.IsChecked = false;
            }
            if (registro.Onicogrifose_Sintoma == 1)
            {
                onicogrifose_Animal.IsChecked = true;
            }
            else
            {
                onicogrifose_Animal.IsChecked = false;
            }
            if (registro.Apetite_Sintoma == 1)
            {
                apetite_Animal.IsChecked = true;
            }
            else
            {
                apetite_Animal.IsChecked = false;
            }
            if (registro.Alteraocular_Sintoma ==1)
            {
                alteraoculares_Animal.IsChecked = true;
            }
            else
            {
                alteraoculares_Animal.IsChecked = false;
            }
            if (registro.Outro_Animal == 1)
            {
                qual_sintoma.IsVisible = true;
                qual_sintoma.Text = registro.Outros_Sintoma;
            }

            dataDPP.Date = DateTime.ParseExact(registro.Data_DPP, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if(registro.Exame_Rapido == 1){
                reagenteR.IsChecked = true;
            }
            if (registro.Exame_Rapido ==0)
            {
                nreagenteR.IsChecked=true;
            }if(registro.Exame_Rapido ==2)
            {
                nrealizadoR.IsChecked = true;
            }

            dataElisa.Date = DateTime.ParseExact(registro.Data_Elisa, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (registro.Exame_Elisa == 1)
            {
                Elisa_Positivo.IsChecked = true;
            }
            if (registro.Exame_Elisa == 2)
            {
                Elisa_NaoRealizado.IsChecked = true;    
            }if(registro.Exame_Elisa ==3)
            {
                Elisa_Indeterminado.IsChecked = true;
            }
            if (registro.Exame_Elisa == 0)
            {
                Elisa_Negativo.IsChecked = true;
            }
            dataParasitologico.Date = DateTime.ParseExact(registro.Data_Parasitologico, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (registro.Exame_Parasitologico == 1)
            {
                reagenteP.IsChecked = true;
            }
            else
            {
                nrealizadoP.IsChecked = true;
            }

            if (registro.Animal_Encoleirado ==1)
            {
                Encoleirado_S.IsChecked = true;
            }
            else
            {
                Encoleirado_N.IsChecked = true;
            }

            if(registro.Evolucao_Caso == 1){
                confirmado.IsChecked = true;
                rb_Tratamento.IsChecked = true;
                pic_Eutanasia.IsVisible = false;
            }
            if (registro.Evolucao_Caso == 2)
            {
                confirmado.IsChecked = true;
                rb_Recolhido.IsChecked = true;
                pic_Eutanasia.IsVisible = true;

            }
            if (registro.Evolucao_Caso == 3)
            {
                confirmado.IsChecked = true;
                rb_NEutanasiado.IsChecked = true;
                pic_Eutanasia.IsVisible = true;

            }
            if (registro.Evolucao_Caso == 4)
            {
                rb_Tratamento.IsVisible = false;
                rb_Recolhido.IsVisible = false;
                rb_NEutanasiado.IsVisible = false;
                pic_Eutanasia.IsVisible = false;
                descartado.IsChecked = true;
               
                pic_Eutanasia.IsVisible = false;

            }
        }

        public void IsEnabledd()
        {
            uf.IsEnabled = false;
            muni_Notificacao.IsEnabled = false;
            fonte_Notificacao.IsEnabled = false;
            nome_Proprietario.IsEnabled = false;
            cpf_Proprietario.IsEnabled = false;
            logradouro_Proprietario.IsEnabled = false;
            numero_Proprietario.IsEnabled = false;
            bairro_Proprietario.IsEnabled = false;
            complemento_Proprietario.IsEnabled = false;
            zona_Proprietario.IsEnabled = false;
            nome_Animal.IsEnabled = false;
            SexoM.IsEnabled = false;
            SexoF.IsEnabled = false;
            idade_Animal.IsEnabled = false;
            raca_Animal.IsEnabled = false;
            porte_Animal.IsEnabled = false;
            imagem_Animal.IsEnabled = false;
            urbana.IsEnabled = false;
            periurbana.IsEnabled = false;
            rural.IsEnabled = false;
            domiciliado.IsEnabled = false;
            semi.IsEnabled = false;
            Presencasim.IsEnabled = false;
            PresencaNao.IsEnabled = false;
            data_Sintomas.IsEnabled = false;
            emagrecimento_Animal.IsEnabled = false;
            alopecia_Animal.IsEnabled = false;
            hepatomegalia_Animal.IsEnabled = false;
            apatia_Animal.IsEnabled = false;
            lesoes_Animal.IsEnabled = false;
            onicogrifose_Animal.IsEnabled = false;
            apetite_Animal.IsEnabled = false;
            alteraoculares_Animal.IsEnabled = false;
            qual_sintoma.IsEnabled = false;
            dataDPP.IsEnabled = false;
            reagenteR.IsEnabled = false;
            nreagenteR.IsEnabled = false;
            nrealizadoR.IsEnabled = false;
            dataElisa.IsEnabled = false;
            Elisa_Positivo.IsEnabled = false;
            Elisa_NaoRealizado.IsEnabled = false;
            Elisa_Indeterminado.IsEnabled = false;
        }


        public async void getString(string _idImage, string _nomeAnimal)
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;
            using (var httpClient = new HttpClient(httpClientHandler))
            {

                var requestData = new { id_Image = _idImage };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(getByid, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    List<ImageB64> image64List = JsonConvert.DeserializeObject<List<ImageB64>>(responseContent);
                    string im = image64List[0].B64Hash.ToString();
                    Info_foto.Text= "Foto do Animal "+_nomeAnimal;
                    byte[] Base64Stream = Convert.FromBase64String(im);
                    imagem_Animal.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));

                }
                else
                {
                    imagem_Animal.Source = ImageSource.FromFile("AnimalNotFound.png");
                }

            }
        }
        private async void Button_Localizacao(object sender, EventArgs e)
        {
            var location = new Location(Latitude, Longitude);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.None };
            await Map.OpenAsync(location, options);
        }
    }
}