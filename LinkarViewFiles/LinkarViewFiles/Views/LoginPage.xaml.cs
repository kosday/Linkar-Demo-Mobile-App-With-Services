using LinkarViewFiles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LinkarViewFiles.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);  // Hide nav bar

            BindingContext = viewModel = new LoginViewModel();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        public async Task LoginAsync()
        {
            await viewModel.ExecuteLoginCommand();
            if (!string.IsNullOrEmpty(App.Token))
                App.Current.MainPage = new MainPage();
        }
    }
}