﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Services
{
    public interface IEmailService
    {
        void SendEmail(string to, string from, string subject, string body);
    }
}
