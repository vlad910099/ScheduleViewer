using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UDUNT_TimeTable
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Shcedule : ContentPage
	{
		public Shcedule ()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
		{
            checkMonday.CheckedChanged += OnCheckMonday;
            checkTuesday.CheckedChanged += OnCheckTuesday;
        }

        private void OnCheckMonday(object sender, CheckedChangedEventArgs e)
        {
            if(checkMonday.IsChecked == true)
                boxViewMonday.IsVisible = true;
            else boxViewMonday.IsVisible = false;
        }
        private void OnCheckTuesday(object sender, CheckedChangedEventArgs e)
        {
            if (checkTuesday.IsChecked == true)
                boxViewTuesday.IsVisible = true;
            else boxViewTuesday.IsVisible = false;
        }
    }
}