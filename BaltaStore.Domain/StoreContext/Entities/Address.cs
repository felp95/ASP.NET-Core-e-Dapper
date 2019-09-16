using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entities;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Address : Entity
    {
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public int Number { get; private set; }
        public string Complement { get; set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public EAddressType Type { get; set; }

        public Address(string street, string neighborhood, int number, string complement, string zipCode, string city, string state, string country, EAddressType type)
        {
            Street = street;
            Neighborhood = neighborhood;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            Country = country;
            State = state;
            City = city;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }
    }
}
