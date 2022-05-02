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
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
    }
}
