using System.Collections.Generic;
using System.Threading.Tasks;
using WearMe.Models;

namespace WearMe.Services
{
    public interface IAdvertRepository
    {
        Task<IEnumerable<Advert>> GetAdverts();
        Task<Advert> GetAdvert(int id);
        Task<bool> AddAdvert(Advert advert);
        Task<bool> DeleteAdvert(int id); 
    }
}
