using Boora_TCC_2019.DAO;
using Boora_TCC_2019.TELAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.TELAS_SERIE;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.OpenWhatsApp;

namespace Boora_TCC_2019
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicial : ContentPage
	{
		public Inicial ()
		{           
          //  NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();           
           // lbl_nome_academia.Text = "ACADEMIA " + Login.Nome_Academia_login.ToString().ToUpper();           
        }
        protected async override void OnAppearing()
        {
            try
            {
                AcademiaDAO academiaDAO = new AcademiaDAO();
                imgagem_logo_Academia.Source = await academiaDAO.Buscar_IMAGEM_Logo_Academia(Login.Id_Academia_Login);
            }
            catch 
            {              
            }
        }
        public void GoInsta(object sender, EventArgs args)
        {
            // 2 semestre =)
            string instagramacadeia = "https://www.instagram.com/"+Login.Instagran_Academia+"/";
            Device.OpenUri(new Uri(instagramacadeia));
        }

        public void GoWhats(object sender, EventArgs args)
        {
            string telefoneacademia = Login.Telefone_Academia;
            try
            {
                Chat.Open("55"+telefoneacademia.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ",""), "Fala parça!");
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}