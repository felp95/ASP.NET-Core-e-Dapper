using System;
using System.Collections.Generic;
using System.Text;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public CreateCustomerCommandResult()
        {
        }

        public CreateCustomerCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

    }
}
