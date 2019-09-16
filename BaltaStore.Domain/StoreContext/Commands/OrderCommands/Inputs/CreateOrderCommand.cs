using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class CreateOrderCommand : Notifiable, ICommand
    {
        public Guid Customer { get; set; }
        public IList<OrdemItemCommand> OrderItems { get; set; }

        public CreateOrderCommand()
        {
             OrderItems = new List<OrdemItemCommand>();   
        }

        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasLen(Customer.ToString(), 36, "Customer", "Id do cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "Items","Nenhum item do pedido foi encontrado")
            );

            return base.Valid;
        }
    }
 
}
