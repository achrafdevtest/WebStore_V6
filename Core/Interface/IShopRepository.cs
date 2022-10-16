using WebStore.Core.Models;

namespace WebStore.Core.Interface;

public interface IShopRepository
{
    Task<IReadOnlyList<ShopDto>> GetProducts();
}
