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
    public class InstrutorDAO
    {
        FirebaseClient firebase = new FirebaseClient("https://tcc-2019-53a08.firebaseio.com/");
        FirebaseStorage firebaseStorage = new FirebaseStorage("tcc-2019-53a08.appspot.com");

        public async Task<List<Instrutor>> Busca_Instrutor()
        {

            return (await firebase
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
            //Gambiarra para increment de id se excluir 
            List<Instrutor> listaInstrutor = await Busca_Instrutor();

            await firebase
              .Child("Instrutor")
              .PostAsync(new Instrutor()
              {
                  Id_Instrutor = listaInstrutor.Count() + 1,
                  Nome = instrutor.Nome,
                  Email = instrutor.Email,
                  Senha = instrutor.Senha,
                  Formacao_Academica= instrutor.Formacao_Academica
              });
        }
    }
}
