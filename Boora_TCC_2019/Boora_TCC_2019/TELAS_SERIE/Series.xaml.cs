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
        //Teste puxando informaçoes de uma lista para alimentar a tela da serie. 
        List<MODEL.Serie> lista = new List<MODEL.Serie>();
        int i = 0;
        int imax;
        public Serie ()
		{
			InitializeComponent ();
            
            //alimento a lista com metdodo que alimenta objeto na mao - guga
            lista = this.gerar_dados();

            //verificando tamanho da lista para usar nos botoes proximo e anterios - guga
            foreach (var item in lista)
            {
                imax++;
            }
            
            //lista na posiçao 0 para nao ficar vazio qnd abrir a tela - guga
            txtDescricao.Text = lista[i].Descricao_Exercicio;
            TxtNomeExercicio.Text = lista[i].Nome_Exercicio;
            TxtPeso.Text = "25";
            TxtRepetiçoes.Text = lista[i].Qtd_Vezes + "/" + lista[1].Qtd_repeticoes;
            ImgGif.Source = ImageSource.FromFile(lista[i].Url_Imagem);


        }

        private void Proximo_Exercicio(Object sender, EventArgs args)
        {
            
            // if para que o botao proximo nao incremento o valor de i superior ao tamanho da lista - guga
            if (i >= (imax-1))
            {
                DisplayAlert("Final", "Final Serie", "Ok");
            }
            else
            {
                i++;
            }
            
            //pega o valor de i e joga na lista , manda pra tela - guga
            txtDescricao.Text = lista[i].Descricao_Exercicio;
            TxtNomeExercicio.Text = lista[i].Nome_Exercicio;
            TxtPeso.Text = "25";
            TxtRepetiçoes.Text = lista[i].Qtd_Vezes + "/" + lista[1].Qtd_repeticoes;
            ImgGif.Source = ImageSource.FromFile(lista[i].Url_Imagem);

        }
        private void Anterior_Exercicio(Object sender, EventArgs args)
        {
            // if para que o botao proximo nao decremento o valor de i inferior ao tamanho da lista - guga
            if (i > 0)
            {
                i--;
            }
            else
            {
                DisplayAlert("inicio", "Inicio Serie", "Ok");
               
            }

            txtDescricao.Text = lista[i].Descricao_Exercicio;
            TxtNomeExercicio.Text = lista[i].Nome_Exercicio;
            TxtPeso.Text = "25";
            TxtRepetiçoes.Text = lista[i].Qtd_Vezes + "/" + lista[1].Qtd_repeticoes;
            ImgGif.Source = ImageSource.FromFile(lista[i].Url_Imagem);

        }

        //Alimentando o objeto e lista na mao - guga
        public List<MODEL.Serie> gerar_dados()
        {
            List<MODEL.Serie> lista = new List<MODEL.Serie>();
            MODEL.Serie serie = new MODEL.Serie();
            serie.Nome_Exercicio = "Supino Reto";
            serie.Peso_Aluno = "35";
            serie.Qtd_repeticoes = 15;
            serie.Qtd_Vezes = 3;
            serie.Url_Imagem = "Logo_Boora.png";
            serie.Descricao_Exercicio = "Peito Trincado";
            lista.Add(serie);

            MODEL.Serie serie1 = new MODEL.Serie();
            serie1.Nome_Exercicio = "Supino Inclinado";
            serie1.Peso_Aluno = "25";
            serie1.Qtd_repeticoes = 18;
            serie1.Qtd_Vezes = 3;
            serie1.Url_Imagem = "Logo_Boora_Preto.png";
            serie1.Descricao_Exercicio = "Peito Malhado";
            lista.Add(serie1);

            MODEL.Serie serie2 = new MODEL.Serie();
            serie2.Nome_Exercicio = "Supino Declinado";
            serie2.Peso_Aluno = "50";
            serie2.Qtd_repeticoes = 10;
            serie2.Qtd_Vezes = 4;
            serie2.Url_Imagem = "SupinoReto.gif";
            serie2.Descricao_Exercicio = "Peito Peito";
            lista.Add(serie2);

            return lista;

        }
    }
}