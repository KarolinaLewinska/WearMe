using System;
using System.IO;
using System.Threading.Tasks;
using WearMe.Models;
using WearMe.Notifications;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WearMe.ViewModels
{
    public class NewAdvertViewModel : BaseAdvertViewModel
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
            if (FieldsAreNotEmpty(advert))
            {
                await App.AdvertService.AddAdvert(advert);
                await Shell.Current.GoToAsync("//AdvertsListPage");
                Notification.createNotification(advert.Title, "Produkt jest już widoczny dla innych", 1);
                await App.Current.MainPage.DisplayAlert("Zapisano dane", "Pomyślnie zapisano dane o produkcie: " + advert.Title, "OK");
                var duration = TimeSpan.FromSeconds(3);
                Vibration.Vibrate(duration);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Brak danych o produkcie", "Uzupełnij wszystkie pola danymi", "OK");
            }
           
        }

        private bool FieldsAreNotEmpty(Advert advert)
        {
            return !string.IsNullOrWhiteSpace(advert.Title)
                && !string.IsNullOrWhiteSpace(advert.Description)
                && !string.IsNullOrWhiteSpace(advert.Photo)
                && !string.IsNullOrWhiteSpace(advert.Price.ToString())
                && !string.IsNullOrWhiteSpace(advert.Size)
                && !string.IsNullOrWhiteSpace(advert.Brand)
                && !string.IsNullOrWhiteSpace(advert.Category)
                && !string.IsNullOrWhiteSpace(advert.Gender)
                && !string.IsNullOrWhiteSpace(advert.Condition)
                && !string.IsNullOrWhiteSpace(advert.Category)
                && !string.IsNullOrWhiteSpace(advert.NameAndSurname)
                && !string.IsNullOrWhiteSpace(advert.Email)
                && !string.IsNullOrWhiteSpace(advert.PhoneNumber)
                //&& advert.PhoneNumber.Length >= 9
                //opis min 20 znakow
                //tytul max 35 znakow 
                && !string.IsNullOrWhiteSpace(advert.City);
        
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("//AdvertsListPage");
        }

        public Command TakePhoto
        {
            get
            {
                return new Command(async (e) =>
                {
                    var photo = await MediaPicker.CapturePhotoAsync();
                    var stream = await LoadPhoto(photo);
                });
            }
        }
        public Command ChoosePhoto
        {
            get
            {
                return new Command(async (e) =>
                {
                    var photo = await MediaPicker.PickPhotoAsync();
                    var stream = await LoadPhoto(photo);
                });
            }
        }

        async Task<Stream> LoadPhoto(FileResult photo)
        {
            if (photo == null)
            {
                return null;
            }
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            var stream = await photo.OpenReadAsync();
            MediaPath = photo.FullPath;
      
            return stream;
        }

        string mediaPath;
        public string MediaPath
        {
            get { return mediaPath; }
            set
            {
                if (value != null)
                {
                    mediaPath = value;
                    OnPropertyChanged();
                    Advert.Photo = mediaPath;
                }
            }
        }
    }
}
