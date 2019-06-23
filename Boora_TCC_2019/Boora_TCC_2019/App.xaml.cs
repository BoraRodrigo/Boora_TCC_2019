using Boora_TCC_2019.TELAS;
using Boora_TCC_2019.TELAS_SERIE;
using Boora_TCC_2019.TELAS_CADASTRO;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Boora_TCC_2019
{
    public partial class App : Application
    {
        public App()
        {

            //chave de licensa do calendario 
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTEzNDM5QDMxMzcyZTMxMmUzMEFxUTdKRUFOdk9ueEljR1dRM1B1dk5LaWpZTTE2bHd1ZG56WnJxQkY0Qk" +
                                                                            "k9;MTEzNDQwQDMxMzcyZTMxMmUzMEtjem5Rem4rb3pXMVpiSTFxcjFZUUxPMk9uQzBHTGZ1R2FWbkczOTR1R0U9");
            InitializeComponent();
           
            MainPage = new Login();
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
}
