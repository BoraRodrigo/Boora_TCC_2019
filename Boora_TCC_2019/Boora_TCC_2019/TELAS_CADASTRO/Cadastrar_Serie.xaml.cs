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
            try
            {
            List<Serie> listaSerie = await serieDAO.Busca_Serie();
            listaSerie = await serieDAO.Busca_Serie();
            Serie serie = new Serie();
           
            serie.Id_Aluno = Txt_Id_Do_Aluno.Text;
            serie.Nome_Serie = Txt_nome_Serie.Text;
            serie.Descricao_Serie = Txt_Descricao_Serie.Text;
            serie.Tempo_Execucao = txt_tempo_execucao.Text;
            serie.Data_Inicio = DateTime.Now.ToString("dd/MM/yyyy");
            serie.Id_Serie = SerieDAO.id_serieKEY;
            if (dataFim != null)
            {
                serie.Data_Fim = dataFim;
                await serieDAO.Cadastrar_Serie(serie);
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
            catch
            {

            }
        }
    }
}