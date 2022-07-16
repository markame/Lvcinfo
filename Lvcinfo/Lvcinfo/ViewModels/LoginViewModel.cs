
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Lvcinfo.Model;
using Lvcinfo.Services;
using Lvcinfo.Views;
namespace Lvcinfo.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _UserName;
        public string UserName
        {
            set
            {this._UserName = value; OnPropertyChanged();}
            get
            { return this._UserName;}
        }
        private string _Name;
        public string Name
        {
            set { this._Name = value; OnPropertyChanged();}
            get{ return this._Name;}
        }

        private string _Password;
        public string Password
        {
            set{this._Password = value; OnPropertyChanged();}
            get{ return this._Password; }
        }

        private bool _Result;
        public bool Result
        {
            set { this._Result = value; OnPropertyChanged(); }
            get { return this._Result; }
        }
        private bool _isBussy;
        public bool IsBussy {
            set { this._isBussy = value; OnPropertyChanged(); } 
            get { return this._isBussy; }   
        }
           public Command LoginCommand { get; set; }
           public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task LoginCommandAsync()
        {
            if (IsBussy)
                return;
            try
            {
                IsBussy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(UserName,Password);
                if (Result)
                {
                    Preferences.Set("UserName", UserName);


                     await Application.Current.MainPage.Navigation.PushAsync(new PaginaInicial());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro","Usuario/Senha Incorreto(s)","OK");
                }
            }
            catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Aparelho sem conexão com a internet", "OK");
            }
            finally
            {
              IsBussy = false;
            }
            
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBussy)
                return;
            try
            {
                IsBussy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(UserName, Password);
                if (Result)
                    
                    Application.Current.MainPage.DisplayAlert("Sucesso", "Usuário Registrado", "Ok");
                else
                    await Application.Current.MainPage.DisplayAlert("Erro", "Falha ao registrar usuário", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
            finally
            {
                IsBussy = false;
            }
        }
    }
}



