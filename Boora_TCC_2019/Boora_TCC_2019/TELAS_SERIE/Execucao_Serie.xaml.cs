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

        int exerciciodalista = 0;

        public Execucao_Serie ()
		{
			InitializeComponent ();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //Somente para teste Busco as inf no banco e coloca nos campos de texto abaixo
            //login por parametro fixo só teste
            var alunoLogado = await alunoDAO.Login_Aluno("Rodrigo", "1");
            var seriealuno = await alunoDAO.Busca_Serie_Aluno(alunoLogado.Id_Aluno);
            var todosexercicio = await alunoDAO.Busca_Exercicio_SERIE_ALUNO(alunoLogado.Id_Aluno);//acho que só retorna o primeiro da lista
            var exercicio = await exercicioDAO.Busca_Exercicio_ID(todosexercicio.Id_Exercicios_Serie);

            //esta funcao retorna uma lista com todos o exercicio cadastrado na serie do aluno.
            //(lembrando que um aluno pode ter mais de uma serie ai só fazer o mesmo esquena do exercicio
            listaExercicio = await exercicios_Serie_DAO.Busca_Exercicios_Serie_DA_SERIE(seriealuno.Id_Serie);
            lblexercicioSerie.Text = "Exercicio" + (exerciciodalista+1).ToString()+" de " + listaExercicio.Count().ToString();



            if (todosexercicio != null)
            {
                txtNomeALUNO.Text = alunoLogado.Nome.ToUpper()+"!";
                txtnomedaSerie.Text = seriealuno.Nome_Serie;
                txtNOMEEXERCICIO.Text = Convert.ToString(exercicio.Nome);
                txtQTDVEZES.Text = Convert.ToString(todosexercicio.Qtd_Vezes);
                txtREPETICOES.Text = Convert.ToString(todosexercicio.Qtd_repeticoes);
                txtOBJTIVOEXERCICIO.Text = exercicio.Objetivo;
                string path = await exercicioDAO.Buscar_IMAGEM(Convert.ToString(exercicio.Id_exercicio));
                imgbaixada.Source = path;
            }
            else
            {
                await DisplayAlert("Falha ao buscar Dados", "", "OK");
            }
        }
        private void Button_OnClicked (object sender, EventArgs e)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Entry.Text = tempo(++_vezesTimer);
                Button.IsEnabled = false;
                return true;
            });
         
        }

        private async void Proximo_Exercicio_Da_SerieAsync(object sender, EventArgs e)
        {
            //variavel para controlar o exercicio a sr exibido pela lista
            exerciciodalista = exerciciodalista + 1;
            if (exerciciodalista<=listaExercicio.Count-1)
            {
                var alunoLogado = await alunoDAO.Login_Aluno("Rodrigo", "1");
                var seriealuno = await alunoDAO.Busca_Serie_Aluno(alunoLogado.Id_Aluno);
                //esta funcao retorna uma lista com todos o exercicio cadastrado na serie do aluno.
                //(lembrando que um aluno pode ter mais de uma serie ai só fazer o mesmo esquena do exercicio
                listaExercicio = await exercicios_Serie_DAO.Busca_Exercicios_Serie_DA_SERIE(seriealuno.Id_Serie);
                //Somente para teste Busco as inf no banco e coloca nos campos de texto abaixo
                //login por parametro fixo só teste

                var todosexercicio = await alunoDAO.Busca_Exercicio_SERIE_ALUNO(alunoLogado.Id_Aluno);//acho que só retorna o primeiro da lista
                var exercicio = await exercicioDAO.Busca_Exercicio_ID(listaExercicio[exerciciodalista].Id_Exercicios_Serie);
                lblexercicioSerie.Text = "Exercicio" + (exerciciodalista + 1).ToString() + " de " + listaExercicio.Count().ToString();
                if (todosexercicio != null)
                {
                    txtNomeALUNO.Text = alunoLogado.Nome.ToUpper() + "!";
                    txtnomedaSerie.Text = seriealuno.Nome_Serie;
                    txtNOMEEXERCICIO.Text = Convert.ToString(exercicio.Nome);
                    txtQTDVEZES.Text = Convert.ToString(todosexercicio.Qtd_Vezes);
                    txtREPETICOES.Text = Convert.ToString(todosexercicio.Qtd_repeticoes);
                    string path = await exercicioDAO.Buscar_IMAGEM(Convert.ToString(listaExercicio[exerciciodalista].Id_Exercicios_Serie));
                    imgbaixada.Source = path;
                }
                else
                {
                    await DisplayAlert("ERRO", "Falha ao buscar Dados", "OK");                }
            }
            else
            {
                await DisplayAlert("BOORA", "Sem mais exercicios nesta serie", "OK");
            }           
        }
        private async void Anterior_Exercicio_Da_SerieAsync(object sender, EventArgs e)
        {
            //variavel para controlar o exercicio a sr exibido pela lista
            exerciciodalista = (exerciciodalista - 1);

            if (exerciciodalista <= listaExercicio.Count - 1 )
            {
                var alunoLogado = await alunoDAO.Login_Aluno("Rodrigo", "1");
                var seriealuno = await alunoDAO.Busca_Serie_Aluno(alunoLogado.Id_Aluno);
                //esta funcao retorna uma lista com todos o exercicio cadastrado na serie do aluno.
                //(lembrando que um aluno pode ter mais de uma serie ai só fazer o mesmo esquena do exercicio
                listaExercicio = await exercicios_Serie_DAO.Busca_Exercicios_Serie_DA_SERIE(seriealuno.Id_Serie);
                //Somente para teste Busco as inf no banco e coloca nos campos de texto abaixo
                //login por parametro fixo só teste

                var todosexercicio = await alunoDAO.Busca_Exercicio_SERIE_ALUNO(alunoLogado.Id_Aluno);//acho que só retorna o primeiro da lista
                var exercicio = await exercicioDAO.Busca_Exercicio_ID(listaExercicio[exerciciodalista].Id_Exercicios_Serie);
                lblexercicioSerie.Text = "Exercicio" + (exerciciodalista + 1).ToString() + " de " + listaExercicio.Count().ToString();
                if (todosexercicio != null)
                {
                    txtNomeALUNO.Text = alunoLogado.Nome.ToUpper() + "!";
                    txtnomedaSerie.Text = seriealuno.Nome_Serie;
                    txtNOMEEXERCICIO.Text = Convert.ToString(exercicio.Nome);
                    txtQTDVEZES.Text = Convert.ToString(todosexercicio.Qtd_Vezes);
                    txtREPETICOES.Text = Convert.ToString(todosexercicio.Qtd_repeticoes);
                    string path = await exercicioDAO.Buscar_IMAGEM(Convert.ToString(listaExercicio[exerciciodalista].Id_Exercicios_Serie));
                    imgbaixada.Source = path;
                }
                else
                {
                    await DisplayAlert("Falha ao buscar Dados", "", "OK");
                }
            }
            else
            {
                await DisplayAlert("BOORA", "Sem mais exercicios nesta serie", "OK");
            }          
        }
        public string tempo(int Tempo)
        {
            int  Horas, Minutos, Segundos;
            string result = "";
            Horas = Tempo / 3600;
            Minutos = Tempo % 3600 / 60;
            Segundos = Tempo % 60;
            result =  Horas + ":" + Minutos + ":" + Segundos;
            return result;
        }        
    }
}
 