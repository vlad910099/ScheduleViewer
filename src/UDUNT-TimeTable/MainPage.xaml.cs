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
        private readonly ScheduleService scheduleService;
        public MainPage()
        {
            InitializeComponent();
            scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();
        }

        protected override async void OnAppearing()
        {
            Ilogo.Source = ImageSource.FromResource("UDUNT-TimeTable.Images.logo_udunt.png");

            var availableScheduleNames = await scheduleService.GetAvailableScheduleNames();

            listView.ItemsSource = availableScheduleNames;
        }
        private async void onScheduleSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var availableScheduleNames = await scheduleService.GetAvailableScheduleNames();

            if (e.SelectedItem != null && availableScheduleNames[0] != null && e.SelectedItem.ToString() == availableScheduleNames[0])
                await Navigation.PushAsync(new Schedule(e.SelectedItem.ToString()));
            else if (e.SelectedItem != null && availableScheduleNames[1] != null && e.SelectedItem.ToString() == availableScheduleNames[1])
                await Navigation.PushAsync(new ShcMK1());
        }
    }
}
