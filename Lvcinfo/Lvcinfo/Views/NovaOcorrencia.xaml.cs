using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Lvcinfo.Models;
using LVCinfo.Services;
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
        private bool emagrecimento;
        private bool alopecia;
        private bool hepato;
        private bool apatia;
        private bool lesao;
        private bool onico;
        private bool apetite;
        private bool ocular;
        private bool linfo;
        private bool vomito;
        private bool diarreia;
        private bool sanguenasal;
        private int amostra;
        private int erapido;
        private int eelisa;
        private int eparasita;
        private string conlusaocaso;
        private string evo;

        FirebaseService fbService = new FirebaseService();
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

            CheckAndRadios();

            try
            {

                await fbService.addRegistro(data_Notificacao.Date.ToShortDateString(), uf.SelectedItem.ToString(), muni_Notificacao.Text
                     , fonte_Notificacao.Text, nome_Proprietario.Text, logradouro_Proprietario.Text, int.Parse(numero_Proprietario.Text),
                     bairro_Proprietario.Text, cep_Proprietario.Text, complemento_Proprietario.Text, municipio_Proprietario.Text, zona_Proprietario.Text,
                     telefone_Proprietario.Text, email_Proprietario.Text, cpf_Proprietario.Text, nascimento_Proprietario.Text, nome_Animal.Text, idade_Animal.Text, raca_Animal.Text, porte_Animal.Text,
                     pelagem_Animal.Text, fotoanimal, PROCEDENCIA, ABRIGO, OUTRO, data_Sintomas.Date.ToLongDateString(), emagrecimento, alopecia, hepato, apatia, lesao, onico,
                     apetite, ocular, linfo, vomito, diarreia, sanguenasal, user.UserName, qual_sintoma.Text, data_Amostra.Date.ToShortDateString(), amostra, qual_amostra.Text, erapido, eelisa, eparasita, conlusaocaso, evo, pic_Data.Date.ToShortDateString());

                await DisplayAlert("Success", "Investigação incluída com sucesso", "OK");
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erro","Ocorreu um erro com o cadastro da investigação. Certifiquei-se que campos importantes não estão em branco "+ex.ToString(), "OK");
            }




            



        }

        private void sim_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            label_outros.IsVisible = true;
            quais_animais.IsVisible = true;
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
            pic_Data.IsEnabled  = true;


        }

        private void outro_sintoma_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            quais_animais.IsEnabled = true;
        }

        private void QualAmostraChecked(object sender, CheckedChangedEventArgs e)
        {
            qual_amostra.IsEnabled = true;
        }
        public void CheckAndRadios()
        {
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
                ABRIGO = 2;
            }
            if (errante.IsChecked)
            {
                ABRIGO = 3;
            }

            if (nao.IsChecked)
            {
                OUTRO = 0;
            }
            if (sim.IsChecked)
            {
                OUTRO = 1;
            }

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
            if (linfomegalia_Animal.IsChecked)
            {
                linfo =  true;
            }
            else
            {
                linfo = false;
            }
            if (vomito_Animal.IsChecked)
            {
                vomito = true;
            }
            else
            {
                vomito = false;
            }
            if (diarreia_Animal.IsChecked)
            {
                diarreia = true;
            }
            else
            {
                diarreia = false;
            }
            if (sanguenasal_Animal.IsChecked)
            {
                sanguenasal = true;

            }
            else
            {
                sanguenasal = false;
            }


            if (sangue.IsChecked)
            {
                amostra = 1;
            }
            if (soro.IsChecked)
            {
                amostra = 2;
            }
            if (reagenteR.IsChecked)
            {
                erapido = 1;
            }
            if (nreagenteR.IsChecked)
            {
                erapido = 2;
            }
            if (nrealizadoR.IsChecked)
            {
                erapido = 3;
            }
            if (reagenteE.IsChecked)
            {
                eelisa = 1;
            }
            if (nrealizadoE.IsChecked)
            {
                eelisa = 2;
            }
            if (nreagentE.IsChecked)
            {
                eelisa =3;
            }
            if (reagenteP.IsChecked)
            {
                eparasita =1;
            }
            if (nreagenteP.IsChecked)
            {
                eparasita = 2;
            }
            if (nrealizadoP.IsChecked)
            {
                eparasita =3;
            }
            if (confirmado.IsChecked)
            {
                conlusaocaso = "1";
            }
            if (descartado.IsChecked)
            {
                conlusaocaso = "0";
            }
            if (rb_Tratamento.IsChecked)
            {
                evo = "1";
            }
            if (rb_Encoleirado.IsChecked)
            {
                evo = "2";
            }
            if (rb_Eutanasiado.IsChecked)
            {
                evo = "3";
            }

        }
    }
}