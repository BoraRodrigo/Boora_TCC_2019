using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.MODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detalhes_Alunos : ContentPage
	{
        Aluno alunoREF;
		public Detalhes_Alunos (Aluno aluno)
		{
                      
			InitializeComponent();

            alunoREF = aluno;

            lbl_Nome.Text = aluno.Nome;
            lbl_Idade.Text = aluno.Idade;
            lbl_Peso.Text = aluno.Peso.ToString();
            lbl_Altura.Text = aluno.Altura.ToString();
            lbl_Email.Text = aluno.Email;
            lbl_Objetivo.Text = aluno.objetivo_Aluno;
            if(aluno.Situacao == 1)
            {
                lbl_Situacao.TextColor = Color.Green;
                lbl_Situacao.Text = "Ativo";
            }
            else
            {
                lbl_Situacao.TextColor = Color.Red;
                lbl_Situacao.Text = "Parado";
            }

            
        }

        private void Cadastrar_SerieAsy(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TELAS.Lista_Frequencia_Aluno(alunoREF));
        }
    }
}