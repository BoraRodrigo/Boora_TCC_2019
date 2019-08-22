using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.BancoSQlite;
using Xamarin.Forms;
using System.IO;
using Boora_TCC_2019.UWP.Banco;
using Windows.Storage;


[assembly: Dependency(typeof(Caminho))]
namespace Boora_TCC_2019.UWP.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomerquivoBanco)
        {
            string CaminhoDaPasta = ApplicationData.Current.LocalFolder.Path;

            string CaminhoDoBanco = Path.Combine(CaminhoDaPasta, NomerquivoBanco);

            return CaminhoDoBanco;
        }
    }
}
