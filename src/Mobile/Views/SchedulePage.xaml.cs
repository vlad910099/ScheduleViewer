using Core.Services;
using Domain;
using Domain.Enums;
using Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : ContentPage
    {
        private readonly ScheduleService scheduleService;
        private const int maxWeekday = 5;
        private const int maxNumber = 6;
        private StackLayout[,] sls;

        public readonly string scheduleName;

        public SchedulePage(string scheduleName)
        {
            InitializeComponent();

            this.scheduleName = scheduleName;
            scheduleService = Startup.ServiceProvider.GetService<ScheduleService>();

            sls = new StackLayout[,]
            {
                {monday_1Class_StackLayout, monday_2Class_StackLayout, monday_3Class_StackLayout, monday_4Class_StackLayout, monday_5Class_StackLayout, monday_6Class_StackLayout},
                {tuesday_1Class_StackLayout, tuesday_2Class_StackLayout, tuesday_3Class_StackLayout, tuesday_4Class_StackLayout, tuesday_5Class_StackLayout, tuesday_6Class_StackLayout},
                {wednesday_1Class_StackLayout, wednesday_2Class_StackLayout, wednesday_3Class_StackLayout, wednesday_4Class_StackLayout, wednesday_5Class_StackLayout, wednesday_6Class_StackLayout},
                {thursday_1Class_StackLayout, thursday_2Class_StackLayout, thursday_3Class_StackLayout, thursday_4Class_StackLayout, thursday_5Class_StackLayout, thursday_6Class_StackLayout},
                {friday_1Class_StackLayout, friday_2Class_StackLayout, friday_3Class_StackLayout, friday_4Class_StackLayout, friday_5Class_StackLayout, friday_6Class_StackLayout}
            };
        }

        protected override async void OnAppearing()
        {
            await InitializePickers();
        }

        private async Task InitializePickers()
        {
            var groups = await scheduleService.GetGroups(scheduleName);
            foreach (var groupName in groups)
            {
                groupPicker.Items.Add(groupName);
            }

            var teachers = await scheduleService.GetTeachers(scheduleName);
            foreach (var teacherName in teachers)
            {
                if (teacherName == "-")
                    continue;
                teacherPicker.Items.Add(teacherName);
            }
        }

        private async Task ViewScheduleGroup(string group)
        {
            CleanSL(sls);

            var searchCriteria = new SearchCriteria(scheduleName, null, group);
            var groupClasses = await scheduleService.GetClasses(searchCriteria);

            foreach (var groupClass in groupClasses)
            {
                for (int weekDayCounter = 1; weekDayCounter <= maxWeekday; weekDayCounter++)
                {
                    if (groupClass.WeekDay == weekDayCounter)
                    {
                        for (int numberCounter = 1; numberCounter <= maxNumber; numberCounter++)
                        {
                            if (groupClass.Number == numberCounter)
                            {
                                ViewSubjectsGroup(sls, groupClass, weekDayCounter, numberCounter);
                            }
                        }
                    }
                }
            }
        }

        public void ViewSubjectsGroup(StackLayout[,] sls, Class groupClass, int weekDayCounter, int numberCounter)
        {
            Label labelSeparator = new Label();
            labelSeparator.Text = "----------------------------------------------";
            labelSeparator.FontAttributes = FontAttributes.Bold;
            StackLayout sl;
            BoxView box = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 90
            };
            if (groupClass.SubType == ClassSubType.Other)
            {
                if (groupClass.WeekType != WeekType.None)
                {
                    if (groupClass.WeekType == WeekType.Numerator)
                    {
                        sl = new StackLayout();
                        sls[weekDayCounter - 1, numberCounter - 1].Children.Add(sl);
                        ViewSubjectGroup(sl, groupClass);
                    }
                    else
                    {
                        sl = new StackLayout();
                        if (sls[weekDayCounter - 1, numberCounter - 1].Children.Count == 0)
                        {
                            sls[weekDayCounter - 1, numberCounter - 1].Children.Add(box);
                            sls[weekDayCounter - 1, numberCounter - 1].Children.Add(labelSeparator);
                        }
                        else
                        {
                            sls[weekDayCounter - 1, numberCounter - 1].Children.RemoveAt(2);
                        }

                        sls[weekDayCounter - 1, numberCounter - 1].Children.Add(sl);
                        ViewSubjectGroup(sl, groupClass);
                    }
                    if (sls[weekDayCounter - 1, numberCounter - 1].Children.Count == 1)
                    {
                        sls[weekDayCounter - 1, numberCounter - 1].Children.Add(labelSeparator);
                        sls[weekDayCounter - 1, numberCounter - 1].Children.Add(box);
                    }
                }
                else
                {
                    sl = new StackLayout();
                    sls[weekDayCounter - 1, numberCounter - 1].Children.Add(sl);
                    ViewSubjectGroup(sl, groupClass);
                }
            }
            else
            {
                if (sls[weekDayCounter - 1, numberCounter - 1].Children.Count > 0)
                {
                    sls[weekDayCounter - 1, numberCounter - 1].Children.Add(labelSeparator);
                }
                sl = new StackLayout();
                Label labelDate = new Label();
                labelDate.Text = groupClass.Date.Value.ToShortDateString();
                Label labelSubType = new Label();
                if (groupClass.SubType == ClassSubType.Consultation)
                {
                    labelSubType.Text = "Консультація";
                }
                else
                {
                    labelSubType.Text = "Модульний контроль";
                }

                Label labelSubject = new Label();
                labelSubject.Text = groupClass.Subject;
                Label labelTeacher = new Label();
                labelTeacher.Text = groupClass.Teacher.Name;
                Label labelTime = new Label();
                labelTime.Text = groupClass.Date.Value.ToShortTimeString();

                labelDate.FontSize = 20; labelSubject.FontAttributes = FontAttributes.Bold;
                labelSubType.FontSize = 20; labelSubject.FontAttributes = FontAttributes.Bold;
                labelSubject.FontSize = 18; labelSubject.FontAttributes = FontAttributes.Bold;
                labelTeacher.FontSize = 18; labelTeacher.FontAttributes = FontAttributes.Italic;
                labelTime.FontSize = 20;

                sl.Children.Add(labelDate);
                sl.Children.Add(labelSubType);
                sl.Children.Add(labelSubject);
                sl.Children.Add(labelTeacher);
                sl.Children.Add(labelTime);
                sls[weekDayCounter - 1, numberCounter - 1].Children.Add(sl);
            }
        }

        public void ViewSubjectGroup(StackLayout sl, Class groupClass)
        {
            Label labelSubject = new Label();
            labelSubject.Text = groupClass.Subject;
            Label labelTeacher = new Label();
            labelTeacher.Text = groupClass.Teacher.Name;
            Label labelRoom = new Label();
            labelRoom.Text = "ауд." + groupClass.Auditory;

            labelSubject.FontSize = 18; labelSubject.FontAttributes = FontAttributes.Bold;
            labelTeacher.FontSize = 18; labelTeacher.FontAttributes = FontAttributes.Italic;
            labelRoom.FontSize = 16;

            sl.Children.Add(labelSubject);
            sl.Children.Add(labelTeacher);
            sl.Children.Add(labelRoom);
        }

        private async Task ViewScheduleTeacher(string teacher)
        {
            CleanSL(sls);

            var searchCriteriaTeacher = new SearchCriteria(scheduleName, teacher, null);
            var teacherClasses = await scheduleService.GetClasses(searchCriteriaTeacher);
            var sortTeacherClasses = teacherClasses.OrderBy(x => x.Date).ToArray();
            foreach (var teacherClass in sortTeacherClasses)
            {
                for (int weekDayCounter = 1; weekDayCounter <= maxWeekday; weekDayCounter++)
                {
                    if (teacherClass.WeekDay == weekDayCounter)
                    {
                        for (int numberCounter = 1; numberCounter <= maxNumber; numberCounter++)
                        {
                            if (teacherClass.Number == numberCounter)
                            {
                                ViewSubjectsTeacher(sls, teacherClass, weekDayCounter, numberCounter);
                            }
                        }
                    }
                }
            }
        }

        public void ViewSubjectsTeacher(StackLayout[,] sls, Class teacherClass, int weekDayCounter, int numberCounter)
        {
            Label labelSeparator = new Label();
            labelSeparator.Text = "----------------------------------------------";
            labelSeparator.FontAttributes = FontAttributes.Bold;
            StackLayout sl;
            BoxView box = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 90
            };

            int i = weekDayCounter - 1;
            int j = numberCounter - 1;

            bool isOneGroup = true;
            if (sls[i, j].Children.Count > 0)
            {
                isOneGroup = false;
            }

            if (teacherClass.SubType == ClassSubType.Other)
            {
                if (teacherClass.WeekType != WeekType.None)
                {
                    if (teacherClass.WeekType == WeekType.Numerator)
                    {
                        if (isOneGroup == false)
                        {
                            sls[i, j].Children.RemoveAt(sls[i, j].Children.Count - 1);
                            sls[i, j].Children.RemoveAt(sls[i, j].Children.Count - 1);
                        }
                        sl = new StackLayout();
                        sls[i, j].Children.Add(sl);
                        ViewSubjectTeacher(sl, teacherClass, isOneGroup);
                        sls[i, j].Children.Add(labelSeparator);
                        sls[i, j].Children.Add(box);
                    }
                    else
                    {
                        sl = new StackLayout();
                        if (sls[i, j].Children.Count == 0)
                        {
                            sls[i, j].Children.Add(box);
                            sls[i, j].Children.Add(labelSeparator);
                        }
                        else
                        {
                            sls[i, j].Children.RemoveAt(2);
                        }

                        sls[i, j].Children.Add(sl);
                        ViewSubjectTeacher(sl, teacherClass, isOneGroup);
                    }
                }
                else
                {
                    sl = new StackLayout();
                    sls[i, j].Children.Add(sl);
                    ViewSubjectTeacher(sl, teacherClass, isOneGroup);
                }
            }
            else
            {
                sl = new StackLayout();
                sls[i, j].Children.Add(sl);
                Label labelDate = new Label();
                labelDate.Text = teacherClass.Date.Value.ToShortDateString();
                Label labelSubType = new Label();
                if (teacherClass.SubType == ClassSubType.Consultation)
                {
                    labelSubType.Text = "Консультація";
                }
                else
                {
                    labelSubType.Text = "Модульний контроль";
                }

                Label labelSubject = new Label();
                labelSubject.Text = teacherClass.Subject;
                Label labelGroup = new Label();
                labelGroup.Text = teacherClass.Group.Name;
                Label labelTime = new Label();
                labelTime.Text = teacherClass.Date.Value.ToShortTimeString();

                labelDate.FontSize = 20; labelSubject.FontAttributes = FontAttributes.Bold;
                labelSubType.FontSize = 20; labelSubject.FontAttributes = FontAttributes.Bold;
                labelSubject.FontSize = 18; labelSubject.FontAttributes = FontAttributes.Bold;
                labelGroup.FontSize = 18; labelGroup.FontAttributes = FontAttributes.Italic;
                labelTime.FontSize = 20;

                Label label = new Label();
                if (!isOneGroup)
                    label = sls[i, j].Children.OfType<Label>().FirstOrDefault();

                if (isOneGroup)
                {
                    sls[i, j].Children.Add(labelDate);
                    sl.Children.Add(labelSubType);
                    sl.Children.Add(labelSubject);
                    sl.Children.Add(labelTime);
                    sl.Children.Add(labelGroup);
                }
                else if (label.Text != labelDate.Text)
                {
                    string str = "";
                    if (sls[i, j].Children[sls[i, j].Children.Count - 2] is Label label1)
                        str = label1.Text;

                    if (str != labelDate.Text)
                    {
                        sls[i, j].Children.Add(labelSeparator);
                        sls[i, j].Children.Add(labelDate);
                        sl.Children.Add(labelSubType);
                        sl.Children.Add(labelSubject);
                        sl.Children.Add(labelTime);
                        sl.Children.Add(labelGroup);
                    }
                    else
                        sl.Children.Add(labelGroup);
                }
                else
                {
                    sl.Children.Add(labelGroup);
                }
            }
        }

        public void ViewSubjectTeacher(StackLayout sl, Class teacherClass, bool isOneGroup)
        {
            Label labelSubject = new Label();
            labelSubject.Text = teacherClass.Subject;
            Label labelGroup = new Label();
            labelGroup.Text = teacherClass.Group.Name;
            Label labelRoom = new Label();
            labelRoom.Text = "ауд." + teacherClass.Auditory;

            labelSubject.FontSize = 18; labelSubject.FontAttributes = FontAttributes.Bold;
            labelGroup.FontSize = 18; labelGroup.FontAttributes = FontAttributes.Italic;
            labelRoom.FontSize = 16;

            if (isOneGroup)
            {
                sl.Children.Add(labelSubject);
                sl.Children.Add(labelRoom);
                sl.Children.Add(labelGroup);
            }
            else
            {
                sl.Children.Add(labelGroup);
            }
        }

        public void CleanSL(StackLayout[,] sls)
        {
            int weekDayCounter = 1;
            while (weekDayCounter <= maxWeekday)
            {
                int numberCounter = 1;
                while (numberCounter <= maxNumber)
                {
                    sls[weekDayCounter - 1, numberCounter - 1].Children.Clear();
                    numberCounter++;
                }
                weekDayCounter++;
            }
        }

        public async void ShowScheduleForGroup()
        {
            var groups = await scheduleService.GetGroups(scheduleName);
            if (groupPicker.SelectedItem != null)
            {
                foreach (var groupName in groups)
                {
                    if (groupPicker.Items[groupPicker.SelectedIndex] == groupName)
                    {
                        await ViewScheduleGroup(groupName);
                        break;
                    }
                }
            }
        }

        public async void ShowScheduleForTeacher()
        {
            var teachers = await scheduleService.GetTeachers(scheduleName);
            if (teacherPicker.SelectedItem != null)
            {
                foreach (var teacherName in teachers)
                {
                    if (teacherPicker.Items[teacherPicker.SelectedIndex] == teacherName)
                    {
                        await ViewScheduleTeacher(teacherName);
                        break;
                    }
                }
            }
        }

        public void onSelectedGroupChange(object sender, EventArgs e)
        {
            if (groupRadioButton.IsChecked)
            {
                ShowScheduleForGroup();
            }
        }

        public void onSelectedTeacherChange(object sender, EventArgs e)
        {
            if (teacherRadioButton.IsChecked)
            {
                ShowScheduleForTeacher();
            }
        }

        private void onMondayCheckChange(object sender, CheckedChangedEventArgs e)
        {
            mondayFrame.IsVisible = mondayCheckbox.IsChecked;
        }

        private void onTuesdayCheckChange(object sender, CheckedChangedEventArgs e)
        {
            tuesdayFrame.IsVisible = tuesdayCheckbox.IsChecked;
        }

        private void onWednesdayCheckChange(object sender, CheckedChangedEventArgs e)
        {
            wednesdayFrame.IsVisible = wednesdayCheckbox.IsChecked;
        }

        private void onThursdayCheckChange(object sender, CheckedChangedEventArgs e)
        {
            thursdayFrame.IsVisible = thursdayCheckbox.IsChecked;
        }

        private void onFridayCheckChange(object sender, CheckedChangedEventArgs e)
        {
            fridayFrame.IsVisible = fridayCheckbox.IsChecked;
        }

        private void onScheduleTypeChange(object sender, CheckedChangedEventArgs e)
        {
            if (teacherPicker.SelectedItem == null || groupPicker.SelectedItem == null)
            {
                CleanSL(sls);
            }

            groupPicker.IsVisible = groupRadioButton.IsChecked;
            teacherPicker.IsVisible = !groupRadioButton.IsChecked;

            if (groupRadioButton.IsChecked)
            {
                ShowScheduleForGroup();
            }
            else
            {
                ShowScheduleForTeacher();
            }
        }
    }
}