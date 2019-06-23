using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
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
        public static int Id_Aluno_Login { get; set; }
        public static string Nome_Aluno_Logado { get; set; }
        public static string Senha_Aluno_Logado { get; set; }

        public Login ()
		{

            InitializeComponent ();

		}
        private async void EfetuarLogin(object sender, EventArgs args)
        {
            Aluno aluno = new Aluno();
            AlunoDAO alunoDAO = new AlunoDAO();



            try
            {
                aluno = await alunoDAO.Login_Aluno(txtNome.Text, txtsenha.Text);

                Id_Aluno_Login = aluno.Id_Aluno;
                Nome_Aluno_Logado = aluno.Nome;
                Senha_Aluno_Logado = aluno.Senha;

                App.Current.MainPage = new NavigationPage(new MENU.Master());
            }
            catch 
            {
                await DisplayAlert("BOORA", "Verefique seu Login Parça", "OK");

            } 
           
            

        }
    }
}