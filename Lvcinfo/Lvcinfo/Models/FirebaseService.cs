
using Firebase.Database;
using Firebase.Database.Query;
using Lvcinfo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LVCinfo.Services
{
    internal class FirebaseService
    {
        FirebaseClient firebase =
            new FirebaseClient("https://lvcinfo-default-rtdb.firebaseio.com/");


        public async Task addRegistro(string datano, string ufno, string munino, string fonteno, string nomepro, string lograpro, int numeropro
            , string bairropro, string ceppro, string complementopro, string municipiopro, string zonapro, string telefonepro, string emailpro, string cpfpro
            , string nascimentopro, string nomeani, string idadeani, string racaani, string porteani, string pelagemani, string fotoani, int procedenciaani,
             int abrigoani, int outroanima, string data_Sintoma, bool emagrecimento_Sintoma, bool alopecia_Sintoma, bool hepatomegalia_Sintoma, bool apatia_Sintoma,
             bool lesoes_Sintoma, bool onicogrifose_Sintoma, bool apetite_Sintoma, bool alteraocular_Sintoma, bool linfomegalia_Sintoma, bool vomito_Sintoma, bool diarreia_Sintoma, bool sanguenasal_Sintoma, string id_Usuario
            , string qual_Sintoma, string data_Amostra, int tipo_Amosta, string qual_Amostra, int exame_Rapido, int exame_Elisa, int exame_Parasitologico, string conclusao_Caso, string evolucao_Caso, string data_Eutanasia)
        {
            await firebase
                .Child("Registro")
                .PostAsync(new Registro()
                {
                    Data_Notificacao = datano,
                    UF = ufno,
                    Muni_Notificacao = munino,
                    Fonte_Notificacao = fonteno,
                    Nome_Proprietario = nomepro,
                    Logradouro_Proprietario = lograpro,
                    Numero_Proprietario = numeropro,
                    Bairro_Proprietario = bairropro,
                    Cep_Proprietario = ceppro,
                    Complemento_Proprietario = complementopro,
                    Municipio_Proprietario = municipiopro,
                    Zona_Proprietario = zonapro,
                    Telefone_Proprietario = telefonepro,
                    Email_Proprietario = emailpro,
                    Cpf_Proprietario = cpfpro,
                    Nascimento_Proprietario = nascimentopro,
                    Nome_Animal = nomeani,
                    Idade_Animal = idadeani,
                    Raca_Animal = racaani,
                    Porte_Animal = porteani,
                    Pelagem_Animal = pelagemani,
                    Foto_Animal = fotoani,
                    Procedencia_Animal = procedenciaani,
                    Abrigo_Animal = abrigoani,
                    Outro_Animal = outroanima,
                    Data_Sintoma = data_Sintoma,
                    Emagrecimento_Sintoma = emagrecimento_Sintoma,
                    Alopecia_Sintoma = alopecia_Sintoma,
                    Hepatomegalia_Sintoma = hepatomegalia_Sintoma,
                    Apatia_Sintoma = apatia_Sintoma,
                    Lesoes_Sintoma = lesoes_Sintoma,
                    Onicogrifose_Sintoma = onicogrifose_Sintoma,
                    Apetite_Sintoma = apetite_Sintoma,
                    Alteraocular_Sintoma = alteraocular_Sintoma,
                    Linfomegalia_Sintoma= linfomegalia_Sintoma,
                    Vomito_Sintoma = vomito_Sintoma,
                    Diarreia_Sintoma = diarreia_Sintoma,
                    Sanguenasal_Sintoma = sanguenasal_Sintoma,
                    Id_Usuario =  id_Usuario,
                    Qual_Sintoma = qual_Sintoma,
                    Data_Amostra = data_Amostra,
                    Tipo_Amosta = tipo_Amosta,
                    Qual_Amostra = qual_Amostra,
                    Exame_Rapido = exame_Rapido,
                    Exame_Elisa =  exame_Elisa,
                    Exame_Parasitologico = exame_Parasitologico,
                    Conclusao_Caso = conclusao_Caso,
                    Evolucao_Caso = evolucao_Caso,
                    Data_Eutanasia = data_Eutanasia,


                });
            ;

        }
        public async Task<List<Registro>> GetRegistrosAll()
        {
            return (await firebase.Child(nameof(Registro)).OnceAsync<Registro>()).Select(item => new Registro
            {
                Data_Notificacao = item.Object.Data_Notificacao,
                UF = item.Object.UF,
                Muni_Notificacao = item.Object.Muni_Notificacao,
                Fonte_Notificacao = item.Object.Fonte_Notificacao,
                Nome_Proprietario = item.Object.Nome_Proprietario,
                Logradouro_Proprietario = item.Object.Logradouro_Proprietario,
                Numero_Proprietario = item.Object.Numero_Proprietario,
                Bairro_Proprietario = item.Object.Bairro_Proprietario,
                Cep_Proprietario=item.Object.Cep_Proprietario,
                Complemento_Proprietario = item.Object.Complemento_Proprietario,
                Municipio_Proprietario = item.Object.Municipio_Proprietario,
                Zona_Proprietario = item.Object.Zona_Proprietario,
                Telefone_Proprietario = item.Object.Telefone_Proprietario,
                Email_Proprietario = item.Object.Email_Proprietario,
                Cpf_Proprietario = item.Object.Cpf_Proprietario,
                Nascimento_Proprietario = item.Object.Nascimento_Proprietario,
                Nome_Animal = item.Object.Nome_Animal,
                Idade_Animal = item.Object.Idade_Animal,
                Raca_Animal = item.Object.Raca_Animal,
                Porte_Animal = item.Object.Porte_Animal,
                Pelagem_Animal = item.Object.Pelagem_Animal,
                Foto_Animal = item.Object.Foto_Animal,
                Procedencia_Animal = item.Object.Procedencia_Animal,
                Abrigo_Animal = item.Object.Abrigo_Animal,
                Outro_Animal = item.Object.Outro_Animal,
                Data_Sintoma = item.Object.Data_Sintoma,
                Emagrecimento_Sintoma  = item.Object.Emagrecimento_Sintoma,
                Alopecia_Sintoma = item.Object.Alopecia_Sintoma,
                Hepatomegalia_Sintoma = item.Object.Hepatomegalia_Sintoma,
                Apatia_Sintoma = item.Object.Apatia_Sintoma,
                Lesoes_Sintoma = item.Object.Lesoes_Sintoma,
                Onicogrifose_Sintoma = item.Object.Onicogrifose_Sintoma,
                Apetite_Sintoma = item.Object.Apetite_Sintoma,
                Alteraocular_Sintoma = item.Object.Alteraocular_Sintoma,
                Linfomegalia_Sintoma = item.Object.Linfomegalia_Sintoma,
                Vomito_Sintoma = item.Object.Vomito_Sintoma,
                Diarreia_Sintoma = item.Object.Diarreia_Sintoma,
                Sanguenasal_Sintoma =item.Object.Sanguenasal_Sintoma,
                Id_Usuario = item.Object.Id_Usuario,
                Qual_Sintoma =  item.Object.Qual_Sintoma,
                Data_Amostra = item.Object.Data_Amostra,
                Tipo_Amosta = item.Object.Tipo_Amosta,
                Qual_Amostra = item.Object.Qual_Amostra,
                Exame_Rapido = item.Object.Exame_Rapido,
                Exame_Elisa =  item.Object.Exame_Elisa,
                Exame_Parasitologico = item.Object.Exame_Parasitologico,
                Conclusao_Caso =    item.Object.Conclusao_Caso,
                Evolucao_Caso = item.Object.Evolucao_Caso,
                Data_Eutanasia = item.Object.Data_Eutanasia
            }).ToList();






        }
        public async Task<Registro> GetRegistro(string cpfProprietario)
        {
            var bregistro = await GetRegistrosAll();
            await firebase.Child("Registro")
                .OnceAsync<Registro>();
            return bregistro.Where(a => a.Cpf_Proprietario == "08213150301").FirstOrDefault();
        }


        public async Task<List<Registro>> GetRegistrosBySituacao(string situacao)
        {
            return (await firebase.Child(nameof(Registro)).OnceAsync<Registro>()).Select(item => new Registro   
            {
                Data_Notificacao = item.Object.Data_Notificacao,
                UF = item.Object.UF,
                Muni_Notificacao = item.Object.Muni_Notificacao,
                Fonte_Notificacao = item.Object.Fonte_Notificacao,
                Nome_Proprietario = item.Object.Nome_Proprietario,
                Logradouro_Proprietario = item.Object.Logradouro_Proprietario,
                Numero_Proprietario = item.Object.Numero_Proprietario,
                Bairro_Proprietario = item.Object.Bairro_Proprietario,
                Cep_Proprietario=item.Object.Cep_Proprietario,
                Complemento_Proprietario = item.Object.Complemento_Proprietario,
                Municipio_Proprietario = item.Object.Municipio_Proprietario,
                Zona_Proprietario = item.Object.Zona_Proprietario,
                Telefone_Proprietario = item.Object.Telefone_Proprietario,
                Email_Proprietario = item.Object.Email_Proprietario,
                Cpf_Proprietario = item.Object.Cpf_Proprietario,
                Nascimento_Proprietario = item.Object.Nascimento_Proprietario,
                Nome_Animal = item.Object.Nome_Animal,
                Idade_Animal = item.Object.Idade_Animal,
                Raca_Animal = item.Object.Raca_Animal,
                Porte_Animal = item.Object.Porte_Animal,
                Pelagem_Animal = item.Object.Pelagem_Animal,
                Foto_Animal = item.Object.Foto_Animal,
                Procedencia_Animal = item.Object.Procedencia_Animal,
                Abrigo_Animal = item.Object.Abrigo_Animal,
                Outro_Animal = item.Object.Outro_Animal,
                Data_Sintoma = item.Object.Data_Sintoma,
                Emagrecimento_Sintoma  = item.Object.Emagrecimento_Sintoma,
                Alopecia_Sintoma = item.Object.Alopecia_Sintoma,
                Hepatomegalia_Sintoma = item.Object.Hepatomegalia_Sintoma,
                Apatia_Sintoma = item.Object.Apatia_Sintoma,
                Lesoes_Sintoma = item.Object.Lesoes_Sintoma,
                Onicogrifose_Sintoma = item.Object.Onicogrifose_Sintoma,
                Apetite_Sintoma = item.Object.Apetite_Sintoma,
                Alteraocular_Sintoma = item.Object.Alteraocular_Sintoma,
                Linfomegalia_Sintoma = item.Object.Linfomegalia_Sintoma,
                Vomito_Sintoma = item.Object.Vomito_Sintoma,
                Diarreia_Sintoma = item.Object.Diarreia_Sintoma,
                Sanguenasal_Sintoma =item.Object.Sanguenasal_Sintoma,
                Id_Usuario = item.Object.Id_Usuario,
                Qual_Sintoma =  item.Object.Qual_Sintoma,
                Data_Amostra = item.Object.Data_Amostra,
                Tipo_Amosta = item.Object.Tipo_Amosta,
                Qual_Amostra = item.Object.Qual_Amostra,
                Exame_Rapido = item.Object.Exame_Rapido,
                Exame_Elisa =  item.Object.Exame_Elisa,
                Exame_Parasitologico = item.Object.Exame_Parasitologico,
                Conclusao_Caso =    item.Object.Conclusao_Caso,
                Evolucao_Caso = item.Object.Evolucao_Caso,
                Data_Eutanasia = item.Object.Data_Eutanasia
            }).Where(c => c.Conclusao_Caso.ToLower().Contains(situacao.ToLower())).ToList();

        }

    }
}
