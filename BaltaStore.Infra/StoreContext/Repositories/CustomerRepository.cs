using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BaltaStore.Domain.StoreContext.Queries;
using Dapper;

namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return _context.Connection.Query<bool>("spCheckDocument", new { Document = document }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context.Connection.Query<bool>("spCheckEmail", new { EmailAddress = email }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer", new
            {
                customer.Id,
                customer.Name.FirstName,
                customer.Name.LastName,
                customer.Document.Number,
                customer.Email.Email,
                customer.Phone

            }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                    new
                    {
                        address.Id,
                        CustomerId = customer.Id,
                        address.Number,
                        address.Complement,
                        address.District,
                        address.City,
                        address.State,
                        address.Country,
                        address.ZipCode,
                        address.Type

                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<ListCustomerQueryResult> Get()
        {
            const string sql = "SELECT Id, CONCAT(FirstName, '', LastName) as Name, Document, Email FROM Customer";

            return _context.Connection.Query<ListCustomerQueryResult>(sql, commandType: CommandType.StoredProcedure).ToList();
        }

        public GetCustomerQueryResult GetById(Guid id)
        {
            const string sql = "SELECT Id, CONCAT(FirstName, '', LastName) as Name, Document, Email FROM Customer WHERE Id = @id";

            return _context.Connection.Query<GetCustomerQueryResult>(sql, new { Id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public List<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            const string sql = "Fazer a query";

            return _context.Connection.Query<ListCustomerOrdersQueryResult>(sql, new { Id = id }, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
