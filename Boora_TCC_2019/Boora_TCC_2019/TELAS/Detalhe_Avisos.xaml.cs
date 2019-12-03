using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS
{
   
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detalhe_Avisos : ContentPage
	{
        

        public Detalhe_Avisos (Avisos_Academia aviso)
		{
			InitializeComponent ();
            img_imagem.Source = aviso.Imagem_Avisos;
            txt_titulo.Text = "Titulo Aviso";
            txt_detalhes.Text = aviso.Descricao_Aviso;

        }

       

        
	}
}