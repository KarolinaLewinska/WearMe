using System;
using Xamarin.Forms;
using WearMe.Database;
using System.IO;

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
                    db = new AdvertsDatabase(Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "AdvertsDB.db3"));
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            /*DependencyService.Register<MockDataStore>();*/
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
