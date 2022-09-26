using Microsoft.EntityFrameworkCore;
using WebStore.Core.Interface;
using WebStore.Core.Models;
using WebStore.DAL.Data.EF;

namespace WebStore.DAL.Repository;

    public class CustomerRepository : ICustomerRepository
{
    private readonly StoreContext _context;
    public CustomerRepository(StoreContext context)
        => _context = context ?? throw new ArgumentNullException(nameof(context));  
    public async Task<bool> Exist(int id)
      => await _context.Customers.AnyAsync(c => c.Id == id);  

    public async Task<Customer> Get(int id)
    {
        var data = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

        return new Customer
        {
            Id        = id,
            Matricule = data.Matricule,
            FirstName = data.FirstName,
            LastName  = data.LastName,     
            EMAIL     = data.EMAIL,       
            Phone     = data.Phone,
            City      = data.City,
            State     = data.State,
            Street    = data.Street,
            ZipCode   = data.ZipCode, 
        };
    }
    public async Task<IReadOnlyList<Customer>> GetAll()
    {
        return await _context.Customers.Select(c => new Customer
        {
            Id        = c.Id,
            Matricule = c.Matricule,
            FirstName = c.FirstName,
            LastName  = c.LastName,
            EMAIL     = c.EMAIL,
            Phone     = c.Phone,
            City      = c.City,
            State     = c.State,
            Street    = c.Street,
            ZipCode   = c.ZipCode,
        }).ToListAsync();
    }
}

