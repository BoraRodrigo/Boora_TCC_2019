using Boora_TCC_2019.MODEL;
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
    public class AlunoDAO
    {
        FirebaseClient firebase = new FirebaseClient("https://tcc-2019-53a08.firebaseio.com/");
        FirebaseStorage firebaseStorage = new FirebaseStorage("tcc-2019-53a08.appspot.com");
        public async Task<List<Aluno>> Busca_Aluno()
        {

            return (await firebase
                .Child("Aluno")
                .OnceAsync<Aluno>()).Select(item => new Aluno
                {
                    Id_Aluno = item.Object.Id_Aluno,
                    Nome = item.Object.Nome,
                    Email = item.Object.Email,
                    Senha = item.Object.Senha,
                    Peso = item.Object.Peso,
                    Altura = item.Object.Altura,
                    Idade = item.Object.Idade,
                    objetivo_Aluno = item.Object.objetivo_Aluno,
                    Situacao = item.Object.Situacao,

                }).ToList();

        }
        public async Task Cadastrar_Aluno(Aluno aluno)
        {
            //Gambiarra para increment de id se excluir 
            List<Aluno> listaAlunos = await Busca_Aluno();

            await firebase
              .Child("Aluno")
              .PostAsync(new Aluno()
              {
                  Id_Aluno = listaAlunos.Count() + 1,
                  Nome = aluno.Nome,
                  Email = aluno.Email,
                  Senha = aluno.Senha,
                  Peso = aluno.Peso,
                  Altura = aluno.Altura,
                  Idade = aluno.Idade,
                  objetivo_Aluno = aluno.objetivo_Aluno,
                  Situacao = aluno.Situacao
              });
        }

  
        public async Task<Exercicios_Serie> Busca_Exercicio_SERIE_ALUNO(int id_serie)
        {
            Exercicios_Serie_DAO exercicios_Serie_DAO = new Exercicios_Serie_DAO();
            var exercicios_serie = await exercicios_Serie_DAO.Busca_Exercicios_Serie();
            await firebase
              .Child("Serie")
              .OnceAsync<Exercicios_Serie_DAO>();
            return exercicios_serie.Where(a => a.Id_Serie == id_serie).FirstOrDefault();
        }

        //não consigo puxar por estes metodos não sei o que acontece 
        public async Task<Serie> Busca_SERIE_ALUNO(int id_Aluno)
        {
            SerieDAO serieDAO = new SerieDAO();
            var serie = await serieDAO.Busca_Serie();
            await firebase
              .Child("Serie")
              .OnceAsync<Serie>();
            return serie.Where(a => a.Id_Aluno == id_Aluno).FirstOrDefault();

        }


    }
}
