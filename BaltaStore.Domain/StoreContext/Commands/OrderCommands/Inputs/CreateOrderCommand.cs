using BaltaStore.Domain.StoreContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class CreateOrderCommand
    {
        public Guid Customer { get; set; }
        public IList<OrdemItemCommand> OrderItems { get; set; }
    }
 
}
