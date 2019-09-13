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
    public partial class ListAlunosView : ContentPage
    {
        AlunoDAO alunoDAO = new AlunoDAO();
        private List<Aluno> listaPesquisa { get; set; }
        private List<Aluno> listaInterna { get; set; }

        public ListAlunosView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            SlCarregandoLista.IsVisible = true;
            listaInterna = await alunoDAO.Busca_Aluno();

            ListaAlunos.ItemsSource = listaInterna;

            for (int i = 0; i < listaInterna.Count; i++)
            {
                listaInterna[i].objetivo_Aluno = "user.png";
            }


            ListaAlunos.ItemsSource = listaInterna;


            SlCarregandoLista.IsVisible = false;

          

        }

        private async void BuscaRapida(Object sender, TextChangedEventArgs args)
        {
            listaInterna = await alunoDAO.Busca_Aluno();
            
                listaPesquisa = listaInterna.Where(a => a.Nome.Contains(args.NewTextValue)).ToList();
            for (int i = 0; i < listaPesquisa.Count; i++)
            {
                listaPesquisa[i].objetivo_Aluno = "user.png";
            }

            ListaAlunos.ItemsSource = listaPesquisa;

        }

        private void SelecaoAlunoAction(object sender, SelectedItemChangedEventArgs args)
        {
            Aluno aluno = (Aluno)args.SelectedItem;

            // Navigation.PushAsync(new TELAS.Cadastrar_Serie(aluno));
            Navigation.PushAsync(new TELAS.Lista_Frequencia_Aluno(aluno));
        }
    }
}