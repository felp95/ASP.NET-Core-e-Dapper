using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class EmailAddress : Notifiable
    {
        public string Email { get; set; }
        public EmailAddress(string email)
        {
            Email = email;

            AddNotifications(new ValidationContract().Requires().IsEmail(Email, "Email", "O E-mail é invalido"));
        }

        public override string ToString()
        {
            return Email;
        }
    }
}
