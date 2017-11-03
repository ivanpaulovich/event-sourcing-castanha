using System;

namespace MyAccountAPI.Domain.Model
{
    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
