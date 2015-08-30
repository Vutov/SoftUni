using OnlineShop.Data.Repositories;
using OnlineShop.Models;

namespace OnlineShop.Data.Data
{
    public interface IOnlineShopData
    {
        IRepository<Ad> Ads { get; }

        IRepository<AdType> AdTypes { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Category> Categories { get; }

        int SaveChanges();
    }
}