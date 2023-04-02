using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Lvcinfo.Models;

using Lvcinfo.Model;

namespace Lvcinfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovaRegistro : ContentPage
    {
        Registro Registro = new Registro();
        User user = new User();
        private byte[] Base64Stream;
        private string fotoanimal;
        private int PROCEDENCIA;
        private int ABRIGO;
        private int OUTRO;
        private int PresencaAninal;
        private bool emagrecimento;
        private bool alopecia;
        private bool hepato;
        private bool apatia;
        private bool lesao;
        private bool onico;
        private bool apetite;
        private bool ocular;
        private int amostra;
        private int erapido;
        private int eelisa;
        private int eparasita;
        private string conlusaocaso;
        private int evo;
        private string sintomas;
        private int sexo;
        private string dataeutanasia;

       JsonConnect jsonconnect = new JsonConnect();
        public NovaRegistro()
        {
            InitializeComponent();
          
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var cameraMediaOptions = new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Rear,
                SaveToAlbum = true,
                Directory = "LvcInfo",
                Name = null,
                CompressionQuality = 100
            };
            MediaFile photo = await CrossMedia.Current.TakePhotoAsync(cameraMediaOptions);
            if (photo == null) return;
            //Anima.Source = ImageSource.FromStream(() => photo.GetStream());
            base64encode(photo);


        }
        private async void Salvar_Clicked(object sender, EventArgs e)
        {

           

            try
            {
                Radiostrigger();
                Checkstrigger();

                await jsonconnect.EnviadorMethod(data_Notificacao.Date.ToShortDateString(), uf.SelectedItem.ToString(), muni_Notificacao.Text, fonte_Notificacao.Text,
                    nome_Proprietario.Text, logradouro_Proprietario.Text, int.Parse(numero_Proprietario.Text), bairro_Proprietario.Text,
                    complemento_Proprietario.Text, zona_Proprietario.Text, cpf_Proprietario.Text, nome_Animal.Text, sexo, idade_Animal.Text, raca_Animal.Text, porte_Animal.Text
                    , fotoanimal, PROCEDENCIA, ABRIGO, PresencaAninal, data_Sintomas.Date.ToShortDateString(), emagrecimento, alopecia, hepato, apatia, lesao, onico,
                     apetite, ocular , "1", qual_sintoma.Text, dataDPP.Date.ToShortDateString(), erapido, dataElisa.Date.ToShortDateString(), eelisa, dataParasitologico.Date.ToShortDateString(), eparasita, conlusaocaso, evo, pic_Eutanasia.Date.ToShortDateString()
                    );

                await DisplayAlert("Successo", "Investigação incluída com sucesso", "OK");
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erro","Ocorreu um erro com o cadastro da investigação. Certifiquei-se que campos importantes não estão em branco "+ex.ToString(), "OK");
            }




            



        }

       

        private async void base64encode(MediaFile file)
        {
            var stream = file.GetStream();
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, (int)stream.Length);
            string base64 = System.Convert.ToBase64String(bytes);
            fotoanimal = base64;
        }
        private async void PrencheImg(string imgs)
        {
            byte[] Base64Stream = Convert.FromBase64String(imgs);
            //FotoAnimal.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        }

        private void ConfirmadoCheck(object sender, CheckedChangedEventArgs e)
        {
            label_Evo.IsEnabled =true;
            label_Tra.IsEnabled = true;
            rb_Tratamento.IsEnabled = true;
            rb_Encoleirado.IsEnabled = true;
            label_Enco.IsEnabled = true;
            rb_Encoleirado.IsEnabled =true;
            label_Eu.IsEnabled = true;
            rb_Eutanasiado.IsEnabled = true;
            label_Data.IsEnabled  = true;
            pic_Eutanasia.IsEnabled  = true;


             

        }
       

        private void outro_sintoma_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
          
            if (outro_sintoma.IsChecked)
            {

                qual_sintoma.IsVisible = true;
             

            }
            else
            {
               qual_sintoma.IsVisible=false;
                qual_sintoma.Text = "SEM SINTOMAS ADICIONAIS";
            }
        }
        public void  Radiostrigger()
        {

            if (SexoM.IsChecked)
            {
                sexo = 1;
            }
            if (SexoF.IsChecked)
            {
                sexo = 2;
            }



            if (urbana.IsChecked)
            {
                PROCEDENCIA = 1;
            }
            if (periurbana.IsChecked)
            {
                PROCEDENCIA = 2;
            }
            if (rural.IsChecked)
            {
                PROCEDENCIA = 3;
            }

            if (domiciliado.IsChecked)
            {
                ABRIGO = 1;
            }
            if (semi.IsChecked)
            {
                ABRIGO=2;
            }

            if (Presencasim.IsChecked)
            {
                PresencaAninal = 1;
            }
            if (PresencaNao.IsChecked)
            {
                PresencaAninal=0;
            }

            if (nreagenteR.IsChecked)
            {
                erapido = 1;
            }
            if (nreagenteR.IsChecked)
            {
                erapido=0;
            }
            if (nreagenteR.IsChecked)
            {
                erapido =2;
            }

            if (Elisa_Positivo.IsChecked)
            {
                eelisa = 1;
            }
            if (Elisa_Negativo.IsChecked)
            {
                eelisa=0;
            }
            if (Elisa_NaoRealizado.IsChecked)
            {
                eelisa = 2;
            }
            if (Elisa_Indeterminado.IsChecked)
            {
                eelisa= 3;
            }

            if (reagenteP.IsChecked)
            {
                eparasita = 1;
            }
            if (nreagenteP.IsChecked)
            {
                eparasita=0;
            }
            if (nrealizadoP.IsChecked)
            {
                eparasita = 2;
            }
            if (rb_Tratamento.IsChecked)
            {
                evo = 1;
            }
            if (rb_Encoleirado.IsChecked)
            {
                evo =2;
            }
            if (rb_Eutanasiado.IsChecked)
            {
                evo =3;
                dataeutanasia = pic_Eutanasia.Date.ToShortDateString();

            }
        }

        public void Checkstrigger()
        {

            if (emagrecimento_Animal.IsChecked)
            {
                emagrecimento = true;
            }
            else
            {
                emagrecimento = false;
            }

            if (alopecia_Animal.IsChecked)
            {
                alopecia = true;
            }
            else
            {
                alopecia = false;
            }
            if (hepatomegalia_Animal.IsChecked)
            {
                hepato = true;
            }
            else
            {
                hepato = false;
            }
            if (apatia_Animal.IsChecked)
            {
                apatia = true;  
            }
            else
            {
                apatia = false;
            }

            if (lesoes_Animal.IsChecked)
            {
                lesao = true;
            }
            else
            {
                lesao = false;
            }
            if (onicogrifose_Animal.IsChecked)
            {
                onico = true;
            }
            else
            {
                onico = false;
            }
            if (apetite_Animal.IsChecked)
            {
                apetite = true;
            }
            else
            {
                apetite = false;
            }
            if (alteraoculares_Animal.IsChecked)
            {
               ocular = true;
            }
            else
            {
                ocular = false;
            }

          


        }

        private void descartado_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            label_Evo.IsEnabled =false;
            label_Tra.IsEnabled = false;
            rb_Tratamento.IsEnabled = false;
            rb_Encoleirado.IsEnabled = false;
            label_Enco.IsEnabled = false;
            rb_Encoleirado.IsEnabled =false;
            label_Eu.IsEnabled = false;
            rb_Eutanasiado.IsEnabled = false;
            label_Data.IsEnabled  = false;
            pic_Eutanasia.IsEnabled  = false;
            evo = 4;
            dataeutanasia = pic_Eutanasia.Date.ToShortDateString();


        }
    }

   

       
           
         
          


           
          

        
    
}