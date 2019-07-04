using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.TELAS;
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
                .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Exercicios_Serie_DAO")
                .OnceAsync<Exercicios_Serie>()).Select(item => new Exercicios_Serie
                {
                    Id_Exercicios_Serie = item.Object.Id_Exercicios_Serie,
                    Id_Serie = item.Object.Id_Serie,
                    Qtd_repeticoes = item.Object.Qtd_repeticoes,
                    Qtd_Vezes = item.Object.Qtd_Vezes,
                    Peso=item.Object.Peso
                }).ToList();

        }
        //Retorna uma lista com os exercicios cadastrados na serie do aluno o para a ser passado devera ser o ID da serie -BORA
        public async Task<List<Exercicios_Serie>> Busca_Exercicios_Serie_DA_SERIE(string id_da_serie)
        {

            return (await firebase
               .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Exercicios_Serie_DAO").OrderBy("Id_Serie").EqualTo(id_da_serie)
                .OnceAsync<Exercicios_Serie>()).Select(item => new Exercicios_Serie
                {
                    Id_Exercicios_Serie = item.Object.Id_Exercicios_Serie,
                    Id_Serie = item.Object.Id_Serie,
                    Qtd_repeticoes = item.Object.Qtd_repeticoes,
                    Qtd_Vezes = item.Object.Qtd_Vezes,
                     Peso = item.Object.Peso
                }).ToList();

        }

        public async Task<List<Serie>> Busca_Todas__Series_Aluno(string idAluno)
        {

            return (await firebase

                //para fazer esse tipo de busca tem que adiconar uma regras no firebase.
                //    "Serie": {
                //       ".indexOn": ["Id_Aluno"],          
                //    ".read": true,
                //     ".write": true
                //  }
                .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Serie").OrderBy("Id_Aluno").EqualTo(idAluno)
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

        public async Task Cadastrar_Exercicios_Serie(Exercicios_Serie exercicios_Serie)
        {
            await firebase
              .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Exercicios_Serie_DAO")
              .PostAsync(new Exercicios_Serie()
              {
               
                  Id_Exercicios_Serie = exercicios_Serie.Id_Exercicios_Serie,
                  Id_Serie = exercicios_Serie.Id_Serie,
                  Qtd_repeticoes = exercicios_Serie.Qtd_repeticoes,
                  Qtd_Vezes = exercicios_Serie.Qtd_Vezes,
                  Peso = exercicios_Serie.Peso
              });
        }
    }
}