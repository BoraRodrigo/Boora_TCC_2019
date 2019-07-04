using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastrar_Exercicio : ContentPage
	{
        MediaFile file;
        ExercicioDAO exercicioDAO = new ExercicioDAO();
        public Cadastrar_Exercicio ()
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
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
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

        private async void Btn_Upload(object sender, EventArgs e)
        {
            try
            {
                await exercicioDAO.Cadastrar_Exercicio("1", txtNOME.Text, txtDESCRICAO.Text, txtOBJETIVO.Text, file.GetStream(), Path.GetFileName(file.Path));
                await DisplayAlert("Sucesso", "Exercicio Cadastrado!", "OK");
            }
            catch 
            {
                await DisplayAlert("erro", "Exercicio  não cadastrado!", "OK");

            }

        }
    }
}