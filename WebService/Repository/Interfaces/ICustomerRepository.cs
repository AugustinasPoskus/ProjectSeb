using WebService.Model;

namespace WebService.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetNameByPersonalId(int personalId);
        int Save();
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}