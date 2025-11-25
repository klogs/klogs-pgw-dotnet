using System;
using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    public class IdName : IEquatable<IdName>, IEqualityComparer<IdName>
    {
        public IdName()
        {
            
        }

        public IdName(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public bool Equals(IdName other)
        {
            return Id == other.Id;
        }

        public bool Equals(IdName x, IdName y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(IdName obj)
        {
            return obj.Id.GetHashCode();
        }

        public static implicit operator IdName((Guid, string) value)
        {
            return new IdName { Id = value.Item1, Name = value.Item2 };
        }

        public static implicit operator IdName(Guid value)
        {
            return new IdName { Id = value };
        }

        public static implicit operator IdName(Guid? value)
        {
            return value == null ? null : new IdName { Id = value.Value };
        }
    }
}