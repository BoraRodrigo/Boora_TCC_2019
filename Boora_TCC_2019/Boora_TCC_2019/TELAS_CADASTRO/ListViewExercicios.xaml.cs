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
            SlCarregandoLista.IsVisible = true;
            listaInterna = await exercicioDAO.Busca_Exercicio();

            for (int i = 0; i < listaInterna.Count; i++)
            {
                string path = await exercicioDAO.Buscar_IMAGEM(listaInterna[i].Imagem_Gif);
                
                listaInterna[i].Imagem_Gif = path;
               
            }
           
            ListaExercicios.ItemsSource = listaInterna;

            SlCarregandoLista.IsVisible = false;
          
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
       
    }
}