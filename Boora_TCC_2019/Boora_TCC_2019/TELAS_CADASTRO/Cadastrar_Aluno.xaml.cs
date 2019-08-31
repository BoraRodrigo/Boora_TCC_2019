using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class Cadastrar_Aluno : ContentPage
    {
        AlunoDAO alunoDAO = new AlunoDAO();

        string  senha_para_Cadastro;

        string datanascimento;
        public Cadastrar_Aluno()
        {
            InitializeComponent();
            lbl_validaemail.IsVisible = false;
        }
        private void DataSelecionada(object sender, DateChangedEventArgs args)
        {
            datanascimento = args.NewDate.ToString("dd/MM/yyyy");
        }
        private async void Cadastrar_AlunoAsy(object sender, EventArgs e)
        {
        //aqui limitei o cadastro de um email por login, se o email já for cadastrado na academia não consegue
        //em outras sim.  
            bool controle = false;

            try
            {
                var vereficar_Aluno_ja_cadastrado_academia = await alunoDAO.Verefica_Se_Email_Ja_Cadastrado_Academia(txt_EMAIL.Text);
                if (vereficar_Aluno_ja_cadastrado_academia.Email.Contains(txt_EMAIL.Text))
                {
                    await DisplayAlert("ERRO", "Email já esta cadastrado", "OK");
                    controle = true;
                }
            }
            catch
            {
                try
                {
                    if (controle == false)
                    {
                        senha_para_Cadastro = gerarsenha();
                        await Enviar_Senha_EmailAsync(txt_EMAIL.Text);

                        btn_Cadastrar.IsEnabled = false;
                        Aluno aluno = new Aluno();
                        aluno.Nome = txt_NOME.Text;
                        aluno.Email = txt_EMAIL.Text;
                        aluno.Senha = senha_para_Cadastro;
                        aluno.Peso = Convert.ToDouble(txt_PESO.Text);
                        aluno.Altura = Convert.ToDouble(txt_ALTURA.Text);
                        aluno.Idade = datanascimento;
                        aluno.objetivo_Aluno = txt_OBJETIVO.Text;
                        aluno.Situacao = 1;

                        await alunoDAO.Cadastrar_Aluno(aluno);
                        limpaCampos();

                    }

                }
                catch
                {

                    await DisplayAlert("ERRO", "Verefique as informações", "OK");
                    btn_Cadastrar.IsEnabled = true;
                }
            } 
            
        }
        public void limpaCampos()
        {
            txt_ALTURA.Text = "";
            txt_EMAIL.Text = "";
            txt_NOME.Text = "";

            txt_OBJETIVO.Text = "";
            txt_PESO.Text = "";
            txt_SITUACAO.Text = "";
            btn_Cadastrar.IsEnabled = true;

        }
        public bool validaemail()
        {
            string email = txt_EMAIL.Text;
            Regex rg = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            if (rg.IsMatch(email))
            {
                lbl_validaemail.IsVisible = false;
                return true;
            }
            else
            {
                lbl_validaemail.IsVisible = true;
                return false;
            }

        }
        public static string gerarsenha()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var sua_senha = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return sua_senha;
        }
        protected async Task Enviar_Senha_EmailAsync(string emailEnviarsenha)
        {
            string remetenteEmail = "booraappcontato@gmail.com"; //O e-mail do remetente
            MailMessage mail = new MailMessage();
            mail.To.Add(emailEnviarsenha);
            mail.From = new MailAddress(remetenteEmail, "Aplicativo Boora", System.Text.Encoding.UTF8);
            mail.Subject = "Assunto: Seja Bem Vindo ao Borra!";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Olá "+txt_NOME.Text+" somos o BOORA esta é sua  senha de acesso "+senha_para_Cadastro;
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

