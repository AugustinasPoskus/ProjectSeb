using WebService.Repository.Interfaces;
using System.Linq;
using System.Data.Entity;
using System;
using WebService.Model;

namespace WebService.Repository.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private DatabaseContext context;

        public CustomerRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public Customer GetNameByPersonalId(int personalId)
        {
            return context.Customers.FirstOrDefault(c => c.PersonalId == personalId);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void InsertCustomer(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }
    }
}