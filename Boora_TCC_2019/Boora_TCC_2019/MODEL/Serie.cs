using System;
using System.Collections.Generic;
using System.Text;

namespace Boora_TCC_2019.MODEL
{
    public class Serie
    {
        public int Id_Serie { get; set; }
        public int Id_Aluno { get; set; }
        public int Id_Exercicio { get; set; }

        public int Qtd_repeticoes { get; set; }
        public DateTime Tempo_Minimo { get; set; }
        public DateTime Tempo_Maximo { get; set; }
        public DateTime Tempo_Execucao { get; set; }

        public string Obs_Instrutor { get; set; }
        public string Obs_Aluno { get; set; }

        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Fim { get; set; }
    }

}
