using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WearMe.Models;
using WearMe.Views;
using Xamarin.Forms;

namespace WearMe.ViewModels
{
    public class AdvertViewModel: BaseAdvertViewModel
    {
        public Command LoadAdvertsCommand { get; }
        public ObservableCollection<Advert> Adverts { get; }

        public Command AddAdvertCommand { get; }
        public Command EditCommandTabbed { get; }
        public Command DeleteCommandTabbed { get; }



        public AdvertViewModel(INavigation navigation)
        {
            LoadAdvertsCommand = new Command(async() => await ExecuteLoadAdvertCommand());
            Adverts = new ObservableCollection<Advert>();
            AddAdvertCommand = new Command(OnAddAdvert);
            EditCommandTabbed = new Command<Advert>(OnEditAdvert);
            DeleteCommandTabbed = new Command<Advert>(OnDeleteAdvert);
            Navigation = navigation;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadAdvertCommand()
        {
            IsBusy = true;

            try
            {
                Adverts.Clear();
                var advertsList = await App.AdvertService.GetAdverts();

                foreach (var advert in advertsList)
                {
                    Adverts.Add(advert);
                }
            } 
            catch (Exception ex)
            {
                throw new Exception("Error during loading data " + ex.Message);
            } 
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddAdvert(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewAdvertPage));
        }

        private async void OnEditAdvert(Advert advert)
        {
            await Navigation.PushAsync(new NewAdvertPage(advert));
        }

        private async void OnDeleteAdvert(Advert advert)
        {
            if (advert == null)
            {
                return;
            }
            await App.AdvertService.DeleteAdvert(advert.AdvertId);
            await ExecuteLoadAdvertCommand();
        }
    }
}
