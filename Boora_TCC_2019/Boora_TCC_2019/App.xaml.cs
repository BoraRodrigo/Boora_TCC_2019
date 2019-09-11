using Boora_TCC_2019.TELAS;
using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.TELAS_CADASTRO;
using Boora_TCC_2019.BancoSQlite;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

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
            MudarCorPersonalizacao();
            MainPage = new NavigationPage(new Login());
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

        public void MudarCorPersonalizacao()
        {
            List<Cores> cores = new List<Cores>();
            Db_SqlLite db = new Db_SqlLite();

            cores = db.Consultar();
            if (cores.Capacity > 0)
            {
                try
                {
                    this.Resources["ColorLabel"] = Color.FromHex(cores[0].CorLabel);
                }
                catch (System.Exception)
                {
                    this.Resources["ColorLabel"] = Color.Black;
                    
                }
               // try
               // {
                    //this.Resources["ColorStacklayout"] = Color.FromHex(cores[0].CorStackLayout);
               // }
              //  catch (System.Exception)
               // {
               //     this.Resources["ColorStacklayout"] = Color.White;
                    
              //  }
                
                
            }
            else
            {
                this.Resources["ColorLabel"] = Color.Black;
                this.Resources["ColorStacklayout"] = Color.White;
            }
        }
        
    }
}
