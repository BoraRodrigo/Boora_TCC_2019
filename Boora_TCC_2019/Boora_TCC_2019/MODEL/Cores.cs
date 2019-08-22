using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Boora_TCC_2019.MODEL
{
    [Table("Cores")]
    public class Cores
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string CorLabel { get; set; }
        public string CorStackLayout { get; set; }

    }
}
