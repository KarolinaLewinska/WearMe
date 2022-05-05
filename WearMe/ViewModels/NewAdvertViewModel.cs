using WearMe.Models;
using Xamarin.Forms;

namespace WearMe.ViewModels
{
    public class NewAdvertViewModel: BaseAdvertViewModel
    {
        public Command SaveAdvertCommand { get; }
        public Command CancelCommand { get; }

        public NewAdvertViewModel()
        {
            SaveAdvertCommand = new Command(OnSaveAdvert);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged += (_, __) => SaveAdvertCommand.ChangeCanExecute();
            Advert = new Advert();
        }

        private async void OnSaveAdvert()
        {
            var advert = Advert;
            await App.AdvertService.AddAdvert(advert);
            await Shell.Current.GoToAsync("//AdvertsListPage");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("//AdvertsListPage");
        }
    }
}
