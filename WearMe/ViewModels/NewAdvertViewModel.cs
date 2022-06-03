using System;
using System.IO;
using System.Text.RegularExpressions;
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
            if (CheckIfFieldsAreNotEmpty(advert) && ChechIfFieldsHaveProperLength(advert) && checkPriceFormat(advert.Price))
            {
                await App.AdvertService.AddAdvert(advert);
                await App.Current.MainPage.DisplayAlert("Zapisano dane", "Pomyślnie zapisano dane o produkcie: " + advert.Title, "OK");

                Notification.createNotification(advert.Title, "Produkt jest już widoczny dla innych", 1);
                vibrateDevice();
     
                await Shell.Current.GoToAsync("//AdvertsListPage");
            }
        }

        private bool CheckIfFieldsAreNotEmpty(Advert advert)
        {
            if (FieldsAreNotEmpty(advert))
            {
                return true;
            } 
            else
            {
                App.Current.MainPage.DisplayAlert("Brak danych o produkcie", "Uzupełnij wszystkie pola danymi", "OK");
                return false;
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
                && !string.IsNullOrWhiteSpace(advert.City);
        }

        private bool ChechIfFieldsHaveProperLength(Advert advert)
        {
            if (advert.Title.Length < 10 || advert.Title.Length > 50)
            {
                App.Current.MainPage.DisplayAlert("Za krótki tytuł", "Tytuł produktu musi posiadać od 10 do 50 znaków", "OK");
                return false;
            }
            if (advert.Description.Length < 30 || advert.Description.Length > 200)
            {
                App.Current.MainPage.DisplayAlert("Za krótki opis", "Opis produktu musi posiadać od 30 do 200 znaków", "OK");
                return false;
            }
            if (advert.PhoneNumber.Length < 9 || advert.PhoneNumber.Length > 15)
            {
                App.Current.MainPage.DisplayAlert("Za krótki numer", "Numer telefonu musi posiadać od 9 do 15 cyfr", "OK");
                return false;
            }
            return true;
        }

        private bool checkPriceFormat(decimal price)
        {
            Regex priceRegex = new Regex(@"^[0-9]+[.,]?[0-9]{2}$");

            if (priceRegex.IsMatch(price.ToString()))
            {
                return true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Cena", "Nieprawidłowy format ceny", "OK");
                return false;
            }
        }

        private void vibrateDevice()
        {
            var duration = TimeSpan.FromSeconds(3);
            Vibration.Vibrate(duration);
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
