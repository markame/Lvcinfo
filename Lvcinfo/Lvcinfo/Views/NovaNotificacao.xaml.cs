using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Lvcinfo.Models;
using Plugin.Geolocator;

using Lvcinfo.Model;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Location = Xamarin.Essentials.Location;


namespace Lvcinfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovaNotificacao : ContentPage
    {
        double Latitude;
        double Logitude;
        Registro Registro = new Registro();
        User user = new User();
        private byte[] Base64Stream;
        private string fotoanimal;
        private int PROCEDENCIA;
        private int ABRIGO;
     
        private int PresencaAninal;
        private int emagrecimento;
        private int alopecia;
        private int hepato;
        private int apatia;
        private int lesao;
        private int onico;
        private int apetite;
        private int ocular;
        private int encoleirado;
    
        private int erapido;
        private int eelisa;
        private int eparasita;
        private string conlusaocaso;
        private int evo;
        private string status;
       
        private int sexo;
        private string dataeutanasia;

       JsonConnect jsonconnect = new JsonConnect();
        public NovaNotificacao()
        {
            InitializeComponent();
    
            Location();


        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var cameraMediaOptions = new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Rear,
                SaveToAlbum = false,
                Directory = "LvcInfo",
                Name = nome_Animal.Text,
                CompressionQuality = 100
            };
            MediaFile photo = await CrossMedia.Current.TakePhotoAsync(cameraMediaOptions);
            if (photo == null) return;
            base64encode(photo);
            if (photo != null)
            {
                DisplayAlert("Tudo ok","Foto Guardada com sucesso","Ok");
            }
            else
            {
                DisplayAlert("Algo deu errado", "Confirme se as permissões para câmera estão ativas", "Ok");
            }


        }
        private async void Salvar_Clicked(object sender, EventArgs e)
        {

            try
            {
                Radiostrigger();
                Checkstrigger();

                if(qual_sintoma.Text == null)
                {
                    qual_sintoma.Text = "SEM SINTOMAS ADICIONAIS";
                }

                if ((evo == 1)|| (evo == 3)||(evo==4))
                {
                    dataeutanasia = "ANIMAL NAO EUTANASIADO";

                }
               
              
                if ((evo == 1)|| (evo ==2)||(evo == 3)||(evo==4))
                {
                    status ="Finalizado";
                }
                else
                {
                    status = "Ativo";
                }

                if (nome_Proprietario.Text != null || nome_Animal.Text != null || cpf_Proprietario.Text != null) {
                    var usuario = Preferences.Get("_Id", "");
                    await jsonconnect.EnviadorMethod(data_Notificacao.Date.ToShortDateString(), uf.SelectedItem.ToString(), muni_Notificacao.Text, fonte_Notificacao.Text,
                        nome_Proprietario.Text, logradouro_Proprietario.Text, int.Parse(numero_Proprietario.Text), bairro_Proprietario.Text,
                        complemento_Proprietario.Text, zona_Proprietario.Text, cpf_Proprietario.Text, nome_Animal.Text, sexo, idade_Animal.Text, raca_Animal.Text, porte_Animal.SelectedItem.ToString()
                        , fotoanimal, PROCEDENCIA, ABRIGO, PresencaAninal, data_Sintomas.Date.ToShortDateString(), emagrecimento, alopecia, hepato, apatia, lesao, onico,
                         apetite, ocular, usuario, qual_sintoma.Text, dataDPP.Date.ToShortDateString(), erapido, dataElisa.Date.ToShortDateString(), eelisa, dataParasitologico.Date.ToShortDateString(), eparasita, conlusaocaso, evo, dataeutanasia, encoleirado, status, Latitude, Logitude
                        );
                    await DisplayAlert("Tudo ok por aqui.", "Cadasto do animal '" + nome_Animal.Text+ "' realizado com sucesso!", "OK");
                    ClearAll();
                }
                else
                {
                    await DisplayAlert("Acho que você esqueceu alguma coisa !", "Certifique-se que pelo menos os campos 'Nome do tutor', 'Cpf do tutor' e 'Nome do animal' estão preenchidos", "OK");

                }

            }

            catch(Exception ex)
            {
                await DisplayAlert("Erro","Ocorreu um erro com o cadastro da investigação. "+ex.ToString(), "OK");
                

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
        private  void PrencheImg(string imgs)
        {
            byte[] Base64Stream = Convert.FromBase64String(imgs);
            //FotoAnimal.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        }

        private void ConfirmadoCheck(object sender, CheckedChangedEventArgs e)
        {
       
            label_Tra.IsEnabled = true;
            rb_Tratamento.IsEnabled = true;
            rb_Recolhido.IsEnabled = true;
            label_Enco.IsEnabled = true;
            rb_NEutanasiado.IsEnabled =true;
            label_Eu.IsEnabled = true;
            label_Data.IsEnabled  = true;
          




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

            if (reagenteR.IsChecked)
            {
                erapido = 1;
            }
            if (nreagenteR.IsChecked)
            {
                erapido=0;
            }
            if (nrealizadoR.IsChecked)
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
            if (rb_Recolhido.IsChecked)
            {
                evo =2;
                dataeutanasia = pic_Eutanasia.Date.ToShortDateString();
            }
            if (rb_NEutanasiado.IsChecked)
            {
                evo =3;
               

            }
            if (Encoleirado_N.IsChecked)
            {
                encoleirado = 0;
            }
            if (Encoleirado_S.IsChecked)
            {
                encoleirado = 1;
            }

            if (emagrecimento_Animal.IsChecked)
            {
                emagrecimento = 1;
            }
            else
            {
                emagrecimento = 0;
            }

            if (alopecia_Animal.IsChecked)
            {
                alopecia = 1;
            }
            else
            {
                alopecia = 0;
            }
            if (hepatomegalia_Animal.IsChecked)
            {
                hepato = 1;
            }
            else
            {
                hepato = 0;
            }
            if (apatia_Animal.IsChecked)
            {
                apatia = 1;
            }
            else
            {
                apatia = 0;
            }

            if (lesoes_Animal.IsChecked)
            {
                lesao = 1;
            }
            else
            {
                lesao = 0;
            }
            if (onicogrifose_Animal.IsChecked)
            {
                onico = 1;
            }
            else
            {
                onico = 0;
            }
            if (apetite_Animal.IsChecked)
            {
                apetite = 1;
            }
            else
            {
                apetite = 0;
            }
            if (alteraoculares_Animal.IsChecked)
            {
                ocular = 1;
            }
            else
            {
                ocular = 0;
            }
        }

        public void Checkstrigger()
        {

            if (emagrecimento_Animal.IsChecked)
            {
                emagrecimento = 1;
            }
            else
            {
                emagrecimento = 0;
            }

            if (alopecia_Animal.IsChecked)
            {
                alopecia = 1;
            }
            else
            {
                alopecia = 0;
            }
            if (hepatomegalia_Animal.IsChecked)
            {
                hepato = 1;
            }
            else
            {
                hepato = 0;
            }
            if (apatia_Animal.IsChecked)
            {
                apatia = 1;  
            }
            else
            {
                apatia = 0;
            }

            if (lesoes_Animal.IsChecked)
            {
                lesao = 1;
            }
            else
            {
                lesao = 0;
            }
            if (onicogrifose_Animal.IsChecked)
            {
                onico = 1;
            }
            else
            {
                onico = 0;
            }
            if (apetite_Animal.IsChecked)
            {
                apetite = 1;
            }
            else
            {
                apetite = 0;
            }
            if (alteraoculares_Animal.IsChecked)
            {
               ocular = 1;
            }
            else
            {
                ocular = 0;
            }

          


        }

        private void descartado_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
          
            label_Tra.IsEnabled = false;
            rb_Tratamento.IsEnabled = false;
            rb_Tratamento.IsEnabled = false;
            label_Enco.IsEnabled = false;
            rb_Recolhido.IsEnabled =false;
            label_Eu.IsEnabled = false;
            rb_NEutanasiado.IsEnabled = false;
            label_Data.IsEnabled  = false;
            pic_Eutanasia.IsEnabled  = false;
            evo = 4;
      


        }


        public void ClearAll()
        {

            uf.SelectedItem = 9;
            muni_Notificacao.Text = "";
            fonte_Notificacao.Text = "";
            nome_Proprietario.Text = "";
            cpf_Proprietario.Text = "";
            logradouro_Proprietario.Text="";
            numero_Proprietario.Text="";
            bairro_Proprietario.Text ="";
            complemento_Proprietario.Text="";
            zona_Proprietario.Text="";
            nome_Animal.Text="";
            idade_Animal.Text="";
            raca_Animal.Text="";
            porte_Animal.SelectedItem=0;
            urbana.IsChecked=false;
            periurbana.IsChecked=false;
            rural.IsChecked=false;
            domiciliado.IsChecked=false;
            semi.IsChecked=false;
            PresencaNao.IsChecked=false;
            Presencasim.IsChecked=false;
            emagrecimento_Animal.IsChecked=false;
            alopecia_Animal.IsChecked = false;
            hepatomegalia_Animal.IsChecked=false;
            apatia_Animal.IsChecked=false;
            lesoes_Animal.IsChecked=false;
            onicogrifose_Animal.IsChecked=false;
            apetite_Animal.IsChecked=false;
            alteraoculares_Animal.IsChecked=false;
            qual_sintoma.Text = "";
            outro_sintoma.IsChecked=false;
            reagenteR.IsChecked=false;
            nreagenteR.IsChecked=false;
            nrealizadoR.IsChecked=false;
            Elisa_Positivo.IsChecked=false;
            Elisa_Negativo.IsChecked=false;
           
            Elisa_NaoRealizado.IsChecked=false;
            reagenteP.IsChecked=false;
            nreagenteP.IsChecked=false;
            nrealizadoP.IsChecked=false;
            rb_Tratamento.IsChecked=false;
            rb_Recolhido.IsChecked=false;
            rb_NEutanasiado.IsChecked=false;
            descartado.IsChecked = false;
            confirmado.IsChecked=false;

        }

        private void rb_Recolhido_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            pic_Eutanasia.IsEnabled = true;
          
        }
        
        private async void Location()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                Latitude = Convert.ToDouble( string.Format("{0:0.0000000}", position.Latitude));
                Logitude = Convert.ToDouble( string.Format("{0:0.0000000}", position.Longitude));

                geop.Text = "Sua localização já foi confimada.";
             

            }
            catch(Exception exc)
            {
                DisplayAlert("erro","Impossivel de capturar a sua localização ", "fim");
            }
          

        }

       
    }

   

       
           
         
          


           
          

        
    
}