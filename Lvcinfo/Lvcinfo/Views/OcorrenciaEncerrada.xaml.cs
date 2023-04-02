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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OcorrenciaEncerrada : ContentPage
    {
        FirebaseService fbService = new FirebaseService();
        public OcorrenciaEncerrada()
        {
            BindingContext = this;
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
        
            
        }
    }
}