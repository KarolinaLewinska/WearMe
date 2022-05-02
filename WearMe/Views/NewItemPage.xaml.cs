using System;
using System.Collections.Generic;
using System.ComponentModel;
using WearMe.Models;
using WearMe.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WearMe.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}