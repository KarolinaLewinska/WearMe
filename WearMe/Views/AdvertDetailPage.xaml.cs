using System.ComponentModel;
using WearMe.ViewModels;
using Xamarin.Forms;

namespace WearMe.Views
{
    public partial class AdvertDetailPage : ContentPage
    {
        public AdvertDetailPage()
        {
            InitializeComponent();
            BindingContext = new AdvertDetailViewModel();
        }
    }
}