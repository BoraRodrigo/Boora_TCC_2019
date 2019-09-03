using Boora_TCC_2019.DAO;
using Boora_TCC_2019.TELAS;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ScheduleSimpleSample;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        MediaFile file;
        AcademiaDAO academiaDAO = new AcademiaDAO();
        AlunoDAO alunoDAO = new AlunoDAO();


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
                btn_cadastrarAviso.IsVisible = false;
            }
            else if (Login.Tipo_login.Equals("Dono_Academia"))
            {
                btn_minhas_Series.IsVisible = false;
                btn_meu_calendario.IsVisible = false;
                btn_Alterar_dados_Aluno.IsVisible = false;
                btn_cadastro_instrutor.IsVisible = false;//deixa de fora de momento
                lblNomeUsuario.Text = Login.Nome_Academia_login;
                btn_Alterar.IsVisible = false;//não fiz o alter pra imagem da academia.
            }
        }
        protected async override void OnAppearing()
        {
            try
            {
                if (Login.Tipo_login.Equals("Dono_Academia"))
                {
                    foto_Perfil.Source = await academiaDAO.Buscar_IMAGEM_Logo_Academia(Login.Id_Academia_Login);
                }
                else if (Login.Tipo_login.Equals("Aluno"))
                {
                    foto_Perfil.Source = await alunoDAO.Buscar_IMAGEM_Perfil_Aluno(Login.Id_Aluno_Login);

                }
            }
            catch
            {
            }
        }
        // aqui vc instancia novo navigationPage com a tela que vc quer cadastrar. cada metodo para um botao.
        private void GoCadastroAluno(object sender, EventArgs args)
        {
            this.Detail = new NavigationPage(new TELAS.Cadastrar_Aluno());
            IsPresented = false;
        }
        private void GoCadastroExercicio(object sender, EventArgs args)
        {
            this.Detail = new NavigationPage(new TELAS.Cadastrar_Exercicio());
            IsPresented = false;
        }
        private void GoCadastroInstrutor(object sender, EventArgs args)
        {
            this.Detail = new NavigationPage(new TELAS.Cadastrar_Instrutor());
            IsPresented = false;
        }

        internal void GoExecucaoTela()
        {
            throw new NotImplementedException();
        }

        private void GoPersonalizacao(object sender, EventArgs args)
        {
            this.Detail = new NavigationPage(new TELAS.Personalizacao());
            IsPresented = false;
        }
        private void GoListExercicios(object sender, EventArgs args)
        {
            this.Detail = new NavigationPage(new TELAS_CADASTRO.ListViewExercicios());
            IsPresented = false;
        }

        private void GoInicial(object sender, EventArgs args)
        {
            this.Detail = new NavigationPage(new Inicial());
            IsPresented = false;
        }

        private void GoEMinhasSeries(object sender, EventArgs args)
        {
            this.Detail = new NavigationPage(new TELAS_SERIE.Serie());
            IsPresented = false;
        }

        private void GoEMeuClendario(object sender, EventArgs args)
        {

            this.Detail = new NavigationPage(new ScheduleSimpleSamplePage());
            IsPresented = false;
        }
        private void GoSAIR(object sender, EventArgs args)
        {
            //Alterado pq ficava liberado o menu apos deslogar, assim nao tem menu
            App.Current.MainPage = new Login();
        }

        private void Send(object sender, EventArgs e)
        {
            this.Detail = new NavigationPage(new TELAS.TelaSobre());
            IsPresented = false;

        }
        private void alterarDados(object sender, EventArgs e)
        {
            this.Detail = new NavigationPage(new Telas_Alterar.Alterar_Dados_Aluno());
            IsPresented = false;

        }
        private void GoListaAlunos(object sender, EventArgs e)
        {
            this.Detail = new NavigationPage(new TELAS.ListAlunosView());
            IsPresented = false;

        }
        private void Cadastrar_Aviso(object sender, EventArgs e)
        {
            this.Detail = new NavigationPage(new TELAS_CADASTRO.Cadastrar_Novo_Aviso());
            IsPresented = false;
        }
        private async void Btn_Alterar_Imagem(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                    // PhotoSize = PhotoSize.Custom,
                    // CustomPhotoSize = 40
                });
                if (file == null)
                    return;
                foto_Perfil.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;                  
                });
              await  alunoDAO.Alterar_Foto_Perfil(Login.Id_Aluno_Login, file.GetStream());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}