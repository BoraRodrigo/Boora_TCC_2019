using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Boora_TCC_2019.MODEL;
using Xamarin.Forms;

namespace Boora_TCC_2019.BancoSQlite
{
    public class Db_SqlLite
    {
        private SQLiteConnection _conexao;

        public Db_SqlLite()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");
            _conexao = new SQLiteConnection(caminho);

            _conexao.CreateTable<Cores>();
            _conexao.CreateTable<Acessar>();

        }

        public List<Cores> Consultar()
        {
            return _conexao.Table<Cores>().ToList();
        }

        public void Salvar(Cores cores)
        {
            _conexao.Insert(cores);
        }

        public void Alterar(Cores cores)
        {
            _conexao.Update(cores);
        }
        public void Excluir(Cores cores)
        {
            _conexao.Delete(cores);
        }

        public List<Acessar> Consultar_Logins()
        {
            return _conexao.Table<Acessar>().ToList();
        }

        public void Salvar_Login(Acessar acessar)
        {
            _conexao.Insert(acessar);
        }

        public void Alterar_Login(Acessar acessar)
        {
            _conexao.Update(acessar);
        }
        public void Excluir_Login(Acessar acessar)
        {
            _conexao.Delete(acessar);
        }
    }
}
