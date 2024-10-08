﻿using Dapper;
using WebApplicationExercise.Data;
using WebApplicationExercise.DTO.Customers;
using WebApplicationExercise.Repositories.Customers;

namespace WebApplicationExercise.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private DBSession _dbSession;
        public CustomerRepository(DBSession dBSession) 
        { 
            _dbSession = dBSession;
        }
        public async Task<Customer?> GetCustomerByIDAsync(short id)
        {
            using var dbConnection = _dbSession.Connection;
            var query = @"SELECT * FROM Customers WHERE ID = @Id";
            Customer? customer = await dbConnection.QuerySingleOrDefaultAsync<Customer>(query, new {Id = id});
            return customer;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            using var dbConnection = _dbSession.Connection;
            var query = "SELECT * FROM Customers";
            List<Customer> customers = (await dbConnection.QueryAsync<Customer>(query)).ToList();
            return customers;
        }

        public async Task<Customer> SaveCustomerAsync(CustomerDTO customerDTO)
        {
            using var dbConnection = _dbSession.Connection;
            var query =
                @"
                    INSERT INTO Customers (Name,City)
                    VALUES(@Name,@City);
                    SELECT * FROM Customers WHERE ID = SCOPE_IDENTITY();
                ";
            return await dbConnection.QuerySingleAsync<Customer>(query, customerDTO);
        }

    }
}
