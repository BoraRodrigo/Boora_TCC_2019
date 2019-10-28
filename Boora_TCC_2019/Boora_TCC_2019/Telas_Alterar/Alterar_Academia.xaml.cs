using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.TELAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.Telas_Alterar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Alterar_Academia : ContentPage
	{
		public Alterar_Academia ()
		{
            carregaDadosAsync();
            InitializeComponent ();
		}
        private async void Btn_AlterarDados_ClickedAsync(object sender, EventArgs e)
        {
            //try
            //{
            txt_NOMEACADEMIA.IsEnabled = true;
                AcademiaDAO academiaDAO = new AcademiaDAO();
                Academia academia = new Academia();
                academia.Nome_academia = txt_NOMEACADEMIA.Text;
                academia.Cidade = txt_CIDADE.Text;
                academia.Cnpj = txt_CNPJ.Text;
                academia.Email = txt_EMAIL.Text;
                academia.Estado = txt_ESTADO.Text;
                academia.Logo_academia = "";
                academia.Senha = txt_SENHA.Text;
                academia.Whats = txt_TELEFONE.Text;
                academia.Instagran = txt_INSTAGRAN.Text;
                academia.Id_academia = Login.Id_Academia_Login;
                academia.Nome_academia = Login.Nome_Academia_login;


                await academiaDAO.Alterar_Academia(Login.Nome_Academia_login, academia);
                App.Current.MainPage = new MENU.Master();


            //}
            //catch
           // {
             //   await DisplayAlert("ERRO", "Verefique as informações", "OK");
            //}

        }
        public async Task carregaDadosAsync()
        {
            AcademiaDAO academiaDAO = new AcademiaDAO();
            var dados_Academia = await academiaDAO.Busca_Academia_Nome(Login.Nome_Academia_login);


            txt_CIDADE.Text = dados_Academia.Cidade;
            txt_CNPJ.Text = dados_Academia.Cnpj;
            txt_EMAIL.Text = dados_Academia.Email;
            txt_ESTADO.Text = dados_Academia.Estado;
            txt_NOMEACADEMIA.Text = dados_Academia.Nome_academia;
            txt_SENHA.Text = dados_Academia.Senha;
            txt_INSTAGRAN.Text = dados_Academia.Instagran;
            txt_TELEFONE.Text = dados_Academia.Whats;


        }
    }
}