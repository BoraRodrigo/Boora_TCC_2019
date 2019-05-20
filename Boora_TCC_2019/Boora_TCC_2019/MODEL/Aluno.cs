using System;
using System.Collections.Generic;
using System.Text;

namespace Boora_TCC_2019.MODEL
{
   public  class Aluno
    {
        public int Id_Aluno { get; set; }
        public int Id_Serie { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
        public float Idade { get; set; }
        public string objetivo_Aluno { get; set; }
        public int Situacao { get; set; }

    }
}
