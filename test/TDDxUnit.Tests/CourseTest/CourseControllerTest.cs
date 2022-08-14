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
using TDDxUnit.Domain.Enum;
using TDDxUnit.Tests.Builders;
using TDDxUnit.Tests.Utils;

namespace TDDxUnit.Tests.CourseTest
{
    public class CourseControllerTest
    {
        private readonly Mock<ICourseRepository> _mockRepository;
        private readonly CourseController _controller;
        private readonly Faker _faker;
        private readonly CourseVM _courseVM;
        public CourseControllerTest()
        {
            _faker = new Faker();
            _mockRepository = new Mock<ICourseRepository>();
            _controller = new CourseController(_mockRepository.Object);
            _courseVM = new CourseVM
            {
                Id = Guid.NewGuid(),
                Name = _faker.Random.Word(),
                Description = _faker.Random.Word(),
                Price = _faker.Random.Double(50, 100),
                TargetAudience = _faker.Random.Enum<TargetAudienceEnum>(),
                Workload = _faker.Random.Double(50, 100)
            };
        }

        [Fact(DisplayName = "Should add a new course")]
        public void ShouldAddACourse()
        {
            var course = new CourseVM
            {
                Id = Guid.NewGuid(),
                Name = _faker.Random.Word(),
                Description = _faker.Random.Word(),
                Price = _faker.Random.Double(1, 1000),
                TargetAudience = TargetAudienceEnum.Doctors,
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

        [Fact(DisplayName = "Should not add a course with invalid target audience")]
        public void  ShouldNotAddACourseTargetAudienceIsInvalid()
        {
            var course = new CourseVM
            {
                Id = Guid.NewGuid(),
                Name = _faker.Random.Word(),
                Description = _faker.Random.Word(),
                Price = _faker.Random.Double(1, 1000),
                TargetAudience = (TargetAudienceEnum)_faker.Random.Int(5, 100),
                Workload = _faker.Random.Int(1, 100)
            };
            Assert.Throws<ArgumentException>(() => _controller.Add(course)).WithMessage("TargetAudience is invalid");
            _mockRepository
                .Verify(x =>
                    x.Add(It.IsAny<Course>()),
                    Times.Never); //verifica se o metodo Add não foi chamado
        }

        [Fact(DisplayName = "You must not add a course with the same name as another course")]
        public void ShouldNotAddACourseWithSameNameAsAnother()
        {
            var course = new CourseBuilder().WithName(_courseVM.Name).Build();
            _mockRepository.Setup(x => x.GetByName(_courseVM.Name)).ReturnsAsync(course);
            Assert.Throws<ArgumentException>(() => _controller.Add(_courseVM)).WithMessage("Course already exists");

        }

    }
}