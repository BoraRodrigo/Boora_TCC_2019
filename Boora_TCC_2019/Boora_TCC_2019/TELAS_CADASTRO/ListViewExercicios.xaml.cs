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
		public ListViewExercicios ()
		{
			InitializeComponent ();

            ExercicioDAO exercicio = new ExercicioDAO();
            List<Exercicio> lista = exercicio.Busca_Exercicio().Result;


            ListaExercicios.ItemsSource = lista;
            
		}
	}
}