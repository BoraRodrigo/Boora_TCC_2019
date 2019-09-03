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
	public partial class Cadastrar_Academia : ContentPage
	{
        MediaFile file;
        public Cadastrar_Academia ()
		{
			InitializeComponent ();
		}
        private async void Cadastrar_AlunoAsy(object sender, EventArgs e)
        {
                AcademiaDAO academiaDAO = new AcademiaDAO();
                Academia academia = new Academia();

                var verefica_se_academia_ja_cadastrada = await academiaDAO.Busca_Academia_Nome(txt_NOMEACADEMIA.Text);
            try
            {
                if (verefica_se_academia_ja_cadastrada.Nome_academia.Equals(txt_NOMEACADEMIA.Text))
                {
                    await DisplayAlert("ERRO", "Academia já cadastrada", "OK");
                }

            }
            catch
            {
                try
                {
                    academia.Id_academia = "2";
                    academia.Nome_academia = txt_NOMEACADEMIA.Text;
                    academia.Cidade = txt_CIDADE.Text;
                    academia.Cnpj = txt_CNPJ.Text;
                    academia.Email = txt_EMAIL.Text;
                    academia.Estado = txt_ESTADO.Text;
                    academia.Logo_academia = "";
                    academia.Senha = txt_SENHA.Text;
                    academia.Whats = txt_TELEFONE.Text;
                    academia.Instagran = txt_INSTAGRAN.Text;
                    await academiaDAO.Cadastrar_Academia(academia, file.GetStream());
                    LimpaCampos();
                }
                catch
                {

                  
                }
            }                      
                {  
            }
        }
        private async void Btn_Buscar(object sender, EventArgs e)
        {          
            await CrossMedia.Current.Initialize();
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {           
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                    // PhotoSize = PhotoSize.Custom,
                   // CustomPhotoSize = 40
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
        public void LimpaCampos()
        {
            txt_CIDADE.Text = "";
            txt_CNPJ.Text = "";
            txt_EMAIL.Text = "";
            txt_ESTADO.Text = "";
            txt_NOMEACADEMIA.Text = "";
            txt_SENHA.Text = "";
            txt_INSTAGRAN.Text = "";
            txt_TELEFONE.Text = "";
        }
    }
}