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
      
        public static string Id_Aluno_Login { get; set; }
        public static string Nome_Aluno_Logado { get; set; }
        public static string Senha_Aluno_Logado { get; set; }
        public static string Nome_Academia_login { get; set; }

        public static string Id_Academia_Login { get; set; }

        public static string Tipo_login { get; set; }

        public Login ()
		{

            InitializeComponent ();
           

        }
        private async void EfetuarLogin(object sender, EventArgs args)
        {


            Aluno aluno = new Aluno();
            AlunoDAO alunoDAO = new AlunoDAO();

            Academia academia = new Academia();
            AcademiaDAO academiaDAO = new AcademiaDAO();
            Nome_Academia_login = txtNome_academia.Text;

            string nome;
            try
            {
                // resolve a questao do espaço

                nome = txtNome.Text.Trim();
                if (chekAluno.IsChecked == true)
                {
                    SlCarregandoLogin.IsVisible = true; // enquanto espera resposta do BD sobe um stacklayout com indicador(carregadndo) rodadndo.
                    aluno = await alunoDAO.Login_Aluno(nome, txtsenha.Text);

                    Id_Aluno_Login = aluno.Id_Aluno;
                    Nome_Aluno_Logado = aluno.Nome;
                    Senha_Aluno_Logado = aluno.Senha;


                    var academiaLogin = await academiaDAO.Busca_Academia_Nome(txtNome_academia.Text);
                    Id_Academia_Login = academiaLogin.Id_academia;


                    SlCarregandoLogin.IsVisible = false; // apos o retorno do BD o Stacklayout some.
                    Tipo_login = "Aluno";
                    App.Current.MainPage = new NavigationPage(new MENU.Master());
                }
                else if (chekAcademia.IsChecked == true)
                {
                    SlCarregandoLogin.IsVisible = true;
                    academia = await academiaDAO.Login_Dono_Academia(txtsenha.Text, txtNome.Text);


                    //aqui tem que ajustar esta imporvisado ainda 
                    Id_Aluno_Login = academia.Id_academia;
                    Id_Academia_Login = academia.Id_academia;
                    Nome_Aluno_Logado = academia.Nome_academia;
                    Senha_Aluno_Logado = academia.Senha;
                    Nome_Academia_login = academia.Nome_academia;
                    Tipo_login = "Dono_Academia";

                    App.Current.MainPage = new NavigationPage(new MENU.Master());
                    SlCarregandoLogin.IsVisible = false;
                }
                else if (chekPersonal.IsChecked == true)
                {
                    await DisplayAlert("", "Não Implementado", "");
                }


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
       public void Cadastre_sua_Academia(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new TELAS_CADASTRO.Cadastrar_Academia());
        }

        
    }
}