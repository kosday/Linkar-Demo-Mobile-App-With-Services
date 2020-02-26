using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using LinkarViewFiles.Models;
using LinkarViewFiles.Views;
using System.Net.Http;
using LinkarViewFiles.Services;

namespace LinkarViewFiles.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginDataStore DataStore = DependencyService.Get<LoginDataStore>() ?? new LoginDataStore();
        public Command LoginCommand { get; set; }
        public Command LogoutCommand { get; set; }

        public LoginViewModel()
        {
            Title = "Login";
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
            LogoutCommand = new Command(async () => await ExecuteLogoutCommand());
        }

        public async Task ExecuteLoginCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var login = await DataStore.LoginAsync();
                if (login != null)
                {
                    App.Token = login.Token;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task ExecuteLogoutCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var resp = await DataStore.LogoutAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}