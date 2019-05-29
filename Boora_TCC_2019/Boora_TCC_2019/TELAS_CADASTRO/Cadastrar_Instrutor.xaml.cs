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
	public partial class Cadastrar_Instrutor : ContentPage
	{
        InstrutorDAO instrutorDAO = new InstrutorDAO();
        public Cadastrar_Instrutor ()
		{
			InitializeComponent ();
		}

        private  async void Cadastrar_InstrutorAsync(object sender, EventArgs e)
        {
            Instrutor instrutor = new Instrutor();
            instrutor.Nome = txt_NOME.Text;
            instrutor.Senha = txt_SENHA.Text;
            instrutor.Email = txt_EMAIL.Text;
            instrutor.Idade = Convert.ToInt32(txt_IDADE.Text);
            instrutor.Formacao_Academica = txt_FORMACAO.Text;

          await  instrutorDAO.Cadastrar_Instrutor(instrutor);

        }
        public void limpaCampos()
        {
           
        }
    }
}