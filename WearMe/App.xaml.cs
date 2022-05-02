using System;
using WearMe.Services;
using WearMe.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WearMe.Database;

namespace WearMe
{
    public partial class App : Application
    {
        static AdvertsDatabase db;

        internal static AdvertsDatabase DB
        {
            get
            {
                if (db == null)
                {
                    db = new AdvertsDatabase();
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
