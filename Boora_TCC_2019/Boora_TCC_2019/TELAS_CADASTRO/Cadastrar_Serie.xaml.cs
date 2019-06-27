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
        string dataFim;
        SerieDAO serieDAO = new SerieDAO();
        Exercicios_Serie_DAO exercicios_Serie_DAO = new Exercicios_Serie_DAO();
        Aluno aluno;
        //GAMBIARA AQUI PRA ID DA SERIE A SER CADASTRADA VAI TER. PROBLME AQUI SE FOR CADASTRAR EXERCICIO SEPADO NA SERIE AI TEM QUE COLOCAR O VALOR DO ID 
        public static int Id_serie_Cadastrar_Exercicio;
        public Cadastrar_Serie(Aluno a)
        {
           
            InitializeComponent();
            aluno = a;
            Lbl_data_Inicial.Text =  DateTime.Now.ToString("dd/MM/yyyy");
            Txt_Id_Do_Aluno.Text = (aluno.Id_Aluno.ToString());
            Txt_nome_Serie.Text = aluno.Nome;
        }

        private void DataSelecionada(object sender, DateChangedEventArgs args)
        {
            dataFim = args.NewDate.ToString("dd/MM/yyyy");
        }

        private async void Btn_Cadastrar_Serie(object sender, EventArgs e)
        {
            List<Serie> listaSerie = await serieDAO.Busca_Serie();
            listaSerie = await serieDAO.Busca_Serie();
            //ADD VALOR DE ID
            Id_serie_Cadastrar_Exercicio = listaSerie.Count() + 1;
            Serie serie = new Serie();
            serie.Id_Serie = listaSerie.Count()+1;
            serie.Id_Aluno = Convert.ToInt32(Txt_Id_Do_Aluno.Text);
            serie.Nome_Serie = Txt_nome_Serie.Text;
            serie.Descricao_Serie = Txt_Descricao_Serie.Text;
            serie.Tempo_Execucao = txt_tempo_execucao.Text;
            serie.Data_Inicio = DateTime.Now.ToString("dd/MM/yyyy");
            if (dataFim != null)
            {
                serie.Data_Fim = dataFim;
                //await serieDAO.Cadastrar_Serie(serie);
                await Navigation.PushAsync(new TELAS_CADASTRO.Cadastrar_Exercicio_Serie(aluno, serie));
            }
            else
            {
                int i = 5;
                bool aux = true;
                dataFinalIsVisible.IsVisible = true;
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {

                    i--;
                    if (i < 0)
                    {
                        dataFinalIsVisible.IsVisible = false;
                        aux = false;
                    }
                    return aux;
                });
                
            }
           
            

               
        }
        //private async void Btn_Cadastrar_Exercicios_Serie(object sender, EventArgs e)
        //{
        //    Exercicios_Serie exercicios_Serie = new Exercicios_Serie();

        //    exercicios_Serie.Id_Exercicios_Serie = Convert.ToInt32(Txt_Id_Exercicios_Serie.Text);
        //    //PASSA O ID DA SERIE PARA CADASTRO DO EXERCICIO
        //    exercicios_Serie.Id_Serie = Id_serie_Cadastrar_Exercicio;
        //    exercicios_Serie.Qtd_repeticoes = Convert.ToInt32(Txt_Quantidade_repeticoes.Text);
        //    exercicios_Serie.Qtd_Vezes = Convert.ToInt32(Txt_Quantidade_Vezes.Text);
        //    exercicios_Serie.Tempo_Minimo = txt_tempo_minimo.Text;
        //    exercicios_Serie.Tempo_Maximo = txt_Tempo_Maximo.Text;
        //    exercicios_Serie.Tempo_Execucao = txt_tempo_execucao.Text;
        //    await exercicios_Serie_DAO.Cadastrar_Exercicios_Serie(exercicios_Serie);

        //    limpaCampos();
        //}
        //public void limpaCampos()
        //{
        //    Txt_Id_Exercicios_Serie.Text = "";
        //    Txt_Quantidade_repeticoes.Text="";
        //    Txt_Quantidade_Vezes.Text = "";
        //    txt_tempo_minimo.Text = "";
        //    txt_Tempo_Maximo.Text = "";
        //    txt_tempo_execucao.Text = "";
        //    Txt_Quantidade_repeticoes.Text = "";

        //}
    }
}