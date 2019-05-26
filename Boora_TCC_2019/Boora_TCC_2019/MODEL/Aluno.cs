using System;
using System.Collections.Generic;
using System.Text;

namespace Boora_TCC_2019.MODEL
{
   public  class Aluno
    {
        public int Id_Aluno { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Idade { get; set; }
        public string objetivo_Aluno { get; set; }
        public int Situacao { get; set; }

    }
}
