using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models
{
    public abstract class EntityBase<TId> : IEquatable<EntityBase<TId>>
    {
        protected EntityBase() { }

        protected EntityBase(TId id)
        {
            if (Equals(id, default(TId)))
            {
                throw new ArgumentException($"The ID cannot be the default value. {id} {default(TId)}", "id");
            }
            Id = id;
        }

        public virtual TId Id { get; set; }

        public virtual bool Equals(EntityBase<TId> other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return obj is EntityBase<TId> entity ? Equals(entity) : base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
