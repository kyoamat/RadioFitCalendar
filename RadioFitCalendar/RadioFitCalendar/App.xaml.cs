using RadioFitCalendar.Models;
using RadioFitCalendar.Services;
using RadioFitCalendar.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RadioFitCalendar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton<IDataStore<Achievement>>(
                new AchievementDataStore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "achieve.db")));
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
