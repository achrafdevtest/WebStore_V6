
using WebStore.Core.Interface;
using WebStore.Core.Models;

namespace WebStore.Core.Services;

public class BrandService 
{
    private readonly IBrandsRepository _brandsRepository;  
    public BrandService(IBrandsRepository brandsRepository)
        => _brandsRepository = brandsRepository ?? throw new ArgumentNullException(nameof(brandsRepository));
    public async Task<IReadOnlyList<Brands>> GetAll() => await _brandsRepository.GetAll();
    public async Task<Brands> GetBrand(int id)
    {
        if (id <= 0)
            throw new Exception("Id invalide!");

        var brandValidator = await _brandsRepository.Exist(id);
        if(!brandValidator)
            throw new InvalidOperationException("Marque n'existe pas !");

        var brand = await _brandsRepository.GetById(id);
        if (brand == null)
            throw new InvalidOperationException("Impossible de charger la marque !");
               
        return brand;
    }
    public async Task<Brands> GetBrand(string code)
    {
        if (string.IsNullOrEmpty(code))
            ArgumentNullException.ThrowIfNull("Code invalide !");

        var brandValidator = await _brandsRepository.Exist(code);

        if (!brandValidator)
            throw new InvalidOperationException($" Code [{code}] n'existe pas !");

        var brand = await _brandsRepository.GetByCode(code);
        if (brand == null)
            throw new InvalidOperationException("Impossible de charger la marque !");

        return brand;
    }     
    public async Task Create(NewBrand newBrand)
    {
        try
        {
            if (newBrand == null)
                throw new InvalidOperationException(nameof(newBrand));

            if (string.IsNullOrEmpty(newBrand.Code))
                ArgumentNullException.ThrowIfNull("Code obligatoire !");

            var brandValidator = await _brandsRepository.Exist(newBrand.Code);
            if (brandValidator)
                throw new InvalidOperationException($" Code [{newBrand.Code}] existe déjà !");

          await _brandsRepository.Create(newBrand);
        }
        catch 
        {
            throw;
        }          
    }
    public async Task Update(UpdateModelBase brand ,string code)
    {
        if (string.IsNullOrEmpty(code))
            ArgumentNullException.ThrowIfNull("Code obligatoire !");

        if (brand == null)
            throw new InvalidOperationException(nameof(brand));

        var brandValidator = await _brandsRepository.Exist(code);
        if (!brandValidator)
            throw new InvalidOperationException($" Code [{code}] n'existe pas !");

       await  _brandsRepository.Update(brand,code);        
    }
    public async Task Delete(int id)
    {
        if (id <= 0)
            throw new Exception("Id invalide!");

        var brandValidator = await _brandsRepository.Exist(id);

        if (!brandValidator)
            throw new InvalidOperationException("Id n'existe pas !");

       await _brandsRepository.Delete(id);
    }
}
