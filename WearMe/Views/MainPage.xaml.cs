using WearMe.ViewModels;
using Xamarin.Forms;

namespace WearMe.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }
    }
}