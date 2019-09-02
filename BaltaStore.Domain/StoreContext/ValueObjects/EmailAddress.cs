namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class EmailAddress
    {
        public string Email { get; set; }
        public EmailAddress(string email)
        {
            Email = email;
        }

        public override string ToString()
        {
            return Email;
        }
    }
}
