using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS_SERIE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class Execucao_Serie : ContentPage
	{
        private int _vezesTimer;
        AlunoDAO alunoDAO = new AlunoDAO();
        ExercicioDAO exercicioDAO = new ExercicioDAO();
        Exercicios_Serie_DAO exercicios_Serie_DAO = new Exercicios_Serie_DAO();
        List<Exercicios_Serie> listaExercicio = new List<Exercicios_Serie>();
        //comentario
        int exerciciodalista = 0;
        //mandando o id da serie por parametro no construtor
        static int  IdSerie;
        Exercicio exe;
        public Execucao_Serie (Exercicio exercicio)
		{
            InitializeComponent ();
            exe = exercicio;
			
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Exercicio_Pelo_List(exe);
        }

        private void Button_OnClicked (object sender, EventArgs e)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Entry.Text = tempo(++_vezesTimer);
               // Button.IsEnabled = false;
                return true;
            });
         
        }

        //private async void Proximo_Exercicio_Da_SerieAsync(object sender, EventArgs e)
        //{
        //    exerciciodalista = exerciciodalista + 1;
        //    try
        //    {
        //        await Dados_DO_Exercicio();
        //    }
        //    catch
        //    {
        //    }
        //}
        //private async void Anterior_Exercicio_Da_SerieAsync(object sender, EventArgs e)
        //{
        //    exerciciodalista = exerciciodalista - 1;
        //    try
        //    {
        //        await Dados_DO_Exercicio();
        //    }
        //    catch
        //    {
        //    }
        //}

        //public async Task Dados_DO_Exercicio()
        //{
        //    var alunoLogado = await alunoDAO.Login_Aluno("Rodrigo", "1");
        //    var seriealuno = await alunoDAO.Busca_Serie_Aluno(alunoLogado.Id_Aluno);

        //    listaExercicio = await exercicios_Serie_DAO.Busca_Exercicios_Serie_DA_SERIE(IdSerie);
        //  //  listaExercicio = await exercicios_Serie_DAO.Busca_Exercicios_Serie_DA_SERIE(3);
        //    if (exerciciodalista <= 0)
        //    {
        //        exerciciodalista = 0;
        //        await DisplayAlert("BOORA", "Este é seu Primeiro Exercicio Parça", "OK");
        //    }
        //    if (exerciciodalista > listaExercicio.Count - 1)
        //    {
        //        exerciciodalista = listaExercicio.Count() - 1;
        //        await DisplayAlert("BOORA", "Está é seu Ultimo Exercicio parça", "OK");
        //    }
        //    if (exerciciodalista <= listaExercicio.Count - 1)
        //    {         
        //        var todosexercicio = await alunoDAO.Busca_Exercicio_SERIE_ALUNO(alunoLogado.Id_Aluno);//acho que só retorna o primeiro da lista

        //        // var exercicio = await exercicioDAO.Busca_Exercicio_ID(todosexercicio.Id_Exercicios_Serie);
        //        var exercicio = await exercicioDAO.Busca_Exercicio_ID(listaExercicio[exerciciodalista].Id_Exercicios_Serie);
        //        //esta funcao retorna uma lista com todos o exercicio cadastrado na serie do aluno.
        //        lblexercicioSerie.Text = "Exercicio " + (exerciciodalista + 1).ToString() + " de " + listaExercicio.Count().ToString();               
        //            txtNomeALUNO.Text = alunoLogado.Nome.ToUpper() + "!";
        //            txtnomedaSerie.Text = seriealuno.Nome_Serie;
        //            txtNOMEEXERCICIO.Text = Convert.ToString(exercicio.Nome);
        //            txtQTDVEZES.Text = Convert.ToString(todosexercicio.Qtd_Vezes);
        //            txtREPETICOES.Text = Convert.ToString(todosexercicio.Qtd_repeticoes);
        //            txtOBJTIVOEXERCICIO.Text = exercicio.Objetivo;
        //            string path = await exercicioDAO.Buscar_IMAGEM(Convert.ToString(exercicio.Id_exercicio));
        //            imgbaixada.Source = path;                
        //    }
            
        //}

        public async Task Exercicio_Pelo_List(Exercicio exercicio)
        {
            var alunoLogado = await alunoDAO.Login_Aluno("Rodrigo", "1");
            var seriealuno = await alunoDAO.Busca_Serie_Aluno(alunoLogado.Id_Aluno);

            listaExercicio = await exercicios_Serie_DAO.Busca_Exercicios_Serie_DA_SERIE(IdSerie);
            //  listaExercicio = await exercicios_Serie_DAO.Busca_Exercicios_Serie_DA_SERIE(3);
           
          //  if (exerciciodalista <= listaExercicio.Count - 1)
            //{
                var todosexercicio = await alunoDAO.Busca_Exercicio_SERIE_ALUNO(alunoLogado.Id_Aluno);//acho que só retorna o primeiro da lista

                // var exercicio = await exercicioDAO.Busca_Exercicio_ID(todosexercicio.Id_Exercicios_Serie);
               // var exercicio = await exercicioDAO.Busca_Exercicio_ID(listaExercicio[id].Id_Exercicios_Serie);
                //esta funcao retorna uma lista com todos o exercicio cadastrado na serie do aluno.
               // lblexercicioSerie.Text = "Exercicio " + (exerciciodalista + 1).ToString() + " de " + listaExercicio.Count().ToString();
                txtNomeALUNO.Text = alunoLogado.Nome.ToUpper() + "!";
                txtnomedaSerie.Text = seriealuno.Nome_Serie;
                txtNOMEEXERCICIO.Text = Convert.ToString(exercicio.Nome);
                txtQTDVEZES.Text = Convert.ToString(todosexercicio.Qtd_Vezes);
                txtREPETICOES.Text = Convert.ToString(todosexercicio.Qtd_repeticoes);
                txtOBJTIVOEXERCICIO.Text = exercicio.Objetivo;
                string path = await exercicioDAO.Buscar_IMAGEM(Convert.ToString(exercicio.Id_exercicio));
                imgbaixada.Source = path;
          //  }
           

        }

        public string tempo(int Tempo)
        {
            int  Horas, Minutos, Segundos;
            string result = "";
            Horas = Tempo / 3600;
            Minutos = Tempo % 3600 / 60;
            Segundos = Tempo % 60;
            result = "Tempo: " + Horas + ":" + Minutos + ":" + Segundos;
            return result;
        }        
    }
}
 