using Boora_TCC_2019.TELAS;
using ScheduleSimpleSample;
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
          //tirar depois
            if (Login.Tipo_login.Equals("Aluno"))
            {
                btn_cadastro_aluno.IsVisible=false;
                btn_cadastro_exercicio.IsVisible = false;
                btn_cadastro_instrutor.IsVisible = false;
                btn_lista_alunos.IsVisible = false;
                lblNomeUsuario.Text = Login.Nome_Aluno_Logado;
            }
            else if (Login.Tipo_login.Equals("Dono_Academia"))
            {
                btn_minhas_Series.IsVisible = false;
                btn_meu_calendario.IsVisible = false;
                lblNomeUsuario.Text = Login.Nome_Academia_login;
            }
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

        private void GoPersonalizacao(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TELAS.Personalizacao());
            IsPresented = false;
        }
        private void GoListExercicios(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TELAS_CADASTRO.ListViewExercicios());
            IsPresented = false;
        }

        private void GoInicial(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Inicial());
            IsPresented = false;
        }

        private void GoEMinhasSeries(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TELAS_SERIE.Serie());
            IsPresented = false;
        }

        private void GoEMeuClendario(object sender, EventArgs args)
        {

            Detail = new NavigationPage(new ScheduleSimpleSamplePage());
            IsPresented = false;
        }
        private void GoSAIR(object sender, EventArgs args)
        {
            //Alterado pq ficava liberado o menu apos deslogar, assim nao tem menu
            Navigation.PushAsync(new TELAS.Login());
           

        }

        //private void abrirfacebook(object sender, EventArgs args)
        //{

        //    Device.OpenUri(new Uri("https://www.facebook.com/angelosfitness/"));
        //}

        private void Send(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new TELAS.TelaSobre());
            IsPresented = false;

        }
        private void alterarDados(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Telas_Alterar.Alterar_Dados_Aluno());
            IsPresented = false;

        }
        

        private void GoListaAlunos(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new TELAS.ListAlunosView());
            IsPresented = false;

        }
    }
}