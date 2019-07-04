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
using System.Collections.ObjectModel;

namespace Boora_TCC_2019.TELAS_SERIE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista_Exercicios_Serie : ContentPage
    {
        //comentario
        string IdSerie;
        string NomeSerie;
        List<Exercicio> Exerciciolista = new List<Exercicio>();
        public Lista_Exercicios_Serie(List<Exercicio> lista, string id)
        {
            InitializeComponent();
            IdSerie = id;
            Exerciciolista = lista;
            
            BuscaNome();
           
            ListaExerciciosSerie.ItemsSource = Exerciciolista;
            

        }
        private async void BuscaNome()
        {
            AlunoDAO alunoDAO = new AlunoDAO();
            
            var seriealuno = await alunoDAO.Busca_Serie_Aluno(IdSerie);

            NomeSerie = seriealuno.Nome_Serie;

            Titulo_Serie.Text = NomeSerie;

            Confere_Dia();

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
            Controle_Dia controle_Dia = new Controle_Dia();
            Controle_Dia_DAO controle_Dia_DAO = new Controle_Dia_DAO();
            List<Controle_Dia> lista_controle_dia = new List<Controle_Dia>();

            lista_controle_dia = await controle_Dia_DAO.Busca_Todas__Dias_Do_Aluno(Login.Id_Aluno_Login);

            bool Verefica_Dia = false;
            for (int i = 0; i < lista_controle_dia.Count; i++)
            {
                try
                {
                    if (lista_controle_dia[i].Data_Presenca.Equals(DateTime.Now.ToString("dd/MM/yyyy")) && lista_controle_dia[i].Nome_serie.Equals(NomeSerie))
                    {

                        LblAvisoSerieRealizado.Text = ("Já realizou esta série hoje - " + (DateTime.Now.ToString("dd/MM/yyyy")));
                        LblAvisoSerieRealizado.BackgroundColor = Color.Black;
                        LblAvisoSerieRealizado.IsVisible = true;

                        Verefica_Dia = true;
                    }
                }
                catch { }
            }

          
            if (Verefica_Dia==false)
            {

                controle_Dia.Id_Aluno = Login.Id_Aluno_Login;//passar o id do aluno que fez a serie
                controle_Dia.Nome_serie = NomeSerie;
                controle_Dia.Hora_Serie = DateTime.Now.Hour.ToString();
                controle_Dia.Data_Presenca = DateTime.Now.ToString("dd/MM/yyyy");
                await controle_Dia_DAO.Cadastrar_Dia(controle_Dia);

            }  //passar aqui o nome da serie que vai salvar e o id do aluno tó fazendo isso de modo direto pra ganhar tempo
        }

        private async void Confere_Dia()
        {
            Controle_Dia_DAO controle_Dia_DAO = new Controle_Dia_DAO();
            List<Controle_Dia> lista_controle_dia = new List<Controle_Dia>();
            lista_controle_dia = await controle_Dia_DAO.Busca_Todas__Dias_Do_Aluno(Login.Id_Aluno_Login);
            for (int i = 0; i < lista_controle_dia.Count; i++)
            {
                try
                {
                    if (lista_controle_dia[i].Data_Presenca.Equals(DateTime.Now.ToString("dd/MM/yyyy")) && lista_controle_dia[i].Nome_serie.Equals(NomeSerie))
                    {

                        LblAvisoSerieRealizado.Text = ("Série ja realizada hoje - " + (DateTime.Now.ToString("dd/MM/yyyy")));
                        LblAvisoSerieRealizado.BackgroundColor = Color.Red;
                        LblAvisoSerieRealizado.IsVisible = true;


                    }
                }
                catch 
                {

                }
                
            }
        }
    }
}