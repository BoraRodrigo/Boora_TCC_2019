using Boora_TCC_2019.MODEL;
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

        public async Task<List<Serie>> Busca_Serie()
        {

            return (await firebase
                .Child("Serie")
                .OnceAsync<Serie>()).Select(item => new Serie
                {
                    Id_Serie = item.Object.Id_Serie,
                    Id_Aluno = item.Object.Id_Aluno,
                    Nome_Serie = item.Object.Nome_Serie,
                    Data_Inicio = item.Object.Data_Inicio,
                    Data_Fim = item.Object.Data_Fim,
                    Descricao_Serie = item.Object.Descricao_Serie
                }).ToList();

        }

        public async Task Cadastrar_Serie(Serie serie)
        {
            //Gambiarra para increment de id
            List<Serie> listaSerie = await Busca_Serie();

            await firebase
              .Child("Serie")
              .PostAsync(new Serie() { Id_Serie = listaSerie.Count() + 1,
                  Id_Aluno = serie.Id_Aluno,
                  Nome_Serie = serie.Nome_Serie,
                  Data_Inicio = serie.Data_Inicio,
                  Data_Fim = serie.Data_Fim,
                  Descricao_Serie =serie.Descricao_Serie });
        }

    }
}