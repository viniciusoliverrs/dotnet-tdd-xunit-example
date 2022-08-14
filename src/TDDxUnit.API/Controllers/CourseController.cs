using Microsoft.AspNetCore.Mvc;
using TDDxUnit.API.ViewModel;
using TDDxUnit.Domain.Data.Repositories;
using TDDxUnit.Domain.Entities;
using TDDxUnit.Domain.Enum;

namespace TDDxUnit.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CourseController : ControllerBase
{
  private readonly ICourseRepository _repository;
    public CourseController(ICourseRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult Add([FromBody] CourseVM dto)
    {
        var model = _repository.GetByName(dto.Name);
        if (model is not null) throw new ArgumentException("Course already exists");
        var target = Enum.IsDefined(typeof(TargetAudienceEnum), dto.TargetAudience);
        if (!target)
            throw new ArgumentException("TargetAudience is invalid");

        var course = new Course(dto.Id.GetValueOrDefault(), dto.Name, dto.Description, dto.Workload, dto.Price, dto.TargetAudience);
        _repository.Add(course);
        return Ok();
    }
}
