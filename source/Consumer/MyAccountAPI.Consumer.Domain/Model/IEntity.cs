namespace MyAccountAPI.Domain.Model
{
    using System;

    public interface IEntity
    {
        Guid Id { get; }
    }
}
