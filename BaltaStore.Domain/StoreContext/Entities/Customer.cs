using System;
using BaltaStore.Domain.StoreContext.ValueObjects;
using FluentValidator;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {

        private readonly IList<Address> _addresses;

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public EmailAddress Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public Customer(Name name, Document document, EmailAddress email, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public void AddAddress(Address address)
        {
            //TODO Validar endereço
            //TODO Adicionar endereço
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }

    }
}
