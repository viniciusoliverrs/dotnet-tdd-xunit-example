using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDDxUnit.Domain.Enum;

namespace TDDxUnit.API.ViewModel
{
    public class CourseVM
    {
        public Guid? Id { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public double Workload { get;  set; }
        public double Price { get;  set; }
        public TargetAudienceEnum TargetAudience { get;  set; }
        
    }
}