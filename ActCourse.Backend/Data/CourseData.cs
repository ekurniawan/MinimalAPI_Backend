using ActCourse.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ActCourse.Backend.Data
{
    public class CourseData : ICourse
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CourseData(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Course> Add(Course entity)
        {
            try
            {
                _applicationDbContext.Add(entity);
                await _applicationDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }

        public async Task<Course> Delete(int id)
        {
            var result = await GetById(id);
            if (result == null)
            {
                throw new ArgumentException("Course not found");
            }
            try
            {
                _applicationDbContext.Remove(result);
                await _applicationDbContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _applicationDbContext.Courses.Include(c => c.Category).ToListAsync();
        }

        public async Task<Course> GetById(int id)
        {
            var result = await _applicationDbContext.Courses.Include(c => c.Category).FirstOrDefaultAsync(x => x.CourseId == id);
            if (result == null)
            {
                throw new ArgumentException("Course not found");
            }
            return result;
        }

        public async Task<Course> Update(Course entity)
        {
            try
            {
                _applicationDbContext.Update(entity);
                await _applicationDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }
    }
}
