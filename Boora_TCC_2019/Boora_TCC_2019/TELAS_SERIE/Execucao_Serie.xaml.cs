﻿using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.TELAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Boora_TCC_2019.TELAS_SERIE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Execucao_Serie : ContentPage
    {
        private bool zerar = false;
        private int _vezesTimer;
        private int i = 0;
        AlunoDAO alunoDAO = new AlunoDAO();
        ExercicioDAO exercicioDAO = new ExercicioDAO();
        Exercicios_Serie_DAO exercicios_Serie_DAO = new Exercicios_Serie_DAO();
        List<Exercicios_Serie> listaExercicio = new List<Exercicios_Serie>();
        //comentario

        //mandando o id da serie por parametro no construtor
        static string IdSerie;

        Exercicio exe;
        public Execucao_Serie(Exercicio exercicio, string id)
        {
            InitializeComponent();
            IdSerie = id;
            exe = exercicio;

        }

        protected async override void OnAppearing()

        {
            SlCarregando.IsVisible = true;
            await Exercicio_Pelo_List(exe);
            base.OnAppearing();
            SlCarregando.IsVisible = false;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (zerar == false)
            {
                zerar = true;
                i++;
            }
            else
            {
                zerar = false;
            }
            
            RepeticoesRealizadas.Text = (i + "/" + txtREPETICOES.Text + " Repetições Realizadas");
            
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                //Entry.Text = tempo(++_vezesTimer);

                btn_cronometro.Text = tempo(++_vezesTimer);
                if (zerar == false)
                {
                  //  Entry.Text = "Iniciar Cronômetro";
                    btn_cronometro.Text = "Iniciar Cronômetro";
                    _vezesTimer = 0;

                }
                return zerar;

            });

        }
        public async Task Exercicio_Pelo_List(Exercicio exercicio)
        {
            Login login = new Login();
            var alunoLogado = await alunoDAO.Login_Aluno(Login.Email_Aluno_Logado, Login.Senha_Aluno_Logado);/////////////////// mudar aqui em casa para static enviar email
            var seriealuno = await alunoDAO.Busca_Serie_Aluno(IdSerie);

            listaExercicio = await exercicios_Serie_DAO.Busca_Exercicios_Serie_DA_SERIE(IdSerie);
           
            var todosexercicio = await alunoDAO.Busca_Exercicio_SERIE_ALUNO(alunoLogado.Id_Aluno);

           
            txtNomeALUNO.Text = alunoLogado.Nome.ToUpper() + "!";
            txtnomedaSerie.Text = seriealuno.Nome_Serie;
            txtNOMEEXERCICIO.Text = Convert.ToString(exercicio.Nome);
            txtQTDVEZES.Text = Convert.ToString(exercicio.Exercicios_Serie.Qtd_Vezes);
            txtREPETICOES.Text = Convert.ToString(exercicio.Exercicios_Serie.Qtd_repeticoes);
            txtOBJTIVOEXERCICIO.Text = exercicio.Objetivo;
            txt_Peso.Text = exercicio.Exercicios_Serie.Peso.ToString();
            if (Device.RuntimePlatform == Device.UWP)
            {
                imgbaixadaW.Source = await exercicioDAO.Buscar_IMAGEM(Convert.ToString(exe.Id_exercicio));
                imgbaixadaM.IsVisible = false;
            }
            else
            {
                imgbaixadaM.Source = await exercicioDAO.Buscar_IMAGEM(Convert.ToString(exe.Id_exercicio));
                imgbaixadaW.IsVisible = false;
            }
        }

        public string tempo(int Tempo)
        {
            int Horas, Minutos, Segundos;
            string result = "";
            Horas = Tempo / 3600;
            Minutos = Tempo % 3600 / 60;
            Segundos = Tempo % 60;
            result = "Descanso - " + Minutos + ":" + Segundos;
            return result;
        }

    }
}