using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WearMe.Models;
using WearMe.ViewModels;
using WearMe.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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