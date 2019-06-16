using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.MENU
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
        }
        // aqui vc instancia novo navigationPage com a tela que vc quer cadastrar. cada metodo para um botao.
        private void GoCadastroAluno(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TELAS.Cadastrar_Aluno());
            IsPresented = false;
        }
        private void GoCadastroExercicio(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TELAS.Cadastrar_Exercicio());
            IsPresented = false;
        }
        private void GoCadastroInstrutor(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TELAS.Cadastrar_Instrutor());
            IsPresented = false;
        }

        internal void GoExecucaoTela()
        {
            throw new NotImplementedException();
        }

        private void GoCadastroSerie(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TELAS.Cadastrar_Serie());
            IsPresented = false;
        }
        private void GoListExercicios(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TELAS_CADASTRO.ListViewExercicios());
            IsPresented = false;
        }
        
        
        private void GoExecucaoTela_(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TELAS_SERIE.Execucao_Serie());
            IsPresented = false;
        }

        private void GoEMinhasSeries(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TELAS_SERIE.Serie());
            IsPresented = false;
        }

        

        private void abrirfacebook(object sender, EventArgs args)
        {

            Device.OpenUri(new Uri("https://www.facebook.com/angelosfitness/"));
        }
        private async void Send(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new TELAS.TelaSobre());
            IsPresented = false;

        }
    }
}