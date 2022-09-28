using WebStore.Core.Interface;
using WebStore.Core.Models;

namespace WebStore.Core.Services
{
    public class StaffService
    {
        private readonly IStaffRepository _staffRepository;
        public StaffService(IStaffRepository staffRepository)
            => _staffRepository = staffRepository ?? throw new ArgumentNullException(nameof(staffRepository));
        public async Task<IReadOnlyList<Staff>> GetAll() => await _staffRepository.GetAll();
        public async Task<Staff> Get(int id)
        {
            if (id <= 0)
                throw new Exception("Id invalide!");

            var staffValidator = await _staffRepository.Exist(id);

            if (!staffValidator)
                throw new InvalidOperationException("L'employé  n'existe pas !");

            var staff = await _staffRepository.GetById(id);

            if (staff == null)
                throw new InvalidOperationException("Impossible de charger l'employé  !");

            return staff;
        }
        public async Task<Staff> Get(string matricule)
        {
            if (string.IsNullOrEmpty(matricule))
                  throw new InvalidOperationException("Matricule invalide !");

            var staffValidator = await _staffRepository.Exist(matricule);

            if (!staffValidator)
                throw new InvalidOperationException($" Matricule [{matricule}] n'existe pas !");

            var staff = await _staffRepository.GetByMatricule(matricule);

            if (staff == null)
                throw new InvalidOperationException("Impossible de charger l'employé !");

            return staff;
        }
        public async Task Create(NewStaff newStaff)
        {
            try
            {
                if (newStaff == null)
                    throw new InvalidOperationException(nameof(newStaff));

                if (string.IsNullOrEmpty(newStaff.Matricule))
                      throw new InvalidOperationException("Matricule obligatoire !");

                var staffValidator = await _staffRepository.Exist(newStaff.Matricule);
                if (staffValidator)
                    throw new InvalidOperationException($" Matricule [{newStaff.Matricule}] existe déjà !");

                await _staffRepository.Create(newStaff);
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(UpdateStaff staff, string matricule)
        {

            if (string.IsNullOrEmpty(matricule))
                  throw new InvalidOperationException("Matricule obligatoire !");

            if (staff == null)
                throw new InvalidOperationException(nameof(staff));

            var brandValidator = await _staffRepository.Exist(matricule);
            if (!brandValidator)
                throw new InvalidOperationException($" Matricule [{matricule}] n'existe pas !");

            await _staffRepository.Update(staff, matricule);
        }
        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id invalide!");

            var categoryValidator = await _staffRepository.Exist(id);
            if (!categoryValidator)
                throw new InvalidOperationException("Id n'existe pas !");

            await _staffRepository.Delete(id);
        }
    }
}
