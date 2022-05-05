using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using WearMe.Models;

namespace WearMe.Services
{
    public class AdvertService : IAdvertRepository
    {
        public SQLiteAsyncConnection conn; 
        public AdvertService(string connPath)
        {
            conn = new SQLiteAsyncConnection(connPath);
            conn.CreateTableAsync<Advert>().Wait();
        }

        public async Task<IEnumerable<Advert>> GetAdverts()
        {
            return await Task.FromResult(await conn.Table<Advert>().ToListAsync());
        }

        public async Task<Advert> GetAdvert(int id)
        {
            return await conn.Table<Advert>().Where(a => a.AdvertId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddAdvert(Advert advert)
        {
            if (advert.AdvertId > 0)
            {
                await conn.UpdateAsync(advert);
            }
            else
            {
                await conn.InsertAsync(advert);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAdvert(int id)
        {
            await conn.DeleteAsync<Advert>(id);
            return await Task.FromResult(true); 
        }
    }
}
