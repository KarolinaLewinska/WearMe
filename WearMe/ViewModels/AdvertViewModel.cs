﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WearMe.Models;
using WearMe.Notifications;
using WearMe.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WearMe.ViewModels
{
    public class AdvertViewModel: BaseAdvertViewModel
    {
        public ObservableCollection<Advert> Adverts { get; }
        public Command LoadAdvertsCommand { get; }
        public Command AddAdvertCommand { get; }
        public Command EditAdvertCommand { get; }
        public Command DeleteAdvertCommand { get; }

        public AdvertViewModel(INavigation navigation)
        {
            Adverts = new ObservableCollection<Advert>();
            LoadAdvertsCommand = new Command(async() => await ExecuteLoadAdvertCommand());
            AddAdvertCommand = new Command(OnAddAdvert);
            EditAdvertCommand = new Command<Advert>(OnEditAdvert);
            DeleteAdvertCommand = new Command<Advert>(OnDeleteAdvert);
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

            var wantsToDelete = await App.Current.MainPage.DisplayAlert("Usuń produkt", "Czy na pewno chcesz usunąć wybrany produkt?", "Tak", "Nie");
            if (wantsToDelete)
            {
                await App.AdvertService.DeleteAdvert(advert.AdvertId);
                await App.Current.MainPage.DisplayAlert("Usunięto dane", "Pomyślnie usunięto dane o produkcie", "OK");

                Notification.createNotification("Usunięto produkt", "Produkt nie jest już widoczny dla innych", 2);
                vibrateDevice();
       
                await ExecuteLoadAdvertCommand();
            }
        }

        private void vibrateDevice()
        {
            var duration = TimeSpan.FromSeconds(4);
            Vibration.Vibrate(duration);
        }
    }
}
