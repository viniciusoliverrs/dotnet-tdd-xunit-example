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
        public int Workload { get; private set; }
        public double Price { get; private set; }
        public TargetAudienceEnum TargetAudience { get; private set; }

        public Course(Guid id, string name, string description, int workload, double price, TargetAudienceEnum targetAudience)
        {
            if(name is null or "")
                throw new ArgumentException();
            Id = id;
            Name = name;
            Description = description;
            Workload = workload;
            Price = price;
            TargetAudience = targetAudience;
        }
    }
}