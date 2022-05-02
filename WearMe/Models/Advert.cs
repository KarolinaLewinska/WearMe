namespace WearMe.Models
{
    public class Advert
    {
        public int AdvertId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Gender { get; set; }
        public string Condition { get; set; }
        public decimal Price { get; set; }
    }
}
