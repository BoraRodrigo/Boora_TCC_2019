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

            //Somente para teste Busco as inf no banco e coloca nos campos de texto abaixo
            var todosexercicio = await alunoDAO.Busca_Exercicio_SERIE_ALUNO(1);
            if (todosexercicio != null)
            {
                txtId.Text = Convert.ToString(todosexercicio.Qtd_Vezes);
                txtNome.Text =Convert.ToString( todosexercicio.Id_Exercicios_Serie);
                await DisplayAlert("DADOS", "", "OK");
            }
            else
            {
                await DisplayAlert("SEM DADOS", "", "OK");
            }
        }
       
    }
}
 