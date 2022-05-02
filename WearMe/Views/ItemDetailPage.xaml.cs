using System.ComponentModel;
using WearMe.ViewModels;
using Xamarin.Forms;

namespace WearMe.Views
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