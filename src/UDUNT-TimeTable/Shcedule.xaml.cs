using Domain;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UDUNT_TimeTable.Persistence.InMemory;
using UDUNT_TimeTable.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace UDUNT_TimeTable
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Shcedule : ContentPage
	{
        public string ScheduleName;
        public const int MaxWeekday = 5;
        public const int MaxNumber = 6;
        public Shcedule (string scheduleName)
		{
			InitializeComponent();
            ScheduleName = scheduleName;
            //Shcedule schedule = new Shcedule(null);
            //schedule.Title = scheduleName;

        }

        protected override async void OnAppearing()
		{
            var scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();

            var avaibleGroup = await scheduleService.GetGroups();
            foreach (var groups in avaibleGroup)
            {
                pickerGroup.Items.Add(groups);
            }

            var avaibleTeacher = await scheduleService.GetTeachers();
            foreach (var teachers in avaibleTeacher)
            {
                pickerTeacher.Items.Add(teachers);
            }
        }


        private async void viewScheduleGroup(string group)
        {

            StackLayout[,] SLs = new StackLayout[,]
            {
                {SL11, SL12, SL13, SL14, SL15, SL16},
                {SL21, SL22, SL23, SL24, SL25, SL26},
                {SL31, SL32, SL33, SL34, SL35, SL36},
                {SL41, SL42, SL43, SL44, SL45, SL46},
                {SL51, SL52, SL53, SL54, SL55, SL56}
            };
            cleanSL(SLs);

            Label labelS, labelT, labelR = null;
            Label labelSeparator = new Label();
            labelSeparator.Text = "----------------------------------------------------------------";

            var scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();
            var searchCriteriaGroup = new SearchCriteria(ScheduleName, null, group);
            var avaibleSchedueforGroup = await scheduleService.GetClasses(searchCriteriaGroup);
            foreach (var schedulForGroup in avaibleSchedueforGroup)
            {
                int weekDayCounter = 1;
                while (weekDayCounter <= MaxWeekday)
                {
                    if (schedulForGroup.WeekDay == weekDayCounter)
                    {
                        int numberCounter = 1;
                        while (numberCounter <= MaxNumber)
                        {
                            if (schedulForGroup.Number == numberCounter)
                            {
                                if ((int)schedulForGroup.WeekType != 0)
                                {
                                    if ((int)schedulForGroup.WeekType == 2)
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelSeparator);

                                    labelS = new Label();
                                    labelS.Text = schedulForGroup.Subject;
                                    labelT = new Label();
                                    labelT.Text = schedulForGroup.Teacher.Name;
                                    labelR = new Label();
                                    labelR.Text = "ауд." + schedulForGroup.Room;

                                    labelS.FontSize = 18; labelS.FontAttributes = FontAttributes.Bold;
                                    labelT.FontSize = 18; labelT.FontAttributes = FontAttributes.Italic;
                                    labelR.FontSize = 16; //labelG.FontAttributes = FontAttributes.Italic;

                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelS);
                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelT);
                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelR);
                                }
    
                                else 
                                {
                                    labelS = new Label();
                                    labelS.Text = schedulForGroup.Subject;
                                    labelT = new Label();
                                    labelT.Text = schedulForGroup.Teacher.Name;
                                    labelR = new Label();
                                    labelR.Text = "ауд." + schedulForGroup.Room;

                                    labelS.FontSize = 18; labelS.FontAttributes = FontAttributes.Bold;
                                    labelT.FontSize = 18; labelT.FontAttributes = FontAttributes.Italic;
                                    labelR.FontSize = 16; //labelG.FontAttributes = FontAttributes.Italic;

                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelS);
                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelT);
                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelR);
                                }
                            }
                            numberCounter++;
                        }
                    }
                    weekDayCounter++;
                }
            }
        }

        private async void viewScheduleTeacher(string teacher)
        {
            StackLayout[,] SLs = new StackLayout[,]
            {
                {SL11, SL12, SL13, SL14, SL15, SL16},
                {SL21, SL22, SL23, SL24, SL25, SL26},
                {SL31, SL32, SL33, SL34, SL35, SL36},
                {SL41, SL42, SL43, SL44, SL45, SL46},
                {SL51, SL52, SL53, SL54, SL55, SL56}
            };
            cleanSL(SLs);

            Label labelS, labelG, labelR = null;
            Label labelSeparator = new Label();
            labelSeparator.Text = "----------------------------------------------------------------";

            var scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();
            var searchCriteriaTeacher = new SearchCriteria(ScheduleName, teacher, null);
            var avaibleSchedueforTeacher = await scheduleService.GetClasses(searchCriteriaTeacher);
            foreach (var schedulForTeacher in avaibleSchedueforTeacher)
            {
                int weekDayCounter = 1;
                while (weekDayCounter <= MaxWeekday)
                {
                    if (schedulForTeacher.WeekDay == weekDayCounter)
                    {
                        int numberCounter = 1;
                        while (numberCounter <= MaxNumber)
                        {
                            if (schedulForTeacher.Number == numberCounter)
                            {
                                if ((int)schedulForTeacher.WeekType != 0)
                                {
                                    if ((int)schedulForTeacher.WeekType == 2)
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelSeparator);

                                    labelS = new Label();
                                    labelS.Text = schedulForTeacher.Subject;
                                    labelG = new Label();
                                    labelG.Text = schedulForTeacher.Group.Name;
                                    labelR = new Label();
                                    labelR.Text = "ауд." + schedulForTeacher.Room;

                                    labelS.FontSize = 18; labelS.FontAttributes = FontAttributes.Bold;
                                    labelG.FontSize = 18; labelG.FontAttributes = FontAttributes.Italic;
                                    labelR.FontSize = 16; //labelG.FontAttributes = FontAttributes.Italic;

                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelS);
                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelR);
                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelG);
                                }

                                else
                                {
                                    labelS = new Label();
                                    labelS.Text = schedulForTeacher.Subject;
                                    labelG = new Label();
                                    labelG.Text = schedulForTeacher.Group.Name;
                                    labelR = new Label();
                                    labelR.Text = "ауд." + schedulForTeacher.Room;

                                    labelS.FontSize = 18; labelS.FontAttributes = FontAttributes.Bold;
                                    labelG.FontSize = 18; labelG.FontAttributes = FontAttributes.Italic;
                                    labelR.FontSize = 16; //labelG.FontAttributes = FontAttributes.Italic;

                                    if (SLs[weekDayCounter - 1, numberCounter - 1].Children.Count == 0)
                                    {
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelS);
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelR);
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelG);
                                    }
                                    else
                                    {
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelG);
                                    }
                                }
                            }
                            
                            numberCounter++;
                        }
                    }
                    weekDayCounter++;
                }
            }
           
        }

        public void cleanSL(StackLayout[,] SLs )
        {
            int weekDayCounter = 1;
            while (weekDayCounter <= MaxWeekday)
            {
                int numberCounter = 1;
                while (numberCounter <= MaxNumber)
                {
                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Clear();
                    numberCounter++;
                }
                weekDayCounter++;
            }  
        }
        public async void SelectedviewScheduleGroup()
        {
            var scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();
            var avaibleGroup = await scheduleService.GetGroups();
            if (pickerGroup.SelectedItem != null)
                foreach (var group in avaibleGroup)
                {
                    if (pickerGroup.Items[pickerGroup.SelectedIndex] == group)
                    {
                        viewScheduleGroup(group);
                        break;
                    }
                }
        
        }
        public async void SelectedviewScheduleTeacher()
        {
            var scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();
            var avaibleTeachers = await scheduleService.GetTeachers();
            if (pickerTeacher.SelectedItem != null)
                foreach (var teacher in avaibleTeachers)
                {
                    if (pickerTeacher.Items[pickerTeacher.SelectedIndex] == teacher)
                    {
                        viewScheduleTeacher(teacher);
                        break;
                    }
                }
        }

        public void picker_SelectedIndexChangedG(object sender, EventArgs e)
        {
            if (RadioGroup.IsChecked)
            {
                SelectedviewScheduleGroup();
            }
        }

        public void picker_SelectedIndexChangedT(object sender, EventArgs e)
        {
            if (RadioTeacher.IsChecked)
            {
                SelectedviewScheduleTeacher();
            }
        }

        private void OnCheckMonday(object sender, CheckedChangedEventArgs e)
        {
            if(checkMonday.IsChecked)
                frameViewMonday.IsVisible = true;
            else frameViewMonday.IsVisible = false;
        }
        private void OnCheckTuesday(object sender, CheckedChangedEventArgs e)
        {
            if (checkTuesday.IsChecked)
                frameViewTuesday.IsVisible = true;
            else frameViewTuesday.IsVisible = false;
        }
        private void OnCheckWednesday(object sender, CheckedChangedEventArgs e)
        {
            if (checkWednesday.IsChecked)
                frameViewWednesday.IsVisible = true;
            else frameViewWednesday.IsVisible = false;
        }
        private void OnCheckThursday(object sender, CheckedChangedEventArgs e)
        {
            if (checkThursday.IsChecked)
                frameViewThursday.IsVisible = true;
            else frameViewThursday.IsVisible = false;
        }
        private void OnCheckFriday(object sender, CheckedChangedEventArgs e)
        {
            if (checkFriday.IsChecked)
                frameViewFriday.IsVisible = true;
            else frameViewFriday.IsVisible = false;
        }

        private void Radio_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            
            if (RadioGroup.IsChecked)
            {
                pickerGroup.IsVisible = true;
                pickerTeacher.IsVisible = false;
                SelectedviewScheduleGroup();
            }
            else
            {
                pickerGroup.IsVisible = false;
                pickerTeacher.IsVisible = true;
                SelectedviewScheduleTeacher();
            }
        }

    }
}