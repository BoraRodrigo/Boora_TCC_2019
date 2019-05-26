using Boora_TCC_2019.DAO;
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
        public Execucao_Serie ()
		{
			InitializeComponent ();
           


        }
        private void Button_OnClicked (object sender, EventArgs e)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
              

                Entry.Text = $"Timer foi executado {++_vezesTimer} vezes";
                Button.IsEnabled = false;
                return true;
            });
         
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var todosexercicio = await alunoDAO.Busca_Exercicio_SERIE_ALUNO(1);
            //este metodo deveria busca a serie do alunno pelo ID mais da um erro que nao sei 
          //  listaAlunos.ItemsSource =todosexercicio;
    }
       
    }
}
 