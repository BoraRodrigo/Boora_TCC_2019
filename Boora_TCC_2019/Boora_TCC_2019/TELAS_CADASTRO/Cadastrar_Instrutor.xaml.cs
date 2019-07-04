using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastrar_Instrutor : ContentPage
	{
        InstrutorDAO instrutorDAO = new InstrutorDAO();
        public Cadastrar_Instrutor ()
		{
      
            InitializeComponent ();
            lbl_validaemail.IsVisible = false;

        }

        private  async void Cadastrar_InstrutorAsync(object sender, EventArgs e)
        {
            try
            {
                if (validaemail() == true)
                {
                    btn_Cadastrar.IsEnabled = false;
                    Instrutor instrutor = new Instrutor();
                    instrutor.Nome = txt_NOME.Text;
                    instrutor.Senha = txt_SENHA.Text;
                    instrutor.Email = txt_EMAIL.Text;
                    instrutor.Idade = Convert.ToInt32(txt_IDADE.Text);
                    instrutor.Formacao_Academica = txt_FORMACAO.Text;
                    await instrutorDAO.Cadastrar_Instrutor(instrutor);
                    limpaCampos();
                    btn_Cadastrar.IsEnabled = true;
                }
            }
            catch 
            {
               await DisplayAlert("ERRO", "Verefique as informações", "OK");
                btn_Cadastrar.IsEnabled = true;

            }
        }
        public void limpaCampos()
        {
            txt_EMAIL.Text="";
            txt_FORMACAO.Text = "";
            txt_NOME.Text = "";
            txt_SENHA.Text = "";
            txt_IDADE.Text = "";
        }

        public bool validaemail()
        {
            string email = txt_EMAIL.Text;
            Regex rg = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            if (rg.IsMatch(email))
            {
                lbl_validaemail.IsVisible = false;
                return true;
            }
            else
            {
                lbl_validaemail.IsVisible = true;
                return false;
            }
        }
    }
}