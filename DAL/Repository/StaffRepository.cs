using Microsoft.EntityFrameworkCore;
using WebStore.Core.Interface;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF;
using WebStore.DAL.Data.EF.Dao;

namespace WebStore.DAL.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly StoreContext _context;
        public StaffRepository(StoreContext context)
         => _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<bool> Exist(string matricule) => await _context.Staffs.AnyAsync(x => x.Matricule == matricule);
        public async Task<bool> Exist(int id) => await _context.Staffs.AnyAsync(x => x.Id == id);
        public async Task Create(NewStaff staff)
        {
            var data = new StaffsDao
            {
                Matricule = staff.Matricule ?? "",
                Name = staff.Name ?? "",
                EMAIL = staff.EMAIL ?? "",
                IsActive = staff.IsActive,
                Phone = staff.Phone ?? "",
                StoreId = staff.StoreId
            };
            _context.Staffs.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Staffs.SingleOrDefaultAsync(b => b.Id == id);
            if (result != null)
                _context.Remove(result);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<Staff>> GetAll()
        {
            return await _context.Staffs.Select(x => new Staff
            {
                Id = x.Id,
                Matricule = x.Matricule,
                Name = x.Name,
                EMAIL = x.EMAIL,
                IsActive = x.IsActive,
                Phone = x.Phone,
                StoreId = x.StoreId
            }).ToListAsync();
        }

        public async Task<Staff> GetById(int id)
        {
            var result = await _context.Staffs.SingleOrDefaultAsync(x => x.Id == id);
            return new Staff
            {
                Id = id,
                Matricule = result.Matricule,
                Name = result.Name,
                EMAIL = result.EMAIL,
                IsActive = result.IsActive,
                Phone = result.Phone,
                StoreId = result.StoreId
            };
        }

        public async Task Update(UpdateStaff staff, string matricule)
        {
            var result = await _context.Staffs.SingleOrDefaultAsync(x => x.Matricule == matricule);

            result.Name = staff.Name ?? "";
            result.Phone = staff.Phone ?? "";
            result.EMAIL = staff.EMAIL ?? "";
            result.IsActive = staff.IsActive;
            result.StoreId = staff.StoreId;

            await _context.SaveChangesAsync();
        }

        public async Task<Staff> GetByMatricule(string matricule)
        {

            var result = await _context.Staffs.SingleOrDefaultAsync(x => x.Matricule == matricule);
            return new Staff
            {
                Id = result.Id,
                Matricule = result.Matricule,
                Name = result.Name,
                EMAIL = result.EMAIL,
                IsActive = result.IsActive,
                Phone = result.Phone,
                StoreId = result.StoreId
            };
        }
    }
}
