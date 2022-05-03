using WearMe.ViewModels;
using Xamarin.Forms;

namespace WearMe.Views
{
    public partial class AdvertsListPage : ContentPage
    {
        AdvertsListViewModel _viewModel;

        public AdvertsListPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new AdvertsListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}