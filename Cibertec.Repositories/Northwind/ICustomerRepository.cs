using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Northwind
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        bool UpdateContactName(Customer entity);
        int InsertCustomer(Customer entity);
        Customer GetByStringId(string id);
        int Count();//total count
        IEnumerable<Customer> PagedList(int startRow, int endRow);
    }
}
