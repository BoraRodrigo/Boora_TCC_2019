using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS_CADASTRO
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastrar_Novo_Aviso : ContentPage
	{
        MediaFile file;
        Avisos_Academia_DAO avisos_Academia_DAO = new Avisos_Academia_DAO();
        Avisos_Academia avisos_Academia = new Avisos_Academia();
        public Cadastrar_Novo_Aviso ()
		{
			InitializeComponent ();
		}
        private async void Btn_Buscar(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
                  
                });
                if (file == null)
                    return;
                imgChoosed.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private async void Btn_Cadastrar(object sender, EventArgs e)
        {
            try
            {
                avisos_Academia.Data_Aviso = DateTime.Now.ToShortTimeString();
                avisos_Academia.Descricao_Aviso = txtDESCRICAO.Text;
                avisos_Academia.Id_Avisos_Academia = "";
                avisos_Academia.Imagem_Avisos = "";
                await avisos_Academia_DAO.Cadastrar_Avisos_Academia(avisos_Academia, file.GetStream());
                await DisplayAlert("Sucesso", "Aviso Cadastrado!", "OK");
            }
            catch
            {
                await DisplayAlert("erro", "Aviso  não cadastrado!", "OK");

            }

        }
    }
}