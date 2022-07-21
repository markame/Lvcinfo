using System;
using System.Collections.Generic;
using System.Text;

namespace Lvcinfo.Models
{
    public class Registro
    {
      
        public string Data_Notificacao { get; set; }
        public string UF { get; set; }
        public string Muni_Notificacao { get; set; }
        public string Fonte_Notificacao { get; set; }
        public string Nome_Proprietario { get; set; }
        public string Logradouro_Proprietario { get; set; }
        public int Numero_Proprietario { get; set; }
        public string Bairro_Proprietario { get; set; }
        public string Cep_Proprietario { get; set; }
        public string Complemento_Proprietario { get; set; }
        public string Municipio_Proprietario { get; set; }
        public string Zona_Proprietario { get; set; }
        public string Telefone_Proprietario { get; set; }
        public string Email_Proprietario { get; set; }
        public string Cpf_Proprietario { get; set; }
        public string Nascimento_Proprietario { get; set; }
        public string Nome_Animal { get; set; }
        public string Idade_Animal { get; set; }
        public string Raca_Animal { get; set; }
        public string Porte_Animal { get; set; }
        public string Pelagem_Animal { get; set; }
        public string Foto_Animal { get; set; }
        public string Outros_Animal { get; set; }
        public int Procedencia_Animal { get; set; }
        public int Abrigo_Animal { get; set; }
        public int Outro_Animal { get; set; }
        public string Data_Sintoma { get; set; }
        public bool Emagrecimento_Sintoma { get; set; }
        public bool Alopecia_Sintoma { get; set; }
        public bool Hepatomegalia_Sintoma { get; set; }
        public bool Apatia_Sintoma { get; set; }
        public bool Lesoes_Sintoma { get; set; }
        public bool Onicogrifose_Sintoma { get; set; }
        public bool Apetite_Sintoma { get; set; }
        public bool Alteraocular_Sintoma { get; set; }
        public bool Linfomegalia_Sintoma { get; set; }
        public bool Vomito_Sintoma { get; set; }
        public bool Diarreia_Sintoma { get; set; }
        public bool Sanguenasal_Sintoma { get; set; }
        public string Id_Usuario { get; set; }
        public string Qual_Sintoma { get; set; }
        public string Data_Amostra { get; set; }
        public int Tipo_Amosta { get; set; }
        public string Qual_Amostra {get; set; }
        public int Exame_Rapido { get; set; }
        public int Exame_Elisa { get; set; }
        public int Exame_Parasitologico { get; set; }
        public string Conclusao_Caso { get; set; }

        public string Evolucao_Caso { get; set; }
        public string Data_Eutanasia {get; set; }
        

    }
}
