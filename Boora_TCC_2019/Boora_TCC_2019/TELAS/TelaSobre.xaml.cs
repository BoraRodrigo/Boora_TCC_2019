using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TelaSobre : ContentPage
	{
		public TelaSobre ()
		{
			InitializeComponent ();
		}

        public void GoFace(object sender, EventArgs args)
        {
            Device.OpenUri(new Uri("https://www.facebook.com/angelosfitness/"));
        }

        public void GoWhats(object sender, EventArgs args)
        {
            try
            {
                Chat.Open("+5541996114270", "Fala parça!");
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void GoInsta(object sender, EventArgs args)
        {
            Device.OpenUri(new Uri("https://www.instagram.com/angelos_fitness_academia/"));
        }

        public void GoTwitter(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "Nao tem Twitter", "Ok");
        }

        public void MaisDetalhesAction(object sender, EventArgs args)
        {
            Lbl_MaisDetalhes.Text = "Software Versão 1.0 - Deselvolvido por Augusto de Lima, Rodrigo Bora";
        }

    }
}