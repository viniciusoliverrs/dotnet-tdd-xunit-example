using Microsoft.AspNetCore.Mvc;
using TDDxUnit.API.ViewModel;
using TDDxUnit.Domain.Data.Repositories;
using TDDxUnit.Domain.Entities;

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
        var course = new Course(dto.Id.GetValueOrDefault(), dto.Name, dto.Description, dto.Workload, dto.Price, dto.TargetAudience);
        _repository.Add(course);
        return Ok();
    }
}
