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
        public readonly string ScheduleName;
        private readonly ScheduleService scheduleService;
        private const int maxWeekday = 5;
        private const int maxNumber = 6;
        public Shcedule (string scheduleName)
		{
			InitializeComponent();
            ScheduleName = scheduleName;
            scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();
        }

        protected override async void OnAppearing()
		{
            await InitializePickers();
        }

        private async Task InitializePickers()
        {
            var groups = await scheduleService.GetGroups();
            foreach (var groupName in groups)
            {
                pickerGroup.Items.Add(groupName);
            }

            var teachers = await scheduleService.GetTeachers();
            foreach (var teacherName in teachers)
            {
                pickerTeacher.Items.Add(teacherName);
            }
        }


        private async Task ViewScheduleGroup(string group)
        {

            StackLayout[,] SLs = new StackLayout[,]
            {
                {SL11, SL12, SL13, SL14, SL15, SL16},
                {SL21, SL22, SL23, SL24, SL25, SL26},
                {SL31, SL32, SL33, SL34, SL35, SL36},
                {SL41, SL42, SL43, SL44, SL45, SL46},
                {SL51, SL52, SL53, SL54, SL55, SL56}
            };
            CleanSL(SLs);

            var searchCriteria = new SearchCriteria(ScheduleName, null, group);
            var groupClasses = await scheduleService.GetClasses(searchCriteria);
            foreach (var groupClass in groupClasses)
            {
                int weekDayCounter = 1;
                while (weekDayCounter <= maxWeekday)
                {
                    if (groupClass.WeekDay == weekDayCounter)
                    {
                        int numberCounter = 1;
                        while (numberCounter <= maxNumber)
                        {
                            if (groupClass.Number == numberCounter)
                                ViewSubjectsGroup(SLs, groupClass, weekDayCounter, numberCounter);
                            numberCounter++;
                        }
                    }
                    weekDayCounter++;
                }
            }
        }
        public void ViewSubjectsGroup(StackLayout[,] SLs, Class groupClass, int weekDayCounter, int numberCounter)
        {
            Label labelSeparator = new Label();
            labelSeparator.Text = "----------------------------------------------------------------";
            StackLayout sl;
            BoxView box = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 90
            };
            if (groupClass.WeekType != WeekType.None)
            {
                if (groupClass.WeekType == WeekType.Numerator)
                {
                    sl = new StackLayout();
                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(sl);
                    ViewSubjectGroup(sl, groupClass, weekDayCounter, numberCounter);
                }
                else
                {
                    sl = new StackLayout();
                    if (SLs[weekDayCounter - 1, numberCounter - 1].Children.Count==0)
                    {
                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(box);
                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelSeparator);
                    }
                    else
                        SLs[weekDayCounter - 1, numberCounter - 1].Children.RemoveAt(2);
                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(sl);
                    ViewSubjectGroup(sl, groupClass, weekDayCounter, numberCounter);
                }
                if (SLs[weekDayCounter - 1, numberCounter - 1].Children.Count == 1)
                {
                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelSeparator);
                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(box);
                }
            }
            else
            {
                sl = new StackLayout();
                SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(sl);
                ViewSubjectGroup(sl, groupClass, weekDayCounter, numberCounter);
            }
        }

        public void ViewSubjectGroup(StackLayout sl, Class groupClass, int weekDayCounter, int numberCounter)
        {
            Label labelSubject = new Label();
            labelSubject.Text = groupClass.Subject;
            Label labelTeacher = new Label();
            labelTeacher.Text = groupClass.Teacher.Name;
            Label labelRoom = new Label();
            labelRoom.Text = "ауд." + groupClass.Room;

            labelSubject.FontSize = 18; labelSubject.FontAttributes = FontAttributes.Bold;
            labelTeacher.FontSize = 18; labelTeacher.FontAttributes = FontAttributes.Italic;
            labelRoom.FontSize = 16;

            sl.Children.Add(labelSubject);
            sl.Children.Add(labelTeacher);
            sl.Children.Add(labelRoom);
        }
        private async Task ViewScheduleTeacher(string teacher)
        {
            StackLayout[,] SLs = new StackLayout[,]
            {
                {SL11, SL12, SL13, SL14, SL15, SL16},
                {SL21, SL22, SL23, SL24, SL25, SL26},
                {SL31, SL32, SL33, SL34, SL35, SL36},
                {SL41, SL42, SL43, SL44, SL45, SL46},
                {SL51, SL52, SL53, SL54, SL55, SL56}
            };
            CleanSL(SLs);

            Label labelSubject, labelGroup, labelRoom = null;
            Label labelSeparator = new Label();
            labelSeparator.Text = "----------------------------------------------------------------";

            var searchCriteriaTeacher = new SearchCriteria(ScheduleName, teacher, null);
            var teacherClasses = await scheduleService.GetClasses(searchCriteriaTeacher);
            foreach (var teacherClass in teacherClasses)
            {
                int weekDayCounter = 1;
                while (weekDayCounter <= maxWeekday)
                {
                    if (teacherClass.WeekDay == weekDayCounter)
                    {
                        int numberCounter = 1;
                        while (numberCounter <= maxNumber)
                        {
                            if (teacherClass.Number == numberCounter)
                            {
                                if (teacherClass.WeekType != WeekType.None)
                                {
                                    if (teacherClass.WeekType == WeekType.Denominator)
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelSeparator);

                                    labelSubject = new Label();
                                    labelSubject.Text = teacherClass.Subject;
                                    labelGroup = new Label();
                                    labelGroup.Text = teacherClass.Group.Name;
                                    labelRoom = new Label();
                                    labelRoom.Text = "ауд." + teacherClass.Room;

                                    labelSubject.FontSize = 18; labelSubject.FontAttributes = FontAttributes.Bold;
                                    labelGroup.FontSize = 18; labelGroup.FontAttributes = FontAttributes.Italic;
                                    labelRoom.FontSize = 16; 

                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelSubject);
                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelRoom);
                                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelGroup);
                                }

                                else
                                {
                                    labelSubject = new Label();
                                    labelSubject.Text = teacherClass.Subject;
                                    labelGroup = new Label();
                                    labelGroup.Text = teacherClass.Group.Name;
                                    labelRoom = new Label();
                                    labelRoom.Text = "ауд." + teacherClass.Room;

                                    labelSubject.FontSize = 18; labelSubject.FontAttributes = FontAttributes.Bold;
                                    labelGroup.FontSize = 18; labelGroup.FontAttributes = FontAttributes.Italic;
                                    labelRoom.FontSize = 16; 

                                    if (SLs[weekDayCounter - 1, numberCounter - 1].Children.Count == 0)
                                    {
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelSubject);
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelRoom);
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelGroup);
                                    }
                                    else
                                    {
                                        SLs[weekDayCounter - 1, numberCounter - 1].Children.Add(labelGroup);
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

        public void CleanSL(StackLayout[,] SLs )
        {
            int weekDayCounter = 1;
            while (weekDayCounter <= maxWeekday)
            {
                int numberCounter = 1;
                while (numberCounter <= maxNumber)
                {
                    SLs[weekDayCounter - 1, numberCounter - 1].Children.Clear();
                    numberCounter++;
                }
                weekDayCounter++;
            }  
        }
        public async void SelectedviewScheduleGroup()
        {
            var  groups = await scheduleService.GetGroups();
            if (pickerGroup.SelectedItem != null)
                foreach (var groupName in  groups)
                {
                    if (pickerGroup.Items[pickerGroup.SelectedIndex] == groupName)
                    {
                        await ViewScheduleGroup(groupName);
                        break;
                    }
                }
        
        }
        public async void SelectedviewScheduleTeacher()
        {
            var teachers = await scheduleService.GetTeachers();
            if (pickerTeacher.SelectedItem != null)
                foreach (var teacherName in teachers)
                {
                    if (pickerTeacher.Items[pickerTeacher.SelectedIndex] == teacherName)
                    {
                        await ViewScheduleTeacher(teacherName);
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