using System;
using System.Collections.Generic;
using System.Text;

namespace Boora_TCC_2019.MODEL
{
    public class Exercicios_Serie
    {
        public int Id_Exercicios_Serie { get; set; }
        public int Id_Serie { get; set; }
    
        public int Qtd_repeticoes { get; set; }
        public int Qtd_Vezes { get; set; }
        public string Tempo_Minimo { get; set; }
        public string Tempo_Maximo { get; set; }
        public string Tempo_Execucao { get; set; }
    }
}
