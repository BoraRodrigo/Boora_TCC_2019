using System;
using System.Collections.Generic;
using System.Text;

namespace Boora_TCC_2019.MODEL
{
   public  class Exercicio

    {
        public int Id_exercicio { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Objetivo { get; set; }
        public string Imagem_Gif { get; set; }
        public Exercicios_Serie Exercicios_Serie { get; set; }
    }
}
