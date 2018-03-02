namespace Castanha.Application.Outputs
{
    using System;
    using System.Collections.Generic;

    public class CustomerOutput
    {
        public Guid CustomerId { get; private set; }
        public string Personnummer { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyList<Guid> Accounts { get; private set; }

        public CustomerOutput()
        {

        }

        public CustomerOutput(Guid customerId, string personnummer, string name,
            List<Guid> accounts)
        {
            CustomerId = customerId;
            Personnummer = personnummer;
            Name = name;
            Accounts = accounts;
        }
    }
}
