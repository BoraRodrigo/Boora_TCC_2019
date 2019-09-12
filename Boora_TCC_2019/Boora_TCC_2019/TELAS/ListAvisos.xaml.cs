using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListAvisos : ContentPage
    {
        Avisos_Academia_DAO avisos_ = new Avisos_Academia_DAO();
        private List<Avisos_Academia> lista_avisos { get; set; }

        public ListAvisos()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            SlCarregandoAvisos.IsVisible = true;
            lista_avisos = await avisos_.Lista_Avisos();

            for (int i = 0; i < lista_avisos.Count; i++)
            {
                string path = await avisos_.Buscar_IMAGEM_AVISOS(lista_avisos[i].Imagem_Avisos);

                lista_avisos[i].Imagem_Avisos = path;

            }

            ListaAvisos.ItemsSource = lista_avisos;

            SlCarregandoAvisos.IsVisible = false;


        }

    }
}