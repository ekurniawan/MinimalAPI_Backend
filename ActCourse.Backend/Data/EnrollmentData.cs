using ActCourse.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ActCourse.Backend.Data
{
    public class EnrollmentData : IEnrollment
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EnrollmentData(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Enrollment> Add(Enrollment entity)
        {
            try
            {
                entity.EnrolledAt = DateTime.Now;
                _applicationDbContext.Add(entity);
                await _applicationDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }

        public Task<Enrollment> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            return await _applicationDbContext.Enrollments.Include(e => e.Course)
                .Include(e => e.Instructor).ToListAsync();
        }

        public async Task<Enrollment> GetById(int id)
        {
            var result = await _applicationDbContext.Enrollments.Include(e => e.Course)
                .Include(e => e.Instructor).FirstOrDefaultAsync(x => x.EnrollmentId == id);
            if (result == null)
            {
                throw new ArgumentException("Enrollment not found");
            }
            return result;
        }

        public async Task<Enrollment> Update(Enrollment entity)
        {
            try
            {
                var result = await GetById(entity.EnrollmentId);
                if (result == null)
                {
                    throw new ArgumentException("Enrollment not found");
                }
                result.CourseId = entity.CourseId;
                result.InstructorId = entity.InstructorId;
                result.EnrolledAt = DateTime.Now;

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
