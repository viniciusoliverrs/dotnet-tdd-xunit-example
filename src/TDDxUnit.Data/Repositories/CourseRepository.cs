using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDDxUnit.Domain.Data.Repositories;
using TDDxUnit.Domain.Entities;

namespace TDDxUnit.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public ICollection<Course> GetAll()
        {
            throw new NotImplementedException();
        }
        
        public Course Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Add(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}