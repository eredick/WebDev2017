using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString)
        {

        }
        public List<Order> GetOrderByCustomer(string customerId)
        {
            string sql = "select OrderID, OrderDate, ShipName from Orders where CustomerID = @CustomerID";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var resultado = connection.Query<Order>(sql, new { CustomerID = customerId });
                return resultado.ToList();
            }
        }
    }
}
