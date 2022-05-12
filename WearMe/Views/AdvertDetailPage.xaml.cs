using System;
using Xamarin.Forms;

namespace WearMe.Views
{
    [QueryProperty(nameof(AdvertId), nameof(AdvertId))]
    public partial class AdvertDetailPage : ContentPage
    {
        private int advertId;
        public AdvertDetailPage()
        {
            InitializeComponent();
        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var imageSender = (Image)sender;
            var imageScale = imageSender.Scale;
            await imageSender.ScaleTo(imageScale * 1.2, 500);
            await imageSender.ScaleTo(imageScale, 500);
        }

        public int AdvertId
        {
            get
            {
                return AdvertId;
            }
            set
            {
                advertId = value;
            }
        }
    }
}