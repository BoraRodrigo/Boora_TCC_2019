using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.BancoSQlite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Boora_TCC_2019.MODEL;

namespace Boora_TCC_2019.TELAS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Personalizacao : ContentPage
	{
        string corlabel { get; set; }
        string corStack { get; set; }
        Cores cores = new Cores();
        List<Cores> lista = new List<Cores>();

        public Personalizacao ()
		{
			InitializeComponent ();
		}


        private void SalvarAction(object sender, EventArgs args)
        {
            Db_SqlLite db = new Db_SqlLite();
            cores.CorLabel = corlabel;
            cores.CorStackLayout = corStack;
            lista = db.Consultar();
            if(lista.Capacity == 0)
            {
                db.Salvar(cores);
            }
            else
            {
                cores.id = lista[0].id;
                db.Alterar(cores);
            }
            App app = new App();
            app.MudarCorPersonalizacao();
        }

        private void TestarAction(object sender, EventArgs args)
        {
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
            this.Resources["CorStack"] = Color.FromHex(corStack);
       
        }

        private void OkLetrasAction(object sender, EventArgs args)
        {
            corlabel = txt_corLabel.Text;

        }
        private void OkStackAction(object sender, EventArgs args)
        {
            corStack = txt_corStack.Text;

        }

        private void CorBrownSelection(object sender, EventArgs args)
        {
            corlabel = "8a5706";
        }
        private void CorRedSelection(object sender, EventArgs args)
        {
            corlabel = "ff0000";
        }
        private void CorGreenSelection(object sender, EventArgs args)
        {
            corStack = "09ff00";
        }
        private void CorOrangeSelection(object sender, EventArgs args)
        {
            corStack = "fc9300";
        }
    }
}