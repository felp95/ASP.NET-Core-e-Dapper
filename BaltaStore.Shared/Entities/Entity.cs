using FluentValidator;
using System;

namespace BaltaStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            
        }
        public Entity(Guid id)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

    }
}
