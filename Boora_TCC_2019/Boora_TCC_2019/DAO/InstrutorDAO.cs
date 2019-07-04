using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.TELAS;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boora_TCC_2019.DAO
{
    public class InstrutorDAO
    {
        FirebaseClient firebase = new FirebaseClient("https://tcc-2019-53a08.firebaseio.com/");
        FirebaseStorage firebaseStorage = new FirebaseStorage("tcc-2019-53a08.appspot.com");

        public async Task<List<Instrutor>> Busca_Instrutor()
        {

            return (await firebase
               .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Instrutor")
                .OnceAsync<Instrutor>()).Select(item => new Instrutor
                {
                    Id_Instrutor = item.Object.Id_Instrutor,
                    Nome = item.Object.Nome,
                    Email = item.Object.Email,
                    Senha = item.Object.Senha,
                    Formacao_Academica = item.Object.Formacao_Academica,
                    

                }).ToList();

        }
        
        public async Task Cadastrar_Instrutor(Instrutor instrutor)
        {
            var cadastro_instrutor= await firebase
              .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Instrutor")
              .PostAsync(new Instrutor()
              {
                  Id_Instrutor = instrutor.Id_Instrutor,
                  Nome = instrutor.Nome,
                  Email = instrutor.Email,
                  Senha = instrutor.Senha,
                  Idade=instrutor.Idade,
                  Formacao_Academica= instrutor.Formacao_Academica
              });
            string  idinstrutotKEY = cadastro_instrutor.Key;//salva o id de cadastro do firebase

            var alterar_instrutoID = (await firebase
              .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Instrutor")
              .OnceAsync<Instrutor>()).Where(a => a.Object.Id_Instrutor == idinstrutotKEY).FirstOrDefault();

            await firebase
              .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Instrutor")
               .Child(idinstrutotKEY)
              .PutAsync(new Instrutor()
              {
                  Id_Instrutor = idinstrutotKEY,//altera pelo novo id
                  Nome = instrutor.Nome,
                  Email = instrutor.Email,
                  Senha = instrutor.Senha,
                  Idade = instrutor.Idade,
                  Formacao_Academica = instrutor.Formacao_Academica
              });
        }
    }
}
