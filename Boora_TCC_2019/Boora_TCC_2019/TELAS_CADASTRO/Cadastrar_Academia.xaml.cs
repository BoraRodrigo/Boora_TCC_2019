using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.TELAS;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
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
            try
            {
            btn_Cadastrar.IsEnabled = false;
            btnPick.IsEnabled = false;

                AcademiaDAO academiaDAO = new AcademiaDAO();
                Academia academia = new Academia();
                var verefica_se_academia_ja_cadastrada = await academiaDAO.Busca_Academia_Nome(txt_NOMEACADEMIA.Text);
                try
                {
                    if (verefica_se_academia_ja_cadastrada.Nome_academia.Equals(txt_NOMEACADEMIA.Text))
                    {
                        await DisplayAlert("ERRO", "Academia já cadastrada", "OK");
                        btn_Cadastrar.IsEnabled = true;
                        btnPick.IsEnabled = true;
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
                        await Enviar_Senha_EmailAsync(txt_EMAIL.Text, txt_SENHA.Text);
                        LimpaCampos();
                        await DisplayAlert("", "Academia Cadastrada", "OK");
                        App.Current.MainPage = new Login();
                    }
                    catch
                    {
                        btn_Cadastrar.IsEnabled = true;
                        btnPick.IsEnabled = true;
                    }
                }

            }
            catch (Exception)
            {

                await DisplayAlert("", "Campos devem ser preenchidos corretamente", "OK");
                btn_Cadastrar.IsEnabled = true;
                btnPick.IsEnabled = true;
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
        protected async Task Enviar_Senha_EmailAsync(string emailEnviarsenha, string senha)
        {
            string remetenteEmail = "booraappcontato@gmail.com"; //O e-mail do remetente
            MailMessage mail = new MailMessage();
            mail.To.Add(emailEnviarsenha);
            mail.From = new MailAddress(remetenteEmail, "Aplicativo Boora", System.Text.Encoding.UTF8);
            mail.Subject = "Assunto: Seja Bem Vindo ao Borra!";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Olá " + txt_NOMEACADEMIA.Text + " somos o BOORA esta é sua  senha de acesso " + senha;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High; //Prioridade do E-Mail

            SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:
            client.Credentials = new System.Net.NetworkCredential(remetenteEmail, "qwe123QWE!@#");

            client.Port = 587; // Esta porta é a utilizada pelo Gmail para envio
            client.Host = "smtp.gmail.com"; //Definindo o provedor que irá disparar o e-mail
            client.EnableSsl = true; //Gmail trabalha com Server Secured Layer
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", "Email com senha não enviado", "OK");
            }
        }
    }
}