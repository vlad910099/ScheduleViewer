using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDUNT_TimeTable;
using UDUNT_TimeTable.Services;
using Xamarin.Forms;

namespace UDUNT_TimeTable
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            Ilogo.Source = ImageSource.FromResource("UDUNT-TimeTable.Images.logo_udunt.png");

            var scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();
            var availableScheduleNames = await scheduleService.GetAvailableScheduleNames();

            listView.ItemsSource = availableScheduleNames;
        }
        private async void Schedule_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();
            var availableScheduleNames = await scheduleService.GetAvailableScheduleNames();

            if (e.SelectedItem != null && availableScheduleNames[0]!= null && e.SelectedItem.ToString() == availableScheduleNames[0])
                await Navigation.PushAsync(new Shcedule(e.SelectedItem.ToString()));
            else if(e.SelectedItem != null && availableScheduleNames[1] != null && e.SelectedItem.ToString() == availableScheduleNames[1])
                await Navigation.PushAsync(new ShcMK1());
        }

        //private async void BSchedule_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Shcedule());
        //}
        private async void BScheduleMK1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShcMK1());
        }
    }
}
