using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
        }

        public int InsertCustomer(Customer entity)
        {
            var codigo = ObtenerCodigoCompania(entity.CompanyName.ToUpper());
            entity.CustomerID = codigo;

            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        private string ObtenerCodigoCompania(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
                return null;

            var palabras = companyName.Split(' ');

            var primeraParte = palabras[0].Substring(0, 4);
            if (palabras.Length < 2)
            {
                return $"{primeraParte}0";
            }
            var segundaParte = palabras[1][0];
            return $"{primeraParte}{segundaParte}";
        }

        public bool UpdateContactName(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer GetByStringId(string id)
        {
            var sql = "select * from Customers where CustomerID = @CustomerID;";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var customer = connection.QueryFirstOrDefault<Customer>(sql, new { CustomerID = id });
                return customer;
            }
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    var customer = connection.Get<Customer>(id);
            //    return customer;
            //}
        }
    }
}
