using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lvcinfo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SobreApp : ContentPage
	{
		public SobreApp ()
		{
			InitializeComponent ();
            Build.Text = "Build atual: "+GetCurrentBuild()+".";
            
            Versao.Text = "Versão atual: "+GetCurrentVersion()+".";
		}

        private static string GetCurrentBuild()
        {
            return VersionTracking.CurrentBuild;
        }

        private static string GetCurrentVersion()
        {
            return VersionTracking.CurrentVersion;
        }
    }
}