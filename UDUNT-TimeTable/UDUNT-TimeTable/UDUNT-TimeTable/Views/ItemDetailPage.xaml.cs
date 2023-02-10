using System.ComponentModel;
using UDUNT_TimeTable.ViewModels;
using Xamarin.Forms;

namespace UDUNT_TimeTable.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}