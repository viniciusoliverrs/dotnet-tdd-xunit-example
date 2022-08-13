using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDDxUnit.Domain.Enum;

namespace TDDxUnit.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Workload { get; private set; }
        public double Price { get; private set; }
        public TargetAudienceEnum TargetAudience { get; private set; }

        public Course(Guid id, string name, string description, double workload, double price, TargetAudienceEnum targetAudience)
        {
            if(name is null or "")
                throw new ArgumentException("Name is required");

            if(workload <= 0)
                throw new ArgumentException("Workload must be greater than zero");

            if(price <= 0)
                throw new ArgumentException("Price must be greater than zero");
                
            Id = id;
            Name = name;
            Description = description;
            Workload = workload;
            Price = price;
            TargetAudience = targetAudience;
        }
    }
}