
using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using Boora_TCC_2019.TELAS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ScheduleSimpleSample
{
    public class ViewModel_Calendario : ContentPage
    {
        public ObservableCollection<Meeting> Meetings { get; set; }
        public ObservableCollection<Meeting> Meetings_Incicio { get; set; }
        public ViewModel_Calendario()
        {
            Meetings = new ObservableCollection<Meeting>();
            Meetings_Incicio = new ObservableCollection<Meeting>();

            CreateAppointmentsAsync();
        }

        /// <summary>
        /// abaixo aqui listo todas as atividades do aluno dentro do calendario
        /// o modo de exibicão do calendario pode ser alterado
        /// a classe view é uma classe aleatoria que estava no outro projeto e usei ele pq tava dando pau sem ela 
        /// </summary>
        public  async System.Threading.Tasks.Task CreateAppointmentsAsync()
        {

            Login login = new Login();
            Controle_Dia_DAO dias_Academia = new Controle_Dia_DAO();
            List<Controle_Dia> listaDia = new List<Controle_Dia>();
            listaDia = await dias_Academia.Busca_Todas__Dias_Do_Aluno(Login.Id_Aluno_Login);

            Console.WriteLine(listaDia[0].Nome_serie);

            for (int i = 0; i < listaDia.Count; i++)
            {
                DateTime marcarAQUI = Convert.ToDateTime(listaDia[i].Data_Presenca.ToString());

                            Meeting meeting = new Meeting();
                            meeting.From = new DateTime(marcarAQUI.Year, marcarAQUI.Month, marcarAQUI.Day, DateTime.Now.Hour, 0, 0);
                            meeting.To = (meeting.From.AddHours(1));
                            meeting.EventName = listaDia[i].Nome_serie;//passo o nome da serie
                            meeting.color = (Color.FromHex("#FFc800"));//cor do prenchimento FF339933
                            meeting.BackgroundColor = Color.FromHex("ffc800");
                            meeting.AllDay = true;
                            Meetings.Add(meeting);//adiciona os elementos no calendario é chamado no calendario.xaml
            }
            List<Serie> lista_Serie = new List<Serie>();
            Exercicios_Serie_DAO exercicios_Serie_DAO = new Exercicios_Serie_DAO();
            lista_Serie = await exercicios_Serie_DAO.Busca_Todas__Series_Aluno(Login.Id_Aluno_Login);

            for (int i = 0; i < lista_Serie.Count; i++)
            {
                DateTime marcarAQUI_Inicio = Convert.ToDateTime(lista_Serie[i].Data_Inicio.ToString());
                Meeting meetingg = new Meeting();
                meetingg.From = new DateTime(marcarAQUI_Inicio.Year, marcarAQUI_Inicio.Month, marcarAQUI_Inicio.Day, DateTime.Now.Hour, 0, 0);
                meetingg.To = (meetingg.From.AddHours(1));
                meetingg.EventName = "Incio da serie " + lista_Serie[i].Nome_Serie.ToUpper();//passo o nome da serie
                meetingg.color = (Color.FromHex("#00ff00"));//cor do prenchimento FF339933
                meetingg.BackgroundColor = Color.FromHex("#00ff00");
                meetingg.AllDay = false;
                Meetings.Add(meetingg);//adiciona os elementos no calendario é chamado no calendario.xaml
            }
            for (int i = 0; i < lista_Serie.Count; i++)
            {
                DateTime marcarAQUI_FIM = Convert.ToDateTime(lista_Serie[i].Data_Fim.ToString());
                Meeting meetinggg = new Meeting();
                meetinggg.From = new DateTime(marcarAQUI_FIM.Year, marcarAQUI_FIM.Month, marcarAQUI_FIM.Day, DateTime.Now.Hour, 0, 0);
                meetinggg.To = (meetinggg.From.AddHours(1));
                meetinggg.EventName = "Troca da serie prevista. " + lista_Serie[i].Nome_Serie.ToUpper();//passo o nome da serie
                meetinggg.color = (Color.FromHex("#ff0000"));//cor do prenchimento FF339933
                meetinggg.BackgroundColor = Color.FromHex("#ff0000");
                meetinggg.AllDay = false;
                Meetings.Add(meetinggg);//adiciona os elementos no calendario é chamado no calendario.xaml
            }
        }
    }
}

