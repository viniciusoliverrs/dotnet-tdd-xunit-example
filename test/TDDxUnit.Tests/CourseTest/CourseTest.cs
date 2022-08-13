using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpectedObjects;
using TDDxUnit.Domain.Entities;
using TDDxUnit.Domain.Enum;
using TDDxUnit.Tests.Builders;

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

        [Fact(DisplayName = "Should throw exception when name is null or empty")]
        [InlineData("")]
        [InlineData(null)]
        public void MustNotHaveInvalidNameEmptyOrNull(string name)
            => Assert.Throws<ArgumentException>(() => CourseBuilder.New().WithName(name).Build());
    }
}