using Boora_TCC_2019.MODEL;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using Firebase.Storage;
using System.IO;

namespace Boora_TCC_2019.DAO
{
   public  class ExercicioDAO
    {
        FirebaseClient firebase = new FirebaseClient("https://tcc-2019-53a08.firebaseio.com/");
        FirebaseStorage firebaseStorage = new FirebaseStorage("tcc-2019-53a08.appspot.com");
       public async Task<List<Exercicio>> Busca_Exercicio()
         {

           return (await firebase
               .Child("Exercicio")
               .OnceAsync<Exercicio>()).Select(item => new Exercicio
               {
                   Nome = item.Object.Nome,
                   Id_exercicio = item.Object.Id_exercicio,
                   Descricao=item.Object.Descricao,
                   Objetivo=item.Object.Objetivo,
                   Imagem_Gif=item.Object.Imagem_Gif
               }).ToList();
               
           }

        public async Task Cadastrar_Exercicio(int id_Exercicio, string nome,string descricao, string objetivo, Stream fileStream, string fileName)
        {
            //Gambiarra para increment de id se excluir alguem do banco vai repetir id HHAHH, salvo o nome da imagem/gif junto com o exercicio o certo seria o id
            List<Exercicio> listaExercicio = await Busca_Exercicio();
            
            await firebase
              .Child("Exercicio")
              
              .PostAsync(new Exercicio() { Id_exercicio=listaExercicio.Count()+1, Nome = nome, Descricao = descricao, Objetivo = objetivo,Imagem_Gif=Convert.ToString(listaExercicio.Count()+1) });

            //Salva a imagem  paremtros fileStreen e file name que são a imagem carregada e o nome que eu quero salvar no banco
            var imageUrl = await firebaseStorage
                 .Child("Gif_Exercicio")
                 //inserindo o id da imagem como id do exercicio metodo só pra rodar depois tem que fazer do jeito certo
                 .Child(Convert.ToString(listaExercicio.Count() + 1))
                 .PutAsync(fileStream);
        }
        public async Task<Exercicio> Busca_Exercicio_ID(int id_Exercicio)
          {
              var exercicio = await Busca_Exercicio();
              await firebase
                .Child("Exercicio")
                .OnceAsync<Exercicio>();
              return exercicio.Where(a => a.Id_exercicio == id_Exercicio).FirstOrDefault();
         
        }


        public async Task Alterar_Exercicio(int id_Exercicio, string nome)
             {
            //metodo incompleto
            var alterar_exercicio = (await firebase
                   .Child("Exercicio")
                   .OnceAsync<Exercicio>()).Where(a => a.Object.Id_exercicio == id_Exercicio).FirstOrDefault();

                 await firebase
                   .Child("Exercicio")
                   .Child(alterar_exercicio.Key)
                   .PutAsync(new Exercicio() { Id_exercicio = id_Exercicio, Nome = nome });
             }

            public async Task Excluir_Exercicio(int id_Exercicio)
          {
              var excluirExercicio = (await firebase
                .Child("Exercicio")
                .OnceAsync<Exercicio>()).Where(a => a.Object.Id_exercicio == id_Exercicio).FirstOrDefault();
              await firebase.Child("Exercicio").Child(excluirExercicio.Key).DeleteAsync();

          }
        ///Cadastro/busca /excluir de imagem.
        //A busca de imagem ou delete da imagem é feita pelo nome da imagem. Na hora de salvar 
        //salva a imagem com o id do cadastro do exercicio. A busca precisa saber o formato 
        //ou seja se o ID for 1 a busca precisa ser "1.gif" concatenar o .gif
        public async Task<string> Buscar_IMAGEM(string nomeImagem)
        {
            return await firebaseStorage
                .Child("Gif_Exercicio")
                .Child(nomeImagem)
                .GetDownloadUrlAsync();
        }
        public async Task DeleteFile(string nomeImagem)
        {
            await firebaseStorage
                 .Child("Exercicio")
                 .Child(nomeImagem)
                 .DeleteAsync();
        }
        public async Task<string> Upload_Imagem(Stream fileStream, string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child("Gif_Exercicio")
                .Child(fileName)
                .PutAsync(fileStream);
            return imageUrl;
        }
    }
}

