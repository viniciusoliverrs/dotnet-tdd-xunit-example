using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Moq;
using TDDxUnit.API.Controllers;
using TDDxUnit.API.ViewModel;
using TDDxUnit.Domain.Data.Repositories;
using TDDxUnit.Domain.Entities;
using TDDxUnit.Tests.Builders;

namespace TDDxUnit.Tests.CourseTest
{
    public class CourseControllerTest
    {
        private readonly Mock<ICourseRepository> _mockRepository;
        private readonly CourseController _controller;
        private readonly Faker _faker;
        public CourseControllerTest()
        {
            _faker = new Faker();
            _mockRepository = new Mock<ICourseRepository>();
            _controller = new CourseController(_mockRepository.Object);
        }

        [Fact]
        public void ShouldAddACourse()
        {
            var course = new CourseVM
            {
                Id = Guid.NewGuid(),
                Name = _faker.Random.Word(),
                Description = _faker.Random.Word(),
                Price = _faker.Random.Double(1, 1000),
                TargetAudience = Domain.Enum.TargetAudienceEnum.Doctors,
                Workload = _faker.Random.Int(1, 100)
            };
            _controller.Add(course);
            _mockRepository
                .Verify(x => 
                    x.Add(It.Is<Course>(c => 
                    c.Name == course.Name && 
                    c.Price == course.Price &&
                    c.Description == course.Description &&
                    c.TargetAudience == course.TargetAudience &&
                    c.Workload == course.Workload
                    )), 
                Times.Once); //verifica se o metodo Add foi chamado uma vez
        }
    }
}