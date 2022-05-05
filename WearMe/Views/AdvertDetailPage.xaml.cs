using Xamarin.Forms;

namespace WearMe.Views
{
    [QueryProperty(nameof(AdvertId), nameof(AdvertId))]
    public partial class AdvertDetailPage : ContentPage
    {
        private int advertId;
        public AdvertDetailPage()
        {
            InitializeComponent();
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
               
            }
        }
    }
}