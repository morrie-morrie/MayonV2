using Mayon.Application.Entities.Duo.Infra;
using Mayon.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace Mayon.Application.Infrastructure;
public class DuoCustomersRepository : IDuoCustomersRepository
{
    private readonly AppDbContext _dbContext;

    public DuoCustomersRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddDuoCustomer(DuoCustomers duoCustomers)
    {
        _dbContext.DuoCustomers.Add(duoCustomers);
        _dbContext.SaveChanges();
    }

    public DuoCustomers GetDuoCustomerById(int id)
    {
        return _dbContext.DuoCustomers.Find(id);
    }

    public IEnumerable<DuoCustomers> GetAllDuoCustomers()
    {
        return _dbContext.DuoCustomers.ToList();
    }

    public void UpdateDuoCustomer(DuoCustomers duoCustomers)
    {
        _dbContext.Entry(duoCustomers).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteDuoCustomer(int id)
    {
        var duoCustomerToDelete = _dbContext.DuoCustomers.Find(id);
        if (duoCustomerToDelete != null)
        {
            _dbContext.DuoCustomers.Remove(duoCustomerToDelete);
            _dbContext.SaveChanges();
        }
    }
}