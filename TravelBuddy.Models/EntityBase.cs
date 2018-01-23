using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models
{
    public abstract class EntityBase<TId> : IEquatable<EntityBase<TId>>
    {
        protected EntityBase(TId id)
        {
            if (Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the default value.", "id");
            }
            Id = id;
        }

        public TId Id { get; set; }

        public bool Equals(EntityBase<TId> other)
        {
            if (other == null)
            {
                return false;
            }
            return Id.Equals(other.Id);
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
