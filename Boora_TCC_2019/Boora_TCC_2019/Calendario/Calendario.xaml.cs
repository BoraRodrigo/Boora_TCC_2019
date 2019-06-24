using Syncfusion.SfSchedule.XForms;
using System;
using Xamarin.Forms;

namespace ScheduleSimpleSample
{
    public partial class ScheduleSimpleSamplePage : ContentPage
    {
        public ScheduleSimpleSamplePage()
        {

           
            InitializeComponent();

            //creating new instance for viewHeaderStyle
            ViewHeaderStyle viewHeaderStyle = new ViewHeaderStyle();
            viewHeaderStyle.BackgroundColor = Color.Black;
            viewHeaderStyle.DayTextColor = (Color.FromHex("#ffc800"));
            viewHeaderStyle.DayFontFamily = "Arial";
      
            schedule.ViewHeaderStyle = viewHeaderStyle;
      

            schedule.TimeZone = "GMT Standard Time";
        }
    }
}
