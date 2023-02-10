using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDUNT_TimeTable.Models;
using UDUNT_TimeTable.ViewModels;
using UDUNT_TimeTable.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UDUNT_TimeTable.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}