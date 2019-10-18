
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
    public class AlunoDAO
    {
        FirebaseClient firebase = new FirebaseClient("https://tcc-2019-53a08.firebaseio.com/");
        FirebaseStorage firebaseStorage = new FirebaseStorage("tcc-2019-53a08.appspot.com");

        public async Task<List<Aluno>> Busca_Aluno()
        {
            return (await firebase
                .Child("Academias")
                .Child(Login.Nome_Academia_login )
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

        public async Task<List<Aluno>> Busca_Aluno_Por_nome_Academia_Enviar_Email(string nome_Academia)
        {

            return (await firebase
                .Child("Academias")
                .Child(nome_Academia)
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
        public async Task Cadastrar_Aluno(Aluno aluno, Stream fileStream)
        {
            var cadastro_aluno= await firebase
               .Child("Academias")
               .Child(Login.Nome_Academia_login)
               .Child("Aluno")
              .PostAsync(new Aluno()
              {
                  Id_Aluno = aluno.Id_Aluno,
                  Nome = aluno.Nome,
                  Email = aluno.Email,
                  Senha = aluno.Senha,
                  Peso = aluno.Peso,
                  Altura = aluno.Altura,
                  Idade = aluno.Idade,
                  objetivo_Aluno = aluno.objetivo_Aluno,
                  Foto_Aluno=aluno.Foto_Aluno,
                  Situacao = aluno.Situacao
              });
            string id_cadastroalunoKEY = cadastro_aluno.Key;

            var alterar_alunoID = (await firebase
             .Child("Academias")
             .Child(Login.Nome_Academia_login)
             .Child("Aluno")
             .OnceAsync<Aluno>()).Where(a => a.Object.Id_Aluno == id_cadastroalunoKEY).FirstOrDefault();

            await firebase
              .Child("Academias")
              .Child(Login.Nome_Academia_login)
              .Child("Aluno")
              .Child(id_cadastroalunoKEY)
              .PutAsync(new Aluno()
              {
                  Id_Aluno = id_cadastroalunoKEY,
                  Nome = aluno.Nome,
                  Email = aluno.Email,
                  Senha = aluno.Senha,
                  Peso = aluno.Peso,
                  Altura = aluno.Altura,
                  Idade = aluno.Idade,
                  objetivo_Aluno = aluno.objetivo_Aluno,
                  Foto_Aluno=id_cadastroalunoKEY,
                  Situacao = aluno.Situacao
              });
            var imageUrl = await firebaseStorage

           .Child(Login.Nome_Academia_login)
           .Child("Foto_Perfil")
           .Child(cadastro_aluno.Key)
           .PutAsync(fileStream);
        }

        public async Task Cadastrar_Aluno_WEB(Aluno aluno)
        {
            //passar aqui o nome da academia para se cadastrar. No moento estou passando só o angelos para teste
            var cadastro_aluno = await firebase
               .Child("Academias")
               .Child("Angelos")
               .Child("Aluno")
              .PostAsync(new Aluno()
              {
                  Id_Aluno = aluno.Id_Aluno,
                  Nome = aluno.Nome,
                  Email = aluno.Email,
                  Senha = aluno.Senha,
                  Peso = aluno.Peso,
                  Altura = aluno.Altura,
                  Idade = aluno.Idade,
                  objetivo_Aluno = aluno.objetivo_Aluno,
                  Foto_Aluno = aluno.Foto_Aluno,
                  Situacao = aluno.Situacao
              });
            string id_cadastroalunoKEY = cadastro_aluno.Key;

            var alterar_alunoID = (await firebase
             .Child("Academias")
             .Child("Angelos")
             .Child("Aluno")
             .OnceAsync<Aluno>()).Where(a => a.Object.Id_Aluno == id_cadastroalunoKEY).FirstOrDefault();

            await firebase
              .Child("Academias")
              .Child("Angelos")
              .Child("Aluno")
              .Child(id_cadastroalunoKEY)
              .PutAsync(new Aluno()
              {
                  Id_Aluno = id_cadastroalunoKEY,
                  Nome = aluno.Nome,
                  Email = aluno.Email,
                  Senha = aluno.Senha,
                  Peso = aluno.Peso,
                  Altura = aluno.Altura,
                  Idade = aluno.Idade,
                  objetivo_Aluno = aluno.objetivo_Aluno,
                  Foto_Aluno = id_cadastroalunoKEY,
                  Situacao = aluno.Situacao
              });
            //var imageUrl = await firebaseStorage

           //.Child("Angelos")
           //.Child("Foto_Perfil")
           //.Child(cadastro_aluno.Key)
           //.PutAsync(null);
        }

        //Busca serie aluno e coloca dados em campos de dados ver implementacao -BORA
        //retona os detalhaes do exercicio da serie.
        // esta tabela possui o ID do exercicio vinculado a estas inf
        public async Task<Exercicios_Serie> Busca_Exercicio_SERIE_ALUNO(string id_serie)
        {
            Exercicios_Serie_DAO exercicios_Serie_DAO = new Exercicios_Serie_DAO();
            var exercicios_serie = await exercicios_Serie_DAO.Busca_Exercicios_Serie();
            await firebase
              .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Exercicios_Serie_DAO")
              .OnceAsync<Exercicios_Serie_DAO>();
            return exercicios_serie.Where(a => a.Id_Serie.Equals( id_serie)).FirstOrDefault();
        }

        public async Task<Aluno> Busca_Dados_Aluno_Para_carregar_Tela_Alterar(string id_alunoAlterar)
        {
            var aluno = await Busca_Aluno();
            await firebase
                .Child("Aluno")
              .OnceAsync<Aluno>();
            return aluno.Where(a => a.Id_Aluno == id_alunoAlterar).FirstOrDefault();

        }
        public async Task<Aluno> Busca_Dados_Aluno_Por_Email(string email, string academia)
        {

            //busca o aluno pelo email para pode enviar um email para alterar a senha
            var aluno = await Busca_Aluno_Por_nome_Academia_Enviar_Email(academia);
            await firebase
                .Child("Academias")
                .Child(academia)
                .Child("Aluno")
              .OnceAsync<Aluno>();
            return aluno.Where(a => a.Email == email).FirstOrDefault();

        }

        public async Task<Aluno> Verefica_Se_Email_Ja_Cadastrado_Academia(string email)
        {
   
            var aluno = await Busca_Aluno_Por_nome_Academia_Enviar_Email(Login.Nome_Academia_login);
            await firebase
                .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Aluno")
              .OnceAsync<Aluno>();
            return aluno.Where(a => a.Email == email).FirstOrDefault();
        }

            //Pesquisa da serie do aluno retorna a serie que tiver o ID do aluno, este id
            //de serie que vier no retono é necessario para busca os exercicios  da serie --BORA
            public async Task<Serie> Busca_Serie_Aluno(string idserie)
             {
            SerieDAO Serie_DAO = new SerieDAO();
            var serie = await Serie_DAO.Busca_Serie();
            await firebase
              .Child("Academias")
                .Child(Login.Nome_Academia_login)
                .Child("Serie")
              .OnceAsync<Serie>();
            return serie.Where(a => a.Id_Serie == idserie).FirstOrDefault();
        }

        public async Task AlterarALUNO(string idAluno, Aluno aluno)
        {
            var alunoAlterar = (await firebase
               .Child("Academias")
               .Child(Login.Nome_Academia_login)
               .Child("Aluno")
              .OnceAsync<Aluno>()).Where(a => a.Object.Id_Aluno == idAluno).FirstOrDefault();

            await firebase
              .Child("Academias")
              .Child(Login.Nome_Academia_login)
               .Child("Aluno")
              .Child(alunoAlterar.Key)
              .PutAsync(new Aluno()
              {
                  Id_Aluno = alunoAlterar.Key,
                  Nome = aluno.Nome,
                  Email = aluno.Email,
                  Senha = aluno.Senha,
                  Peso = aluno.Peso,
                  Altura = aluno.Altura,
                  Idade = aluno.Idade,
                  objetivo_Aluno = aluno.objetivo_Aluno,
                  Foto_Aluno=aluno.Foto_Aluno,
                  Situacao = aluno.Situacao
              });
        }

        public async Task Aterar_senha(string email, string novasenha,string academia)
        {

            var aluno = await  Busca_Dados_Aluno_Por_Email(email, academia);

            var alunoAlterar = (await firebase
               .Child("Academias")
               .Child(academia)
               .Child("Aluno")
              .OnceAsync<Aluno>()).Where(a => a.Object.Email == email).FirstOrDefault();


            await firebase
              .Child("Academias")
              .Child(academia)
               .Child("Aluno")
              .Child(alunoAlterar.Key)
              .PutAsync(new Aluno()
              {
                  Id_Aluno = aluno.Id_Aluno,
                  Nome = aluno.Nome,
                  Email = aluno.Email,
                  Senha = novasenha,
                  Peso = aluno.Peso,
                  Altura = aluno.Altura,
                  Idade = aluno.Idade,
                  objetivo_Aluno = aluno.objetivo_Aluno,
                  Situacao = aluno.Situacao
              });

        }

        public async Task<Aluno> Login_Aluno(string email, string senha)//troquei pra logar com email
        {
            try
            {
                var aluno = await Busca_Aluno();
                await firebase
                 .Child("Academias")
                .Child(Login.Nome_Academia_login)
                    .Child("Aluno")
                  .OnceAsync<Aluno>();
                return aluno.Where(a => a.Email == email && a.Senha == senha).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<string> Buscar_IMAGEM_Perfil_Aluno(string id_Aluno)
        {
            return await firebaseStorage
                .Child(Login.Nome_Academia_login)
                .Child("Foto_Perfil")
                .Child(id_Aluno)
                .GetDownloadUrlAsync();
        }
        public async Task Alterar_Foto_Perfil(string id_Aluno_Alterar_Foto, Stream fileStream)
        {

           var imageUrl = await firebaseStorage
          .Child(Login.Nome_Academia_login)
          .Child("Foto_Perfil")
          .Child(id_Aluno_Alterar_Foto)
          .PutAsync(fileStream);
        }
    }
}