using System;
using System.Collections.Generic;
using System.Text;
using BaltaStore.Domain.StoreContext.Services;

namespace BaltaStore.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void SendEmail(string to, string from, string subject, string body)
        {
        }
    }
}
