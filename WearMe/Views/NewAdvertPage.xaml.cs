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
            base.OnAppearing();
        }

        private bool ValidateSave()
        {
  /*          return !String.IsNullOrWhiteSpace(advert)
                && !String.IsNullOrWhiteSpace(description);*/
            return true;
        }

    }
}