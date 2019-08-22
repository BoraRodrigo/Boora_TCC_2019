using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Boora_TCC_2019.BancoSQlite;
using System.IO;
using Boora_TCC_2019.Droid.Banco;

[assembly: Dependency(typeof(Caminho))]
namespace Boora_TCC_2019.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomerquivoBanco)
        {
            var CaminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string CaminhoDoBanco = Path.Combine(CaminhoDaPasta, NomerquivoBanco);
            return CaminhoDoBanco;

        }
    }
}