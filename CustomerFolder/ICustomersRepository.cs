using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vancouver.CustomerFolder
{
    public interface ICustomersRepository
    {
        Task<Customer> GetObject(string id);
        Task<List<Customer>> GetObjectsList();
        Task AddObject(Customer o);
        Task UpdateObject(Customer o);
        Task DeleteObject(Customer o);

    }
}