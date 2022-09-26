using WebStore.Core.Interface;
using WebStore.Core.Models;

namespace WebStore.Core.Services;
public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
      => _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    public async Task<IReadOnlyList<Category>> GetAll() => await _categoryRepository.GetAll();
    public async Task<Category> Get(int id)
    {
        if (id <= 0)
            throw new Exception("Id invalide!");

        var CategoryValidator = await _categoryRepository.Exist(id);

        if (!CategoryValidator)
            throw new InvalidOperationException("Catégorie n'existe pas !");

        var category = await _categoryRepository.GetById(id);

        if (category == null)
            throw new InvalidOperationException("Impossible de charger la catégorie !");

        return category;
    }
    public async Task<Category> Get(string code)
    {
        if (string.IsNullOrEmpty(code))
            ArgumentNullException.ThrowIfNull("Code invalide !");

        var categoryValidator = await _categoryRepository.Exist(code);

        if (!categoryValidator)
            throw new InvalidOperationException($" Code [{code}] n'existe pas !");

        var category = await _categoryRepository.GetByCode(code);

        if (category == null)
            throw new InvalidOperationException("Impossible de charger la catégorie !");

        return category;
    }
    public async Task Create(NewCategory newCategory)
    {
        try
        {
            if (newCategory == null)
                throw new InvalidOperationException(nameof(newCategory));

            if (string.IsNullOrEmpty(newCategory.Code))
                ArgumentNullException.ThrowIfNull("Code obligatoire !");

            var categoryValidator = await _categoryRepository.Exist(newCategory.Code);
            if (categoryValidator)
                throw new InvalidOperationException($" Code [{newCategory.Code}] existe déjà !");

            await _categoryRepository.Create(newCategory);
        }
        catch
        {
            throw;
        }
    }
    public async Task Update(UpdateModelBase category, string code)
    {
        if (string.IsNullOrEmpty(code))
            ArgumentNullException.ThrowIfNull("Code obligatoire !");

        if (category == null)
            throw new InvalidOperationException(nameof(Category));
        var categoryValidator = await _categoryRepository.Exist(code);
        if (!categoryValidator)
            throw new InvalidOperationException($" Code [{code}] n'existe pas !");

        await _categoryRepository.Update(category, code);
    }
    public async Task Delete(int id)
    {
        if (id <= 0)
            throw new Exception("Id invalide!");

        var categoryValidator = await _categoryRepository.Exist(id);
        if (!categoryValidator)
            throw new InvalidOperationException("Id n'existe pas !");

        await _categoryRepository.Delete(id);
    }
}
