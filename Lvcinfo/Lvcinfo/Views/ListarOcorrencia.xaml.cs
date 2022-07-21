using LVCinfo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lvcinfo.Views
{
   
    

    public partial class ListarRegistro : ContentPage
    {
        FirebaseService fbService = new FirebaseService();
        public ListarRegistro()
        {
            BindingContext = this;
            InitializeComponent();
          
        }

        protected async override void OnAppearing()
        {

            var registrosbd = await fbService.GetRegistrosBySituacao("1");
            listar_Registro.ItemsSource = registrosbd;

        }
   

        public async void busca()
        {
            var Registros_listar = await fbService.GetRegistrosAll();
            listar_Registro.ItemsSource = Registros_listar;
            
        }
    }
}