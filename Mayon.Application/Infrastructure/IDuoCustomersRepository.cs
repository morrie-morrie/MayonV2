using Mayon.Application.Entities.Duo.Infra;

namespace Mayon.Application.Infrastructure;
public interface IDuoCustomersRepository
{
    // Create a new DuoCustomers entity
    void AddDuoCustomer(DuoCustomers duoCustomers);

    // Retrieve a DuoCustomers entity by Id
    DuoCustomers GetDuoCustomerById(int id);

    // Retrieve all DuoCustomers entities
    IEnumerable<DuoCustomers> GetAllDuoCustomers();

    // Update an existing DuoCustomers entity
    void UpdateDuoCustomer(DuoCustomers duoCustomers);

    // Delete a DuoCustomers entity by Id
    void DeleteDuoCustomer(int id);
}