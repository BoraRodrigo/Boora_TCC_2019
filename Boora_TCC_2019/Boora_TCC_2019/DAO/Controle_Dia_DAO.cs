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
    class Controle_Dia_DAO
    {
        FirebaseClient firebase = new FirebaseClient("https://tcc-2019-53a08.firebaseio.com/");
      
        public async Task Cadastrar_Dia(Controle_Dia controle_Dia)
        {

            await firebase
              .Child("Dia_Presenca")
              .PostAsync(new Controle_Dia()
              {
                  Id_Aluno=controle_Dia.Id_Aluno,
                  Data_Presenca=controle_Dia.Data_Presenca,
                  Nome_serie=controle_Dia.Nome_serie,
                  Hora_Serie=controle_Dia.Hora_Serie
              });
        }
        public async Task<List<Controle_Dia>> Busca_Todas__Dias_Do_Aluno(int idAluno)
        {

            return (await firebase
                .Child("Dia_Presenca").OrderBy("Id_Aluno").EqualTo(idAluno)
                .OnceAsync<Controle_Dia>()).Select(item => new Controle_Dia
                {
                    Id_Aluno = item.Object.Id_Aluno,
                    Data_Presenca = item.Object.Data_Presenca,
                    Nome_serie = item.Object.Nome_serie,
                    Hora_Serie=item.Object.Hora_Serie
                   

                }).ToList();

        }
    }
}
