using System;
using WearMe.Views;
using Xamarin.Forms;

namespace WearMe.ViewModels
{
    public class MainPageViewModel: BaseViewModel
    {
        public Command StartAppCommand { get; }
        public string Source { get; set; }
      
        public MainPageViewModel()
        {
            PageTitle = "Witamy w WearMe";
            StartAppCommand = new Command(OnStartClicked);

        }

        private async void OnStartClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AdvertsListPage)}");
        }
    }
}