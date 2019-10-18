﻿using Boora_TCC_2019.ClassesUTEIS;
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

            string nomelogin;
            string senhalogin;

            string academialogin;
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
                //else if (chekPersonal.IsChecked == true)
                //{
                //    await DisplayAlert("", "Não Implementado", "");
                //}


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


        
            //txt_email_redefinir_senha.IsVisible = true;
           //btn_RedefinirSenha.IsVisible = true;                     
        }
        //public async void RedefinirSenhaAsync(object sender,EventArgs args)
        //{
        //    Email email = new Email();
        //   await email.RedefinirSenha(txt_email_redefinir_senha.Text,txtNome_academia.Text);

        //    txt_email_redefinir_senha.IsVisible = false;
        //    btn_RedefinirSenha.IsVisible = false;
        //}
       public void Cadastre_sua_Academia(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TELAS_CADASTRO.Cadastrar_Academia(), true);
        }        
    }
}