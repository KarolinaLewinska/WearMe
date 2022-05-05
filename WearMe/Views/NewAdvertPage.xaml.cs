using System;
using WearMe.Models;
using WearMe.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WearMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAdvertPage : ContentPage
    {
        public Advert Advert { get; set; }

        public NewAdvertPage()
        {
            InitializeComponent();
            BindingContext = new NewAdvertViewModel();
        }

        public NewAdvertPage(Advert advert)
        {
            InitializeComponent();
            BindingContext = new NewAdvertViewModel();

            if (advert != null)
            {
                ((NewAdvertViewModel)BindingContext).Advert = advert;
            }
        }

        protected override void OnAppearing()
        {
           /* var advert = (Advert) BindingContext;
           
            BindingContext = new AdvertAction() { Advert = advert, Action = advert.AdvertId == 0 ? "Dodaj ogłoszenie" : "Zaktualizuj ogłoszenie" };*/

           

            base.OnAppearing();
        }

       /* private void Add_Advert_Clicked(object sender, EventArgs e)
        {
            App.AdvertService.AddAdvert(((AdvertAction)BindingContext).Advert);
            Shell.Current.GoToAsync("//AdvertsListPage");
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//AdvertsListPage");
        }*/

        private bool ValidateSave()
        {
  /*          return !String.IsNullOrWhiteSpace(advert)
                && !String.IsNullOrWhiteSpace(description);*/
            return true;
        }

    }
    class AdvertAction
    {
        public string Action { get; set; }
        public Advert Advert { get; set; }
    }
}