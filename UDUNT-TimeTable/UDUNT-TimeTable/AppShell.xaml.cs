using System;
using System.Collections.Generic;
using UDUNT_TimeTable.ViewModels;
using UDUNT_TimeTable.Views;
using Xamarin.Forms;

namespace UDUNT_TimeTable
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
