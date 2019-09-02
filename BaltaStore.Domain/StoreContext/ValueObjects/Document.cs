using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Document
    {
        public string Number { get; set; }

        public Document(string number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return Number;
        }
    }
}
