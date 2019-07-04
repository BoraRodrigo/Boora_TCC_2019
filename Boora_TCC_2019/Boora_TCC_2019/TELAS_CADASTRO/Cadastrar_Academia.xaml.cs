using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS_CADASTRO
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastrar_Academia : ContentPage
	{
		public Cadastrar_Academia ()
		{
			InitializeComponent ();
		}
        private async void Cadastrar_AlunoAsy(object sender, EventArgs e)
        {
                AcademiaDAO academiaDAO = new AcademiaDAO();
                Academia academia = new Academia();

                var verefica_se_academia_ja_cadastrada = await academiaDAO.Busca_Academia_Nome(txt_NOMEACADEMIA.Text);
            try
            {
                if (verefica_se_academia_ja_cadastrada.Nome_academia.Equals(txt_NOMEACADEMIA.Text))
                {
                    await DisplayAlert("ERRO", "Academia já cadastrada", "OK");
                }

            }
            catch
            {
                try
                {
                    academia.Id_academia = "2";
                    academia.Nome_academia = txt_NOMEACADEMIA.Text;
                    academia.Cidade = txt_CIDADE.Text;
                    academia.Cnpj = txt_CNPJ.Text;
                    academia.Email = txt_EMAIL.Text;
                    academia.Estado = txt_ESTADO.Text;
                    academia.Logo_academia = txt_logo.Text;
                    academia.Senha = txt_SENHA.Text;
                    await academiaDAO.Cadastrar_Academia(academia);
                    LimpaCampos();
                }
                catch
                {

                  
                }
            }                      
                {  
            }
        }
        public void LimpaCampos()
        {
            txt_CIDADE.Text = "";
            txt_CNPJ.Text = "";
            txt_EMAIL.Text = "";
            txt_ESTADO.Text = "";
            txt_logo.Text = "";
            txt_NOMEACADEMIA.Text = "";
            txt_SENHA.Text = "";
        }
    }
}