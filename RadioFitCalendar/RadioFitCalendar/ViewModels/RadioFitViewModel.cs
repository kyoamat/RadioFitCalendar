using RadioFitCalendar.Models;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RadioFitCalendar.ViewModels
{
    public class RadioFitViewModel : BaseViewModel
    {
        public RadioFitViewModel()
        {
            Title = "ラジオ体操";

            OpenRadioFit1Command = new Command(async () =>
            {
                await Browser.OpenAsync("https://www.youtube.com/watch?v=feSVtC1BSeQ");
                if (_isCompletedRadio1 == false)
                {
                    await DataStore.AddAsync(new Achievement { Id = Guid.NewGuid().ToString(), Type = 1, Date = DateTime.Now.ToString("yyyy-MM-dd") });
                    Radio1Image = ImageSource.FromResource("RadioFitCalendar.Images.complete.png");
                    Radio1Text = TextCompletedRadio1;
                    _isCompletedRadio1 = true;
                }
            });
            OpenRadioFit2Command = new Command(async () =>
            {
                await Browser.OpenAsync("https://www.youtube.com/watch?v=dzQIMo-Xvyg");
                if (_isCompletedRadio2 == false)
                {
                    await DataStore.AddAsync(new Achievement { Id = Guid.NewGuid().ToString(), Type = 2, Date = DateTime.Now.ToString("yyyy-MM-dd") });
                    Radio2Image = ImageSource.FromResource("RadioFitCalendar.Images.complete.png");
                    Radio2Text = TextCompletedRadio2;
                    _isCompletedRadio2 = true;
                }
            });

            var nowDate = DateTime.Now.ToString("yyyy-MM-dd");
            _isCompletedRadio1 = DataStore.GetAsync(1, nowDate).Result != null;
            _isCompletedRadio2 = DataStore.GetAsync(2, nowDate).Result != null;
            Radio1Text = _isCompletedRadio1 ? TextCompletedRadio1 : TextNotCompletedRadio1;
            Radio2Text = _isCompletedRadio2 ? TextCompletedRadio2 : TextNotCompletedRadio2;
            Radio1Image = _isCompletedRadio1 ? ImageSource.FromResource("RadioFitCalendar.Images.complete.png") : ImageSource.FromResource("RadioFitCalendar.Images.notComplete.png");
            Radio2Image = _isCompletedRadio2 ? ImageSource.FromResource("RadioFitCalendar.Images.complete.png") : ImageSource.FromResource("RadioFitCalendar.Images.notComplete.png");

            Radio1ButtonLabel = "ラジオ体操第一を再生";
            Radio2ButtonLabel = "ラジオ体操第二を再生";
        }

        public ICommand OpenRadioFit1Command { get; }

        public ICommand OpenRadioFit2Command { get; }

        private string _radio1Text;
        public string Radio1Text 
        { 
            get => _radio1Text; 
            set => SetProperty(ref _radio1Text, value); 
        }

        private string _radio2Text;
        public string Radio2Text 
        { 
            get => _radio2Text; 
            set => SetProperty(ref _radio2Text, value); 
        }

        public string Radio1ButtonLabel { get; }

        public string Radio2ButtonLabel { get; }

        private ImageSource _radio1Image;
        public ImageSource Radio1Image 
        { 
            get => _radio1Image;
            set => SetProperty(ref _radio1Image, value);
        }

        private ImageSource _radio2Image;
        public ImageSource Radio2Image 
        { 
            get => _radio2Image;
            set => SetProperty(ref _radio2Image, value);
        }

        private const string TextNotCompletedRadio1 = "ラジオ体操第一をはじめましょう！";
        private const string TextNotCompletedRadio2 = "ラジオ体操第二をはじめましょう！";
        private const string TextCompletedRadio1 = "今日はラジオ体操第一をやりました！";
        private const string TextCompletedRadio2 = "今日はラジオ体操第二をやりました！";

        private bool _isCompletedRadio1 { get; set; }
        private bool _isCompletedRadio2 { get; set; }
    }
}