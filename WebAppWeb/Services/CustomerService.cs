using Dapper;
using WebAppWeb.Data;
using WebAppWeb.Models;

namespace WebAppWeb.Services
{
    public class CustomerService
    {
        private readonly DapperContext _dbContext;

        public CustomerService(DapperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var sql = "SELECT * FROM customers";
            using (var connection = await _dbContext.CreateDbConnection())
            {
                await connection.ExecuteAsync("SET search_path TO automappertest");
                var result = await connection.QueryAsync<Customer>(sql);

                return result.ToList();
            }
        }

        public async Task<bool> AddCustomersAsync(NewCustomerModel customer)
        {
            var sql = "INSERT INTO customers(\"FirstName\", \"LastName\", \"Address\") VALUES (@FirstName, @LastName, @Address)";

            using (var connection = await _dbContext.CreateDbConnection())
            {
                await connection.ExecuteAsync("SET search_path TO automappertest");
                await connection.ExecuteAsync(sql, new { customer.FirstName, customer.LastName, customer.Address });
            }

            return true;
        }
    }
}
