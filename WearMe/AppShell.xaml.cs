using System;
using System.Collections.Generic;
using WearMe.ViewModels;
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

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
