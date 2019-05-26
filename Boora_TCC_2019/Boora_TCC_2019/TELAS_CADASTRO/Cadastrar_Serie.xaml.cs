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
    public partial class Cadastrar_Serie : ContentPage
    {
        SerieDAO serieDAO = new SerieDAO();
        Exercicios_Serie_DAO exercicios_Serie_DAO = new Exercicios_Serie_DAO();
        public Cadastrar_Serie()
        {
            InitializeComponent();
        }

        private async void Btn_Cadastrar_Serie(object sender, EventArgs e)
        {
            Serie serie = new Serie();
            serie.Id_Serie = Convert.ToInt32(Txt_Id_Da_Serie.Text);
            serie.Id_Aluno = Convert.ToInt32(Txt_Id_Do_Aluno.Text);
            serie.Nome_Serie = Txt_nome_Serie.Text;
            serie.Descricao_Serie = Txt_Descricao_Serie.Text;
            serie.Data_Inicio = Txt_Data_Inicio.Text;
            serie.Data_Fim = Txt_Data_Fim.Text;
            
            await serieDAO.Cadastrar_Serie(serie);
        }
        private async void Btn_Cadastrar_Exercicios_Serie(object sender, EventArgs e)
        {
            Exercicios_Serie exercicios_Serie = new Exercicios_Serie();

            exercicios_Serie.Id_Exercicios_Serie = Convert.ToInt32(Txt_Id_Da_Serie_Cadastro_Exercicio.Text);
            exercicios_Serie.Id_Serie = Convert.ToInt32(Txt_Id_Da_Serie.Text);
            exercicios_Serie.Qtd_repeticoes = Convert.ToInt32(Txt_Quantidade_repeticoes.Text);
            exercicios_Serie.Qtd_Vezes = Convert.ToInt32(Txt_Quantidade_Vezes.Text);
            exercicios_Serie.Tempo_Minimo = txt_tempo_minimo.Text;
            exercicios_Serie.Tempo_Maximo = txt_Tempo_Maximo.Text;
            exercicios_Serie.Tempo_Execucao = txt_tempo_execucao.Text;
            await exercicios_Serie_DAO.Cadastrar_Exercicios_Serie(exercicios_Serie);

            limpaCampos();
        }
        public void limpaCampos()
        {
            Txt_Id_Exercicios_Serie.Text = "";
            Txt_Id_Da_Serie_Cadastro_Exercicio.Text = "";
            Txt_Quantidade_repeticoes.Text="";
            Txt_Quantidade_Vezes.Text = "";
            txt_tempo_minimo.Text = "";
            txt_Tempo_Maximo.Text = "";
            txt_tempo_execucao.Text = "";
            Txt_Quantidade_repeticoes.Text = "";

        }
    }
}