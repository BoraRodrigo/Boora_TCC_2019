using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{

        public Login ()
		{

            InitializeComponent ();

		}
        private void EfetuarLogin(object sender, EventArgs args)
        {

            App.Current.MainPage = new NavigationPage(new MENU.Master());
            

        }
    }
}