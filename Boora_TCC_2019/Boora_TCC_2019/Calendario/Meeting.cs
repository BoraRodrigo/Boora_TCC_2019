using System;

using Xamarin.Forms;

namespace ScheduleSimpleSample
{
    /// <summary>   
    /// Represents custom data properties.   
    /// </summary>  
    public class Meeting : ContentPage
    {
        //não uso essa classe era só o exemplo para poder integrar com o que eu queria.
        public string EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool AllDay { get; set; }
        public Color color { get; set; }
    }
}


