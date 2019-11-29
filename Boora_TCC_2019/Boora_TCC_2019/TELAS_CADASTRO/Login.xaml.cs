using Boora_TCC_2019.BancoSQlite;
using Boora_TCC_2019.ClassesUTEIS;
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

        public static string Email_Aluno_Logado { get; set; }

        public static string Nome_Academia_login { get; set; }

        public static string Telefone_Academia { get; set; }
        public static string Instagran_Academia { get; set; }


        public static string Id_Academia_Login { get; set; }

        public static string Tipo_login { get; set; }

        Db_SqlLite db = new Db_SqlLite();
        List<Acessar> lista = new List<Acessar>();
        Acessar acessar = new Acessar();
        public Login ()
		{

            InitializeComponent ();
            lista = db.Consultar_Logins();
            if (lista.Capacity != 0)
            {
                try
                {
                    txtNome.Text = lista[0].Email;
                    txtNome_academia.Text = lista[0].Academia;
                    txtsenha.Text = lista[0].Senha;
                    if (lista[0].Tipo.Equals("ALUNO"))
                    {
                        chekAluno.IsChecked = true;
                    }
                    else if (lista[0].Tipo.Equals("ACADEMIA"))
                    {
                        chekAcademia.IsChecked = true;
                    }
                    if (lista[0].salvar_Dados == 1)
                    {
                        ch_salvarDados.IsChecked = true;
                    }
                    else
                    {
                        ch_salvarDados.IsChecked = false;
                        txtNome.Text = "";
                        txtNome_academia.Text = "";
                        txtsenha.Text = "";
                        chekAcademia.IsChecked = false;
                        chekAcademia.IsChecked = false;
                    }
                }
                catch 
                {

                    
                }
                
                
            }
        }
        private async void EfetuarLogin(object sender, EventArgs args)
        {
            
            Aluno aluno = new Aluno();
            AlunoDAO alunoDAO = new AlunoDAO();

            Academia academia = new Academia();
            AcademiaDAO academiaDAO = new AcademiaDAO();
            Nome_Academia_login = txtNome_academia.Text;

            string nomelogin;
            string senhalogin;
            string academialogin;
            
            if(ch_salvarDados.IsChecked == true)
            {
                if (lista.Capacity == 0)
                {

                    acessar.salvar_Dados = 1;
                    acessar.Email = txtNome.Text;
                    acessar.Academia = txtNome_academia.Text;
                    acessar.Senha = txtsenha.Text;
                    if (chekAluno.IsChecked == true)
                    {
                        acessar.Tipo = "ALUNO";
                    }
                    if (chekAcademia.IsChecked == true)
                    {
                        acessar.Tipo = "ACADEMIA";
                    }
                    db.Salvar_Login(acessar);
                }
                else
                {
                    acessar.salvar_Dados = 1;
                    acessar.Email = txtNome.Text;
                    acessar.Academia = txtNome_academia.Text;
                    acessar.Senha = txtsenha.Text;
                    if (chekAluno.IsChecked == true)
                    {
                        acessar.Tipo = "ALUNO";
                    }
                    if (chekAcademia.IsChecked == true)
                    {
                        acessar.Tipo = "ACADEMIA";
                    }
                    acessar.id = lista[0].id;
                    db.Alterar_Login(acessar);
                }
            }
            else
            {
                if (lista.Capacity == 0)
                {

                    acessar.salvar_Dados = 0;
                    acessar.Email = txtNome.Text;
                    acessar.Academia = txtNome_academia.Text;
                    acessar.Senha = txtsenha.Text;
                    if (chekAluno.IsChecked == true)
                    {
                        acessar.Tipo = "ALUNO";
                    }
                    if (chekAcademia.IsChecked == true)
                    {
                        acessar.Tipo = "ACADEMIA";
                    }
                    db.Salvar_Login(acessar);
                }
                else
                {
                    acessar.salvar_Dados = 0;
                    acessar.Email = txtNome.Text;
                    acessar.Academia = txtNome_academia.Text;
                    acessar.Senha = txtsenha.Text;
                    if (chekAluno.IsChecked == true)
                    {
                        acessar.Tipo = "ALUNO";
                    }
                    if (chekAcademia.IsChecked == true)
                    {
                        acessar.Tipo = "ACADEMIA";
                    }
                    acessar.id = lista[0].id;
                    db.Alterar_Login(acessar);
                }

            }

           

            try
            {
                // resolve a questao do espaço no final da palavra 10/09


                nomelogin = txtNome.Text.TrimEnd();
                senhalogin = txtsenha.Text.TrimEnd();
                academialogin = txtNome_academia.Text.TrimEnd();

                if (chekAluno.IsChecked == true)
                {
                    SlCarregandoLogin.IsVisible = true; // enquanto espera resposta do BD sobe um stacklayout com indicador(carregadndo) rodadndo.
                    aluno = await alunoDAO.Login_Aluno(nomelogin, senhalogin);

                    ///resolve o erro do loping login (Retorna null na busca de não econtrar)
                    if (aluno == null)
                    {
                        SlCarregandoLogin.IsVisible = false;
                        await DisplayAlert("", "Erro ao Efetuar Login", "");
                        App.Current.MainPage = new Login();
                     
                    }

                    Id_Aluno_Login = aluno.Id_Aluno;
                    Nome_Aluno_Logado = aluno.Nome;
                    Senha_Aluno_Logado = aluno.Senha;
                    Email_Aluno_Logado = aluno.Email;


                    var academiaLogin = await academiaDAO.Busca_Academia_Nome(academialogin);
                    Telefone_Academia = academiaLogin.Whats;
                    Instagran_Academia = academiaLogin.Instagran;
                    Id_Academia_Login = academiaLogin.Id_academia;

                

                    SlCarregandoLogin.IsVisible = false; // apos o retorno do BD o Stacklayout some.
                    Tipo_login = "Aluno";

                   
                    App.Current.MainPage = new MENU.Master();
                }
                else if (chekAcademia.IsChecked == true)
                {
                    SlCarregandoLogin.IsVisible = true;
                    academia = await academiaDAO.Login_Dono_Academia(senhalogin,academialogin, nomelogin);

                    ///resolve o erro do loping login (Retorna null na busca de não econtrar)
                    if (academia == null)
                    {
                        SlCarregandoLogin.IsVisible = false;
                        await DisplayAlert("", "Erro ao Efetuar Login", "");
                        App.Current.MainPage = new Login();
                   
                    }


                    //aqui tem que ajustar esta imporvisado ainda 
                    Id_Aluno_Login = academia.Id_academia;
                    Id_Academia_Login = academia.Id_academia;
                    Nome_Aluno_Logado = academia.Nome_academia;
                    Senha_Aluno_Logado = academia.Senha;
                    Telefone_Academia = academia.Whats;
                    Nome_Academia_login = academia.Nome_academia;
                    Tipo_login = "Dono_Academia";

                   


                    App.Current.MainPage = new MENU.Master();
                    SlCarregandoLogin.IsVisible = false;
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
            Navigation.PushAsync(new TELAS.RecuperarSenha(), true);      
        }
       
       public void Cadastre_sua_Academia(object sender, EventArgs args)
        {
         
        Navigation.PushAsync(new TELAS_CADASTRO.Cadastrar_Academia(), true);
      //aqui trava se logar e sair depois clicar aqui é algo com o navigation page ele pede pra usar 
        }
        public void  Cadastrar_Aluno(object sender, EventArgs args)
        {
            Device.OpenUri(new Uri("http://booraapp.gear.host"));
        }
        
    }
}