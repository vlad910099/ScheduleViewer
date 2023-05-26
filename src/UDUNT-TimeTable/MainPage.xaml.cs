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
        private ScheduleInfo[] availableScheduleNames;
       public MainPage()
        {
            InitializeComponent();
            scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();
        }

        protected override async void OnAppearing()
        {
            //Ilogo.Source = ImageSource.FromResource("UDUNT-TimeTable.Images.logo_udunt.png");

            availableScheduleNames = await scheduleService.GetSchedules();
            string[] schedules = new string[availableScheduleNames.Count()];
            
            for (int i = 0; i < availableScheduleNames.Length; i++)
                schedules[i] = availableScheduleNames[i].Name;

            listView.ItemsSource = schedules;
            
        }
        private async void onScheduleSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedScheduleName = e.SelectedItem.ToString();
            if (selectedScheduleName.Contains("Розклад занять") || selectedScheduleName.Contains("МК"))
            {
                var selectIndex = e.SelectedItemIndex;
                await scheduleService.LoadSchedule(availableScheduleNames[selectIndex]);
                await Navigation.PushAsync(new Schedule(selectedScheduleName));
            }
            else
                await DisplayAlert("Увага!", "Відображення даного розкладу знаходиться в розробці!", "OK");
            
        }
    }
}
