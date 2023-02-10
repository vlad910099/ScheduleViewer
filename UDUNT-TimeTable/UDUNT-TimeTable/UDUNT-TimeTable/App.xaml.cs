using System;
using UDUNT_TimeTable.Services;
using UDUNT_TimeTable.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UDUNT_TimeTable
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
