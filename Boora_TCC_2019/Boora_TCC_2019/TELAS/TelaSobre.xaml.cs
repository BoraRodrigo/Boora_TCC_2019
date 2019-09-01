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

        

        public void MaisDetalhesAction(object sender, EventArgs args)
        {
            Lbl_MaisDetalhes.Text = "Software Versão 1.0 - Deselvolvido por Augusto de Lima, Rodrigo Bora";
            Lbl_MaisDetalhes2.Text = "Contato - booraappcontato@gmail.com";
            Lbl_MaisDetalhes2.IsVisible = true;
        }

    }
}