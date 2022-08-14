using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TDDxUnit.API.Controllers;
using TDDxUnit.API.ViewModel;
using TDDxUnit.Domain.Data.Repositories;
using TDDxUnit.Domain.Entities;
using TDDxUnit.Tests.Builders;

namespace TDDxUnit.Tests.CourseTest
{
    public class CourseRepositoryTest
    {
        [Fact]
       public void ShouldAddACourse()
        {
            var course = new CourseVM
            {
                Id = Guid.NewGuid(),
                Name = "Test Course",
                Description = "Test Description",
                Price = 100,
                TargetAudience = Domain.Enum.TargetAudienceEnum.Doctors,
                Workload = 10
            };
            var repository = new Mock<ICourseRepository>();
            var controller = new CourseController(repository.Object);
            controller.Add(course);
            repository.Verify(x => x.Add(It.IsAny<Course>()), Times.Once); //verifica se o metodo Add foi chamado uma vez
        
        }
    }
}