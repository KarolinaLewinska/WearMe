using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WearMe.Models;

namespace WearMe.Services
{
    public class MockDataStore
    {
         List<Advert> adverts;

        public MockDataStore()
        {
            adverts = new List<Advert>()
            {
                new Advert { AdvertId = 1, Title = "Koszulka", Description="Fajna koszulka",
                    Brand = "Zara", Category = "Spodnie", Condition = "Bardzo dobry", Gender = "Kobieta", 
                    Photo="image", Price=23.99m, NameAndSurname="Jan Kowalski", City="Gdańsk", 
                    Email="jankowalski2@wp.pl", PhoneNumber="509698454"}
            };
        }

        public async Task<bool> AddAdvertAsync(Advert advert)
        {
            adverts.Add(advert);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAdvertAsync(Advert advert)
        {
            var oldAdvert = adverts.Where((Advert adv) => adv.AdvertId == advert.AdvertId).FirstOrDefault();
            adverts.Remove(oldAdvert);
            adverts.Add(advert);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAdvertAsync(int id)
        {
            var oldAdvert = adverts.Where((Advert adv) => adv.AdvertId == id).FirstOrDefault();
            adverts.Remove(oldAdvert);

            return await Task.FromResult(true);
        }

        public async Task<Advert> GetAdvertAsync(int id)
        {
            return await Task.FromResult(adverts.FirstOrDefault(adv => adv.AdvertId == id));
        }

        public async Task<IEnumerable<Advert>> GetAdvertsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(adverts);
        }
    }
}