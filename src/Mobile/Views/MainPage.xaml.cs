using Core.Services;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xamarin.Forms;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        private readonly ScheduleService scheduleService;
        private ScheduleInfo[] scheduleInfos;

        public MainPage()
        {
            InitializeComponent();
            scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();
        }

        protected override async void OnAppearing()
        {
            scheduleInfos = await scheduleService.GetScheduleInfos();
            listView.ItemsSource = scheduleInfos.Select(s => s.Name);
        }

        private async void onScheduleSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedScheduleName = e.SelectedItem.ToString();
            if (selectedScheduleName.Contains("Розклад занять") || selectedScheduleName.Contains("МК"))
            {
                var selectIndex = e.SelectedItemIndex;
                await scheduleService.LoadSchedule(scheduleInfos[selectIndex]);
                await Navigation.PushAsync(new SchedulePage(selectedScheduleName));
            }
            else
            {
                await DisplayAlert("Увага!", "Відображення даного розкладу знаходиться в розробці!", "OK");
            }
        }
    }
}