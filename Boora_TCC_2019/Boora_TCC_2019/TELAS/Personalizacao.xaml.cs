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
          //  cores.CorStackLayout = corStack;
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

        //private void TestarAction(object sender, EventArgs args)
        //{
        //    this.Resources["CorLabel"] = Color.FromHex(corlabel);
        //    this.Resources["CorStack"] = Color.FromHex("ffffff");
       
        //}

        //private void OkLetrasAction(object sender, EventArgs args)
        //{
        //    //corlabel = txt_corLabel.Text;

        //}
        //private void OkStackAction(object sender, EventArgs args)
        //{
        //    //corStack = txt_corStack.Text;

        //}

        private void CorBlackSelection(object sender, EventArgs args)
        {
            corlabel = "000000";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorGreenSelection(object sender, EventArgs args)
        {
            corlabel = "09ff00";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorRedSelection(object sender, EventArgs args)
        {
            corlabel = "ff0000";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorOrangeSelection(object sender, EventArgs args)
        {
            corlabel = "fc9300";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorYellowSelection(object sender, EventArgs args)
        {
            corlabel = "faf60f";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorLightGraySelection(object sender, EventArgs args)
        {
            corlabel = "d6d6c9";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorBlueSelection(object sender, EventArgs args)
        {
            corlabel = "0d05fa";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorIndigoSelection(object sender, EventArgs args)
        {
            corlabel = "27334c";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorVioletSelection(object sender, EventArgs args)
        {
            corlabel = "59107d";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorGraySelection(object sender, EventArgs args)
        {
            corlabel = "cccccc";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorAccentSelection(object sender, EventArgs args)
        {
            corlabel = "007167";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
        private void CorBrownSelection(object sender, EventArgs args)
        {
            corlabel = "8a5706";
            this.Resources["CorLabel"] = Color.FromHex(corlabel);
        }
    }
}