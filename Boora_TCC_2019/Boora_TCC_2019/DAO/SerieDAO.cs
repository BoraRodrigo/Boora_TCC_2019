using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.TELAS;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boora_TCC_2019.DAO
{
    public class SerieDAO
    {
        FirebaseClient firebase = new FirebaseClient("https://tcc-2019-53a08.firebaseio.com/");

        public  static string id_serieKEY;

        public async Task<List<Serie>> Busca_Serie()
        {

            return (await firebase
                .Child("Serie")
                .Child(Login.Nome_Academia_login)
                .Child("Serie")
                .OnceAsync<Serie>()).Select(item => new Serie
                {
                    Id_Serie = item.Object.Id_Serie,
                    Id_Aluno = item.Object.Id_Aluno,
                    Nome_Serie = item.Object.Nome_Serie,
                    Data_Inicio = item.Object.Data_Inicio,
                    Data_Fim = item.Object.Data_Fim,
                    Descricao_Serie = item.Object.Descricao_Serie,
                    Tempo_Execucao=item.Object.Tempo_Execucao
                }).ToList();

        }

        public async Task Cadastrar_Serie(Serie serie)
        {
          

         var cadastro_serie=   await firebase
                .Child("Serie")
                .Child(Login.Nome_Academia_login)
                .Child("Serie")
              .PostAsync(new Serie() { Id_Serie = serie.Id_Serie,
                  
                  Id_Aluno = serie.Id_Aluno,
                  Nome_Serie = serie.Nome_Serie,
                  Data_Inicio = serie.Data_Inicio,
                  Data_Fim = serie.Data_Fim,
                  Descricao_Serie =serie.Descricao_Serie,
                  Tempo_Execucao = serie.Tempo_Execucao
              });
             id_serieKEY = cadastro_serie.Key;

            var alterar_serieID = (await firebase
                .Child("Serie")
                .Child(Login.Nome_Academia_login)
                .Child("Serie")
            .OnceAsync<Serie>()).Where(a => a.Object.Id_Serie == id_serieKEY).FirstOrDefault();

            await firebase
            .Child("Serie")
            .Child(Login.Nome_Academia_login)
            .Child("Serie")
            .Child(id_serieKEY)
            .PutAsync(new Serie()
            {
                Id_Serie = id_serieKEY,

                Id_Aluno = serie.Id_Aluno,
                Nome_Serie = serie.Nome_Serie,
                Data_Inicio = serie.Data_Inicio,
                Data_Fim = serie.Data_Fim,
                Descricao_Serie = serie.Descricao_Serie,
                Tempo_Execucao = serie.Tempo_Execucao
            });
        }
        public async Task<Serie> Busca_Serie_ID(string id_Serie)
        {
            var exercicio = await Busca_Serie();
            await firebase
                .Child("Serie")
                .Child(Login.Nome_Academia_login)
                .Child("Serie")
              .OnceAsync<Serie>();
            return exercicio.Where(a => a.Id_Serie == id_Serie).FirstOrDefault();

        }


    }
}