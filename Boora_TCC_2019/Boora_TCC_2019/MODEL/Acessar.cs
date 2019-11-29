using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Boora_TCC_2019.MODEL
{
    [Table("Acessar")]
    public class Acessar
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Academia { get; set; }
        public string Tipo { get; set; }
        public int salvar_Dados { get; set; }

    }
}
