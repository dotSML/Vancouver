using System.Collections.Generic;
using System.Threading.Tasks;
using Vancouver.Models;

namespace Vancouver.CustomerFolder
{
    public interface ICustomersRepository
    {
        Task<Customer> GetObject(string id);
        List<Customer> GetObjectsList();
        Task AddObject(Customer o);
        Task UpdateObject(Customer o);
        Task DeleteObject(Customer o);
        void SetCustomerPassport(Customer o);

    }
}