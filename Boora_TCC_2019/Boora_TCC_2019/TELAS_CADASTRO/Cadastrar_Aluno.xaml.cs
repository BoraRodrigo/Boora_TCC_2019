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

   
    public partial class Cadastrar_Aluno : ContentPage
    {
        AlunoDAO alunoDAO = new AlunoDAO();
        public Cadastrar_Aluno()
        {
            InitializeComponent();
            lbl_validaemail.IsVisible = false;
        }

        private async void  Cadastrar_AlunoAsy(object sender, EventArgs e)
        {
            try
            {
               
                    btn_Cadastrar.IsEnabled = false;
                    Aluno aluno = new Aluno();
                    aluno.Nome = txt_NOME.Text;
                    aluno.Email = txt_EMAIL.Text;
                    aluno.Senha = txt_SENHA.Text;
                    aluno.Peso = Convert.ToDouble(txt_PESO.Text);
                    aluno.Altura = Convert.ToDouble(txt_ALTURA.Text);
                    aluno.Idade = Convert.ToInt32(txt_IDADE.Text);
                    aluno.objetivo_Aluno = txt_OBJETIVO.Text;
                    aluno.Situacao = 1;

                    await alunoDAO.Cadastrar_Aluno(aluno);
                    limpaCampos();
             

            }
            catch{

                await DisplayAlert("ERRO", "Verefique as informações", "OK");
                btn_Cadastrar.IsEnabled = true;
            }  
         }
        public void limpaCampos()
        {
            txt_ALTURA.Text = "";
            txt_EMAIL.Text = "";
            txt_IDADE.Text = "";
            txt_NOME.Text = "";
            txt_OBJETIVO.Text = "";
            txt_PESO.Text = "";
            txt_SENHA.Text = "";
            txt_SITUACAO.Text = "";
            btn_Cadastrar.IsEnabled = true;

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