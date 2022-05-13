using System;
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

        async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var imageSender = (Image) sender;
            imageSender.Opacity = 0;
            await imageSender.FadeTo(1, 4000);
        }
    }
}