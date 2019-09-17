using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContexts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
    }
}
