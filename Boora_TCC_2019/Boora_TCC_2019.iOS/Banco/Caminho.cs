using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Boora_TCC_2019.BancoSQlite;
using System.IO;
using Boora_TCC_2019.iOS.Banco;


[assembly: Dependency(typeof(Caminho))]
namespace Boora_TCC_2019.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomerquivoBanco)
        {


            var CaminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string CaminhoBiblioteca = Path.Combine(CaminhoDaPasta, "..", "Library");

            string CaminhoDoBando = Path.Combine(CaminhoBiblioteca, NomerquivoBanco);

            return CaminhoDoBando;

        }
    }
}