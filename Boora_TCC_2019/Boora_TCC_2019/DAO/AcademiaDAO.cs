using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.TELAS;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boora_TCC_2019.DAO
{
    public class AcademiaDAO
    {
        static FirebaseClient firebase = new FirebaseClient("https://tcc-2019-53a08.firebaseio.com/");
        FirebaseStorage firebaseStorage = new FirebaseStorage("tcc-2019-53a08.appspot.com");

 
        public async Task Cadastrar_Academia(Academia academia, Stream fileStream)
        {
            var cadastroAcademia = await firebase
              .Child("Academias")
              //.Child(academia.Nome_academia)
             // .Child("Dados_Academia")
                .PostAsync(new Academia()
                {
                    Id_academia = academia.Id_academia,
                    Cidade=academia.Cidade,
                    Estado=academia.Estado,
                    Cnpj=academia.Cnpj,
                    Logo_academia=academia.Logo_academia,
                    Email=academia.Email,
                    Nome_academia = academia.Nome_academia,
                    Senha=academia.Senha,
                    Whats=academia.Whats,
                    Instagran=academia.Instagran

                });

            string id_academiaKEY = cadastroAcademia.Key;//salva o id de cadastro do firebase

            
            await firebase
              .Child("Academias")
              .Child(id_academiaKEY)
              .PutAsync(new Academia()
              {
                  Id_academia = id_academiaKEY,
                  Cidade = academia.Cidade,
                  Estado = academia.Estado,
                  Cnpj = academia.Cnpj,
                  Logo_academia = id_academiaKEY,
                  Email = academia.Email,
                  Nome_academia = academia.Nome_academia,
                  Senha = academia.Senha,
                  Whats = academia.Whats,
                  Instagran = academia.Instagran

              });

            var imageUrl = await firebaseStorage

           .Child("Logo_Academias")
           .Child(cadastroAcademia.Key)
           .PutAsync(fileStream);
        }
        public async Task<Academia> Busca_Academia_Nome(string nomeAcademia)
        {
           var academia =await Busca_Academia();
           await firebase
          .Child("Academias")
          //.Child(nomeAcademia)
          .OnceAsync<Academia>();

            return academia.Where(a => a.Nome_academia == nomeAcademia).FirstOrDefault();
        }
        

        public async Task<List<Academia>> Busca_Academia()
        {
            return (await firebase
                .Child("Academias")
                //.Child(nome)
                
                .OnceAsync<Academia>()).Select(item =>
                {

                    return new Academia
                    {
                        Id_academia = item.Object.Id_academia,
                        Cidade = item.Object.Cidade,
                        Estado = item.Object.Estado,
                        Cnpj = item.Object.Cnpj,
                        Logo_academia = item.Object.Logo_academia,
                        Email = item.Object.Email,
                        Nome_academia = item.Object.Nome_academia,
                        Senha = item.Object.Senha,
                        Whats = item.Object.Whats,
                        Instagran = item.Object.Instagran

                    };
                }).ToList();

        }
        public async Task<List<Academia>> Busca_Academia_WEB()
        {
  
            Academia academia = new Academia();
           
            return (await firebase
                .Child("Academias")
                
                .OnceAsync<Academia>()).Select(item =>
                {

                    return new Academia
                    {
                        Id_academia = item.Object.Id_academia,
                        Cidade = item.Object.Cidade,
                        Estado = item.Object.Estado,
                        Cnpj = item.Object.Cnpj,
                        Logo_academia = item.Object.Logo_academia,
                        Email = item.Object.Email,
                        Nome_academia = item.Object.Nome_academia,
                        Senha = item.Object.Senha,
                        Whats = item.Object.Whats,
                        Instagran = item.Object.Instagran

                    };
                }).ToList();

        }

        public async Task<Academia> Login_Dono_Academia( string senha, string nome,string email)//alt
        {
            try
            {
                var academia = await Busca_Academia();
                await firebase
                .Child("Academias")
                //.Child(Login.Nome_Academia_login)
                .OnceAsync<Academia>();
                return academia.Where(a => a.Email == email && a.Senha == senha).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<string> Buscar_IMAGEM_Logo_Academia(string id_Academia)
        {
            return await firebaseStorage
                .Child("Logo_Academias")
                .Child(id_Academia)
                .GetDownloadUrlAsync();
        }
        public async Task Alterar_Academia(string nome_academia, Academia academia)
        {
            await firebase
               .Child("Academias")
               .Child(academia.Id_academia)
              // .Child("Dados_Academia")
              .PutAsync(new Academia()
              {
                  Id_academia = Login.Id_Academia_Login,
                  Cidade = academia.Cidade,
                  Estado = academia.Estado,
                  Cnpj = academia.Cnpj,
                  Nome_academia=nome_academia,
                  Logo_academia = Login.Id_Academia_Login,
                  Email = academia.Email,
                  Senha = academia.Senha,
                  Whats = academia.Whats,
                  Instagran = academia.Instagran
              });
        }
    }
}