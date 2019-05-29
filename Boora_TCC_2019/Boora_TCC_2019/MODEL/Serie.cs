using System;
using System.Collections.Generic;
using System.Text;

namespace Boora_TCC_2019.MODEL
{
    public class Serie
    {
        public int Id_Serie { get; set; }
        public int Id_Aluno { get; set; }
        public string Nome_Serie { get; set; }
        public string Data_Inicio { get; set; }
        public string Data_Fim { get; set; }
        public string Descricao_Serie { get; set; }

       

        /*public List<Serie> gerar_dados()
        {
            Serie serie = new Serie();
            this.Nome_Exercicio = "Supino Reto";
            this.Peso_Aluno = "25";
            this.Qtd_repeticoes = 12;
            this.Qtd_Vezes = 3;
            this.Url_Imagem = "SupinoReto.gif";
            this.Descricao_Exercicio = "Peito Trincado";
            lista.Add(serie);

            Serie serie1 = new Serie();
            Nome_Exercicio = "Supino Inclinado";
            Peso_Aluno = "25";
            Qtd_repeticoes = 12;
            Qtd_Vezes = 3;
            Url_Imagem = "Logo_Boora.png";
            Descricao_Exercicio = "Peito Malhado";
            lista.Add(serie1);

            Serie serie2 = new Serie();
            Nome_Exercicio = "Supino Declinado";
            Peso_Aluno = "25";
            Qtd_repeticoes = 12;
            Qtd_Vezes = 3;
            Url_Imagem = "SupinoReto.gif";
            Descricao_Exercicio = "Peito Peito";
            lista.Add(serie2);

            return lista;

        }*/

    }

}
