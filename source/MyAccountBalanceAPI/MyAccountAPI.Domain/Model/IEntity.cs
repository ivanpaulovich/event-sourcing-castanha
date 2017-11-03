using System;

namespace MyAccountAPI.Domain.Model
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
