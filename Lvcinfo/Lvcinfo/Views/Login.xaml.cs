using Lvcinfo.Model;
using Lvcinfo.Models;
using Lvcinfo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lvcinfo
{
    public partial class MainPage : ContentPage
    {
        JsonConnect jsonConnect = new JsonConnect();
        public MainPage()
        {
            InitializeComponent();
           

        }

        private async void Button_Login(object sender, EventArgs e)
        {

            try
            {
               var loginJson =  await jsonConnect.Login(UserName.Text, Password.Text);
                

            }
            catch(Exception x)
            {
                DisplayAlert("Erro de login","Aparentemente você ainda não  tem acesso","ok");
            }
          
        }
    }
}
