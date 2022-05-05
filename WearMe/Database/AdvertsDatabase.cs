using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using WearMe.Models;

namespace WearMe.Database
{
    internal class AdvertsDatabase
    {
        private readonly SQLiteAsyncConnection conn;

        public AdvertsDatabase(string path)
        {
            conn = new SQLiteAsyncConnection(path); 
            conn.CreateTableAsync<Advert>().Wait(); 
        }

        public Task<List<Advert>> getAdvertsList()
        {
            return conn.Table<Advert>().ToListAsync();
        }

        public Task<Advert> getAdvertById(int id)
        {
            return conn.Table<Advert>().FirstOrDefaultAsync(adv => adv.AdvertId == id);
        }

        public Task<int> AddOrUpdateAdvert(Advert advert)
        {
            if (advert.AdvertId == 0)
            {
                return conn.InsertAsync(advert);
            }
            else
            {
                return conn.UpdateAsync(advert);
            }
        }

       /* public  Task<Advert> deleteAdvert(int id)
        {
            return conn.DeleteAsync<Advert>(id);
        }*/
    }
}
