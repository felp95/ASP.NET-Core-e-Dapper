﻿using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract().Requires()
                  .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                  .HasMaxLen(FirstName, 40, "FirstName", "O Nome deve ter no máximo 40 caracteres")
                  .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                  .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve ter no máximo 40 caracteres"));
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
