using Bogus;
using ExpectedObjects;
using TDDxUnit.Domain.Entities;
using TDDxUnit.Domain.Enum;
using TDDxUnit.Tests.Builders;
using TDDxUnit.Tests.Utils;
using Xunit.Abstractions;

namespace TDDxUnit.Tests.CourseTest
{
    public class CourseTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly Guid _id;
        private readonly string _name;
        private readonly string _description;
        private readonly double _workload;
        private readonly double _price;
        private readonly TargetAudienceEnum _targetAudience;

        public CourseTest(ITestOutputHelper output)
        {
            var faker = new Faker();
            _output = output;
            _id = Guid.NewGuid();
            _name = faker.Random.Word();
            _description = faker.Lorem.Paragraph();
            _workload = faker.Random.Double(1, 100);
            _price = faker.Random.Double(1, 100);
            _targetAudience = TargetAudienceEnum.Developers;
        }
        public void Dispose()
        {
            _output.WriteLine("Dispose");
        }

        [Fact(DisplayName = "Should be able to create a course")]
        public void ShouldCreateACourse()
        {
            var course = new
            {
                Id = _id,
                Name = _name,
                Description = _description,
                Workload = (double)_workload,
                Price = (double)_price,
                TargetAudience = _targetAudience
            };
            var courseExpected = new Course(_id, _name, _description, _workload, _price, _targetAudience);
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


        [Theory]
        [InlineData(0)]
        [InlineData(-10.0)]
        public void MustNotHavePriceLessThanZero(double price)
            => Assert.Throws<ArgumentException>(() => CourseBuilder.New().WithPrice(price).Build()).WithMessage("Price must be greater than zero");
    }
}