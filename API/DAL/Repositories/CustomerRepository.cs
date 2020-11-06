using API.DAL.Interfaces;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Customer Create(Customer obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Customer obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person";
                string sql2 = "SELECT city FROM City WHERE zipCode = @zipCode";
                var customers = conn.Query<Customer>(sql);
                foreach (var customer in customers)
                {
                    customer.City = conn.QuerySingleOrDefault<string>(sql2, new { zipCode = customer.ZipCode });
                }
                return customers;
            }
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}