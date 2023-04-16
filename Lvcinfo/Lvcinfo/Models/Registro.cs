using System;
using System.Collections.Generic;
using System.Text;

namespace Lvcinfo.Models
{
    public class Registro
    {
        public int idRegistro { get; set; }
        public string Data_Notificacao { get; set; }
        public string UF { get; set; }
        public string Muni_Notificacao { get; set; }
        public string Fonte_Notificacao { get; set; }
        public string Nome_Proprietario { get; set; }
        public string Logradouro_Proprietario { get; set; }
        public int Numero_Proprietario { get; set; }
        public string Bairro_Proprietario { get; set; }
        public string Complemento_Proprietario { get; set; }
        public string Zona_Proprietario { get; set; }
        public string Cpf_Proprietario { get; set; }
        public string Nome_Animal { get; set; }
        public int Sexo_Animal { get; set; }
        public string Idade_Animal { get; set; }
        public string Raca_Animal { get; set; }
        public string Porte_Animal { get; set; }
        public string Foto_Animal { get; set; }
        public int Procedencia_Animal { get; set; }
        public int Abrigo_Animal { get; set; }
        public int Outro_Animal { get; set; }
        public string Data_Sintoma { get; set; }
        public int Emagrecimento_Sintoma { get; set; }
        public int Alopecia_Sintoma { get; set; }
        public int Hepatomegalia_Sintoma { get; set; }
        public int Apatia_Sintoma { get; set; }
        public int Lesoes_Sintoma { get; set; }
        public int Onicogrifose_Sintoma { get; set; }
        public int Apetite_Sintoma { get; set; }
        public int Alteraocular_Sintoma { get; set; }
        public string Id_Usuario { get; set; }
        public string Outros_Sintoma { get; set; }
        public string Data_DPP { get; set; }
        public int Exame_Rapido { get; set; }
        public string Data_Elisa { get; set; }
        public int Exame_Elisa { get; set; }
        public string Data_Parasitologico { get; set; }
        public int Exame_Parasitologico { get; set; }
        public int Animal_Encoleirado { get; set; }
        public int Evolucao_Caso { get; set; }
        public string Data_Eutanasia {get; set; }
        public string Status_Caso { get; set; }
        public double Latitude { get; set;}
        public double Longitude { get; set; }
        public int Obito_Conclusao { get; set;}


    }
}
