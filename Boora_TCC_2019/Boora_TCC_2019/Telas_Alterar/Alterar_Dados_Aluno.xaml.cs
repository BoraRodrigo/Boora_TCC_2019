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
	public partial class Alterar_Dados_Aluno : ContentPage
	{
        string datanascimento;
        public Alterar_Dados_Aluno ()
        {


            carregaDadosAsync();
            InitializeComponent();
          

        }

        private void DataSelecionada(object sender, DateChangedEventArgs args)
        {
            datanascimento = args.NewDate.ToString("dd/MM/yyyy");
        }
        private async void Btn_AlterarDados_ClickedAsync(object sender, EventArgs e)
        {
            try
           {
                AlunoDAO alunoDAO = new AlunoDAO();
                Aluno aluno = new Aluno();
                aluno.Nome = txt_NOME.Text;
                aluno.Email = txt_EMAIL.Text;
                aluno.Senha = txt_SENHA.Text;
                aluno.Peso = Convert.ToDouble(txt_PESO.Text);
                aluno.Altura = Convert.ToDouble(txt_ALTURA.Text);
                aluno.Idade = datanascimento;
                aluno.objetivo_Aluno = txt_OBJETIVO.Text;
                aluno.Foto_Aluno = Login.Id_Aluno_Login;
                aluno.Situacao = 1;
                
                await alunoDAO.AlterarALUNO(Login.Id_Aluno_Login, aluno);
                App.Current.MainPage = new MENU.Master();
                limpaCampos();

            }
            catch 
           {
                await DisplayAlert("ERRO", "Verefique as informações", "OK");
            }
        
        }
        public async Task carregaDadosAsync()
        {
            AlunoDAO alunoDAO = new AlunoDAO();
            var dadosAluno = await alunoDAO.Busca_Dados_Aluno_Para_carregar_Tela_Alterar(Login.Id_Aluno_Login);

            txt_SITUACAO.Text = dadosAluno.Situacao.ToString();
            txt_PESO.Text = dadosAluno.Peso.ToString();
            txt_OBJETIVO.Text = dadosAluno.objetivo_Aluno;
            txt_NOME.Text = dadosAluno.Nome;
            txt_EMAIL.Text = dadosAluno.Email.ToString();
            txt_SENHA.Text = dadosAluno.Senha;
            txt_ALTURA.Text = dadosAluno.Altura.ToString();
            datanascimento = dadosAluno.Idade;
            
        }
        public void limpaCampos()
        {
            txt_ALTURA.Text = "";
            txt_EMAIL.Text = "";

            txt_NOME.Text = "";
            txt_OBJETIVO.Text = "";
            txt_PESO.Text = "";
            txt_SENHA.Text = "";
            txt_SITUACAO.Text = "";
        

        }
    }
}