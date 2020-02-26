using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LinkarViewFiles.Views;
using System.Globalization;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LinkarViewFiles
{
    public partial class App : Application
    {
        public static string servicesUrl = "http://demolinkarapp.ddns.net";
        public static string Token = null;

        public App()
        {
            InitializeComponent();


            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ret = "";
            if (value != null)
            {
                ret = ((DateTime)value).ToString("dd'/'MM'/'yyyy");
            }
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
