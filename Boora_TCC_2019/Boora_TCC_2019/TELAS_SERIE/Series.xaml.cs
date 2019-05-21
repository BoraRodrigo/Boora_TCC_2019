using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.MODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS_SERIE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Serie : ContentPage
	{
		public Serie ()
		{
			InitializeComponent ();
            MODEL.Serie serie = new MODEL.Serie();
            List<MODEL.Serie> lista = new List<MODEL.Serie>();
            lista = serie.gerar_dados();

            txtDescricao.Text = lista[0].Descricao_Exercicio;
            TxtNomeExercicio.Text = lista[0].Nome_Exercicio;
            TxtPeso.Text = "25";
            TxtRepetiçoes.Text = lista[0].Qtd_Vezes + "/" + lista[0].Qtd_repeticoes;
            ImgGif.Source = ImageSource.FromFile(lista[0].Url_Imagem);


		}
	}
}