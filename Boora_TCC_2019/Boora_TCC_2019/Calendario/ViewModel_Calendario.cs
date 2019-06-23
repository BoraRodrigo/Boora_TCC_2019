
using Boora_TCC_2019.DAO;
using Boora_TCC_2019.MODEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ScheduleSimpleSample
{
    public class ViewModel_Calendario : ContentPage
    {
        public ObservableCollection<Meeting> Meetings { get; set; }
        public ViewModel_Calendario()
        {
            Meetings = new ObservableCollection<Meeting>();


            CreateAppointmentsAsync();
        }
        /// <summary>
        /// abaixo aqui listo todas as atividades do aluno dentro do calendario
        /// o modo de exibicão do calendario pode ser alterado
        /// a classe view é uma classe aleatoria que estava no outro projeto e usei ele pq tava dando pau sem ela 
        /// </summary>
        private async System.Threading.Tasks.Task CreateAppointmentsAsync()
        {
            Controle_Dia_DAO dias_Academia = new Controle_Dia_DAO();
            List<Controle_Dia> listaDia = new List<Controle_Dia>();
            listaDia = await dias_Academia.Busca_Todas__Dias_Do_Aluno(1);

            Console.WriteLine(listaDia[0].Nome_serie);

            for (int i = 0; i < listaDia.Count; i++)
            {
                DateTime marcarAQUI = Convert.ToDateTime(listaDia[i].Data_Presenca.ToString());

                            Meeting meeting = new Meeting();
                            meeting.From = new DateTime(marcarAQUI.Year, marcarAQUI.Month, marcarAQUI.Day, DateTime.Now.Hour, 0, 0);
                            meeting.To = (meeting.From.AddHours(1));
                            meeting.EventName = listaDia[i].Nome_serie;//passo o nome da serie
                            meeting.color = (Color.FromHex("#FF339933"));//cor do prenchimento
                            meeting.AllDay = true;
                            Meetings.Add(meeting);//adiciona os elementos no calendario é chamado no calendario.xaml
            }
        }
    }
}

