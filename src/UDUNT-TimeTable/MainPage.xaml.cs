﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UDUNT_TimeTable
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            bSchedule.Clicked += BSchedule_Clicked;

            logo.Source = ImageSource.FromResource("UDUNT-TimeTable.Images.logo_udunt.png");

            //Image image = new Image();
            //image.Source = ImageSource.FromResource("UDUNT-TimeTable\\Images\\logo_udunt.png");
            //Content = image;

            //StackLayout layout = new StackLayout();

            //Label lnameprog = new Label();
            //lnameprog.Text = "\n        УДУНТ\nРозклад зянять\n";
            //lnameprog.FontSize = 32;
            //lnameprog.FontAttributes = FontAttributes.Bold;
            //lnameprog.HorizontalOptions = LayoutOptions.Center;

            //layout.Children.Add(lnameprog);

            //Content = layout;
        }

        private void BSchedule_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}