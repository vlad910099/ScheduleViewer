using System;
using System.Collections.Generic;
using System.ComponentModel;
using UDUNT_TimeTable.Models;
using UDUNT_TimeTable.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UDUNT_TimeTable.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}