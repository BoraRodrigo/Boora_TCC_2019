using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.DAO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Boora_TCC_2019.TELAS_CADASTRO
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastrar_Exercicio_Serie : ContentPage
	{
        Aluno aluno;
        Serie serie;
        Exercicio exercicio;
        ExercicioDAO exercicioDAO = new ExercicioDAO();
        private List<Exercicio> listaPesquisa { get; set; }
        private List<Exercicio> listaInterna { get; set; }
        ObservableCollection<Exercicio> listaExerciciosSerie = new ObservableCollection<Exercicio>();
        private List<Exercicio> listaAuxiliar { get; set; }
        public Cadastrar_Exercicio_Serie (Aluno a, Serie s)
		{
			InitializeComponent ();
            
            aluno = a;
            serie = s;
		}

        private async void Btn_Cadastrar_Exercicios_Serie(object sender, EventArgs e)
        {
            try
            {
                Exercicios_Serie_DAO exercicios_Serie_DAO = new Exercicios_Serie_DAO();
                Exercicios_Serie exercicios_Serie = new Exercicios_Serie();

                exercicios_Serie.Id_Exercicios_Serie = Convert.ToInt32(Txt_Id_Exercicios_Serie.Text);
                //PASSA O ID DA SERIE PARA CADASTRO DO EXERCICIO
                exercicios_Serie.Id_Serie = serie.Id_Serie;
                exercicios_Serie.Qtd_repeticoes = Convert.ToInt32(Txt_Quantidade_repeticoes.Text);
                exercicios_Serie.Qtd_Vezes = Convert.ToInt32(Txt_Quantidade_Vezes.Text);
                exercicios_Serie.Peso = Convert.ToDouble(txt_Peso.Text);
                await exercicios_Serie_DAO.Cadastrar_Exercicios_Serie(exercicios_Serie);

                listaAuxiliar = listaInterna.Where(a => a.Id_exercicio == (exercicios_Serie.Id_Exercicios_Serie)).ToList();
                listaExerciciosSerie.Add(listaAuxiliar[0]);
                ListaExerciciosSeriesView.ItemsSource = listaExerciciosSerie;
                ListaExerciciosSeriesView.IsRefreshing = true;



                limpaCampos();
            }
            catch 
            {

            await    DisplayAlert("BOORA","Verefique os campos","OK");
            }
            
        }
       
        public void limpaCampos()
        {
            Txt_Id_Exercicios_Serie.Text = "";
            Txt_Quantidade_repeticoes.Text = "";
            Txt_Quantidade_Vezes.Text = "";
            Txt_Quantidade_repeticoes.Text = "";
            Txt_nome_Exercicio.Text = "";
            txt_Peso.Text = "";

            
            

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
           
            listaInterna = await exercicioDAO.Busca_Exercicio();
            
            for (int i = 0; i < listaInterna.Count; i++)
            {
                string path = await exercicioDAO.Buscar_IMAGEM(listaInterna[i].Imagem_Gif);

                listaInterna[i].Imagem_Gif = path;

            }

            ListaExercicios.ItemsSource = listaInterna;
            
                
            
            


        }

        private async void BuscaRapida(Object sender, TextChangedEventArgs args)
        {
            listaInterna = await exercicioDAO.Busca_Exercicio();
            try
            {
                listaPesquisa = listaInterna.Where(a => a.Nome.Contains(args.NewTextValue)).ToList();

                for (int i = 0; i < listaInterna.Count; i++)
                {
                    string path = await exercicioDAO.Buscar_IMAGEM(listaInterna[i].Imagem_Gif);
                    listaInterna[i].Imagem_Gif = path;

                }

                ListaExercicios.ItemsSource = listaPesquisa;

            }
            catch
            {

            }

        }

        private void SelecaoExercicioAction(object sender, SelectedItemChangedEventArgs args)
        {
            exercicio = (Exercicio)args.SelectedItem;
            Txt_nome_Exercicio.Text = exercicio.Nome;
            Txt_Id_Exercicios_Serie.Text = exercicio.Id_exercicio.ToString();
        }
    }
}