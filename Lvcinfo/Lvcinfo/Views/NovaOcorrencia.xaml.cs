using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Lvcinfo.Models;



namespace Lvcinfo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovaOcorrencia : ContentPage
    {
        Ocorrencia ocorrencia = new Ocorrencia();
        private byte[] Base64Stream;
        private string fotoanimal;
        private int PROCEDENCIA;
        private int ABRIGO;
        private int OUTRO;
        //FirebaseService fbService = new FirebaseService();
        public NovaOcorrencia()
        {
            InitializeComponent();
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var cameraMediaOptions = new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Rear,

                // Set the value to true if you want to save the photo to your public storage.
                SaveToAlbum = true,

                // Give the name of the folder you want to save to
                Directory = "MyAppName",

                // Give a photo name of your choice,
                // or set it to null if you want to use the default naming convention
                Name = null,

                // Set the compression quality
                // 0 = Maximum compression but worse quality
                // 100 = Minimum compression but best quality
                CompressionQuality = 100
            };
            MediaFile photo = await CrossMedia.Current.TakePhotoAsync(cameraMediaOptions);
            if (photo == null) return;
            //Anima.Source = ImageSource.FromStream(() => photo.GetStream());
            base64encode(photo);


        }
        private async void Salvar_Clicked(object sender, EventArgs e)
        {

            /* item.Data_Notificacao = data_Notificacao.Date.ToShortDateString();
             item.UF = uf.SelectedItem.ToString();
             item.Muni_Notificacao = muni_Notificacao.Text;
             item.Fonte_Notificacao = fonte_Notificacao.Text;
             item.Nome_Proprietario = nome_Proprietario.Text;
             item.Logradouro_Proprietario = logradouro_Proprietario.Text;
             item.Numero_Proprietario = int.Parse(numero_Proprietario.Text);
             item.Bairro_Proprietario = bairro_Proprietario.Text;
             item.Cep_Proprietario = cep_Proprietario.Text;
             item.Complemento_Proprietario = complemento_Proprietario.Text;
             item.Municipio_Proprietario = municipio_Proprietario.Text;
             item.Zona_Proprietario = zona_Proprietario.Text;
             item.Telefone_Proprietario = telefone_Proprietario.Text;
             item.Email_Proprietario = email_Proprietario.Text;
             item.Cpf_Proprietario = cpf_Proprietario.Text;
             item.Nascimento_Proprietario = nascimento_Proprietario.Text;
             item.Nome_Animal = nome_Animal.Text;   
             item.Idade_Animal = idade_Animal.Text;
             item.Raca_Animal = raca_Animal.Text;
             item.Porte_Animal  =   raca_Animal.Text;
             item.Pelagem_Animal = pelagem_Animal.Text;*/

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
           /* await fbService.addRegistro(data_Notificacao.Date.ToShortDateString(), uf.SelectedItem.ToString(), muni_Notificacao.Text
                , fonte_Notificacao.Text, nome_Proprietario.Text, logradouro_Proprietario.Text, int.Parse(numero_Proprietario.Text),
                bairro_Proprietario.Text, cep_Proprietario.Text, complemento_Proprietario.Text, municipio_Proprietario.Text, zona_Proprietario.Text,
                telefone_Proprietario.Text, email_Proprietario.Text, cpf_Proprietario.Text, nascimento_Proprietario.Text, nome_Animal.Text, idade_Animal.Text, raca_Animal.Text, porte_Animal.Text,
                pelagem_Animal.Text, fotoanimal, PROCEDENCIA, ABRIGO, OUTRO);*/

            await DisplayAlert("Success", "Ocorrencia incluído com sucesso", "OK");








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

        }
    }
}