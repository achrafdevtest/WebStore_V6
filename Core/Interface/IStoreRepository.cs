namespace WebStore.Core.Interface;
public interface IStoreRepository
{
    Task<bool> Exist(int id);
}
