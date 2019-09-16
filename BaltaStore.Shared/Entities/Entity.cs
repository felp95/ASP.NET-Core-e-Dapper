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
            Id = new Guid();
        }

        public Guid Id { get; set; }

    }
}
