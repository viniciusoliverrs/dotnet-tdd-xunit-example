using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpectedObjects;
using TDDxUnit.Domain.Entities;
using TDDxUnit.Domain.Enum;
using TDDxUnit.Tests.Builders;
using TDDxUnit.Tests.Utils;

namespace TDDxUnit.Tests.CourseTest
{
    public class CourseTest
    {
        [Fact(DisplayName = "Should be able to create a course")]
        public void ShouldCreateACourse()
        {
            var course = CourseBuilder.New().Build();
            var courseExpected = course;

            courseExpected.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void MustNotHaveInvalidNameEmptyOrNull(string name)
                => Assert.Throws<ArgumentException>(() => CourseBuilder.New().WithName(name).Build()).WithMessage("Name is required");

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void MustNotHaveWorkloadLessThanZero(double workload)
            => Assert.Throws<ArgumentException>(() => CourseBuilder.New().WithWorkload(workload).Build()).WithMessage("Workload must be greater than zero");
    }
}