using WearMe.Models;
using Xamarin.Forms;

namespace WearMe.Views
{
    public partial class AdvertsListPage : ContentPage
    {
        public AdvertsListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var adverts = await App.DB.getAdvertsList();

            BindingContext = adverts;
            base.OnAppearing();
        }

        private async void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewAdvertPage()
            {
                BindingContext = new Advert() { }
            });
        }

        private async void Adverts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var advert = (Advert)e.SelectedItem;
            await Navigation.PushAsync(new AdvertDetailPage()
            {
                BindingContext = advert
            });

        }
    }
}