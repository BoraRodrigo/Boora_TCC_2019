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

            string nome;
            

            try
            {
                // resolve a questao do espaço
                nome = txtNome.Text.Trim();

                SlCarregandoLogin.IsVisible = true; // enquanto espera resposta do BD sobe um stacklayout com indicador(carregadndo) rodadndo.
                aluno = await alunoDAO.Login_Aluno(nome, txtsenha.Text);

                Id_Aluno_Login = aluno.Id_Aluno;
                Nome_Aluno_Logado = aluno.Nome;
                Senha_Aluno_Logado = aluno.Senha;
                SlCarregandoLogin.IsVisible = false; // apos o retorno do BD o Stacklayout some.
                App.Current.MainPage = new NavigationPage(new MENU.Master());
            }
            catch 
            {
                int i = 4;
                bool aux = true;
                EsqueceuSenhaLbl.Text = "Verifique seu login";
                EsqueceuSenhaLbl.IsVisible = true;
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {

                    i--;
                    if (i < 0)
                    {
                        EsqueceuSenhaLbl.IsVisible = false;
                        aux = false;
                    }
                    return aux;
                });
                

            } 
           
        }
        public void EsqueceuSenha(object sender, EventArgs args)
        {
            // TODO - Desenvolver metodo da esqueceu a senha
            int i = 4;
            bool aux = true;
            EsqueceuSenhaLbl.Text = "Em desenvolvimento";
            EsqueceuSenhaLbl.IsVisible = true;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                i--;
                if (i < 0)
                {
                    EsqueceuSenhaLbl.IsVisible = false;
                    aux = false;
                }
                return aux;
            });
            
        }
    }
}