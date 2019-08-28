using Boora_TCC_2019.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Boora_TCC_2019.ClassesUTEIS
{
    public class Email
    {
        string senha_para_alterar;
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
        public async Task RedefinirSenha(string emailEnviarsenha,string nomeAcademia)
        {
            senha_para_alterar = gerarsenha();
            AlunoDAO alunoDAO= new AlunoDAO();

            string remetenteEmail = "rodrigobora93@gmail.com"; //O e-mail do remetente
            MailMessage mail = new MailMessage();
            mail.To.Add(emailEnviarsenha);
            mail.From = new MailAddress(remetenteEmail, "Aplicativo Boora", System.Text.Encoding.UTF8);
            mail.Subject = "Assunto: Redefinição de senha Borra!";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Olá sua nova senha de acesso é: " + senha_para_alterar;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High; //Prioridade do E-Mail

            SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:
            client.Credentials = new System.Net.NetworkCredential(remetenteEmail, "Aa@222abcdegrb36");

            client.Port = 587; // Esta porta é a utilizada pelo Gmail para envio
            client.Host = "smtp.gmail.com"; //Definindo o provedor que irá disparar o e-mail
            client.EnableSsl = true; //Gmail trabalha com Server Secured Layer
            try
            {
                client.Send(mail);
                await   alunoDAO.Aterar_senha(emailEnviarsenha,senha_para_alterar,nomeAcademia);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
