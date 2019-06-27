using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicial : ContentPage
	{
		public Inicial ()
		{
			InitializeComponent ();
		}

        public void GoInsta(object sender, EventArgs args)
        {
            // 2 semestre =)
           //Device.OpenUri(new Uri("https://www.instagram.com/angelos_fitness_academia/"));
        }

        public void GoWhats(object sender, EventArgs args)
        {
            // 2 semestre =)
            //try
            //{
            //    Chat.Open("+5541996114270", "Fala parça!");
            //}
            //catch (Exception ex)
            //{
            //    DisplayAlert("Erro", ex.Message, "OK");
            //}
        }
    }
}