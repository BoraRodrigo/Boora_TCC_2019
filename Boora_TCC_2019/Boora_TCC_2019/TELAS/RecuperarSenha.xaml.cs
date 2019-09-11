using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.ClassesUTEIS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecuperarSenha : ContentPage
	{
		public RecuperarSenha ()
		{
			InitializeComponent ();
		}

        public async void RedefinirSenhaAsync(object sender, EventArgs args)
        {
            Email email = new Email();
            await email.RedefinirSenha(txt_email_redefinir_senha.Text, txtNome_Academia.Text);

            await Navigation.PopAsync();
        }

    }
}