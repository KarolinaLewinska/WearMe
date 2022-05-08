using SQLite;

namespace WearMe.Models
{
    public class Advert
    {
        [PrimaryKey, AutoIncrement]
        public int AdvertId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Gender { get; set; }
        public string Condition { get; set; }
        public string NameAndSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}
