using System.Linq;
using WearMe.Models;
using WearMe.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WearMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdvertsListPage : ContentPage
    {
        private AdvertViewModel advertViewModel;
        
        public AdvertsListPage()
        {
            InitializeComponent();
            BindingContext = advertViewModel = new AdvertViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            advertViewModel.OnAppearing();
        }

        private async void Adverts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAdvert = e.CurrentSelection.FirstOrDefault() as Advert;
            await Navigation.PushAsync(new AdvertDetailPage()
            {
                BindingContext = selectedAdvert
            });
        }
    }
}