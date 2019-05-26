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

   
    public partial class Cadastrar_Aluno : ContentPage
    {
        AlunoDAO alunoDAO = new AlunoDAO();
        public Cadastrar_Aluno()
        {
            InitializeComponent();
        }

        private async void  Cadastrar_AlunoAsy(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Nome = txt_NOME.Text;
            aluno.Email = txt_EMAIL.Text;
            aluno.Senha = txt_SENHA.Text;
            aluno.Peso = Convert.ToDouble(txt_PESO.Text);
            aluno.Altura = Convert.ToDouble(txt_ALTURA.Text);
            aluno.Idade = Convert.ToInt32(txt_IDADE.Text);
            aluno.objetivo_Aluno = txt_OBJETIVO.Text;
            aluno.Situacao = 1;

          await  alunoDAO.Cadastrar_Aluno(aluno);
        }

       
    }
}