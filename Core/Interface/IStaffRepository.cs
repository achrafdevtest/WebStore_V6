using WebStore.Core.Models;

namespace WebStore.Core.Interface;
public interface IStaffRepository
{
    Task<Staff> GetById(int id);
    Task<Staff> GetByMatricule(string matricule);
    Task<IReadOnlyList<Staff>> GetAll();
    Task Create(NewStaff staff);
    Task Update(UpdateStaff staff, string matricule);
    Task Delete(int id);
    Task<bool> Exist(string matricule);
    Task<bool> Exist(int id);
}

