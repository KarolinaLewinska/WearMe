using System;
using WearMe.Services;
using Xamarin.Forms;

namespace WearMe.ViewModels
{
    [QueryProperty(nameof(AdvertId), nameof(AdvertId))]
    public class AdvertDetailViewModel : BaseViewModel
    {
        private int advertId;
        private string title;
        private string description;
        private string photo;
        private decimal price;
        private string brand;
        private string category;
        private string gender;
        private string condition;
        private string nameAndSurname;
        private string phoneNumber;
        private string email;
        private string city;
        public int Id { get; set; }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }

        public decimal Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string Brand
        {
            get => brand;
            set => SetProperty(ref brand, value);
        }

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }

        public string Condition
        {
            get => condition;
            set => SetProperty(ref condition, value);
        }

        public string NameAndSurname
        {
            get => nameAndSurname;
            set => SetProperty(ref nameAndSurname, value);
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        public int AdvertId
        {
            get
            {
                return AdvertId;
            }
            set
            {
                advertId = value;
                LoadAdvertId(value);
            }
        }

        public async void LoadAdvertId(int advertId)
        {
            try
            {
                MockDataStore mock = new MockDataStore();
                var advert = await mock.GetAdvertAsync(advertId);
                Id = advert.AdvertId;
                Title = advert.Title;
                Description = advert.Description;
                Photo = advert.Photo;
                Price = advert.Price;
                Brand = advert.Brand;
                Category = advert.Category;
                Gender = advert.Gender;
                Condition = advert.Condition;
                NameAndSurname = advert.NameAndSurname;
                PhoneNumber = advert.PhoneNumber;
                Email = advert.Email;
                City = advert.City;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
    }
}
