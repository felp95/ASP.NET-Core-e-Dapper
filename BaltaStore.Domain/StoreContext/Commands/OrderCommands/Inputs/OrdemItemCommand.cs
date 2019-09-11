using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class OrdemItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
