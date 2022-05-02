using System;
using WearMe.Models;
using WearMe.Services;
using Xamarin.Forms;

namespace WearMe.ViewModels
{
    public class NewAdvertViewModel : BaseViewModel
    {
        private string title;
        private string description;

        public NewAdvertViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(description);
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            MockDataStore mock = new MockDataStore();
            Advert newAdvert = new Advert()
            {
                Title = Title,
                Description = Description
            };

            await mock.AddAdvertAsync(newAdvert);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
