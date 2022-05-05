using System;
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
        AdvertViewModel advertViewModel;
        
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

      /*  private async void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewAdvertPage()
            {
                BindingContext = new Advert() { }
            });
        }*/

    /*    private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            var current = (e.CurrentSelection.FirstOrDefault() as Advert)?.AdvertId;
            await Navigation.PushAsync(new AdvertDetailPage()
            {
                BindingContext = current
            });

        }*/
    }
}