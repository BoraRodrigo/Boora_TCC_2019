using Boora_TCC_2019.MODEL;
using Firebase.Database;
using Firebase.Database.Query;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Boora_TCC_2019.DAO
{
    public class Exercicios_Serie_DAO
    {
        FirebaseClient firebase = new FirebaseClient("https://tcc-2019-53a08.firebaseio.com/");

        public async Task<List<Exercicios_Serie>> Busca_Exercicios_Serie()
        {

            return (await firebase
                .Child("Exercicios_Serie_DAO")
                .OnceAsync<Exercicios_Serie>()).Select(item => new Exercicios_Serie
                {
                    Id_Exercicios_Serie = item.Object.Id_Exercicios_Serie,
                    Id_Serie = item.Object.Id_Serie,
                    Qtd_repeticoes = item.Object.Qtd_repeticoes,
                    Qtd_Vezes = item.Object.Qtd_Vezes,
                    Tempo_Maximo = item.Object.Tempo_Maximo,
                    Tempo_Minimo = item.Object.Tempo_Minimo,
                    Tempo_Execucao = item.Object.Tempo_Execucao
                }).ToList();

        }
        //Retorna uma lista com os exercicios cadastrados na serie do aluno o para a ser passado devera ser o ID da serie -BORA
        public async Task<List<Exercicios_Serie>> Busca_Exercicios_Serie_DA_SERIE(int id_da_serie)
        {

            return (await firebase
                .Child("Exercicios_Serie_DAO").OrderBy("Id_Serie").EqualTo(id_da_serie)
                .OnceAsync<Exercicios_Serie>()).Select(item => new Exercicios_Serie
                {
                    Id_Exercicios_Serie = item.Object.Id_Exercicios_Serie,
                    Id_Serie = item.Object.Id_Serie,
                    Qtd_repeticoes = item.Object.Qtd_repeticoes,
                    Qtd_Vezes = item.Object.Qtd_Vezes,
                    Tempo_Maximo = item.Object.Tempo_Maximo,
                    Tempo_Minimo = item.Object.Tempo_Minimo,
                    Tempo_Execucao = item.Object.Tempo_Execucao
                }).ToList();

        }

       




        public async Task Cadastrar_Exercicios_Serie(Exercicios_Serie exercicios_Serie)
        {
            //Gambiarra para increment de id
            List<Exercicios_Serie> listaExercicios_Serie= await Busca_Exercicios_Serie();

            await firebase
              .Child("Exercicios_Serie_DAO")
              .PostAsync(new Exercicios_Serie()
              {
                  Id_Exercicios_Serie = listaExercicios_Serie.Count() + 1,
                  Id_Serie = exercicios_Serie.Id_Serie,
                  Qtd_repeticoes = exercicios_Serie.Qtd_repeticoes,
                  Qtd_Vezes = exercicios_Serie.Qtd_Vezes,
                  Tempo_Maximo = exercicios_Serie.Tempo_Maximo,
                  Tempo_Minimo = exercicios_Serie.Tempo_Minimo,
                  Tempo_Execucao=exercicios_Serie.Tempo_Execucao
              });
        }
    }
}
