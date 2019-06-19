using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.MODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS_SERIE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Lista_Exercicios_Serie : ContentPage
	{

        //comentario
        int IdSerie;
        
        List<Exercicio> Exerciciolista = new List<Exercicio>();
        public Lista_Exercicios_Serie(List<Exercicio> lista, int id)
        {
            InitializeComponent();
            IdSerie = id;
            Exerciciolista = lista;
            
            ListaExerciciosSerie.ItemsSource = Exerciciolista;
            
        }

         private async void ListaExerciciosSerie_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Exercicio exercicio = (Exercicio)e.SelectedItem;
            
            Exerciciolista[Exerciciolista.IndexOf(exercicio)].Imagem_Gif = "Check.png";
            
            await Navigation.PushAsync(new TELAS_SERIE.Lista_Exercicios_Serie(Exerciciolista, IdSerie));

           await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new TELAS_SERIE.Execucao_Serie(exercicio));

        }

        
	}
}