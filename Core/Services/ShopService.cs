using WebStore.Core.Interface;
using WebStore.Core.Models;

namespace WebStore.Core.Services;

public class ShopService
{
    private readonly IShopRepository _shopRepository;   
    public ShopService(IShopRepository shopRepository)
    {
            _shopRepository = shopRepository ?? throw new ArgumentNullException(nameof(shopRepository));
    }

    public async Task<IReadOnlyList<ShopDto>> ProductsShop() => await _shopRepository.GetProducts();
    
}
