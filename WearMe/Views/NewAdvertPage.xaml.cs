using System;
using System.Collections.Generic;
using System.ComponentModel;
using WearMe.Models;
using WearMe.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WearMe.Views
{
    public partial class NewAdvertPage : ContentPage
    {
        public Advert Advert { get; set; }

        public NewAdvertPage()
        {
            InitializeComponent();
            BindingContext = new NewAdvertViewModel();
        }
    }
}