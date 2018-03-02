using System;
using System.Collections.Generic;

namespace Castanha.UI.Model
{
    public class CustomerDetailsModel
    {
        public Guid CustomerId { get; }
        public string Personnummer { get; }
        public string Name { get; }
        public List<Guid> Accounts { get; }

        public CustomerDetailsModel(Guid customerId, string personnummer, string name, List<Guid> accounts)
        {
            CustomerId = customerId;
            Personnummer = personnummer;
            Name = name;
            Accounts = accounts;
        }
    }
}
