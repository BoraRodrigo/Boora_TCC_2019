using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.MODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Boora_TCC_2019.DAO;

namespace Boora_TCC_2019.TELAS_CADASTRO
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewExercicios : ContentPage
	{
        ExercicioDAO exercicioDAO = new ExercicioDAO();
        private List<Exercicio> listaPesquisa { get; set; }
        private List<Exercicio> listaInterna { get; set; }
        public ListViewExercicios ()
		{
			InitializeComponent ();

            
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listaInterna = await exercicioDAO.Busca_Exercicio();
            ListaExercicios.ItemsSource = listaInterna;
        }

        private void BuscaRapida(Object sender, TextChangedEventArgs args)
        {
            listaPesquisa = listaInterna.Where(a => a.Nome.Contains(args.NewTextValue)).ToList();
            ListaExercicios.ItemsSource = listaPesquisa;
        }

    }
}