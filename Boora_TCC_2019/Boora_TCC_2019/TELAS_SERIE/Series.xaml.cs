using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MENU;
using Boora_TCC_2019.MODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS_SERIE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Serie : ContentPage
    {
        List<Serie> lista_Serie = new List<Serie>();
        Exercicios_Serie_DAO exercicios_Serie_DAO = new Exercicios_Serie_DAO();
        AlunoDAO alunoDAO = new AlunoDAO();
        SerieDAO serieDAO = new SerieDAO();


        public static int idSerie = 0;//não consigo usar o static 

        //variavel para controlar o exercicio exibibo na serie
        int serie_da_lista = 0;
        public Serie()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            await Dados_Da_serie();
        }
        private async void Proxima_SerieAsync(object sender, EventArgs e)
        {
            serie_da_lista = serie_da_lista + 1;
            try
            {
                await Dados_Da_serie();
            }
            catch
            {
            }
        }
        private async void Anterior_SerieAsync(object sender, EventArgs e)
        {
            serie_da_lista = serie_da_lista - 1;
            try
            {
                await Dados_Da_serie();
            }
            catch
            {
            }
        }
        private void IniciarSerie(object sender, EventArgs args)
        {
        

            //não sei como colocar dentro do menu.
            App.Current.MainPage = new NavigationPage(new TELAS_SERIE.Execucao_Serie());
        }

        public async Task Dados_Da_serie()
        {
            //mudei aquiii
            var alunoLogado = await alunoDAO.Login_Aluno("Rodrigo", "1");
            //tras todas as series que o aluno tem 
            var lista_Serie = await exercicios_Serie_DAO.Busca_Todas__Series_Aluno(alunoLogado.Id_Aluno);
            if (serie_da_lista <= 0)
            {
                serie_da_lista = 0;
                await DisplayAlert("BOORA", "Está é sua Primeira Serie Parça", "OK");
            }
            if (serie_da_lista > lista_Serie.Count - 1)
            {
                serie_da_lista = lista_Serie.Count() - 1;
                await DisplayAlert("BOORA", "Está é sua Ultima Serie parça", "OK");
            }
            if (serie_da_lista <= lista_Serie.Count - 1)
            {
                lblQuantidade_De_Series.Text = "Serie " + (serie_da_lista + 1).ToString() + " de " + lista_Serie.Count().ToString();
                var serieEXibida = await serieDAO.Busca_Serie_ID(lista_Serie[serie_da_lista].Id_Serie);

                txt_Nome_Serie.Text = serieEXibida.Nome_Serie.ToString();
                //salva id da serie exibida em uma varialvel static 
                idSerie = serieEXibida.Id_Serie;

                txt_Descricao_Serie.Text = serieEXibida.Descricao_Serie.ToString();

            }
        }

    }
}