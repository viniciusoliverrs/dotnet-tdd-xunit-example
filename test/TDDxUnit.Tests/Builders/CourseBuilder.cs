using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDDxUnit.Domain.Entities;
using TDDxUnit.Domain.Enum;

namespace TDDxUnit.Tests.Builders
{
    public class CourseBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string _name = "Name";
        private string _description = "Description";
        private int _workload = 100;
        private double _price = 100;
        private TargetAudienceEnum _targetAudience = TargetAudienceEnum.Developers;

        public static CourseBuilder New() => new CourseBuilder();

        public Course Build() => new Course(_id, _name, _description, _workload, _price, _targetAudience);

        public CourseBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
        public CourseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CourseBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CourseBuilder WithWorkload(int workload)
        {
            _workload = workload;
            return this;
        }

        public CourseBuilder WithPrice(double price)
        {
            _price = price;
            return this;
        }

        public CourseBuilder WithTargetAudience(TargetAudienceEnum targetAudience)
        {
            _targetAudience = targetAudience;
            return this;
        }

    }
}