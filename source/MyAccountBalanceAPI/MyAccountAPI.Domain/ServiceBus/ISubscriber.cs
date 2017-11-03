using MediatR;
using System;

namespace MyAccountAPI.Domain.ServiceBus
{
    public interface ISubscriber : IDisposable
    {
        void Listen(IMediator mediator);
    }
}
