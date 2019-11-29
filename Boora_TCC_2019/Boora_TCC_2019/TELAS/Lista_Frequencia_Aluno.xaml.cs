using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Lista_Frequencia_Aluno : ContentPage
	{
    
        Aluno aluno_parametro;
        Controle_Dia_DAO controle_Dia_DAO = new Controle_Dia_DAO();
        private List<Controle_Dia> lista_Dias_Frequencia { get; set; }

        public Lista_Frequencia_Aluno(Aluno aluno)
        {
            aluno_parametro = aluno;
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            SlCarregandoAvisos.IsVisible = true;
            lista_Dias_Frequencia = await controle_Dia_DAO.Busca_Todas__Dias_Do_Aluno(aluno_parametro.Id_Aluno);        
            Lista_Frequencia.ItemsSource = lista_Dias_Frequencia;
            SlCarregandoAvisos.IsVisible = false;
            
        }

        private void _Cadastrar_SerieAsy(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TELAS.Cadastrar_Serie(aluno_parametro));
        }
    }
}