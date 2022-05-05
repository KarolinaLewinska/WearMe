using System;
using Xamarin.Forms;
using System.IO;
using WearMe.Services;

namespace WearMe
{
    public partial class App : Application
    {
        static AdvertService advertService;

        public static AdvertService AdvertService
        {
            get
            {
                if (advertService == null)
                {
                    advertService = new AdvertService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertsDB.db3"));
                }
                return advertService;
            }
        }

        public App()
        {
            InitializeComponent();
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
