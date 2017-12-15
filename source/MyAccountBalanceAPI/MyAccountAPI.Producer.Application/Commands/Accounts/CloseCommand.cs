namespace MyAccountAPI.Producer.Application.Commands.Accounts
{
    using MediatR;
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class CloseCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid AccountId { get; private set; }

        public CloseCommand()
        {

        }
    }
}
