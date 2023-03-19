using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lvcinfo.Models;
using LVCinfo.Services;
using Newtonsoft.Json;

namespace Lvcinfo.Models
{
    
    public class JsonConnect
    {

        public const string senderUrl = "https://lvcinfo.com.br/simple/LvcInfoRegistroSender.php";
        private const string recivedUrl = "";

        public async Task EnviadorMethod(string _Data_Notificacao, string _UF, string _Muni_Notificacao, string _Fonte_Notificacao,
            string _Nome_Proprietario, string _Logradouro_Proprietario, int _Numero_Proprietario, string _Bairro_Proprietario, string _Cep_Proprietario,
            string _Complemento_Proprietario, string _Municipio_Proprietario, string _Zona_Proprietario, string _Telefone_Proprietario,
            string _Email_Proprietario, string _Cpf_Proprietario, string _Nascimento_Proprietario, string _Nome_Animal, string _Idade_Animal,
            string _Raca_Animal, string _Porte_Animal, string _Pelagem_Animal, string _Foto_Animal, int _Procedencia_Animal,
            int _Abrigo_Animal, int _Outro_Animal, string _Data_Sintoma, bool _Emagrecimento_Sintoma, bool _Alopecia_Sintoma, bool _Hepatomegalia_Sintoma,
             bool _Apatia_Sintoma, bool _Lesoes_Sintoma, bool _Onicogrifose_Sintoma, bool _Apetite_Sintoma , bool _Alteraocular_Sintoma, bool _Linfomegalia_Sintoma,
             bool _Vomito_Sintoma, bool _Diarreia_Sintoma, bool _Sanguenasal_Sintoma, string _Id_Usuario, string _Qual_Sintoma, string _Data_Amostra,
             int _Tipo_Amosta, string _Qual_Amostra, int _Exame_Rapido, int _Exame_Elisa, int _Exame_Parasitologico, string _Conclusao_Caso, string _Evolucao_Caso, string _Data_Eutanasia)
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
                Cep_Proprietario = _Cep_Proprietario,
                Complemento_Proprietario = _Complemento_Proprietario,
                Municipio_Proprietario = _Municipio_Proprietario,
                Zona_Proprietario = _Zona_Proprietario,
                Telefone_Proprietario = _Telefone_Proprietario,
                Email_Proprietario = _Email_Proprietario,
                Cpf_Proprietario = _Cpf_Proprietario,
                Nascimento_Proprietario = _Nascimento_Proprietario,
                Nome_Animal = _Nome_Animal,
                Idade_Animal = _Idade_Animal,
                Raca_Animal = _Raca_Animal,
                Porte_Animal = _Porte_Animal,
                Pelagem_Animal = _Pelagem_Animal,
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
                Linfomegalia_Sintoma = _Linfomegalia_Sintoma,
                Vomito_Sintoma = _Vomito_Sintoma,
                Diarreia_Sintoma = _Diarreia_Sintoma,
                Sanguenasal_Sintoma = _Sanguenasal_Sintoma,
                Id_Usuario = _Id_Usuario,
                Qual_Sintoma = _Qual_Sintoma,
                Data_Amostra = _Data_Amostra,
                Tipo_Amosta = _Tipo_Amosta,
                Qual_Amostra = _Qual_Amostra,
                Exame_Rapido = _Exame_Rapido,
                Exame_Elisa = _Exame_Elisa,
                Exame_Parasitologico = _Exame_Parasitologico,
                Conclusao_Caso = _Conclusao_Caso,
                Evolucao_Caso = _Evolucao_Caso,
                Data_Eutanasia = _Data_Eutanasia


            };

            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;
            var httpClient = new HttpClient(httpClientHandler);

            string jsonData = JsonConvert.SerializeObject(jsonRegistro);


          
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(senderUrl, content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
            }
          
          






        }
    }
}
