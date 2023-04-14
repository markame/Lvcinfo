

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lvcinfo.Model;
using Lvcinfo.Views;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Lvcinfo.Models
{

    public class JsonConnect
    {

        public const string senderUrl = "https://lvcinfo.com.br/simple/LvcInfoRegistroReciver.php";
        public const string recivedUrl = "https://lvcinfo.com.br/simple/LvcInfoRegistroSender.php";
        public const string userlink = "https://lvcinfo.com.br/simple/LvcInfoUserLogin.php";
      

        public async Task EnviadorMethod(string _Data_Notificacao, string _UF, string _Muni_Notificacao, string _Fonte_Notificacao,
            string _Nome_Proprietario, string _Logradouro_Proprietario, int _Numero_Proprietario, string _Bairro_Proprietario,
            string _Complemento_Proprietario, string _Zona_Proprietario, string _Cpf_Proprietario, string _Nome_Animal, int _Sexo_Animal, string _Idade_Animal,
            string _Raca_Animal, string _Porte_Animal, string _Foto_Animal, int _Procedencia_Animal,
            int _Abrigo_Animal, int _Outro_Animal, string _Data_Sintoma, int _Emagrecimento_Sintoma, int _Alopecia_Sintoma, int _Hepatomegalia_Sintoma,
             int _Apatia_Sintoma, int _Lesoes_Sintoma, int _Onicogrifose_Sintoma, int _Apetite_Sintoma, int _Alteraocular_Sintoma,
             string _Id_Usuario, string _Outros_Sintoma, string _Data_DPP,
              int _Exame_Rapido, string _Data_Elisa, int _Exame_Elisa, string _Data_Parasitologico, int _Exame_Parasitologico, string _Conclusao_Caso, int _Evolucao_Caso, string _Data_Eutanasia, int _Animal_Encoleirado, string _Status_Caso)
        {


            var jsonRegistro = new Registro
            {
                Data_Notificacao = _Data_Notificacao,
                UF = _UF,
                Muni_Notificacao = _Muni_Notificacao,
                Fonte_Notificacao = _Fonte_Notificacao,
                Nome_Proprietario = _Nome_Proprietario,
                Logradouro_Proprietario = _Logradouro_Proprietario,
                Numero_Proprietario = _Numero_Proprietario,
                Bairro_Proprietario = _Bairro_Proprietario,
                Complemento_Proprietario = _Complemento_Proprietario,
                Zona_Proprietario = _Zona_Proprietario,
                Cpf_Proprietario = _Cpf_Proprietario,
                Nome_Animal = _Nome_Animal,
                Sexo_Animal = _Sexo_Animal,
                Idade_Animal = _Idade_Animal,
                Raca_Animal = _Raca_Animal,
                Porte_Animal = _Porte_Animal,
                Foto_Animal = _Foto_Animal,
                Procedencia_Animal = _Procedencia_Animal,
                Abrigo_Animal = _Abrigo_Animal,
                Outro_Animal = _Outro_Animal,
                Data_Sintoma = _Data_Sintoma,
                Emagrecimento_Sintoma = _Emagrecimento_Sintoma,
                Alopecia_Sintoma = _Alopecia_Sintoma,
                Hepatomegalia_Sintoma = _Hepatomegalia_Sintoma,
                Apatia_Sintoma = _Apatia_Sintoma,
                Lesoes_Sintoma = _Lesoes_Sintoma,
                Onicogrifose_Sintoma = _Onicogrifose_Sintoma,
                Apetite_Sintoma = _Apetite_Sintoma,
                Alteraocular_Sintoma = _Alteraocular_Sintoma,
                Id_Usuario = _Id_Usuario,
                Outros_Sintoma = _Outros_Sintoma,
                Data_DPP = _Data_DPP,
                Exame_Rapido = _Exame_Rapido,
                Data_Elisa = _Data_Elisa,
                Exame_Elisa = _Exame_Elisa,
                Data_Parasitologico = _Data_Parasitologico,
                Exame_Parasitologico = _Exame_Parasitologico,
                Evolucao_Caso = _Evolucao_Caso,
                Data_Eutanasia = _Data_Eutanasia,
                Animal_Encoleirado = _Animal_Encoleirado,
                Status_Caso = _Status_Caso

            };
            string jsonDataS = JsonConvert.SerializeObject(jsonRegistro);

            await JsonSender(jsonDataS);
        }

        public async Task JsonSender(string jsonData)
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;
            var httpClient = new HttpClient(httpClientHandler);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(senderUrl, content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();


            }
        }

        public async Task<object> Login(string _user, string _pass)
        {

            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;
            using (var httpClient = new HttpClient(httpClientHandler))
            {

                var requestData = new { usuario = _user, senha = _pass };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(userlink, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                List<User> userList = JsonConvert.DeserializeObject<List<User>>(responseContent);
                Preferences.Set("_Id", userList[0].Id_User.ToString());

                if (userList[0].UserName.Equals(_user)&&userList[0].Password.Equals(_pass))
                {

                    _=Application.Current.MainPage.Navigation.PushAsync(new PaginaInicial());
                }
                return userList;
            }
        }
      
        }
    }




