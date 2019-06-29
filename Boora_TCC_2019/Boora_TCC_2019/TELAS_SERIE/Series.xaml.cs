using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MENU;
using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.TELAS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS_SERIE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Serie : ContentPage
    { //comentario
        List<Serie> lista_Serie = new List<Serie>();
        Exercicios_Serie_DAO exercicios_Serie_DAO = new Exercicios_Serie_DAO();
        AlunoDAO alunoDAO = new AlunoDAO();
        SerieDAO serieDAO = new SerieDAO();
        ExercicioDAO exercicioDAO = new ExercicioDAO();
        List<Exercicios_Serie> listaExercicio = new List<Exercicios_Serie>();
        List<Exercicio> lista = new List<Exercicio>();


        public static int idSerie = 0;//não consigo usar o static 

        //variavel para controlar o exercicio exibibo na serie
        int serie_da_lista = 0;
        public Serie()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            SlCarregandoLogin.IsVisible = true;
            await Dados_Da_serie();
            SlCarregandoLogin.IsVisible = false;
        }
        private async void Proxima_SerieAsync(object sender, EventArgs e)
        {
          
            serie_da_lista = serie_da_lista + 1;
            try
            {
                SlCarregandoLogin.IsVisible = true;
               
                await Dados_Da_serie();

                SlCarregandoLogin.IsVisible = false;
                
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
                SlCarregandoLogin.IsVisible = true;
                
                await Dados_Da_serie();

                SlCarregandoLogin.IsVisible = false;
            }
            catch
            {
            }
        }
        private async void IniciarSerie(object sender, EventArgs args)
        {
          
            listaExercicio.Clear();//limpar a lista antes de carregar outra senão duplica
            lista.Clear();
            listaExercicio = await exercicios_Serie_DAO.Busca_Exercicios_Serie_DA_SERIE(idSerie);

            for (int i = 0; i < listaExercicio.Count; i++)
            {
                Exercicio exercicio = await exercicioDAO.Busca_Exercicio_ID(listaExercicio[i].Id_Exercicios_Serie);
                exercicio.Exercicios_Serie = listaExercicio[i];
                exercicio.Imagem_Gif = "fail.png";
                lista.Add(exercicio);

            }

            //ListaExerciciosSerie.ItemsSource = lista;

            await Navigation.PushAsync(new TELAS_SERIE.Lista_Exercicios_Serie(lista, idSerie));

        }

        public async Task Dados_Da_serie()
        {
          
            lbl_DATAVENC.Text= DateTime.Now.ToString("dd/MM/yyyy");
            Login login = new Login();
            var alunoLogado = await alunoDAO.Login_Aluno(Login.Nome_Aluno_Logado, Login.Senha_Aluno_Logado);
            
            //tras todas as series que o aluno tem 
            var lista_Serie = await exercicios_Serie_DAO.Busca_Todas__Series_Aluno(Login.Id_Aluno_Login);
            lbl_DATA.Text = lista_Serie[0].Data_Inicio;
            lbl_DATAVENC.Text = lista_Serie[0].Data_Fim;
            if (serie_da_lista <= 0)
            {
                int i = 8;
                bool aux = true;
                VerificarLimite.IsVisible = true;
                VerificarLimite.Text = "Está é sua primeira";
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {

                    i--;
                    if (i < 0)
                    {
                        VerificarLimite.IsVisible = false;
                        aux = false;
                    }
                    return aux;
                });
                serie_da_lista = 0;


            }
            if (serie_da_lista > lista_Serie.Count - 1)
            {
                int i = 8;
                bool aux = true;
                VerificarLimite.IsVisible = true;
                VerificarLimite.Text = "Está é sua ultima";
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {

                    i--;
                    if (i < 0)
                    {
                        VerificarLimite.IsVisible = false;
                        aux = false;
                    }
                    return aux;
                });

                serie_da_lista = (lista_Serie.Count - 1);

            }
            if (serie_da_lista <= lista_Serie.Count - 1 && serie_da_lista >= 0)
            {
                lblQuantidade_De_Series.Text = "Série " + (serie_da_lista + 1).ToString() + " de " + lista_Serie.Count().ToString();
                var serieEXibida = await serieDAO.Busca_Serie_ID(lista_Serie[serie_da_lista].Id_Serie);

                txt_Nome_Serie.Text = serieEXibida.Nome_Serie;
                idSerie = serieEXibida.Id_Serie;
                lbl_DATA.Text = serieEXibida.Data_Inicio;
                lbl_DATAVENC.Text = serieEXibida.Data_Fim;

                txt_Descricao_Serie.Text = serieEXibida.Descricao_Serie;
                
            }
        }

       


    }
}