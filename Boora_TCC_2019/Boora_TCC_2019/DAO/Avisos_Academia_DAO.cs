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
   public  class Avisos_Academia_DAO
    {
        FirebaseClient firebase = new FirebaseClient("https://tcc-2019-53a08.firebaseio.com/");
        FirebaseStorage firebaseStorage = new FirebaseStorage("tcc-2019-53a08.appspot.com");

        public async Task Cadastrar_Avisos_Academia(Avisos_Academia aviso_Academia, Stream fileStream)
        {
            var cadastro_avisos = await firebase
               .Child("Avisos_Academias")
               .Child(Login.Nome_Academia_login)
              .PostAsync(new Avisos_Academia()
              {
                  Id_Avisos_Academia = aviso_Academia.Id_Avisos_Academia,
                  Descricao_Aviso = aviso_Academia.Descricao_Aviso,
                  Data_Aviso = aviso_Academia.Data_Aviso,
                  Imagem_Avisos = aviso_Academia.Imagem_Avisos

              });
            string id_cadastroAVISO_KEY = cadastro_avisos.Key;

            var alterar_alunoID = (await firebase
             .Child("Avisos_Academias")
             .Child(Login.Nome_Academia_login)
             .OnceAsync<Avisos_Academia>()).Where(a => a.Object.Id_Avisos_Academia == id_cadastroAVISO_KEY).FirstOrDefault();

            await firebase
              .Child("Avisos_Academias")
              .Child(Login.Nome_Academia_login)
              .Child(id_cadastroAVISO_KEY)
              .PutAsync(new Avisos_Academia()
              {
                  Id_Avisos_Academia = id_cadastroAVISO_KEY,
                  Descricao_Aviso = aviso_Academia.Descricao_Aviso,
                  Data_Aviso = aviso_Academia.Data_Aviso,
                  Imagem_Avisos = aviso_Academia.Imagem_Avisos
                  
              });
            var imageUrl = await firebaseStorage

           .Child(Login.Nome_Academia_login)
           .Child("Avisos_Da_Academia")
           .Child(cadastro_avisos.Key)
           .PutAsync(fileStream);
        }
        public async Task<List<Avisos_Academia>> Lista_Avisos()
        {
            return (await firebase
                .Child("Avisos_Academias")
                .Child(Login.Nome_Academia_login)
                .OnceAsync<Avisos_Academia>()).Select(item => new Avisos_Academia
                {
                    Id_Avisos_Academia = item.Object.Id_Avisos_Academia,
                    Descricao_Aviso = item.Object.Descricao_Aviso,
                    Data_Aviso = item.Object.Data_Aviso,
                    Imagem_Avisos = item.Object.Imagem_Avisos,
                    
                }).ToList();
        }
        public async Task<string> Buscar_IMAGEM_AVISOS(string id_Avisos)
        {
            return await firebaseStorage
                .Child(Login.Nome_Academia_login)
                .Child("Avisos_Da_Academia")
                .Child(id_Avisos)
                .GetDownloadUrlAsync();
        }

    }
}
