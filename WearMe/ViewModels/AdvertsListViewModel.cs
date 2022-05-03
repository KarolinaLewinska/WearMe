using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WearMe.Models;
using WearMe.Views;
using Xamarin.Forms;
using WearMe.Services;

namespace WearMe.ViewModels
{
    public class AdvertsListViewModel : BaseViewModel
    {
        private Advert _selectedAdvert;

        public ObservableCollection<Advert> Adverts { get; }
        public Command LoadAdvertsCommand { get; }
        public Command AddAdvertCommand { get; }
        public Command<Advert> AdvertTapped { get; }

        public AdvertsListViewModel()
        {
            PageTitle = "Ubrania";
            Adverts = new ObservableCollection<Advert>();
            LoadAdvertsCommand = new Command(async () => await ExecuteLoadAdvertsCommand());

            AdvertTapped = new Command<Advert>(OnAdvertSelected);

            AddAdvertCommand = new Command(OnAddAdvert);
        }

        async Task ExecuteLoadAdvertsCommand()
        {
            IsBusy = true;

            try
            {
                MockDataStore mock = new MockDataStore();
                Adverts.Clear();
                var adverts = await mock.GetAdvertsAsync(true);
                foreach (var advert in adverts)
                {
                    Adverts.Add(advert);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedAdvert = null;
        }

        public Advert SelectedAdvert
        {
            get => _selectedAdvert;
            set
            {
                SetProperty(ref _selectedAdvert, value);
                OnAdvertSelected(value);
            }
        }

        private async void OnAddAdvert(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewAdvertPage));
        }

        async void OnAdvertSelected(Advert advert)
        {
            if (advert == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(AdvertDetailPage)}?{nameof(AdvertDetailViewModel.AdvertId)}={advert.AdvertId}");
        }
    }
}