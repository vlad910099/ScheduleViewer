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

        }

        private void OnCheckMonday(object sender, CheckedChangedEventArgs e)
        {
            if(checkMonday.IsChecked == true)
                frameViewMonday.IsVisible = true;
            else frameViewMonday.IsVisible = false;
        }
        private void OnCheckTuesday(object sender, CheckedChangedEventArgs e)
        {
            if (checkTuesday.IsChecked == true)
                frameViewTuesday.IsVisible = true;
            else frameViewTuesday.IsVisible = false;
        }
    }
}