﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boora_TCC_2019.MODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Boora_TCC_2019.DAO;

namespace Boora_TCC_2019.TELAS_CADASTRO
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewExercicios : ContentPage
	{
        ExercicioDAO exercicioDAO = new ExercicioDAO();
        private List<Exercicio> listaPesquisa { get; set; }
        private List<Exercicio> listaInterna { get; set; }
       
        public ListViewExercicios ()
		{
			InitializeComponent ();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listaInterna = await exercicioDAO.Busca_Exercicio();
            ListaExercicios.ItemsSource = listaInterna;

        }

        private async void BuscaRapida(Object sender, TextChangedEventArgs args)
        {
            listaInterna = await exercicioDAO.Busca_Exercicio();
            try
            {
                listaPesquisa = listaInterna.Where(a => a.Nome.Contains(args.NewTextValue)).ToList();
                string path = await exercicioDAO.Buscar_IMAGEM(listaPesquisa[0].Imagem_Gif);
                listaPesquisa[0].Imagem_Gif = path;

                ListaExercicios.ItemsSource = listaPesquisa;
            }
            catch
            {
                
            }

        }
        //Metodo que faz a busca da imagem do banco atraves de seu nome 
        //este metodo não esta sendo usado porem ele atualiza uma imagem atravez da busca
        public async void imagemExercicio(string nomeImagem)
        {
            string path = await exercicioDAO.Buscar_IMAGEM(nomeImagem);
            if (path != null)
            {
                //seta a imagem no campo imagem
                imagem_Exercicio_Selecionado.Source= path;
            }
        }
    }
}