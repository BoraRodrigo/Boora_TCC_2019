using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.MODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Boora_TCC_2019.DAO;
using Boora_TCC_2019.TELAS;

namespace Boora_TCC_2019.TELAS_SERIE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista_Exercicios_Serie : ContentPage
    {
        //comentario
        int IdSerie;
        string NomeSerie;
        List<Exercicio> Exerciciolista = new List<Exercicio>();
        public Lista_Exercicios_Serie(List<Exercicio> lista, int id)
        {
            InitializeComponent();
            IdSerie = id;
            Exerciciolista = lista;
            BuscaNome();
            Titulo_Serie.Text = NomeSerie;
            ListaExerciciosSerie.ItemsSource = Exerciciolista;

        }
        private async void BuscaNome()
        {
            AlunoDAO alunoDAO = new AlunoDAO();
            
            var seriealuno = await alunoDAO.Busca_Serie_Aluno(IdSerie);

            NomeSerie = seriealuno.Nome_Serie;

        }

        private async void ListaExerciciosSerie_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Exercicio exercicio = (Exercicio)e.SelectedItem;

            Exerciciolista[Exerciciolista.IndexOf(exercicio)].Imagem_Gif = "Check.png";

            await Navigation.PushAsync(new TELAS_SERIE.Lista_Exercicios_Serie(Exerciciolista, IdSerie));

            await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new TELAS_SERIE.Execucao_Serie(exercicio, IdSerie));

        }
        private async void finalizarSerie(object sender, EventArgs e)
        {
            Login login = new Login();
            //passar aqui o nome da serie que vai salvar e o id do aluno tó fazendo isso de modo direto pra ganhar tempo
            Controle_Dia controle_Dia = new Controle_Dia();
            Controle_Dia_DAO controle_Dia_DAO= new Controle_Dia_DAO();
            controle_Dia.Id_Aluno =Login.Id_Aluno_Login ;//passar o id do aluno que fez a serie
            controle_Dia.Nome_serie = NomeSerie;
            controle_Dia.Hora_Serie = DateTime.Now.Hour.ToString();
            controle_Dia.Data_Presenca =DateTime.Now.ToString("dd/MM/yyyy");
            await  controle_Dia_DAO.Cadastrar_Dia(controle_Dia);
        }
    }
}