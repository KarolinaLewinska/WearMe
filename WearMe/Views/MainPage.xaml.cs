using Xamarin.Forms;

namespace WearMe.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartApp_Clicked(object sender, System.EventArgs e)
        {
           await Shell.Current.GoToAsync($"//AdvertsListPage");
        }
    }
}