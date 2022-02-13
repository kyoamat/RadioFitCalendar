using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RadioFitCalendar.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        public CalendarViewModel()
        {
            Title = "カレンダー";
            var list = DataStore.GetListAsync().Result.Select(x => $"{x.Date}の{(x.Type == 1 ? "ラジオ体操第一" : "ラジオ体操第二")}");
            Test = string.Join("\n", list);
        }

        public string Test { get; }
    }
}