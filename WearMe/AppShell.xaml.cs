using System;
using WearMe.Views;
using Xamarin.Forms;

namespace WearMe
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AdvertDetailPage), typeof(AdvertDetailPage));
            Routing.RegisterRoute(nameof(NewAdvertPage), typeof(NewAdvertPage));
        }

        private async void OnMenuLeaveItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        private async void MenuAddItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NewAdvertPage));
        }
    }
}
