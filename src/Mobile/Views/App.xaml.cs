using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;

namespace Mobile
{
    public partial class App : Application
    {
        public App(Action<IServiceCollection> addPlatformSpecificServices)
        {
            InitializeComponent();

            Startup.Init(addPlatformSpecificServices);

            MainPage = new NavigationPage(new MainPage());
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