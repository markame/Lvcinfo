using Lvcinfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;


namespace Lvcinfo.Views
{
    
    public partial class PaginaInicial : Xamarin.Forms.TabbedPage
    {
        public PaginaInicial()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            var isFirstRun = Preferences.Get("isFirstRun", true);
            if (!isFirstRun)
            {
                // Marca a flag indicando que o aplicativo já foi iniciado pelo menos uma vez
                Preferences.Set("isFirstRun", false);

                // Chama o método para verificar e solicitar permissão de localização
                Task.Run(async () =>
                {
                    await CheckAndRequestLocationPermissionAsync();
                });
            }


        }
        public async Task CheckAndRequestLocationPermissionAsync()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
               

                if (status != PermissionStatus.Granted)
                {
                    if (await DisplayAlert("Permissão de localização", "Por favor, habilite a permissão de localização para usar o aplicativo.", "Configurações", "Cancelar"))
                    {

                        try
                        {
                            Xamarin.Essentials.AppInfo.ShowSettingsUI();

                        }
                        catch (Exception ex)
                        {
                            // Lidar com qualquer exceção
                            await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
                        }
                    }
                    return;
                }
            }

            // Permissão concedida, faça algo aqui que exige acesso à localização
            // Por exemplo, iniciar o rastreamento de localização
        }
    }
}